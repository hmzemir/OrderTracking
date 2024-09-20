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
    public partial class orders : Form
    {
        public orders()
        {
            InitializeComponent();
        }







        private void anaSayfaToolStripMenuItem_Click_1(object sender, EventArgs e)
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
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
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
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
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
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        private void kullanıcıEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                // Yeni tickets formunu aç
                addUser adduserForm = new addUser();
                adduserForm.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }
    }
}
