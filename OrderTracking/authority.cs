using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderTracking
{
    public partial class authority : Form
    {
        public authority()
        {
            InitializeComponent();
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
    }
}

