using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace OrderTracking
{
    public partial class orders : Form
    {
        private string connectionString = "Data Source=TETrA\\SQLEXPRESS;Initial Catalog=orderTracking;Integrated Security=True;Encrypt=False;";

        public orders()
        {
            InitializeComponent();
            LoadOrders(); // Siparişleri yükle
        }

        private void LoadOrders()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Siparisler";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;

                    // DataGridView'de satırların arka plan rengini ayarlayın
                    foreach (DataRow row in dataTable.Rows)
                    {
                        int onayDurumu = Convert.ToInt32(row["siparis_onay"]);
                        int rowIndex = dataTable.Rows.IndexOf(row);
                        dataGridView1.Rows[rowIndex].DefaultCellStyle.BackColor = (onayDurumu == 1)
                            ? Color.LightGreen // Onaylananlar için açık yeşil
                            : Color.LightCoral; // Onaylanmayanlar için açık kırmızı
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri yüklenirken bir hata oluştu: " + ex.Message);
            }
        }

        private void orders_Load(object sender, EventArgs e)
        {
            // Form yüklendiğinde yapılacak işlemler
        }

        private void anaSayfaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                int userAdminLevel = GetUserAdminLevel(); // Bu yöntemi, admin seviyesini alacak şekilde tanımlayın
                home homeForm = new home(userAdminLevel); // adminLevel değerini geçin
                homeForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        private int GetUserAdminLevel()
        {
            // Burada admin seviyesini almak için gereken mantığı yazın
            return 1; // Örneğin 1 döndürdük
        }

        private void teklifOnaylaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
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
                this.Hide();
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
                databaseSave dataForm = new databaseSave();
                dataForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // TextBox içindeki kelimeye göre filtreleme yap
            string filterText = textBox1.Text.ToLower();
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"sahip LIKE '%{filterText}%'";
        }

        private void yazdırbtn_Click(object sender, EventArgs e)
        {
            // Seçili satırı kontrol edelim
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen bir sipariş seçin.");
                return;
            }

            // Seçili siparişi alalım
            var selectedRow = dataGridView1.SelectedRows[0];
            Siparis selectedSiparis = new Siparis
            {
                Sahip = selectedRow.Cells["sahip"].Value.ToString(),
                Tarih = Convert.ToDateTime(selectedRow.Cells["tarih"].Value),
                UrunAdi = selectedRow.Cells["urun_adi"].Value.ToString(),
                UrunMiktari = Convert.ToInt32(selectedRow.Cells["urun_miktari"].Value),
                UrunCinsi = selectedRow.Cells["urun_cinsi"].Value.ToString(),
                Aciklama = selectedRow.Cells["aciklama"].Value.ToString()
            };

            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += (s, args) => PrintPage(args, selectedSiparis); // Seçilen siparişi geçiriyoruz

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        private void PrintPage(PrintPageEventArgs e, Siparis siparis)
        {
            // Yazdırılacak içerik
            Font headerFont = new Font("Arial", 16, FontStyle.Bold);
            Font regularFont = new Font("Arial", 12);
            float pageWidth = e.MarginBounds.Width;
            float boxWidth = 500;
            float xMargin = (pageWidth - boxWidth) / 2;
            float lineHeight = regularFont.GetHeight(e.Graphics) + 10;
            float yMargin = 50;

            // Başlık
            e.Graphics.DrawString("SİPARİŞ BİLGİLERİ", headerFont, Brushes.Black, xMargin, yMargin);

            // Sipariş Bilgileri
            yMargin += lineHeight + 10;
            e.Graphics.DrawString($"Sahip: {siparis.Sahip}", regularFont, Brushes.Black, xMargin, yMargin);
            e.Graphics.DrawString($"Tarih: {siparis.Tarih}", regularFont, Brushes.Black, xMargin, yMargin + lineHeight);
            e.Graphics.DrawString($"Ürün Adı: {siparis.UrunAdi}", regularFont, Brushes.Black, xMargin, yMargin + lineHeight * 2);
            e.Graphics.DrawString($"Ürün Miktarı: {siparis.UrunMiktari}", regularFont, Brushes.Black, xMargin, yMargin + lineHeight * 3);
            e.Graphics.DrawString($"Ürün Cinsi: {siparis.UrunCinsi}", regularFont, Brushes.Black, xMargin, yMargin + lineHeight * 4);
            e.Graphics.DrawString($"Açıklama: {siparis.Aciklama}", regularFont, Brushes.Black, xMargin, yMargin + lineHeight * 5);
        }
    }

    public class Siparis
    {
        public string Sahip { get; set; }
        public DateTime Tarih { get; set; }
        public string UrunAdi { get; set; }
        public int UrunMiktari { get; set; }
        public string UrunCinsi { get; set; }
        public string Aciklama { get; set; }
    }
}
