using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OrderTracking
{
    public partial class authority : Form
    {
        public authority()
        {
            InitializeComponent();
            LoadRoles(); // Form açıldığında roller combobox'a yüklenecek
            LoadAdminUsers(); // Form açıldığında admin kullanıcıları yükle
            LoadRegularUsers(); // Form açıldığında yetkisi olmayan kullanıcıları yükle
        }

        private void LoadRoles()
        {
            // Veritabanı bağlantısını oluştur
            string connectionString = ConfigurationManager.ConnectionStrings["OrderTrackingDB"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT rol_isim FROM Roller"; // Roller tablosundaki rol_isim değerlerini seç

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        yetkicombo.Items.Clear(); // ComboBox'ı temizle

                        while (reader.Read())
                        {
                            // Her rol ismini yetkicombo'ya ekle
                            yetkicombo.Items.Add(reader["rol_isim"].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Roller yüklenirken bir hata oluştu: " + ex.Message);
                }
            }
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
            string connectionString = ConfigurationManager.ConnectionStrings["OrderTrackingDB"].ConnectionString;

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

            // Veritabanı bağlantısını oluştur
            string connectionString = ConfigurationManager.ConnectionStrings["OrderTrackingDB"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Seçilen rol ismine göre rol_id'yi bulmak için SQL sorgusu
                    string roleIdQuery = "SELECT rol_id FROM Roller WHERE rol_isim = @rolIsim";
                    SqlCommand getRoleIdCommand = new SqlCommand(roleIdQuery, connection);
                    getRoleIdCommand.Parameters.AddWithValue("@rolIsim", yetki);

                    object result = getRoleIdCommand.ExecuteScalar();
                    if (result == null)
                    {
                        MessageBox.Show("Seçilen rol bulunamadı.");
                        return;
                    }

                    int rolId = Convert.ToInt32(result);

                    // Kullanıcının rolünü güncelleyen SQL sorgusu
                    string updateQuery = "UPDATE Kullanıcılar SET u_rol = @rolId WHERE u_username = @kullaniciAdi";
                    using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                    {
                        updateCommand.Parameters.AddWithValue("@rolId", rolId);
                        updateCommand.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);

                        int rowsAffected = updateCommand.ExecuteNonQuery(); // Sorguyu çalıştır

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Kullanıcı rolü başarıyla güncellendi.");
                            LoadAdminUsers(); // Kullanıcı güncellendiğinde listeyi yeniden yükle
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
            LoadRoles(); // Sayfa yüklendiğinde Roller tablosundaki roller ComboBox'a yüklenecek
            LoadAdminUsers(); // Sayfa yüklendiğinde yetkili kullanıcıları yükle
            LoadRegularUsers(); // Sayfa yüklendiğinde yetkisi olmayan kullanıcıları yükle
        }
    }
}
