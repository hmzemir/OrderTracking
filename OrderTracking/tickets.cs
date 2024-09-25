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
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT rota_adi, ucret FROM Rotalar WHERE siparis_id = @siparisId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@siparisId", siparisId);
                    SqlDataReader reader = command.ExecuteReader();

                    decimal toplamUcret = 0; // Ücretleri toplamak için
                    richTextBox1.Clear(); // Önceki bilgileri temizle
                    int rotaIndex = 1; // Rota numaralandırması

                    while (reader.Read())
                    {
                        string rotaAdi = reader["rota_adi"].ToString();
                        decimal ucret = Convert.ToDecimal(reader["ucret"]);
                        toplamUcret += ucret;

                        // Rota bilgilerini yazdır
                        richTextBox1.AppendText($"Rota {rotaIndex}: {rotaAdi} ({ucret} TL)\n");
                        rotaIndex++; // Rota numarasını artır
                    }

                    // Toplam ücreti yazdır
                    rotaToplamLabel.Text = toplamUcret.ToString("F2");

                    // KDV Hesaplama (toplamUcret'in %20'si)
                    decimal kdv = toplamUcret * 0.20m; // KDV'yi hesapla
                    decimal kdvliToplam = toplamUcret + kdv; // Toplam + KDV
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
            StringBuilder printContent = new StringBuilder();

            // Başlık ve içerik stili
            Font headerFont = new Font("Arial", 16, FontStyle.Bold);
            Font regularFont = new Font("Arial", 12); // Kalın olmayan font
            Font boxFont = new Font("Arial", 12, FontStyle.Bold);

            // Sayfa Merkezi
            float pageWidth = e.MarginBounds.Width;
            float pageHeight = e.MarginBounds.Height;
            float boxWidth = 500; // Kutu genişliği
            float xMargin = (pageWidth - boxWidth) / 2; // Sayfanın ortasında kutu için
            float lineHeight = regularFont.GetHeight(e.Graphics) + 10;

            // Başlık Kutu
            float yMargin = 50;
            e.Graphics.DrawRectangle(Pens.Black, xMargin, yMargin, boxWidth, lineHeight * 2);
            e.Graphics.DrawString("SİPARİŞ BİLGİLERİ", headerFont, Brushes.Black, xMargin + 10, yMargin + 10);

            // Kişi Bilgileri
            yMargin += lineHeight * 2 + 10; // Başlık altı boşluk
            e.Graphics.DrawRectangle(Pens.Black, xMargin, yMargin, boxWidth, lineHeight * 4);
            e.Graphics.DrawString("----- Kişi Bilgileri -----", headerFont, Brushes.Black, xMargin + 10, yMargin);
            e.Graphics.DrawString($"Sahip: {sahipText.Text}", regularFont, Brushes.Black, xMargin + 10, yMargin + lineHeight);
            e.Graphics.DrawString($"Tarih: {tarihTimerPicker.Value}", regularFont, Brushes.Black, xMargin + 10, yMargin + lineHeight * 2);

            // Ürün Bilgileri
            yMargin += lineHeight * 4 + 10;
            e.Graphics.DrawRectangle(Pens.Black, xMargin, yMargin, boxWidth, lineHeight * 6);
            e.Graphics.DrawString("----- Ürün Bilgileri -----", headerFont, Brushes.Black, xMargin + 10, yMargin);
            e.Graphics.DrawString($"Ürün Adı: {urunadiText.Text}", regularFont, Brushes.Black, xMargin + 10, yMargin + lineHeight);
            e.Graphics.DrawString($"Ürün Miktarı: {urunmiktarıText.Text}", regularFont, Brushes.Black, xMargin + 10, yMargin + lineHeight * 2);
            e.Graphics.DrawString($"Ürün Cinsi: {uruncinsiText.Text}", regularFont, Brushes.Black, xMargin + 10, yMargin + lineHeight * 3);
            e.Graphics.DrawString($"Açıklama: {aciklamaTextBox.Text}", regularFont, Brushes.Black, xMargin + 10, yMargin + lineHeight * 4);

            // Rota Bilgileri
            yMargin += lineHeight * 6 + 10;
            e.Graphics.DrawRectangle(Pens.Black, xMargin, yMargin, boxWidth, lineHeight * (richTextBox1.Lines.Length + 1)); // Rota kutusunun yüksekliği dinamik
            e.Graphics.DrawString("----- Rota Bilgileri -----", headerFont, Brushes.Black, xMargin + 10, yMargin);
            float lineY = yMargin + lineHeight;
            foreach (var line in richTextBox1.Lines)
            {
                e.Graphics.DrawString(line, regularFont, Brushes.Black, xMargin + 10, lineY);
                lineY += lineHeight;
            }

            // Ücret Bilgileri
            yMargin += lineHeight * (richTextBox1.Lines.Length + 1) + 10; // Rota bilgilerini ekleyince yüksekliği ayarlama
            e.Graphics.DrawRectangle(Pens.Black, xMargin, yMargin, boxWidth, lineHeight * 4);
            e.Graphics.DrawString("----- Ücret Bilgileri -----", headerFont, Brushes.Black, xMargin + 10, yMargin);
            e.Graphics.DrawString($"Toplam Ücret: {rotaToplamLabel.Text} TL", boxFont, Brushes.Black, xMargin + 10, yMargin + lineHeight);
            e.Graphics.DrawString($"KDV'li Toplam: {kdvliToplamLabel.Text} TL", boxFont, Brushes.Black, xMargin + 10, yMargin + lineHeight * 2);
            e.Graphics.DrawString($"KDV'li Adet Fiyatı: {kdvliAdetLabel.Text} TL", boxFont, Brushes.Black, xMargin + 10, yMargin + lineHeight * 3);

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
