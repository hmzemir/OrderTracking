using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace OrderTracking
{
    public partial class home : Form
    {
        // Kontrol setlerini saklamak için liste
        private List<ControlSet> controlSets = new List<ControlSet>();

        // Kontrol setleri arasýndaki dikey boþluk (piksel cinsinden)
        private int verticalSpacing = 20;

        // Panelin referansý (Designer'da panelin adýný kontrol edin)
        private Panel parentPanel;

        public home()
        {
            InitializeComponent();

            // Panelin adýný doðru þekilde belirtin. Örneðin, panel1 ise:
            parentPanel = this.panel1;



            // AutoScroll'u kapatýn
            parentPanel.AutoScroll = false;

            // Ýsteðe baðlý: Form yeniden boyutlandýrýldýðýnda iþlemi güncelle
            this.Resize += home_Resize;
        }

        /// <summary>
        /// Form yeniden boyutlandýrýldýðýnda kontrol setlerinin düzenini günceller.
        /// </summary>
        private void home_Resize(object sender, EventArgs e)
        {
            // Boþ býrakýldý veya UpdateControlSets çaðrýlabilir
            UpdateControlSets();
        }

        /// <summary>
        /// comboBox2'nin seçimi deðiþtiðinde tetiklenen olay.
        /// </summary>
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Boþ býrakýldý.
        }

        /// <summary>
        /// button2'nin Click olayý tetiklendiðinde çaðrýlýr.
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            // Boþ býrakýldý veya DuplicateControlSet çaðrýlabilir
            // DuplicateControlSet();
        }

        /// <summary>
        /// Yeni bir kontrol seti ekler. Panel doluysa en eski seti kaldýrýr ve yeni seti ekler.
        /// </summary>
        private void DuplicateControlSet()
        {
            // Boþ býrakýldý veya mevcut mantýðýnýzý koruyabilirsiniz.
        }

        /// <summary>
        /// Tüm kontrol setlerinin numaralarýný ve konumlarýný günceller.
        /// </summary>
        private void UpdateControlSets()
        {
            // Boþ býrakýldý veya mevcut mantýðýnýzý koruyabilirsiniz.
        }

        /// <summary>
        /// Kontrol setlerini temsil eden sýnýf
        /// </summary>
        private class ControlSet
        {
            public Label Label27 { get; set; }
            public RichTextBox RichTextBox1 { get; set; }
            public Label Label12 { get; set; }
            public NumericUpDown NumericUpDown1 { get; set; }
            public Panel ControlSetPanel { get; set; }
        }

        /// <summary>
        /// Veritabanýna kaydetme iþlemleri için temel metod (Sadece RichTextBox verilerini kaydeder)
        /// </summary>
        private void SaveDataToDatabase()
        {
            // Boþ býrakýldý veya mevcut mantýðýnýzý koruyabilirsiniz.
        }

        private void anaSayfaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Mevcut formu kapat
                this.Hide();

                // Yeni tickets formunu aç
                home homeForm = new home();
                homeForm.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluþtu: " + ex.Message);
            }
        }

        private void onaylananTekliflerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Mevcut formu kapat
                this.Hide();

                // Yeni tickets formunu aç
                orders orderForm = new orders();
                orderForm.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluþtu: " + ex.Message);
            }
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
                MessageBox.Show("Bir hata oluþtu: " + ex.Message);
            }
        }

        private void kullanýcýEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                // Yeni tickets formunu aç
                addUser adduserForm = new addUser();
                adduserForm.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluþtu: " + ex.Message);
            }
        }

        private void yedeklemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                // Yeni tickets formunu aç
                databaseSave dataForm = new databaseSave();
                dataForm.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluþtu: " + ex.Message);
            }
        }
    }
}
