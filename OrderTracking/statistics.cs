using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        }
    }
}
