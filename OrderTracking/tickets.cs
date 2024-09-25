using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderTracking
{
    public partial class tickets : Form
    {
        private string connectionString = "Data Source=TETrA\\SQLEXPRESS;Initial Catalog=orderTracking;Integrated Security=True;Encrypt=False";
        public tickets()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void tickets_Load(object sender, EventArgs e)
        {
            // Form yüklendiğinde onay bekleyen siparişleri otomatik listele
            LoadPendingOrders();
        }

        private void LoadPendingOrders()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString)) // connectionString kullanıyoruz
            {
                sqlConnection.Open();
                string query = "SELECT * FROM Siparisler WHERE siparis_onay = 0"; // Onay bekleyen siparişleri al
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection); // Değişken adını güncelledik
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                onayBekleyenlerDGV.DataSource = dataTable; // DataGridView'e bağla
            }
        }

        private void anaSayfaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Mevcut formu kapat
                this.Hide();

                // Kullanıcı admin seviyesini al
                int userAdminLevel = GetUserAdminLevel(); // Bu yöntemi, admin seviyesini alacak şekilde tanımlayın

                // Yeni home formunu aç
                home homeForm = new home(userAdminLevel); // adminLevel değerini geçin
                homeForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        // Örnek bir yöntem
        private int GetUserAdminLevel()
        {
            // Burada admin seviyesini almak için gereken mantığı yazın
            return 1; // Örneğin 1 döndürdük
        }

        private void teklifOnaylaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Mevcut formu kapat
                this.Hide();

                // Yeni tickets formunu aç
                tickets ticketForm = new tickets();
                ticketForm.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        private void onaylananTekliflerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Mevcut formu kapat
                this.Hide();

                // Yeni orders formunu aç
                orders orderForm = new orders();
                orderForm.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        private void kullanıcıEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Yeni addUser formunu aç
                addUser adduserForm = new addUser();
                adduserForm.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        private void yedeklemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Yeni databaseSave formunu aç
                databaseSave dataForm = new databaseSave();
                dataForm.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        private void sahiparamaText_KeyUp(object sender, KeyEventArgs e)
        {
            string aramaKelimesi = sahiparamaText.Text.Trim();
            FilterPendingOrders(aramaKelimesi);
        }

        private void FilterPendingOrders(string aramaKelimesi)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Siparisler WHERE siparis_onay = 0 AND sahip LIKE @aramaKelimesi";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@aramaKelimesi", "%" + aramaKelimesi + "%");
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    onayBekleyenlerDGV.DataSource = dt; // Filtrelenmiş veriyi yükle
                }
            }
        }

        private void onayBekleyenlerDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Geçerli bir satıra tıklanıp tıklanmadığını kontrol et
            {
                DataGridViewRow row = onayBekleyenlerDGV.Rows[e.RowIndex];

                // Bilgileri al
                string sahip = row.Cells["sahip"].Value.ToString();
                string tarih = row.Cells["tarih"].Value.ToString();
                string urunAdi = row.Cells["urun_adi"].Value.ToString();
                string urunMiktari = row.Cells["urun_miktari"].Value.ToString();
                string urunCinsi = row.Cells["urun_cinsi"].Value.ToString();
                string aciklama = row.Cells["aciklama"].Value.ToString();
                int siparisId = Convert.ToInt32(row.Cells["id"].Value);

                // Bilgileri yaz
                sahipText.Text = sahip;
                tarihTimerPicker.Value = Convert.ToDateTime(tarih);
                urunadiText.Text = urunAdi;
                urunmiktarıText.Text = urunMiktari;
                uruncinsiText.Text = urunCinsi;
                aciklamaTextBox.Text = aciklama;

                // Rota bilgilerini al
                LoadRouteInfo(siparisId);
            }
        }

        private void LoadRouteInfo(int siparisId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString)) // connectionString kullanıyoruz
            {
                connection.Open();
                string query = "SELECT rota_adi, ucret FROM Rotalar WHERE siparis_id = @siparisId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@siparisId", siparisId);
                    SqlDataReader reader = command.ExecuteReader();

                    decimal toplamUcret = 0; // Ücretleri toplamak için
                    richTextBox1.Clear(); // Önceki bilgileri temizle

                    while (reader.Read())
                    {
                        string rotaAdi = reader["rota_adi"].ToString();
                        decimal ucret = Convert.ToDecimal(reader["ucret"]);
                        toplamUcret += ucret;

                        // Rota bilgilerini yazdır
                        richTextBox1.AppendText($"{rotaAdi} ({ucret} TL)\n");
                    }

                    // Toplam ücreti yazdır
                    rotaToplamLabel.Text = toplamUcret.ToString("F2");

                    // KDV Hesaplama
                    decimal kdvliToplam = toplamUcret + 120; // 120 TL ekle
                    kdvliToplamLabel.Text = kdvliToplam.ToString("F2");

                    // Adet başına KDV'li fiyat hesaplama
                    if (decimal.TryParse(urunmiktarıText.Text, out decimal urunMiktari) && urunMiktari > 0)
                    {
                        decimal kdvliAdetFiyati = kdvliToplam / urunMiktari;
                        kdvliAdetLabel.Text = kdvliAdetFiyati.ToString("F2");
                    }
                }
            }
        }

        private void onaylabtn_Click(object sender, EventArgs e)
        {
            int siparisId = GetSelectedSiparisId(); // Seçilen siparişin ID'sini al
            UpdateSiparisOnay(siparisId);
            PrintSiparisBilgileri();
        }

        private void UpdateSiparisOnay(int siparisId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString)) // connectionString kullanıyoruz
            {
                connection.Open();
                string updateQuery = "UPDATE Siparisler SET siparis_onay = 1 WHERE id = @siparisId";

                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@siparisId", siparisId);
                    command.ExecuteNonQuery(); // Sorguyu çalıştır
                    MessageBox.Show("Sipariş onaylandı.");
                }
            }
        }

        private void PrintSiparisBilgileri()
        {
            // Yazdırma işlemleri
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(PrintPage);
            PrintPreviewDialog previewDialog = new PrintPreviewDialog
            {
                Document = printDocument
            };
            previewDialog.ShowDialog(); // Önizlemeyi göster
        }

        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            // Yazdırılacak içerik
            string printContent = $"Sahip: {sahipText.Text}\n" +
                                  $"Tarih: {tarihTimerPicker.Value}\n" +
                                  $"Ürün Adı: {urunadiText.Text}\n" +
                                  $"Ürün Miktarı: {urunmiktarıText.Text}\n" +
                                  $"Ürün Cinsi: {uruncinsiText.Text}\n" +
                                  $"Açıklama: {aciklamaTextBox.Text}\n" +
                                  $"Toplam Ücret: {rotaToplamLabel.Text} TL\n" +
                                  $"KDV'li Toplam: {kdvliToplamLabel.Text} TL\n" +
                                  $"KDV'li Adet Fiyatı: {kdvliAdetLabel.Text} TL";

            e.Graphics.DrawString(printContent, new Font("Arial", 12), Brushes.Black, new PointF(100, 100)); // Yazdır
        }

        private int GetSelectedSiparisId()
        {
            // DataGridView'den seçilen siparişin ID'sini al
            if (onayBekleyenlerDGV.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = onayBekleyenlerDGV.SelectedRows[0];
                return Convert.ToInt32(selectedRow.Cells["id"].Value);
            }
            return -1; // Seçim yoksa -1 döndür
        }

        private void sahiparamaText_TextChanged(object sender, EventArgs e)
        {
            string aramaKelimesi = sahiparamaText.Text.Trim();
            FilterPendingOrders(aramaKelimesi);
        }

        private void sahiparamaText_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kullanıcıdan sadece metin girişi
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
