using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Configuration;

namespace OrderTracking
{
    public partial class addUser : Form
    {
        // Veritabanı bağlantı cümlesi
        private string connectionString = ConfigurationManager.ConnectionStrings["OrderTrackingDB"].ConnectionString;

        public addUser()
        {
            InitializeComponent();
        }

        // Rastgele şifre oluşturma (Zaten mevcut)
        private void label3_Click(object sender, EventArgs e)
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            int passwordLength = 4;  // Örneğin, 4 karakterlik bir şifre
            char[] password = new char[passwordLength];

            for (int i = 0; i < passwordLength; i++)
            {
                password[i] = chars[random.Next(chars.Length)];
            }

            // Şifreyi TextBox2'ye yazdır
            sıfreTextbox.Text = new string(password);
        }



        // SHA-256 ile şifreyi hashleme fonksiyonu
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

        private void kullanıcıEkle_Click(object sender, EventArgs e)
        {

            // Kullanıcı adı ve şifre textBox'lardan alınıyor
            string kullaniciAdi = kullanıcıadıTextbox.Text;
            string sifre = sıfreTextbox.Text;

            // Şifre hashleniyor
            string hashliSifre = ComputeSha256Hash(sifre);

            // Veritabanına ekleme
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // SQL sorgusu: Kullanıcı adı ve hashlenmiş şifreyi kaydet
                    string query = "INSERT INTO Kullanıcılar (u_username, u_password) VALUES (@kullaniciAdi, @hashliSifre)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
                    cmd.Parameters.AddWithValue("@hashliSifre", hashliSifre);

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Kullanıcı başarıyla eklendi.");
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı eklenemedi.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }
    }
}
