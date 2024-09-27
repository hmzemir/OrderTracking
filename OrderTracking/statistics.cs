using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OrderTracking
{
    public partial class statistics : Form
    {
        private int userAdminLevel; // Kullanıcı admin seviyesini tanımladık.

        public statistics()
        {
            InitializeComponent();
            userAdminLevel = GetUserAdminLevel(); // Admin seviyesini form oluşturulduğunda al
        }

        private void anaSayfaToolStripMenuItem_Click(object sender, EventArgs e)
            => ShowForm(new home(userAdminLevel)); // Ana sayfa yönlendirme

        private void onaylananTekliflerToolStripMenuItem_Click(object sender, EventArgs e)
            => ShowForm(new orders()); // Onaylanan teklifler yönlendirme

        private void teklifOnaylaToolStripMenuItem_Click(object sender, EventArgs e)
            => PerformAdminAction(new tickets()); // Teklif onaylama yönlendirme

        private void kullanıcıEkleToolStripMenuItem_Click(object sender, EventArgs e)
            => PerformAdminAction(new addUser()); // Kullanıcı ekleme yönlendirme

        private void yedeklemeToolStripMenuItem_Click(object sender, EventArgs e)
            => ShowForm(new databaseSave()); // Yedekleme yönlendirme

        private void yetkiVerToolStripMenuItem_Click(object sender, EventArgs e)
            => PerformAdminAction(new authority()); // Yetki verme yönlendirme

        private void PerformAdminAction(Form form)
        {
            // Kullanıcı yetkisini kontrol et
            if (userAdminLevel != 1) // Yetkisi yoksa
            {
                MessageBox.Show("Bu işlemi gerçekleştirmek için yetkiniz yok.");
                return; // İşlemi durdur
            }
            // Yetkisi varsa formu göster
            ShowForm(form);
        }

        private void ShowForm(Form form)
        {
            try
            {
                this.Hide(); // Mevcut formu gizle
                form.Show(); // Yeni formu göster
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

        private void statistics_Load(object sender, EventArgs e)
        {
            // DataGridView'e sütunları ekleme
            verilerTablo.Columns.Clear(); // Önce var olan sütunları temizleyin
            verilerTablo.Columns.Add("Id", "ID");
            verilerTablo.Columns.Add("Sahip", "Sahip");
            verilerTablo.Columns.Add("Tarih", "Tarih");
            verilerTablo.Columns.Add("UrunAdi", "Ürün Adı");
            verilerTablo.Columns.Add("UrunMiktari", "Ürün Miktarı");
            verilerTablo.Columns.Add("UrunCinsi", "Ürün Cinsi");
            verilerTablo.Columns.Add("Aciklama", "Açıklama");
            verilerTablo.Columns.Add("Kar", "Kar");
            verilerTablo.Columns.Add("SiparisOnay", "Sipariş Onay");

            // Başlangıçta boş bir veri seti ile başlatabilirsiniz
            verilerTablo.Rows.Clear();

            // Tarih ve arama kısımlarını başlangıçta pasif yap
            tarihBaslangıc.Enabled = false;
            tarihBitis.Enabled = false;
            aramaText.Enabled = false;
        }

        private void tarihSec_CheckedChanged(object sender, EventArgs e)
        {
            tarihBaslangıc.Enabled = tarihSec.Checked;
            tarihBitis.Enabled = tarihSec.Checked;
        }

        private void isimAra_CheckedChanged(object sender, EventArgs e)
        {
            aramaText.Enabled = isimAra.Checked;
        }

        private void arabtn_Click(object sender, EventArgs e)
        {
            // Seçimlerin kontrolü
            if (!tarihSec.Checked && !isimAra.Checked)
            {
                MessageBox.Show("Lütfen en az bir filtre seçin.");
                return;
            }

            // SQL sorguları ve veri çekme işlemleri
            DateTime? baslangicTarihi = tarihSec.Checked ? (DateTime?)tarihBaslangıc.Value : null;
            DateTime? bitisTarihi = tarihSec.Checked ? (DateTime?)tarihBitis.Value : null;
            string isim = isimAra.Checked ? aramaText.Text.Trim() : null; // Boşlukları temizle
            bool sadeceOnayli = sadeceOnayCheck.Checked;

            // Verileri çekin ve tabloya ekleyin
            var siparisler = GetSiparisler(baslangicTarihi, bitisTarihi, isim, sadeceOnayli);
            VerileriTabloyaEkle(siparisler);
        }

        private List<Siparis> GetSiparisler(DateTime? baslangic, DateTime? bitis, string isim, bool sadeceOnayli)
        {
            List<Siparis> siparisler = new List<Siparis>();

            using (SqlConnection conn = new SqlConnection("Data Source=TETrA\\SQLEXPRESS;Initial Catalog=orderTracking;Integrated Security=True;Encrypt=False;"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Siparisler WHERE 1=1", conn);

                if (baslangic.HasValue)
                {
                    cmd.CommandText += " AND tarih >= @Baslangic";
                    cmd.Parameters.AddWithValue("@Baslangic", baslangic.Value);
                }

                if (bitis.HasValue)
                {
                    cmd.CommandText += " AND tarih <= @Bitis";
                    cmd.Parameters.AddWithValue("@Bitis", bitis.Value);
                }

                if (!string.IsNullOrEmpty(isim))
                {
                    cmd.CommandText += " AND sahip LIKE @Isim";
                    cmd.Parameters.AddWithValue("@Isim", "%" + isim + "%");
                }

                // Siparişin onaylı olup olmadığını kontrol et
                if (sadeceOnayli)
                {
                    cmd.CommandText += " AND siparis_onay = 1"; // Sadece onaylı siparişleri al
                }

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        siparisler.Add(new Siparis
                        {
                            Id = reader["id"] != DBNull.Value ? (int)reader["id"] : 0,
                            Sahip = reader["sahip"] != DBNull.Value ? reader["sahip"].ToString() : string.Empty,
                            Tarih = reader["tarih"] != DBNull.Value ? (DateTime)reader["tarih"] : DateTime.MinValue,
                            UrunAdi = reader["urun_adi"] != DBNull.Value ? reader["urun_adi"].ToString() : string.Empty,
                            UrunMiktari = reader["urun_miktari"] != DBNull.Value ? (int)reader["urun_miktari"] : 0,
                            UrunCinsi = reader["urun_cinsi"] != DBNull.Value ? reader["urun_cinsi"].ToString() : string.Empty,
                            Aciklama = reader["aciklama"] != DBNull.Value ? reader["aciklama"].ToString() : string.Empty,
                            Kar = reader["kar"] != DBNull.Value ? Convert.ToDecimal(reader["kar"]) : 0m, // decimal dönüşümü
                            SiparisOnay = reader["siparis_onay"] != DBNull.Value ? (bool)reader["siparis_onay"] : false
                        });
                    }
                }
            }

            return siparisler;
        }


        private void VerileriTabloyaEkle(List<Siparis> siparisler)
        {
            verilerTablo.Rows.Clear();
            decimal toplamUrun = 0;
            decimal toplamTutar = 0;
            int toplamSiparis = 0;

            foreach (var siparis in siparisler)
            {
                // DataGridView'e satır ekleme
                verilerTablo.Rows.Add(siparis.Id, siparis.Sahip, siparis.UrunMiktari, siparis.SiparisOnay); // 'Isim' yerine 'Sahip' kullanıldı

                // Toplam ürün miktarını hesaplama
                toplamUrun += siparis.UrunMiktari;
                toplamSiparis++;

                // Rotalar tablosundaki sipariş ID'ye göre toplam ücretleri hesaplama
                decimal rotaUcreti = GetRotaUcreti(siparis.Id);
                decimal karYuzdesi = siparis.Kar * rotaUcreti / 100;
                decimal sonFiyat = rotaUcreti + karYuzdesi;
                sonFiyat *= 1.20m; // %20 ekleme

                toplamTutar += sonFiyat;
            }

            // Label'lara yazdırma
            toplamUrunText.Text = toplamUrun.ToString();
            toplamSiparisText.Text = toplamSiparis.ToString();
            toplamTutarText.Text = toplamTutar.ToString("C2"); // Para formatında gösterme
        }

        private decimal GetRotaUcreti(int siparisId)
        {
            // Rota ücretini veritabanından çekme işlemleri
            // Örnek olarak sabit bir değer döndürülmekte
            return 100; // Örnek değer
        }

        public class Siparis
        {
            public int Id { get; set; }
            public string Sahip { get; set; }
            public DateTime Tarih { get; set; }
            public string UrunAdi { get; set; }
            public int UrunMiktari { get; set; }
            public string UrunCinsi { get; set; }
            public string Aciklama { get; set; }
            public decimal Kar { get; set; }
            public bool SiparisOnay { get; set; }
        }
    }
}
