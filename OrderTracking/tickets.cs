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
using System.Configuration;


namespace OrderTracking
{
    public partial class tickets : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["OrderTrackingDB"].ConnectionString;
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

        // Yeni rota sınıfı
        public class Rota
        {
            public string RotaAdi { get; set; }
            public string RotaAciklama { get; set; }
            public decimal Ucret { get; set; }
        }

        // Rotaları saklamak için liste
        private List<Rota> rotalarListesi = new List<Rota>();

        private void LoadRouteInfo(int siparisId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Siparişin kar yüzdesini almak için sorgu
                decimal karYuzdesi = 0; // Başlangıç değeri
                string karYuzdesiQuery = "SELECT kar FROM Siparisler WHERE id = @siparisId";
                using (SqlCommand karCommand = new SqlCommand(karYuzdesiQuery, connection))
                {
                    karCommand.Parameters.AddWithValue("@siparisId", siparisId);
                    var result = karCommand.ExecuteScalar();
                    if (result != null)
                    {
                        karYuzdesi = Convert.ToDecimal(result) / 100; // Yüzde olarak al
                    }
                }

                // Rotaları almak için sorgu
                string query = "SELECT rota_adi, rota_aciklama, ucret FROM Rotalar WHERE siparis_id = @siparisId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@siparisId", siparisId);
                    SqlDataReader reader = command.ExecuteReader();

                    rotalarListesi.Clear(); // Önceki rotaları temizle
                    decimal toplamUcret = 0; // Ücretleri toplamak için
                    rotaPanel.Controls.Clear(); // Mevcut rota kutucuklarını temizle
                    int yOffset = 10; // Yükseklik ayarı için başlangıç
                    int minimalSpacing = 0; // Label ve TextBox için sıkı boşluk
                    int spacing = 10; // Kontroller arasında az boşluk bırak

                    while (reader.Read())
                    {
                        string rotaAdi = reader["rota_adi"].ToString();
                        string rotaAciklama = reader["rota_aciklama"].ToString();
                        decimal ucret = Convert.ToDecimal(reader["ucret"]);
                        toplamUcret += ucret;

                        // Rotaları listeye ekle
                        rotalarListesi.Add(new Rota { RotaAdi = rotaAdi, RotaAciklama = rotaAciklama, Ucret = ucret });

                        // Rota Adı Label
                        Label rotaAdiLabel = new Label
                        {
                            Location = new Point(10, yOffset),
                            Width = 150,
                            Text = rotaAdi,
                            Padding = new Padding(0),
                            Margin = new Padding(0)
                        };
                        rotaPanel.Controls.Add(rotaAdiLabel);

                        // Rota Açıklama TextBox (salt okunur)
                        TextBox rotaAciklamaTextBox = new TextBox
                        {
                            Location = new Point(rotaAdiLabel.Right + minimalSpacing, yOffset),
                            Width = 200,
                            Text = rotaAciklama,
                            ReadOnly = true
                        };
                        rotaPanel.Controls.Add(rotaAciklamaTextBox);

                        // Ücret NumericUpDown (devre dışı)
                        NumericUpDown ucretNumericUpDown = new NumericUpDown
                        {
                            Location = new Point(rotaAciklamaTextBox.Right + spacing, yOffset),
                            Width = 80,
                            Minimum = 0,
                            Maximum = 10000,
                            DecimalPlaces = 2,
                            Value = ucret,
                            Enabled = false
                        };
                        rotaPanel.Controls.Add(ucretNumericUpDown);

                        // Bir sonraki kutucuk için yükseklik ayarı
                        yOffset += 30;
                    }

                    // Toplam ücreti hesapla ve rotaToplamLabel'a yazdır
                    rotaToplamLabel.Text = toplamUcret.ToString("F2");

                    // Kâr yüzdesi hesaplama
                    decimal karMiktari = toplamUcret * karYuzdesi; // Kâr miktarını hesapla
                    decimal karlitoplam = toplamUcret + karMiktari; // Kâr eklenmiş toplam
                    karlıToplamLabel.Text = karlitoplam.ToString("F2");

                    // KDV hesaplama (%20)
                    decimal kdv = karlitoplam * 0.20m; // KDV'yi hesapla
                    decimal kdvliToplam = karlitoplam + kdv; // KDV eklenmiş toplam
                    kdvliToplamLabel.Text = kdvliToplam.ToString("F2");

                    // Adet başına KDV'li fiyat hesaplama
                    if (decimal.TryParse(urunmiktarıText.Text, out decimal urunMiktari) && urunMiktari > 0)
                    {
                        decimal kdvliAdetFiyati = kdvliToplam / urunMiktari; // KDV'li toplamı ürün miktarına böl
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
            // Seçilen satırdan Sipariş ID'sini al
            int selectedRowIndex = onayBekleyenlerDGV.CurrentCell.RowIndex; // Seçilen satır indeksi
            string siparisID = onayBekleyenlerDGV.Rows[selectedRowIndex].Cells["ID"].Value.ToString(); // ID kolonundan veri çekme

            // Fontlar
            Font headerFont = new Font("Arial", 16, FontStyle.Bold);
            Font regularFont = new Font("Arial", 12);
            Font boldFont = new Font("Arial", 20, FontStyle.Bold); // Sipariş ID'si için büyük ve kalın font

            // Sayfa boyutları
            float pageWidth = e.PageBounds.Width;
            float boxWidth = 600; // Kutu genişliği
            float xMargin = (pageWidth - boxWidth) / 2; // Ortalamak için kenar boşluğu
            float lineHeight = regularFont.GetHeight(e.Graphics) + 10;
            float yMargin = 50; // Başlangıç yeri
            float padding = 10; // Kutuların iç boşluğu

            // 1. Sipariş ID'sini en üstte çiz
            string siparisIDYazisi = $"Sipariş ID: {siparisID}";
            SizeF siparisIDSize = e.Graphics.MeasureString(siparisIDYazisi, boldFont);
            float siparisIDX = (pageWidth - siparisIDSize.Width) / 2; // Ortala
            float siparisIDY = yMargin; // Üst boşluk
            e.Graphics.DrawString(siparisIDYazisi, boldFont, Brushes.Black, siparisIDX, siparisIDY);

            // Y marjini güncelle
            yMargin += siparisIDSize.Height + 30; // Sipariş ID'sinden sonra biraz boşluk

            // 2. Kişi Bilgileri kutusu
            string kisiBilgileriBaslik = "Kişi Bilgileri";
            SizeF kisiBilgileriSize = e.Graphics.MeasureString(kisiBilgileriBaslik, headerFont);
            RectangleF kisiBilgileriBox = new RectangleF(xMargin, yMargin, boxWidth, kisiBilgileriSize.Height + padding * 2);
            e.Graphics.DrawRectangle(Pens.Black, kisiBilgileriBox.X, kisiBilgileriBox.Y, kisiBilgileriBox.Width, kisiBilgileriBox.Height);
            e.Graphics.DrawString(kisiBilgileriBaslik, headerFont, Brushes.Black, kisiBilgileriBox.X + (kisiBilgileriBox.Width - kisiBilgileriSize.Width) / 2, kisiBilgileriBox.Y + padding);

            // Y marjini güncelle
            yMargin += kisiBilgileriBox.Height + 20; // Kutudan sonra boşluk

            // Kişi Bilgileri içeriği
            e.Graphics.DrawString("Sahip:", regularFont, Brushes.Black, xMargin + padding, yMargin);
            e.Graphics.DrawString($"{sahipText.Text}", regularFont, Brushes.Black, xMargin + 70, yMargin);

            yMargin += lineHeight;
            e.Graphics.DrawString("Tarih:", regularFont, Brushes.Black, xMargin + padding, yMargin);
            e.Graphics.DrawString($"{tarihTimerPicker.Value.ToShortDateString()}", regularFont, Brushes.Black, xMargin + 70, yMargin);

            yMargin += lineHeight + 30; // İçerik sonrası boşluk

            // 3. Ürün Bilgileri kutusu
            string urunBilgileriBaslik = "Ürün Bilgileri";
            SizeF urunBilgileriSize = e.Graphics.MeasureString(urunBilgileriBaslik, headerFont);
            RectangleF urunBilgileriBox = new RectangleF(xMargin, yMargin, boxWidth, urunBilgileriSize.Height + padding * 2);
            e.Graphics.DrawRectangle(Pens.Black, urunBilgileriBox.X, urunBilgileriBox.Y, urunBilgileriBox.Width, urunBilgileriBox.Height);
            e.Graphics.DrawString(urunBilgileriBaslik, headerFont, Brushes.Black, urunBilgileriBox.X + (urunBilgileriBox.Width - urunBilgileriSize.Width) / 2, urunBilgileriBox.Y + padding);

            // Y marjini güncelle
            yMargin += urunBilgileriBox.Height + 20;

            // Ürün Bilgileri içeriği
            e.Graphics.DrawString("Ürün Adı:", regularFont, Brushes.Black, xMargin + padding, yMargin);
            e.Graphics.DrawString($"{urunadiText.Text}", regularFont, Brushes.Black, xMargin + 90, yMargin);

            yMargin += lineHeight;
            e.Graphics.DrawString("Ürün Miktarı:", regularFont, Brushes.Black, xMargin + padding, yMargin);
            e.Graphics.DrawString($"{urunmiktarıText.Text}", regularFont, Brushes.Black, xMargin + 110, yMargin);

            yMargin += lineHeight;
            e.Graphics.DrawString("Ürün Cinsi:", regularFont, Brushes.Black, xMargin + padding, yMargin);
            e.Graphics.DrawString($"{uruncinsiText.Text}", regularFont, Brushes.Black, xMargin + 100, yMargin);

            yMargin += lineHeight;
            e.Graphics.DrawString("Açıklama:", regularFont, Brushes.Black, xMargin + padding, yMargin);
            e.Graphics.DrawString($"{aciklamaTextBox.Text}", regularFont, Brushes.Black, xMargin + 90, yMargin);

            yMargin += lineHeight + 30; // İçerik sonrası boşluk

            // 4. Rota Bilgileri kutusu
            string rotaBilgileriBaslik = "Rota Bilgileri";
            SizeF rotaBilgileriSize = e.Graphics.MeasureString(rotaBilgileriBaslik, headerFont);
            RectangleF rotaBilgileriBox = new RectangleF(xMargin, yMargin, boxWidth, rotaBilgileriSize.Height + padding * 2);
            e.Graphics.DrawRectangle(Pens.Black, rotaBilgileriBox.X, rotaBilgileriBox.Y, rotaBilgileriBox.Width, rotaBilgileriBox.Height);
            e.Graphics.DrawString(rotaBilgileriBaslik, headerFont, Brushes.Black, rotaBilgileriBox.X + (rotaBilgileriBox.Width - rotaBilgileriSize.Width) / 2, rotaBilgileriBox.Y + padding);

            yMargin += rotaBilgileriBox.Height + 20;

            // Rotalar için ayrı ayrı kutular
            foreach (var rota in rotalarListesi)
            {
                RectangleF rotaRect = new RectangleF(xMargin, yMargin, boxWidth, lineHeight * 4);
                e.Graphics.DrawRectangle(Pens.Black, rotaRect.X, rotaRect.Y, rotaRect.Width, rotaRect.Height);

                // Rota adı ve açıklaması
                e.Graphics.DrawString($"Rota: {rota.RotaAdi}", regularFont, Brushes.Black, xMargin + padding, yMargin + padding);
                e.Graphics.DrawString($"Açıklama: {rota.RotaAciklama}", regularFont, Brushes.Black, xMargin + padding, yMargin + padding + lineHeight);

                yMargin += rotaRect.Height + 20; // Her rota kutusundan sonra boşluk
            }

            e.HasMorePages = false;
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