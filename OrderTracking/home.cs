using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;

namespace OrderTracking
{
    public partial class home : Form
    {
        private int verticalSpacing = 20;
        private Panel parentPanel;
        private int userAdminLevel; // Kullan�c�n�n yetki seviyesi

        public home(int adminLevel) // Yap�c� metot
        {
            InitializeComponent(); // Bu metodun ilk �a�r�lmas� gerekti�inden emin olun
            userAdminLevel = adminLevel; // Yetki seviyesini ayarla

            // 'panel1' burada InitializeComponent() ile ba�lat�lm�� olmal�
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
            string connectionString = ConfigurationManager.ConnectionStrings["OrderTrackingDB"].ConnectionString;

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

                // Yeni sipari� ekleme sorgusu (rota sistemi ile birlikte)
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

                    // Sipari� ID'sini al
                    int siparisId = (int)orderCommand.ExecuteScalar();

                    // Kaydedilen sipari� ID'sini kontrol edelim
                    Console.WriteLine($"Kaydedilen Sipari� ID: {siparisId}");

                    // Rota alanlar�n� kaydet
                    for (int i = 0; i <= 10; i++) // i'yi 0'dan ba�latt�m ��nk� panelde 0'dan ba�l�yordu.
                    {
                        // Her bir rota i�in TextBox ve NumericUpDown de�erlerini al
                        string rotaAd = this.Controls.Find($"rotaLabel{i}", true).FirstOrDefault()?.Text.Trim();  // Label'dan rota ad�n� al
                        TextBox rotaTextBox = this.Controls.Find($"rota{i}Text", true).FirstOrDefault() as TextBox;
                        NumericUpDown rotaNumeric = this.Controls.Find($"rota{i}Numeric", true).FirstOrDefault() as NumericUpDown;

                        decimal? ucret = rotaNumeric?.Value;
                        string rotaAciklama = rotaTextBox?.Text.Trim(); // TextBox'tan a��klamay� al

                        // E�er rota ad� bo� de�ilse ve �cret varsa rotay� kaydet
                        if (!string.IsNullOrEmpty(rotaAd) && ucret.HasValue)
                        {
                            string insertRotaQuery = "INSERT INTO Rotalar (siparis_id, rota_adi, ucret, rota_aciklama) VALUES (@siparis_id, @rota_adi, @ucret, @rota_aciklama)";

                            using (SqlCommand rotaCommand = new SqlCommand(insertRotaQuery, connection))
                            {
                                rotaCommand.Parameters.AddWithValue("@siparis_id", siparisId);
                                rotaCommand.Parameters.AddWithValue("@rota_adi", rotaAd);
                                rotaCommand.Parameters.AddWithValue("@ucret", ucret.Value);
                                rotaCommand.Parameters.AddWithValue("@rota_aciklama", string.IsNullOrEmpty(rotaAciklama) ? "" : rotaAciklama); // Rota a��klamas� bo� olabilir
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






        // T�m giri� alanlar�n� temizleme fonksiyonu


        private void ClearInputFields()
        {
            sahipCombo.SelectedIndex = -1;
            urun_adiCombo.SelectedIndex = -1;
            urun_cinsiCombo.SelectedIndex = -1;
            aciklamaTextBox.Clear();
            urunMiktarNumeric.Value = 0;
            karNumeric.Value = 0;
            tarihTimerPicker.Value = DateTime.Now;

            // Rota alanlar�n� temizle
            for (int i = 1; i <= 10; i++)
            {
                TextBox rotaText = this.Controls.Find($"rota{i}Text", true).FirstOrDefault() as TextBox;
                NumericUpDown rotaNumeric = this.Controls.Find($"rota{i}Numeric", true).FirstOrDefault() as NumericUpDown;

                if (rotaText != null)
                    rotaText.Clear();

                if (rotaNumeric != null)
                    rotaNumeric.Value = 0;
            }
        }

        private void anaSayfaToolStripMenuItem_Click(object sender, EventArgs e) => ShowForm(new home(userAdminLevel));
        private void onaylananTekliflerToolStripMenuItem_Click(object sender, EventArgs e) => ShowForm(new orders());
        private void teklifOnaylaToolStripMenuItem_Click(object sender, EventArgs e) => PerformAdminAction(new tickets());
        private void kullan�c�EkleToolStripMenuItem_Click(object sender, EventArgs e) => PerformAdminAction(new addUser());
        private void yedeklemeToolStripMenuItem_Click(object sender, EventArgs e) => PerformAdminAction(new databaseSave());
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
            Application.Exit(); // Uygulamay� 

        }

        private void rotaAlanlariniGizle()
        {

        }
        private int rotaSayaci = 0;

        

        private void home_Load(object sender, EventArgs e)
        {
            FillSahipComboBox();
            FillUrunAdiComboBox();
            FillUrunCinsiComboBox();
            FillRotaComboBox();
        }
        

        private void FillSahipComboBox()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["OrderTrackingDB"].ConnectionString;

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
            string connectionString = ConfigurationManager.ConnectionStrings["OrderTrackingDB"].ConnectionString;

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
            string connectionString = ConfigurationManager.ConnectionStrings["OrderTrackingDB"].ConnectionString;

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

        private void yeniRotabtn_Click(object sender, EventArgs e)
        {
            // yeniRota formunu olu�tur
            yeniRota rotaForm = new yeniRota();

            // yeniRota formunu g�ster
            rotaForm.Show();

            // E�er a��lan formun �nceki form ile ba��ms�z olmas�n� istiyorsan, a�a��daki kodu ekleyebilirsin
            // rotaForm.Show(this);  // Bu, yeni formu �nceki formun sahibi yapar.
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void FillRotaComboBox()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["OrderTrackingDB"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Kay�tl� rotalar�n ba�l�klar�n� getiren sorgu
                string query = "SELECT DISTINCT k_rota_baslik FROM kayitliRotalar";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // ComboBox'a ba�l�klar� ekle
                        rotaCombo.Items.Add(reader["k_rota_baslik"].ToString());
                    }
                }
            }
        }

        private void rotaCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedRota = rotaCombo.SelectedItem.ToString();
            string connectionString = ConfigurationManager.ConnectionStrings["OrderTrackingDB"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Se�ilen rota ba�l���na g�re rota adlar�n� getiren sorgu
                string query = "SELECT k_rota_adi FROM kayitliRotalar WHERE k_rota_baslik = @baslik";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@baslik", selectedRota);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Panel i�eri�ini temizle
                        panel1.Controls.Clear();

                        int i = 1; // Kontrol setleri i�in saya� (1'den ba�lat�yoruz)
                        while (reader.Read())
                        {
                            // Yeni label olu�tur
                            Label rotaLabel = new Label();
                            rotaLabel.Name = $"rotaLabel{i}";
                            rotaLabel.Text = reader["k_rota_adi"].ToString();
                            rotaLabel.Location = new Point(20, 50 + (i * 30));
                            panel1.Controls.Add(rotaLabel); // panel1 i�ine ekle

                            // Yeni TextBox olu�tur (rota a��klamas� i�in)
                            TextBox rotaTextBox = new TextBox();
                            rotaTextBox.Name = $"rota{i}Text";
                            rotaTextBox.Location = new Point(150, 50 + (i * 30));
                            panel1.Controls.Add(rotaTextBox); // panel1 i�ine ekle

                            // Yeni NumericUpDown olu�tur (rota �creti i�in)
                            NumericUpDown rotaNumeric = new NumericUpDown();
                            rotaNumeric.Name = $"rota{i}Numeric";
                            rotaNumeric.Location = new Point(300, 50 + (i * 30));

                            // NumericUpDown ayarlar�
                            rotaNumeric.Minimum = 0;
                            rotaNumeric.Maximum = decimal.MaxValue;
                            rotaNumeric.DecimalPlaces = 2;
                            rotaNumeric.Increment = 1M;

                            panel1.Controls.Add(rotaNumeric); // panel1 i�ine ekle

                            i++; // Saya� art�r
                        }

                        // E�er hi�bir kay�t yoksa, iste�e ba�l� olarak kullan�c�ya bir mesaj g�sterebilirsiniz
                        if (i == 1) // Dizin 1'den ba�l�yorsa, i hala 1 ise hi�bir rota eklenmemi�tir
                        {
                            Label noResultsLabel = new Label();
                            noResultsLabel.Text = "Hi�bir rota bulunamad�.";
                            noResultsLabel.Location = new Point(20, 50);
                            panel1.Controls.Add(noResultsLabel);
                        }
                    }
                }
            }
        }











    }
}
