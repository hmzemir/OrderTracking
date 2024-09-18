using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace OrderTracking
{
    public partial class home : Form
    {
        // Dinamik kontrol setlerini takip etmek i�in saya�
        private int controlSetCount = 0;

        // Kontrol setleri aras�ndaki dikey bo�luk (piksel cinsinden)
        private int verticalSpacing = 20;

        // Panelin referans� (Designer'da panelin ad�n� kontrol edin)
        private Panel parentPanel;

        // Eklenen kontrol setlerini saklamak i�in liste
        private List<ControlSet> controlSets = new List<ControlSet>();

        // Maksimum kontrol seti say�s�
        private int maxControlSets;

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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Mevcut bo� metod
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DuplicateControlSet();
        }

        /// <summary>
        /// Yeni bir kontrol seti ekler. Panelin alt�na ula��ld���nda en eski seti kald�r�r ve yeni seti ekler.
        /// </summary>
        private void DuplicateControlSet()
        {
            // Kontrol setinin y�ksekli�ini hesapla
            int setHeight = numericUpDown1.Bottom - label27.Top;

            // Yeni kontrol seti i�in Y konumunu hesapla
            int newSetY;

            if (controlSets.Count == 0)
            {
                // �lk set i�in pozisyon
                newSetY = label27.Location.Y;
            }
            else
            {
                // Son eklenen setin konumunu al
                ControlSet lastSet = controlSets[controlSets.Count - 1];
                // Yeni setin Y pozisyonu: son setin panelinin alt�na verticalSpacing ekleyerek
                newSetY = lastSet.ControlSetPanel.Location.Y + lastSet.ControlSetPanel.Height + verticalSpacing;
            }

            // E�er yeni setin alt� panelin y�ksekli�ini a�arsa, en eski seti kald�r ve yeni seti alt�na ekle
            if (newSetY + setHeight > parentPanel.Height)
            {
                if (controlSets.Count > 0)
                {
                    // En eski seti al
                    ControlSet firstSet = controlSets[0];

                    // Panelden kald�r
                    parentPanel.Controls.Remove(firstSet.ControlSetPanel);

                    // Listenin ba��ndan sil
                    controlSets.RemoveAt(0);

                    // Yeni setin Y pozisyonunu son setin alt�na ayarla
                    if (controlSets.Count > 0)
                    {
                        ControlSet lastSet = controlSets[controlSets.Count - 1];
                        newSetY = lastSet.ControlSetPanel.Location.Y + lastSet.ControlSetPanel.Height + verticalSpacing;
                    }
                    else
                    {
                        // E�er t�m setler silindiyse, ilk setin Y pozisyonunu kullan
                        newSetY = label27.Location.Y;
                    }

                    // ControlSetCount'� azalt
                    controlSetCount--;
                }
            }

            // Yeni Panel olu�turma (Kontrol Seti i�in)
            Panel controlSetPanel = new Panel();
            controlSetPanel.Name = "controlSetPanel_" + controlSetCount;
            controlSetPanel.Size = new Size(parentPanel.Width - 25, setHeight); // Geni�li�i panel geni�li�ine g�re ayarlay�n
            controlSetPanel.Location = new Point(0, newSetY);
            controlSetPanel.BorderStyle = BorderStyle.None; // �ste�e ba�l� olarak �er�eve ekleyebilirsiniz

            // **Yeni Label27 Olu�turma**
            Label newLabel27 = new Label();
            newLabel27.Name = "label27_" + controlSetCount;
            newLabel27.Text = label27.Text;
            newLabel27.Location = new Point(label27.Location.X, 0); // Panel i�indeki konum
            newLabel27.Size = label27.Size;
            newLabel27.AutoSize = label27.AutoSize;

            // **Yeni RichTextBox1 Olu�turma**
            RichTextBox newRichTextBox1 = new RichTextBox();
            newRichTextBox1.Name = "richTextBox1_" + controlSetCount;
            newRichTextBox1.Location = new Point(richTextBox1.Location.X, newLabel27.Bottom + 5); // 5 piksel alt bo�luk
            newRichTextBox1.Size = richTextBox1.Size;
            newRichTextBox1.Text = ""; // Yeni eklenen kutuya varsay�lan bo� de�er

            // **Yeni Label12 Olu�turma**
            Label newLabel12 = new Label();
            newLabel12.Name = "label12_" + controlSetCount;
            newLabel12.Text = label12.Text;
            newLabel12.Location = new Point(label12.Location.X, newLabel27.Bottom + 5); // RichTextBox1'in alt�na
            newLabel12.Size = label12.Size;
            newLabel12.AutoSize = label12.AutoSize;

            // **Yeni NumericUpDown1 Olu�turma**
            NumericUpDown newNumericUpDown1 = new NumericUpDown();
            newNumericUpDown1.Name = "numericUpDown1_" + controlSetCount;
            newNumericUpDown1.Location = new Point(numericUpDown1.Location.X, newLabel27.Bottom + 5); // RichTextBox1'in alt�na
            newNumericUpDown1.Size = numericUpDown1.Size;
            newNumericUpDown1.Minimum = numericUpDown1.Minimum;
            newNumericUpDown1.Maximum = numericUpDown1.Maximum;
            newNumericUpDown1.Value = numericUpDown1.Value; // �ste�e ba�l� olarak de�eri kopyalayabilirsiniz

            // **Kontrolleri Yeni Panel'e Eklemek**
            controlSetPanel.Controls.Add(newLabel27);
            controlSetPanel.Controls.Add(newRichTextBox1);
            controlSetPanel.Controls.Add(newLabel12);
            controlSetPanel.Controls.Add(newNumericUpDown1);

            // **Yeni Paneli Ana Panel'e Eklemek**
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

            // Saya� art�rma
            controlSetCount++;

            // Yerle�imi g�ncelle
            parentPanel.Refresh();
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
