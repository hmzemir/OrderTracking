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

        // Maksimum kontrol seti say�s�
        private int maxControlSets;

        // Kontrol setleri aras�ndaki dikey bo�luk (piksel cinsinden)
        private int verticalSpacing = 20;

        // Panelin referans� (Designer'da panelin ad�n� kontrol edin)
        private Panel parentPanel;

        public home()
        {
            InitializeComponent();

            // Panelin ad�n� do�ru �ekilde belirtin. �rne�in, panel1 ise:
            parentPanel = this.panel1;

            // Butonun Click olay�n� ba�lama (E�er Designer �zerinden ba�lamad�ysan�z)
            button2.Click += button2_Click;

            // AutoScroll'u kapat�n
            parentPanel.AutoScroll = false;

            // Panelin i�ine ka� set s��abilece�ini hesapla
            CalculateMaxControlSets();

            // �ste�e ba�l�: Form yeniden boyutland�r�ld���nda i�lemi g�ncelle
            this.Resize += home_Resize;
        }

        /// <summary>
        /// Panelin i�ine ka� kontrol seti s��abilece�ini hesaplar.
        /// </summary>
        private void CalculateMaxControlSets()
        {
            // Her bir setin y�ksekli�ini hesapla
            int setHeight = numericUpDown1.Bottom - label27.Top;

            // Maksimum ka� set s��abilir
            maxControlSets = parentPanel.Height / (setHeight + verticalSpacing);

            // En az bir set s��abilmesi i�in kontrol
            if (maxControlSets < 1)
                maxControlSets = 1;
        }

        private void home_Resize(object sender, EventArgs e)
        {
            CalculateMaxControlSets();
            UpdateControlSets();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Mevcut bo� metod
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DuplicateControlSet();
        }

        /// <summary>
        /// Yeni bir kontrol seti ekler. Panel doluysa en eski seti kald�r�r ve yeni seti ekler.
        /// </summary>
        private void DuplicateControlSet()
        {
            // Kontrol setinin y�ksekli�ini hesapla
            int setHeight = numericUpDown1.Bottom - label27.Top;

            // Panelin dolu olup olmad���n� kontrol et
            if (controlSets.Count >= maxControlSets)
            {
                // En eski kontrol setini kald�r
                ControlSet firstSet = controlSets[0];
                parentPanel.Controls.Remove(firstSet.ControlSetPanel);
                controlSets.RemoveAt(0);
            }

            // Yeni Panel olu�turma (Kontrol Seti i�in)
            Panel controlSetPanel = new Panel();
            controlSetPanel.Size = new Size(parentPanel.Width - 25, setHeight); // Geni�li�i panel geni�li�ine g�re ayarlay�n
            controlSetPanel.BorderStyle = BorderStyle.None; // �ste�e ba�l� olarak �er�eve ekleyebilirsiniz

            // **Yeni Label27 (Rota Numaras�)**
            Label newLabel27 = new Label();
            newLabel27.Name = "label27_" + (controlSets.Count + 1);
            newLabel27.Text = "Rota " + (controlSets.Count + 1).ToString();
            newLabel27.Location = new Point(label27.Location.X, 0); // Panel i�indeki konum
            newLabel27.AutoSize = label27.AutoSize;

            // **Yeni RichTextBox1**
            RichTextBox newRichTextBox1 = new RichTextBox();
            newRichTextBox1.Name = "richTextBox1_" + (controlSets.Count + 1);
            newRichTextBox1.Location = new Point(richTextBox1.Location.X, newLabel27.Bottom + 5); // 5 piksel alt bo�luk
            newRichTextBox1.Size = richTextBox1.Size;
            newRichTextBox1.Text = ""; // Varsay�lan bo� de�er

            // **Yeni Label12**
            Label newLabel12 = new Label();
            newLabel12.Name = "label12_" + (controlSets.Count + 1);
            newLabel12.Text = label12.Text;
            newLabel12.Location = new Point(label12.Location.X, newRichTextBox1.Bottom + 5); // RichTextBox1'in alt�na
            newLabel12.AutoSize = label12.AutoSize;

            // **Yeni NumericUpDown1**
            NumericUpDown newNumericUpDown1 = new NumericUpDown();
            newNumericUpDown1.Name = "numericUpDown1_" + (controlSets.Count + 1);
            newNumericUpDown1.Location = new Point(numericUpDown1.Location.X, newLabel12.Bottom + 5); // Label12'nin alt�na
            newNumericUpDown1.Size = numericUpDown1.Size;
            newNumericUpDown1.Minimum = numericUpDown1.Minimum;
            newNumericUpDown1.Maximum = numericUpDown1.Maximum;
            newNumericUpDown1.Value = numericUpDown1.Value; // �ste�e ba�l� olarak de�eri kopyalayabilirsiniz

            // Kontrolleri Yeni Panel'e Eklemek
            controlSetPanel.Controls.Add(newLabel27);
            controlSetPanel.Controls.Add(newRichTextBox1);
            controlSetPanel.Controls.Add(newLabel12);
            controlSetPanel.Controls.Add(newNumericUpDown1);

            // Yeni Paneli Ana Panel'e Eklemek
            parentPanel.Controls.Add(controlSetPanel);

            // Kontrol setlerini takip etmek i�in listeye ekleme
            controlSets.Add(new ControlSet
            {
                Label27 = newLabel27,
                RichTextBox1 = newRichTextBox1,
                Label12 = newLabel12,
                NumericUpDown1 = newNumericUpDown1,
                ControlSetPanel = controlSetPanel
            });

            // Numaraland�rma ve yerle�imi g�ncelle
            UpdateControlSets();
        }

        /// <summary>
        /// T�m kontrol setlerinin numaralar�n� ve konumlar�n� g�nceller.
        /// </summary>
        private void UpdateControlSets()
        {
            for (int i = 0; i < controlSets.Count; i++)
            {
                ControlSet set = controlSets[i];

                // Rota numaras�n� g�ncelle
                set.Label27.Text = "Rota " + (i + 1).ToString();

                // Y konumunu g�ncelle
                set.ControlSetPanel.Location = new Point(0, i * (set.ControlSetPanel.Height + verticalSpacing));
            }
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
        /// Veritaban�na kaydetme i�lemleri i�in �rnek metod (Hen�z uygulanmam��)
        /// </summary>
        private void SaveDataToDatabase()
        {
            foreach (var set in controlSets)
            {
                string label27Text = set.Label27.Text;
                string richTextBox1Text = set.RichTextBox1.Text;
                string label12Text = set.Label12.Text;
                decimal numericUpDown1Value = set.NumericUpDown1.Value;

                // Burada veritaban�na ekleme i�lemi yap�lacak
                // �rne�in:
                // string query = "INSERT INTO YourTable (Label27, RichTextBox1, Label12, NumericUpDown1) VALUES (@Label27, @RichTextBox1, @Label12, @NumericUpDown1)";
                // Parametreleri ekleyin ve komutu �al��t�r�n
            }
        }
    }
}
