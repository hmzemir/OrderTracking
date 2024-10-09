using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace OrderTracking
{
    public partial class authority : Form
    {
        public authority()
        {
            InitializeComponent();
            LoadAdminUsers(); // Form açıldığında admin kullanıcıları yükle
            LoadRegularUsers(); // Form açıldığında yetkisi olmayan kullanıcıları yükle
        }

        private void LoadAdminUsers()
        {
            // Veritabanı bağlantısını oluştur
            string connectionString = ConfigurationManager.ConnectionStrings["OrderTrackingDB"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT u_username FROM Kullanıcılar WHERE u_admin_level = 1"; // Admin seviyesindeki kullanıcıları seç

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        yetkiliListeLabel.Text = ""; // Önceki metni temizle

                        while (reader.Read())
                        {
                            // Kullanıcı adını label'a ekle ve ardından bir satır boşluk bırak
                            yetkiliListeLabel.Text += reader["u_username"].ToString() + Environment.NewLine;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
            }
        }

        private void LoadRegularUsers()
        {
            // Veritabanı bağlantısını oluştur
            string connectionString = "Data Source=TETrA\\SQLEXPRESS;Initial Catalog=orderTracking;Integrated Security=True;Encrypt=False";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT u_username FROM Kullanıcılar WHERE u_admin_level = 0"; // Yetkisi olmayan kullanıcıları seç

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        kullanıcılarLabel.Text = ""; // Önceki metni temizle

                        while (reader.Read())
                        {
                            // Kullanıcı adını label'a ekle ve ardından bir satır boşluk bırak
                            kullanıcılarLabel.Text += reader["u_username"].ToString() + Environment.NewLine;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
            }
        }

        private void kullanıcıEkle_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = kullanıcıadıTextbox.Text.Trim();
            string yetki = yetkicombo.SelectedItem?.ToString(); // Seçili yetkiyi al

            // Kullanıcı adı ve yetki kontrolü
            if (string.IsNullOrWhiteSpace(kullaniciAdi) || string.IsNullOrWhiteSpace(yetki))
            {
                MessageBox.Show("Lütfen kullanıcı adını ve yetkiyi doldurun.");
                return;
            }

            int uAdminLevel = (yetki == "Admin") ? 1 : 0; // Yetkiye göre admin seviyesi belirle

            // Veritabanı bağlantısını oluştur
            string connectionString = "Data Source=TETrA\\SQLEXPRESS;Initial Catalog=orderTracking;Integrated Security=True;Encrypt=False";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Kullanıcı yetkisini güncelleyen SQL sorgusu
                    string updateQuery = "UPDATE Kullanıcılar SET u_admin_level = @uAdminLevel WHERE u_username = @kullaniciAdi";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@uAdminLevel", uAdminLevel);
                        command.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);

                        int rowsAffected = command.ExecuteNonQuery(); // Sorguyu çalıştır

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Kullanıcı yetkisi başarıyla güncellendi.");
                            LoadAdminUsers(); // Kullanıcı yetkisi güncellendiğinde listeyi yeniden yükle
                            LoadRegularUsers(); // Yetkisi olmayan kullanıcıları da yeniden yükle
                        }
                        else
                        {
                            MessageBox.Show("Kullanıcı bulunamadı veya güncelleme başarısız oldu.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
            }
        }

        private void authority_Load(object sender, EventArgs e)
        {
            LoadAdminUsers(); // Sayfa yüklendiğinde yetkili kullanıcıları yükle
            LoadRegularUsers(); // Sayfa yüklendiğinde yetkisi olmayan kullanıcıları yükle
        }
    }
}
