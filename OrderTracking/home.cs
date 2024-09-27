using System;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace OrderTracking
{
    public partial class home : Form
    {
        private int verticalSpacing = 20;
        private Panel parentPanel;
        private int userAdminLevel; // Kullan�c�n�n yetki seviyesi

        public home(int adminLevel) // Yap�c� metot
        {
            InitializeComponent();
            userAdminLevel = adminLevel; // Yetki seviyesini ayarla
            parentPanel = this.panel1;
            parentPanel.AutoScroll = false;
            this.Resize += home_Resize;
            rotaAlanlariniGizle();
        }

        private void home_Resize(object sender, EventArgs e)
        {
            UpdateControlSets();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DuplicateControlSet();
        }

        private void DuplicateControlSet() { /* Implement your logic here */ }
        private void UpdateControlSets() { /* Implement your logic here */ }

        private void SaveDataToDatabase()
        {
            string connectionString = "Data Source=TETrA\\SQLEXPRESS;Initial Catalog=orderTracking;Integrated Security=True;Encrypt=False";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Kontrol de�erlerini al
                string sahip = sahipCombo.Text.Trim();
                string urunAdi = urun_adiCombo.Text.Trim();
                string urunCinsi = urun_cinsiCombo.Text.Trim();
                string aciklama = aciklamaTextBox.Text.Trim();
                decimal urunMiktari = urunMiktarNumeric.Value;
                decimal kar = karNumeric.Value;

                // Debug: Alan de�erlerini kontrol et
                Console.WriteLine($"Sahip: {sahip}, �r�n Ad�: {urunAdi}, �r�n Cinsi: {urunCinsi}, A��klama: {aciklama}, Miktar: {urunMiktari}, Kar: {kar}");

                // Alan kontrol�
                if (string.IsNullOrWhiteSpace(sahip) || string.IsNullOrWhiteSpace(urunAdi) || string.IsNullOrWhiteSpace(urunCinsi) ||
                    string.IsNullOrWhiteSpace(aciklama) || urunMiktari <= 0 || kar < 0)
                {
                    MessageBox.Show("L�tfen t�m alanlar� do�ru �ekilde doldurun.");
                    return;
                }

                string insertOrderQuery = "INSERT INTO siparisler (sahip, tarih, urun_adi, urun_miktari, urun_cinsi, aciklama, kar) OUTPUT INSERTED.id VALUES (@sahip, @tarih, @urun_adi, @urun_miktari, @urun_cinsi, @aciklama, @kar)";

                using (SqlCommand orderCommand = new SqlCommand(insertOrderQuery, connection))
                {
                    orderCommand.Parameters.AddWithValue("@sahip", sahip);
                    orderCommand.Parameters.AddWithValue("@tarih", tarihTimerPicker.Value);
                    orderCommand.Parameters.AddWithValue("@urun_adi", urunAdi);
                    orderCommand.Parameters.AddWithValue("@urun_miktari", urunMiktari);
                    orderCommand.Parameters.AddWithValue("@urun_cinsi", urunCinsi);
                    orderCommand.Parameters.AddWithValue("@aciklama", aciklama);
                    orderCommand.Parameters.AddWithValue("@kar", kar);

                    int siparisId = (int)orderCommand.ExecuteScalar();

                    for (int i = 1; i <= 10; i++)
                    {
                        string rotaAd = this.Controls.Find($"rota{i}Text", true).FirstOrDefault()?.Text.Trim();
                        NumericUpDown rotaNumeric = this.Controls.Find($"rota{i}Numeric", true).FirstOrDefault() as NumericUpDown;
                        decimal? ucret = rotaNumeric?.Value;

                        if (!string.IsNullOrEmpty(rotaAd) && ucret.HasValue)
                        {
                            string insertRotaQuery = "INSERT INTO rotalar (siparis_id, rota_adi, ucret) VALUES (@siparis_id, @rota_adi, @ucret)";

                            using (SqlCommand rotaCommand = new SqlCommand(insertRotaQuery, connection))
                            {
                                rotaCommand.Parameters.AddWithValue("@siparis_id", siparisId);
                                rotaCommand.Parameters.AddWithValue("@rota_adi", rotaAd);
                                rotaCommand.Parameters.AddWithValue("@ucret", ucret.Value);
                                rotaCommand.ExecuteNonQuery();
                            }
                        }
                    }
                }

                // Kay�t ba�ar�l� oldu�unda t�m kutular� temizle
                ClearInputFields();
                MessageBox.Show("Kay�t ba�ar�yla tamamland�.");
            }
        }

        private void ClearInputFields()
        {
            sahipCombo.SelectedIndex = -1;
            urun_adiCombo.SelectedIndex = -1;
            urun_cinsiCombo.SelectedIndex = -1;
            aciklamaTextBox.Clear();
            urunMiktarNumeric.Value = 0;
            karNumeric.Value = 0;

            for (int i = 1; i <= 10; i++)
            {
                var rotaText = this.Controls.Find($"rota{i}Text", true).FirstOrDefault() as TextBox;
                var rotaNumeric = this.Controls.Find($"rota{i}Numeric", true).FirstOrDefault() as NumericUpDown;

                if (rotaText != null) rotaText.Clear();
                if (rotaNumeric != null) rotaNumeric.Value = 0;
            }
        }

        private void anaSayfaToolStripMenuItem_Click(object sender, EventArgs e) => ShowForm(new home(userAdminLevel));
        private void onaylananTekliflerToolStripMenuItem_Click(object sender, EventArgs e) => ShowForm(new orders());
        private void teklifOnaylaToolStripMenuItem_Click(object sender, EventArgs e) => PerformAdminAction(new tickets());
        private void kullan�c�EkleToolStripMenuItem_Click(object sender, EventArgs e) => PerformAdminAction(new addUser());
        private void yedeklemeToolStripMenuItem_Click(object sender, EventArgs e) => ShowForm(new databaseSave());
        private void yetkiVerToolStripMenuItem_Click(object sender, EventArgs e) => PerformAdminAction(new authority());
        private void istatistiklkerToolStripMenuItem_Click(object sender, EventArgs e) => PerformAdminAction(new statistics());


        private void PerformAdminAction(Form form)
        {
            // Kullan�c� yetkisini kontrol et
            if (userAdminLevel != 1) // Yetkisi yoksa
            {
                MessageBox.Show("Bu i�lemi ger�ekle�tirmek i�in yetkiniz yok.");
                return; // ��lemi durdur
            }
            // Yetkisi varsa formu g�ster
            ShowForm(form);
        }

        private void ShowForm(Form form)
        {
            try
            {
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata olu�tu: " + ex.Message);
            }
        }

        private void kayit_Click(object sender, EventArgs e)
        {
            SaveDataToDatabase();
        }

        private void hesaplabtn_Click(object sender, EventArgs e)
        {
            // Rota toplam�n� hesapla
            decimal rotaToplam = 0;
            for (int i = 1; i <= 10; i++)
            {
                NumericUpDown rotaNumeric = this.Controls.Find($"rota{i}Numeric", true).FirstOrDefault() as NumericUpDown;
                if (rotaNumeric != null)
                {
                    rotaToplam += rotaNumeric.Value;
                }
            }

            rotaToplamLabel.Text = rotaToplam.ToString("F2");

            // K�r oran� y�zdesi
            decimal kar = karNumeric.Value;

            // K�r eklenmi� toplam hesaplama
            decimal k�rMiktar� = rotaToplam * (kar / 100);
            decimal karl�Toplam = rotaToplam + k�rMiktar�;
            karl�ToplamLabel.Text = karl�Toplam.ToString("F2");

            // KDV hesaplama
            decimal kdv = karl�Toplam * 0.20m; // %20 KDV
            toplamKdvLabel.Text = kdv.ToString("F2");

            // KDV'li toplam hesaplama
            decimal kdvliToplam = karl�Toplam + kdv;
            kdvliToplamLabel.Text = kdvliToplam.ToString("F2");

            // Toplam tutar� KDV'li toplam olarak ayarlama
            toplamTutarLabel.Text = kdvliToplam.ToString("F2");

            // KDV'li adeti hesaplama
            decimal urunMiktari = urunMiktarNumeric.Value;
            decimal kdvliAdet = kdvliToplam / urunMiktari;
            kdvliAdetLabel.Text = kdvliAdet.ToString("F2");

            // KDV'siz adeti hesaplama
            decimal kdvsizAdet = karl�Toplam / urunMiktari;
            kdvsizAdetLabel.Text = kdvsizAdet.ToString("F2");
        }

        private void ��k��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            login homeForm = new login();
            homeForm.Show();
        }

        private void rotaAlanlariniGizle()
        {
            // T�m rota alanlar�n� ba�lang��ta gizliyoruz
            rota1Label.Visible = false;
            rota1Text.Visible = false;
            rota1TL.Visible = false;
            rota1Numeric.Visible = false;

            rota2Label.Visible = false;
            rota2Text.Visible = false;
            rota2TL.Visible = false;
            rota2Numeric.Visible = false;

            rota3Label.Visible = false;
            rota3Text.Visible = false;
            rota3TL.Visible = false;
            rota3Numeric.Visible = false;

            rota4Label.Visible = false;
            rota4Text.Visible = false;
            rota4TL.Visible = false;
            rota4Numeric.Visible = false;

            rota5Label.Visible = false;
            rota5Text.Visible = false;
            rota5TL.Visible = false;
            rota5Numeric.Visible = false;

            rota6Label.Visible = false;
            rota6Text.Visible = false;
            rota6TL.Visible = false;
            rota6Numeric.Visible = false;

            rota7Label.Visible = false;
            rota7Text.Visible = false;
            rota7TL.Visible = false;
            rota7Numeric.Visible = false;

            rota8Label.Visible = false;
            rota8Text.Visible = false;
            rota8TL.Visible = false;
            rota8Numeric.Visible = false;

            rota9Label.Visible = false;
            rota9Text.Visible = false;
            rota9TL.Visible = false;
            rota9Numeric.Visible = false;

            rota10Label.Visible = false;
            rota10Text.Visible = false;
            rota10TL.Visible = false;
            rota10Numeric.Visible = false;
        }
        private int rotaSayaci = 0;

        private void rotaEklebtn_Click(object sender, EventArgs e)
        {
            // Saya� kontrol� yaparak hangi alanlar� a�aca��m�z� belirliyoruz
            rotaSayaci++;

            switch (rotaSayaci)
            {
                case 1:
                    rota1Label.Visible = true;
                    rota1Text.Visible = true;
                    rota1TL.Visible = true;
                    rota1Numeric.Visible = true;
                    break;
                case 2:
                    rota2Label.Visible = true;
                    rota2Text.Visible = true;
                    rota2TL.Visible = true;
                    rota2Numeric.Visible = true;
                    break;
                case 3:
                    rota3Label.Visible = true;
                    rota3Text.Visible = true;
                    rota3TL.Visible = true;
                    rota3Numeric.Visible = true;
                    break;
                case 4:
                    rota4Label.Visible = true;
                    rota4Text.Visible = true;
                    rota4TL.Visible = true;
                    rota4Numeric.Visible = true;
                    break;
                case 5:
                    rota5Label.Visible = true;
                    rota5Text.Visible = true;
                    rota5TL.Visible = true;
                    rota5Numeric.Visible = true;
                    break;
                case 6:
                    rota6Label.Visible = true;
                    rota6Text.Visible = true;
                    rota6TL.Visible = true;
                    rota6Numeric.Visible = true;
                    break;
                case 7:
                    rota7Label.Visible = true;
                    rota7Text.Visible = true;
                    rota7TL.Visible = true;
                    rota7Numeric.Visible = true;
                    break;
                case 8:
                    rota8Label.Visible = true;
                    rota8Text.Visible = true;
                    rota8TL.Visible = true;
                    rota8Numeric.Visible = true;
                    break;
                case 9:
                    rota9Label.Visible = true;
                    rota9Text.Visible = true;
                    rota9TL.Visible = true;
                    rota9Numeric.Visible = true;
                    break;
                case 10:
                    rota10Label.Visible = true;
                    rota10Text.Visible = true;
                    rota10TL.Visible = true;
                    rota10Numeric.Visible = true;
                    break;
                default:
                    MessageBox.Show("T�m rotalar zaten aktif!");
                    break;
            }
        }

        private void home_Load(object sender, EventArgs e)
        {
            FillSahipComboBox();
            FillUrunAdiComboBox();
            FillUrunCinsiComboBox();
        }

        private void FillSahipComboBox()
        {
            string connectionString = "Data Source=TETrA\\SQLEXPRESS;Initial Catalog=orderTracking;Integrated Security=True;Encrypt=False";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Sipari� tablosundaki sahip bilgilerini almak i�in sorgu
                string query = "SELECT DISTINCT sahip FROM siparisler";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // ComboBox'a sahip isimlerini ekle
                        sahipCombo.Items.Add(reader["sahip"].ToString());
                    }
                }
            }

            // Kullan�c�ya kendi ismini yazma izni ver
            sahipCombo.DropDownStyle = ComboBoxStyle.DropDown;
        }

        private void FillUrunAdiComboBox()
        {
            string connectionString = "Data Source=TETrA\\SQLEXPRESS;Initial Catalog=orderTracking;Integrated Security=True;Encrypt=False";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Sipari� tablosundaki �r�n ad� bilgilerini almak i�in sorgu
                string query = "SELECT DISTINCT urun_adi FROM siparisler"; // urun_adi s�tununu se�

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // ComboBox'a �r�n adlar�n� ekle
                        urun_adiCombo.Items.Add(reader["urun_adi"].ToString());
                    }
                }
            }

            // Kullan�c�ya kendi �r�n ismini yazma izni ver
            urun_adiCombo.DropDownStyle = ComboBoxStyle.DropDown;
        }

        private void FillUrunCinsiComboBox()
        {
            string connectionString = "Data Source=TETrA\\SQLEXPRESS;Initial Catalog=orderTracking;Integrated Security=True;Encrypt=False";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Sipari� tablosundaki �r�n cinsi bilgilerini almak i�in sorgu
                string query = "SELECT DISTINCT urun_cinsi FROM siparisler"; // urun_cinsi s�tununu se�

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // ComboBox'a �r�n cinslerini ekle
                        urun_cinsiCombo.Items.Add(reader["urun_cinsi"].ToString());
                    }
                }
            }

            // Kullan�c�ya kendi �r�n cinsini yazma izni ver
            urun_cinsiCombo.DropDownStyle = ComboBoxStyle.DropDown;
        }

    }
}
