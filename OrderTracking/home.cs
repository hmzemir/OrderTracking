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

        // Maksimum kontrol seti sayýsý
        private int maxControlSets;

        // Kontrol setleri arasýndaki dikey boþluk (piksel cinsinden)
        private int verticalSpacing = 20;

        // Panelin referansý (Designer'da panelin adýný kontrol edin)
        private Panel parentPanel;

        public home()
        {
            InitializeComponent();

            // Panelin adýný doðru þekilde belirtin. Örneðin, panel1 ise:
            parentPanel = this.panel1;

            // Butonun Click olayýný baðlama (Eðer Designer üzerinden baðlamadýysanýz)
            button2.Click += button2_Click;

            // AutoScroll'u kapatýn
            parentPanel.AutoScroll = false;

            // Panelin içine kaç set sýðabileceðini hesapla
            CalculateMaxControlSets();

            // Ýsteðe baðlý: Form yeniden boyutlandýrýldýðýnda iþlemi güncelle
            this.Resize += home_Resize;
        }

        /// <summary>
        /// Panelin içine kaç kontrol seti sýðabileceðini hesaplar.
        /// </summary>
        private void CalculateMaxControlSets()
        {
            // Her bir setin yüksekliðini hesapla
            int setHeight = numericUpDown1.Bottom - label27.Top;

            // Maksimum kaç set sýðabilir
            maxControlSets = parentPanel.Height / (setHeight + verticalSpacing);

            // En az bir set sýðabilmesi için kontrol
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
            // Mevcut boþ metod
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DuplicateControlSet();
        }

        /// <summary>
        /// Yeni bir kontrol seti ekler. Panel doluysa en eski seti kaldýrýr ve yeni seti ekler.
        /// </summary>
        private void DuplicateControlSet()
        {
            // Kontrol setinin yüksekliðini hesapla
            int setHeight = numericUpDown1.Bottom - label27.Top;

            // Panelin dolu olup olmadýðýný kontrol et
            if (controlSets.Count >= maxControlSets)
            {
                // En eski kontrol setini kaldýr
                ControlSet firstSet = controlSets[0];
                parentPanel.Controls.Remove(firstSet.ControlSetPanel);
                controlSets.RemoveAt(0);
            }

            // Yeni Panel oluþturma (Kontrol Seti için)
            Panel controlSetPanel = new Panel();
            controlSetPanel.Size = new Size(parentPanel.Width - 25, setHeight); // Geniþliði panel geniþliðine göre ayarlayýn
            controlSetPanel.BorderStyle = BorderStyle.None; // Ýsteðe baðlý olarak çerçeve ekleyebilirsiniz

            // **Yeni Label27 (Rota Numarasý)**
            Label newLabel27 = new Label();
            newLabel27.Name = "label27_" + (controlSets.Count + 1);
            newLabel27.Text = "Rota " + (controlSets.Count + 1).ToString();
            newLabel27.Location = new Point(label27.Location.X, 0); // Panel içindeki konum
            newLabel27.AutoSize = label27.AutoSize;

            // **Yeni RichTextBox1**
            RichTextBox newRichTextBox1 = new RichTextBox();
            newRichTextBox1.Name = "richTextBox1_" + (controlSets.Count + 1);
            newRichTextBox1.Location = new Point(richTextBox1.Location.X, newLabel27.Bottom + 5); // 5 piksel alt boþluk
            newRichTextBox1.Size = richTextBox1.Size;
            newRichTextBox1.Text = ""; // Varsayýlan boþ deðer

            // **Yeni Label12**
            Label newLabel12 = new Label();
            newLabel12.Name = "label12_" + (controlSets.Count + 1);
            newLabel12.Text = label12.Text;
            newLabel12.Location = new Point(label12.Location.X, newRichTextBox1.Bottom + 5); // RichTextBox1'in altýna
            newLabel12.AutoSize = label12.AutoSize;

            // **Yeni NumericUpDown1**
            NumericUpDown newNumericUpDown1 = new NumericUpDown();
            newNumericUpDown1.Name = "numericUpDown1_" + (controlSets.Count + 1);
            newNumericUpDown1.Location = new Point(numericUpDown1.Location.X, newLabel12.Bottom + 5); // Label12'nin altýna
            newNumericUpDown1.Size = numericUpDown1.Size;
            newNumericUpDown1.Minimum = numericUpDown1.Minimum;
            newNumericUpDown1.Maximum = numericUpDown1.Maximum;
            newNumericUpDown1.Value = numericUpDown1.Value; // Ýsteðe baðlý olarak deðeri kopyalayabilirsiniz

            // Kontrolleri Yeni Panel'e Eklemek
            controlSetPanel.Controls.Add(newLabel27);
            controlSetPanel.Controls.Add(newRichTextBox1);
            controlSetPanel.Controls.Add(newLabel12);
            controlSetPanel.Controls.Add(newNumericUpDown1);

            // Yeni Paneli Ana Panel'e Eklemek
            parentPanel.Controls.Add(controlSetPanel);

            // Kontrol setlerini takip etmek için listeye ekleme
            controlSets.Add(new ControlSet
            {
                Label27 = newLabel27,
                RichTextBox1 = newRichTextBox1,
                Label12 = newLabel12,
                NumericUpDown1 = newNumericUpDown1,
                ControlSetPanel = controlSetPanel
            });

            // Numaralandýrma ve yerleþimi güncelle
            UpdateControlSets();
        }

        /// <summary>
        /// Tüm kontrol setlerinin numaralarýný ve konumlarýný günceller.
        /// </summary>
        private void UpdateControlSets()
        {
            for (int i = 0; i < controlSets.Count; i++)
            {
                ControlSet set = controlSets[i];

                // Rota numarasýný güncelle
                set.Label27.Text = "Rota " + (i + 1).ToString();

                // Y konumunu güncelle
                set.ControlSetPanel.Location = new Point(0, i * (set.ControlSetPanel.Height + verticalSpacing));
            }
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
        /// Veritabanýna kaydetme iþlemleri için örnek metod (Henüz uygulanmamýþ)
        /// </summary>
        private void SaveDataToDatabase()
        {
            foreach (var set in controlSets)
            {
                string label27Text = set.Label27.Text;
                string richTextBox1Text = set.RichTextBox1.Text;
                string label12Text = set.Label12.Text;
                decimal numericUpDown1Value = set.NumericUpDown1.Value;

                // Burada veritabanýna ekleme iþlemi yapýlacak
                // Örneðin:
                // string query = "INSERT INTO YourTable (Label27, RichTextBox1, Label12, NumericUpDown1) VALUES (@Label27, @RichTextBox1, @Label12, @NumericUpDown1)";
                // Parametreleri ekleyin ve komutu çalýþtýrýn
            }
        }
    }
}
