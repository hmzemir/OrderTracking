using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderTracking
{
    public partial class addRole : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["OrderTrackingDB"].ConnectionString;
        public addRole()
        {
            InitializeComponent();
            YetkileriListele();
        }

        private void yetkiEklebtn_Click(object sender, EventArgs e)
        {
            string rolIsmi = yetkiadıTextbox.Text.Trim();

            if (!string.IsNullOrEmpty(rolIsmi))
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // Aynı rol isminin eklenip eklenmediğini kontrol et
                    SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Roller WHERE rol_isim = @rolIsim", con);
                    checkCmd.Parameters.AddWithValue("@rolIsim", rolIsmi);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count == 0)
                    {
                        // Eğer rol zaten yoksa, ekleme işlemini yap
                        SqlCommand insertCmd = new SqlCommand("INSERT INTO Roller (rol_isim) VALUES (@rolIsim)", con);
                        insertCmd.Parameters.AddWithValue("@rolIsim", rolIsmi);
                        insertCmd.ExecuteNonQuery();
                        MessageBox.Show("Rol başarıyla eklendi.");
                    }
                    else
                    {
                        MessageBox.Show("Bu isimde bir rol zaten var.");
                    }
                }

                YetkileriListele();
            }
            else
            {
                MessageBox.Show("Lütfen bir rol ismi girin.");
            }
        }

        private void yetkiSilbtn_Click(object sender, EventArgs e)
        {
            string rolIsmi = yetkiadıTextbox.Text.Trim();

            if (!string.IsNullOrEmpty(rolIsmi))
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    SqlCommand deleteCmd = new SqlCommand("DELETE FROM Roller WHERE rol_isim = @rolIsim", con);
                    deleteCmd.Parameters.AddWithValue("@rolIsim", rolIsmi);
                    int rowsAffected = deleteCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Rol başarıyla silindi.");
                    }
                    else
                    {
                        MessageBox.Show("Bu isimde bir rol bulunamadı.");
                    }
                }

                YetkileriListele();
            }
            else
            {
                MessageBox.Show("Lütfen bir rol ismi girin.");
            }
        }

        // Roller tablosundaki verileri labela listeleme
        private void YetkileriListele()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT rol_isim FROM Roller", con);
                SqlDataReader reader = cmd.ExecuteReader();

                yetkiListeLabel.Text = ""; // Label'ı temizle

                while (reader.Read())
                {
                    yetkiListeLabel.Text += reader["rol_isim"].ToString() + Environment.NewLine;
                }
            }

        }
    }
}
