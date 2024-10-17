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
        private int userAdminLevel; // Kullanýcýnýn yetki seviyesi

        public home(int adminLevel) // Yapýcý metot
        {
            InitializeComponent(); // Bu metodun ilk çaðrýlmasý gerektiðinden emin olun
            userAdminLevel = adminLevel; // Yetki seviyesini ayarla

            // 'panel1' burada InitializeComponent() ile baþlatýlmýþ olmalý
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

                // Kontrol deðerlerini al
                string sahip = sahipCombo.Text.Trim();
                string urunAdi = urun_adiCombo.Text.Trim();
                string urunCinsi = urun_cinsiCombo.Text.Trim();
                string aciklama = aciklamaTextBox.Text.Trim();
                decimal urunMiktari = urunMiktarNumeric.Value;
                decimal kar = karNumeric.Value;

                // Debug: Alan deðerlerini kontrol et
                Console.WriteLine($"Sahip: {sahip}, Ürün Adý: {urunAdi}, Ürün Cinsi: {urunCinsi}, Açýklama: {aciklama}, Miktar: {urunMiktari}, Kar: {kar}");

                // Alan kontrolü
                if (string.IsNullOrWhiteSpace(sahip) || string.IsNullOrWhiteSpace(urunAdi) || string.IsNullOrWhiteSpace(urunCinsi) ||
                    string.IsNullOrWhiteSpace(aciklama) || urunMiktari <= 0 || kar < 0)
                {
                    MessageBox.Show("Lütfen tüm alanlarý doðru þekilde doldurun.");
                    return;
                }

                // Yeni sipariþ ekleme sorgusu (rota sistemi ile birlikte)
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

                    // Sipariþ ID'sini al
                    int siparisId = (int)orderCommand.ExecuteScalar();

                    // Kaydedilen sipariþ ID'sini kontrol edelim
                    Console.WriteLine($"Kaydedilen Sipariþ ID: {siparisId}");

                    // Rota alanlarýný kaydet
                    for (int i = 0; i <= 10; i++) // i'yi 0'dan baþlattým çünkü panelde 0'dan baþlýyordu.
                    {
                        // Her bir rota için TextBox ve NumericUpDown deðerlerini al
                        string rotaAd = this.Controls.Find($"rotaLabel{i}", true).FirstOrDefault()?.Text.Trim();  // Label'dan rota adýný al
                        TextBox rotaTextBox = this.Controls.Find($"rota{i}Text", true).FirstOrDefault() as TextBox;
                        NumericUpDown rotaNumeric = this.Controls.Find($"rota{i}Numeric", true).FirstOrDefault() as NumericUpDown;

                        decimal? ucret = rotaNumeric?.Value;
                        string rotaAciklama = rotaTextBox?.Text.Trim(); // TextBox'tan açýklamayý al

                        // Eðer rota adý boþ deðilse ve ücret varsa rotayý kaydet
                        if (!string.IsNullOrEmpty(rotaAd) && ucret.HasValue)
                        {
                            string insertRotaQuery = "INSERT INTO Rotalar (siparis_id, rota_adi, ucret, rota_aciklama) VALUES (@siparis_id, @rota_adi, @ucret, @rota_aciklama)";

                            using (SqlCommand rotaCommand = new SqlCommand(insertRotaQuery, connection))
                            {
                                rotaCommand.Parameters.AddWithValue("@siparis_id", siparisId);
                                rotaCommand.Parameters.AddWithValue("@rota_adi", rotaAd);
                                rotaCommand.Parameters.AddWithValue("@ucret", ucret.Value);
                                rotaCommand.Parameters.AddWithValue("@rota_aciklama", string.IsNullOrEmpty(rotaAciklama) ? "" : rotaAciklama); // Rota açýklamasý boþ olabilir
                                rotaCommand.ExecuteNonQuery();
                            }
                        }
                    }
                }

                // Kayýt baþarýlý olduðunda tüm kutularý temizle
                ClearInputFields();
                MessageBox.Show("Kayýt baþarýyla tamamlandý.");
            }
        }






        // Tüm giriþ alanlarýný temizleme fonksiyonu


        private void ClearInputFields()
        {
            sahipCombo.SelectedIndex = -1;
            urun_adiCombo.SelectedIndex = -1;
            urun_cinsiCombo.SelectedIndex = -1;
            aciklamaTextBox.Clear();
            urunMiktarNumeric.Value = 0;
            karNumeric.Value = 0;
            tarihTimerPicker.Value = DateTime.Now;

            // Rota alanlarýný temizle
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
        private void kullanýcýEkleToolStripMenuItem_Click(object sender, EventArgs e) => PerformAdminAction(new addUser());
        private void yedeklemeToolStripMenuItem_Click(object sender, EventArgs e) => PerformAdminAction(new databaseSave());
        private void yetkiVerToolStripMenuItem_Click(object sender, EventArgs e) => PerformAdminAction(new authority());
        private void istatistiklkerToolStripMenuItem_Click(object sender, EventArgs e) => PerformAdminAction(new statistics());


        private void PerformAdminAction(Form form)
        {
            // Kullanýcý yetkisini kontrol et
            if (userAdminLevel != 1) // Yetkisi yoksa
            {
                MessageBox.Show("Bu iþlemi gerçekleþtirmek için yetkiniz yok.");
                return; // Ýþlemi durdur
            }
            // Yetkisi varsa formu göster
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
                MessageBox.Show("Bir hata oluþtu: " + ex.Message);
            }
        }

        private void kayit_Click(object sender, EventArgs e)
        {
            SaveDataToDatabase();
            
        }

        private void hesaplabtn_Click(object sender, EventArgs e)
        {
            // Rota toplamýný hesapla
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

            // Kâr oraný yüzdesi
            decimal kar = karNumeric.Value;

            // Kâr eklenmiþ toplam hesaplama
            decimal kârMiktarý = rotaToplam * (kar / 100);
            decimal karlýToplam = rotaToplam + kârMiktarý;
            karlýToplamLabel.Text = karlýToplam.ToString("F2");

            // KDV hesaplama
            decimal kdv = karlýToplam * 0.20m; // %20 KDV
            toplamKdvLabel.Text = kdv.ToString("F2");

            // KDV'li toplam hesaplama
            decimal kdvliToplam = karlýToplam + kdv;
            kdvliToplamLabel.Text = kdvliToplam.ToString("F2");

            // Toplam tutarý KDV'li toplam olarak ayarlama
            toplamTutarLabel.Text = kdvliToplam.ToString("F2");

            // KDV'li adeti hesaplama
            decimal urunMiktari = urunMiktarNumeric.Value;
            decimal kdvliAdet = kdvliToplam / urunMiktari;
            kdvliAdetLabel.Text = kdvliAdet.ToString("F2");

            // KDV'siz adeti hesaplama
            decimal kdvsizAdet = karlýToplam / urunMiktari;
            kdvsizAdetLabel.Text = kdvsizAdet.ToString("F2");
        }

        private void çýkýþToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Uygulamayý 

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

                // Sipariþ tablosundaki sahip bilgilerini almak için sorgu
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

            // Kullanýcýya kendi ismini yazma izni ver
            sahipCombo.DropDownStyle = ComboBoxStyle.DropDown;
        }

        private void FillUrunAdiComboBox()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["OrderTrackingDB"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Sipariþ tablosundaki ürün adý bilgilerini almak için sorgu
                string query = "SELECT DISTINCT urun_adi FROM siparisler"; // urun_adi sütununu seç

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // ComboBox'a ürün adlarýný ekle
                        urun_adiCombo.Items.Add(reader["urun_adi"].ToString());
                    }
                }
            }

            // Kullanýcýya kendi ürün ismini yazma izni ver
            urun_adiCombo.DropDownStyle = ComboBoxStyle.DropDown;
        }

        private void FillUrunCinsiComboBox()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["OrderTrackingDB"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Sipariþ tablosundaki ürün cinsi bilgilerini almak için sorgu
                string query = "SELECT DISTINCT urun_cinsi FROM siparisler"; // urun_cinsi sütununu seç

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // ComboBox'a ürün cinslerini ekle
                        urun_cinsiCombo.Items.Add(reader["urun_cinsi"].ToString());
                    }
                }
            }

            // Kullanýcýya kendi ürün cinsini yazma izni ver
            urun_cinsiCombo.DropDownStyle = ComboBoxStyle.DropDown;
        }

        private void yeniRotabtn_Click(object sender, EventArgs e)
        {
            // yeniRota formunu oluþtur
            yeniRota rotaForm = new yeniRota();

            // yeniRota formunu göster
            rotaForm.Show();

            // Eðer açýlan formun önceki form ile baðýmsýz olmasýný istiyorsan, aþaðýdaki kodu ekleyebilirsin
            // rotaForm.Show(this);  // Bu, yeni formu önceki formun sahibi yapar.
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

                // Kayýtlý rotalarýn baþlýklarýný getiren sorgu
                string query = "SELECT DISTINCT k_rota_baslik FROM kayitliRotalar";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // ComboBox'a baþlýklarý ekle
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

                // Seçilen rota baþlýðýna göre rota adlarýný getiren sorgu
                string query = "SELECT k_rota_adi FROM kayitliRotalar WHERE k_rota_baslik = @baslik";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@baslik", selectedRota);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Panel içeriðini temizle
                        panel1.Controls.Clear();

                        int i = 1; // Kontrol setleri için sayaç (1'den baþlatýyoruz)
                        while (reader.Read())
                        {
                            // Yeni label oluþtur
                            Label rotaLabel = new Label();
                            rotaLabel.Name = $"rotaLabel{i}";
                            rotaLabel.Text = reader["k_rota_adi"].ToString();
                            rotaLabel.Location = new Point(20, 50 + (i * 30));
                            panel1.Controls.Add(rotaLabel); // panel1 içine ekle

                            // Yeni TextBox oluþtur (rota açýklamasý için)
                            TextBox rotaTextBox = new TextBox();
                            rotaTextBox.Name = $"rota{i}Text";
                            rotaTextBox.Location = new Point(150, 50 + (i * 30));
                            panel1.Controls.Add(rotaTextBox); // panel1 içine ekle

                            // Yeni NumericUpDown oluþtur (rota ücreti için)
                            NumericUpDown rotaNumeric = new NumericUpDown();
                            rotaNumeric.Name = $"rota{i}Numeric";
                            rotaNumeric.Location = new Point(300, 50 + (i * 30));

                            // NumericUpDown ayarlarý
                            rotaNumeric.Minimum = 0;
                            rotaNumeric.Maximum = decimal.MaxValue;
                            rotaNumeric.DecimalPlaces = 2;
                            rotaNumeric.Increment = 1M;

                            panel1.Controls.Add(rotaNumeric); // panel1 içine ekle

                            i++; // Sayaç artýr
                        }

                        // Eðer hiçbir kayýt yoksa, isteðe baðlý olarak kullanýcýya bir mesaj gösterebilirsiniz
                        if (i == 1) // Dizin 1'den baþlýyorsa, i hala 1 ise hiçbir rota eklenmemiþtir
                        {
                            Label noResultsLabel = new Label();
                            noResultsLabel.Text = "Hiçbir rota bulunamadý.";
                            noResultsLabel.Location = new Point(20, 50);
                            panel1.Controls.Add(noResultsLabel);
                        }
                    }
                }
            }
        }











    }
}
