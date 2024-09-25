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
        private int userAdminLevel; // Kullanýcýnýn yetki seviyesi

        public home(int adminLevel) // Yapýcý metot
        {
            InitializeComponent();
            userAdminLevel = adminLevel; // Yetki seviyesini ayarla
            parentPanel = this.panel1;
            parentPanel.AutoScroll = false;
            this.Resize += home_Resize;
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

                // Kayýt baþarýlý olduðunda tüm kutularý temizle
                ClearInputFields();
                MessageBox.Show("Kayýt baþarýyla tamamlandý.");
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
        private void teklifOnaylaToolStripMenuItem_Click(object sender, EventArgs e) => ShowForm(new tickets());
        private void kullanýcýEkleToolStripMenuItem_Click(object sender, EventArgs e) => PerformAdminAction(new addUser());
        private void yedeklemeToolStripMenuItem_Click(object sender, EventArgs e) => ShowForm(new databaseSave());
        private void yetkiVerToolStripMenuItem_Click(object sender, EventArgs e) => PerformAdminAction(new authority());

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
            this.Hide();
            login homeForm = new login();
            homeForm.Show();
        }
    }
}
