using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace OrderTracking
{
    public partial class login : Form
    {
        // Veritabanı bağlantı cümlesi (Connection String)
        string connectionString = "Data Source=TETrA\\SQLEXPRESS;Initial Catalog=orderTracking;Integrated Security=True;Encrypt=False";

        public static int UserAdminLevel { get; private set; } // Kullanıcı admin seviyesi

        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Kullanıcıdan alınan giriş bilgileri
            string kullaniciAdi = kullanıcıadıTextbox.Text;
            string sifre = sifreTextbox.Text;

            // Şifreyi hash'lemek
            string hashliSifre = ComputeSha256Hash(sifre);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Kullanıcının yetki seviyesini de almak için sorguyu güncelleyelim
                    string query = "SELECT u_admin_level FROM Kullanıcılar WHERE u_username = @kullaniciAdi AND u_password = @hashliSifre";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
                    cmd.Parameters.AddWithValue("@hashliSifre", hashliSifre);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        // Giriş başarılıysa, yetki seviyesini al
                        int adminLevel = reader.GetInt32(0);
                        MessageBox.Show("Giriş başarılı! Yönlendiriliyorsunuz...");
                        this.Hide();
                        home homeForm = new home(adminLevel); // Yetki seviyesini geçir
                        homeForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı adı veya şifre hatalı.");
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        // SHA-256 algoritması ile şifreyi hash'leyen fonksiyon
        private static string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Girdiği bayt dizisine çevir
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Hash değerini string'e çevir
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
