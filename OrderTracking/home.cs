using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace OrderTracking
{
    public partial class home : Form
    {
        // Kontrol setlerini saklamak i�in liste
        private List<ControlSet> controlSets = new List<ControlSet>();

        // Kontrol setleri aras�ndaki dikey bo�luk (piksel cinsinden)
        private int verticalSpacing = 20;

        // Panelin referans� (Designer'da panelin ad�n� kontrol edin)
        private Panel parentPanel;

        public home()
        {
            InitializeComponent();

            // Panelin ad�n� do�ru �ekilde belirtin. �rne�in, panel1 ise:
            parentPanel = this.panel1;



            // AutoScroll'u kapat�n
            parentPanel.AutoScroll = false;

            // �ste�e ba�l�: Form yeniden boyutland�r�ld���nda i�lemi g�ncelle
            this.Resize += home_Resize;
        }

        /// <summary>
        /// Form yeniden boyutland�r�ld���nda kontrol setlerinin d�zenini g�nceller.
        /// </summary>
        private void home_Resize(object sender, EventArgs e)
        {
            // Bo� b�rak�ld� veya UpdateControlSets �a�r�labilir
            UpdateControlSets();
        }

        /// <summary>
        /// comboBox2'nin se�imi de�i�ti�inde tetiklenen olay.
        /// </summary>
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Bo� b�rak�ld�.
        }

        /// <summary>
        /// button2'nin Click olay� tetiklendi�inde �a�r�l�r.
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            // Bo� b�rak�ld� veya DuplicateControlSet �a�r�labilir
            // DuplicateControlSet();
        }

        /// <summary>
        /// Yeni bir kontrol seti ekler. Panel doluysa en eski seti kald�r�r ve yeni seti ekler.
        /// </summary>
        private void DuplicateControlSet()
        {
            // Bo� b�rak�ld� veya mevcut mant���n�z� koruyabilirsiniz.
        }

        /// <summary>
        /// T�m kontrol setlerinin numaralar�n� ve konumlar�n� g�nceller.
        /// </summary>
        private void UpdateControlSets()
        {
            // Bo� b�rak�ld� veya mevcut mant���n�z� koruyabilirsiniz.
        }

        /// <summary>
        /// Kontrol setlerini temsil eden s�n�f
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
        /// Veritaban�na kaydetme i�lemleri i�in temel metod (Sadece RichTextBox verilerini kaydeder)
        /// </summary>
        private void SaveDataToDatabase()
        {
            // Bo� b�rak�ld� veya mevcut mant���n�z� koruyabilirsiniz.
        }

        private void anaSayfaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Mevcut formu kapat
                this.Hide();

                // Yeni tickets formunu a�
                home homeForm = new home();
                homeForm.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata olu�tu: " + ex.Message);
            }
        }

        private void onaylananTekliflerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Mevcut formu kapat
                this.Hide();

                // Yeni tickets formunu a�
                orders orderForm = new orders();
                orderForm.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata olu�tu: " + ex.Message);
            }
        }

        private void teklifOnaylaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Mevcut formu kapat
                this.Hide();

                // Yeni tickets formunu a�
                tickets ticketForm = new tickets();
                ticketForm.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata olu�tu: " + ex.Message);
            }
        }

        private void kullan�c�EkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                // Yeni tickets formunu a�
                addUser adduserForm = new addUser();
                adduserForm.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata olu�tu: " + ex.Message);
            }
        }

        private void yedeklemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                // Yeni tickets formunu a�
                databaseSave dataForm = new databaseSave();
                dataForm.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata olu�tu: " + ex.Message);
            }
        }
    }
}
