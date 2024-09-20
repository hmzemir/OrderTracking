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
    public partial class addUser : Form
    {
        public addUser()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            // Rastgele şifre oluşturmak için kullanılacak karakterler
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();

            // Şifrenin uzunluğunu belirle
            int passwordLength = 4;  // Örneğin, 8 karakterlik bir şifre

            // Şifreyi oluşturmak için StringBuilder kullan
            char[] password = new char[passwordLength];

            for (int i = 0; i < passwordLength; i++)
            {
                // Rastgele bir karakter seç ve şifreye ekle
                password[i] = chars[random.Next(chars.Length)];
            }

            // Şifreyi TextBox2'ye yazdır
            textBox2.Text = new string(password);
        }

    }
}
