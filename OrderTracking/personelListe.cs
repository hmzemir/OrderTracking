using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OrderTracking
{
    public partial class personelListe : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["OrderTrackingDB"].ConnectionString;

        public personelListe()
        {
            InitializeComponent();
            LoadYetkiCombo();
        }

        private void LoadYetkiCombo()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT rol_isim FROM Roller";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        yetkiCombo.Items.Add(reader["rol_isim"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void araBtn_Click(object sender, EventArgs e)
        {
            string personelAdi = personeladıTextbox.Text.Trim();
            string secilenYetki = yetkiCombo.SelectedItem?.ToString();

            if (yetkisizlercheckbox.Checked)
            {
                // Eğer 'yetkisizlerCheckbox' işaretliyse, sadece 'u_rol' değeri boş olanları listele.
                ListYetkisizler();
            }
            else if (!string.IsNullOrEmpty(secilenYetki))
            {
                ListByYetki(secilenYetki);
            }
            else if (!string.IsNullOrEmpty(personelAdi))
            {
                ListByUsername(personelAdi);
            }
        }

        // Kullanıcı adına göre listeleme fonksiyonu.
        private void ListByUsername(string username)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT k.u_username AS 'Kullanıcı Adı', r.rol_isim AS 'Yetkisi'
                        FROM Kullanıcılar k
                        LEFT JOIN Roller r ON k.u_rol = r.rol_id
                        WHERE k.u_username LIKE @username";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", "%" + username + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    personellerDGV.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        // Yetkiye göre listeleme fonksiyonu.
        private void ListByYetki(string yetki)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT k.u_username AS 'Kullanıcı Adı', r.rol_isim AS 'Yetkisi'
                        FROM Kullanıcılar k
                        JOIN Roller r ON k.u_rol = r.rol_id
                        WHERE r.rol_isim = @yetki";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@yetki", yetki);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    personellerDGV.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        // Yetkisi olmayanları (u_rol değeri NULL olanları) listeleme fonksiyonu.
        private void ListYetkisizler()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT k.u_username AS 'Kullanıcı Adı', 'Yetkisiz' AS 'Yetkisi'
                        FROM Kullanıcılar k
                        WHERE k.u_rol IS NULL";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    personellerDGV.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }
    }
}
