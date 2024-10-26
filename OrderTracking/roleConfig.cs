using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OrderTracking
{
    public partial class roleConfig : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["OrderTrackingDB"].ConnectionString;

        public roleConfig()
        {
            InitializeComponent();
            LoadRollerToCombo();
        }

        // Roller tablosundan verileri çek ve ComboBox'a ekle
        private void LoadRollerToCombo()
        {
            string query = "SELECT rol_id, rol_isim FROM Roller";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    yetkilerCombo.Items.Add(new { Id = reader["rol_id"], Name = reader["rol_isim"] });
                }
                reader.Close();
            }
            yetkilerCombo.DisplayMember = "Name";
            yetkilerCombo.ValueMember = "Id";
            yetkilerCombo.SelectedIndexChanged += yetkilerCombo_SelectedIndexChanged;
        }

        // Sayfalar tablosundan checkbox oluştur ve rol izinlerini yükle
        private void LoadSayfalarAndPermissions(int rolId)
        {
            sayfalarPanel.Controls.Clear(); // Önceki kontrolleri temizle
            string query = @"
        SELECT s.sayfa_id, s.sayfa_adi, ISNULL(ri.erisim, 0) AS erisim
        FROM sayfalar s
        LEFT JOIN rol_sayfa_izinleri ri ON s.sayfa_id = ri.sayfa_id AND ri.rol_id = @rolId";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@rolId", rolId);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CheckBox cb = new CheckBox
                    {
                        Text = reader["sayfa_adi"].ToString(),
                        Tag = reader["sayfa_id"],
                        Checked = Convert.ToBoolean(reader["erisim"]),
                        AutoSize = true // Checkbox boyutunu otomatik ayarla
                    };
                    sayfalarPanel.Controls.Add(cb); // FlowLayoutPanel'e checkbox ekle
                }
                reader.Close();
            }
        }




        private void yetkilerCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (yetkilerCombo.SelectedItem != null)
            {
                var selectedRol = (dynamic)yetkilerCombo.SelectedItem;
                LoadSayfalarAndPermissions((int)selectedRol.Id);
            }
        }

        private void kayitBtn_Click(object sender, EventArgs e)
        {
            if (yetkilerCombo.SelectedItem == null) return;

            var selectedRol = (dynamic)yetkilerCombo.SelectedItem;
            int rolId = (int)selectedRol.Id;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    SqlCommand deleteCmd = new SqlCommand("DELETE FROM rol_sayfa_izinleri WHERE rol_id = @rolId", conn, transaction);
                    deleteCmd.Parameters.AddWithValue("@rolId", rolId);
                    deleteCmd.ExecuteNonQuery();

                    foreach (CheckBox cb in sayfalarPanel.Controls)
                    {
                        SqlCommand insertCmd = new SqlCommand(@"
                            INSERT INTO rol_sayfa_izinleri (rol_id, sayfa_id, erisim) 
                            VALUES (@rolId, @sayfaId, @erisim)", conn, transaction);
                        insertCmd.Parameters.AddWithValue("@rolId", rolId);
                        insertCmd.Parameters.AddWithValue("@sayfaId", (int)cb.Tag);
                        insertCmd.Parameters.AddWithValue("@erisim", cb.Checked);
                        insertCmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    MessageBox.Show("Yetki başarıyla güncellendi.");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Yetki güncellenirken hata oluştu: " + ex.Message);
                }
            }
        }
    }
}
