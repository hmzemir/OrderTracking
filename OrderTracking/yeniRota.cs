using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration; // ConfigurationManager için gerekli
using System.Windows.Forms;

namespace OrderTracking
{
    public partial class yeniRota : Form
    {
        // Bağlantı dizesini ConfigurationManager'dan alıyoruz
        private string connectionString = ConfigurationManager.ConnectionStrings["OrderTrackingDB"].ConnectionString;

        // Dinamik rota eklemek için sayaç
        private int rotaCounter = 1;

        public yeniRota()
        {
            InitializeComponent();
        }

        // "Yeni Alt Rota Ekle" butonuna basıldığında çağrılan metot
        private void btnYeniRotaEkle_Click(object sender, EventArgs e)
        {
            rotaCounter++;

            // Yeni TextBox oluştur
            TextBox yeniRota = new TextBox
            {
                Name = "rotaAdiTextBox" + rotaCounter,
                Width = 250,
                Text = $"Alt Rota Adı {rotaCounter}", // Placeholder olarak başlangıç metni
            };

            // TextBox'a odaklanıldığında temizlemek için event ekleyelim
            yeniRota.Enter += (s, ea) =>
            {
                if (yeniRota.Text == $"Alt Rota Adı {rotaCounter}")
                    yeniRota.Clear();
            };

            // TextBox'dan odak kaybolduğunda eğer boşsa placeholder metnini geri yükleyelim
            yeniRota.Leave += (s, ea) =>
            {
                if (string.IsNullOrWhiteSpace(yeniRota.Text))
                    yeniRota.Text = $"Alt Rota Adı {rotaCounter}";
            };

            // Alt rotalar için kullanılan FlowLayoutPanel'e yeni rota ekle
            flowLayoutPanelAltRotalar.Controls.Add(yeniRota);
        }

        // "Kaydet" butonuna basıldığında çağrılan metot
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string rotaBaslik = txtRotaBaslik.Text; // Rota başlığını al
            List<string> rotaAdlari = new List<string>();

            // FlowLayoutPanel'deki tüm TextBox'ları dolaşarak rota adlarını al
            foreach (Control control in flowLayoutPanelAltRotalar.Controls)
            {
                if (control is TextBox textBox && !string.IsNullOrWhiteSpace(textBox.Text))
                {
                    rotaAdlari.Add(textBox.Text.Trim()); // Boşlukları temizle ve ekle
                }
            }

            // Rota adlarını kaydet
            if (rotaAdlari.Count > 0)
            {
                KaydetVeritabanina(rotaBaslik, rotaAdlari);
            }
            else
            {
                MessageBox.Show("Lütfen en az bir alt rota adı giriniz.");
            }
        }


        private void KaydetVeritabanina(string rotaBaslik, List<string> rotaAdlari)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Mevcut başlığı kontrol et
                string checkQuery = "SELECT COUNT(*) FROM kayitliRotalar WHERE k_rota_baslik = @RotaBaslik";
                int count = 0;

                using (SqlCommand command = new SqlCommand(checkQuery, connection))
                {
                    command.Parameters.AddWithValue("@RotaBaslik", rotaBaslik);
                    count = (int)command.ExecuteScalar(); // Başlık sayısını al
                }

                // Eğer başlık mevcut değilse, ekleme yap
                if (count == 0)
                {
                    // Rota başlığını kaydet
                    string insertRotaQuery = "INSERT INTO kayitliRotalar (k_rota_baslik) VALUES (@RotaBaslik)";
                    using (SqlCommand command = new SqlCommand(insertRotaQuery, connection))
                    {
                        command.Parameters.AddWithValue("@RotaBaslik", rotaBaslik);
                        command.ExecuteNonQuery(); // Rota başlığını ekle
                    }

                    // Rota adlarını kaydet
                    string insertRotaAdQuery = "INSERT INTO kayitliRotalar (k_rota_baslik, k_rota_adi) VALUES (@RotaBaslik, @K_Rota_Adi)";
                    foreach (var rotaAdi in rotaAdlari)
                    {
                        using (SqlCommand command = new SqlCommand(insertRotaAdQuery, connection))
                        {
                            command.Parameters.AddWithValue("@RotaBaslik", rotaBaslik); // Başlığı kullan
                            command.Parameters.AddWithValue("@K_Rota_Adi", rotaAdi.Trim()); // Boşlukları temizle
                            command.ExecuteNonQuery(); // Her rota adı için kaydet
                        }
                    }

                    MessageBox.Show("Kayıt işlemi başarılı.");
                }
                else
                {
                    MessageBox.Show("Bu başlık zaten mevcut. Lütfen farklı bir başlık girin.");
                }
            }
        }






        // "Temizle" butonuna basıldığında çağrılan metot
        private void btnTemizle_Click(object sender, EventArgs e)
        {
            // Rota başlığını temizler
            txtRotaBaslik.Clear();

            // FlowLayoutPanel'deki tüm dinamik TextBox'ları temizler
            flowLayoutPanelAltRotalar.Controls.Clear();

            // Sayaç sıfırlanır
            rotaCounter = 1;
        }
    }
}
