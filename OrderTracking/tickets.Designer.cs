namespace OrderTracking
{
    partial class tickets
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            menuStrip1 = new MenuStrip();
            anaSayfaToolStripMenuItem = new ToolStripMenuItem();
            onaylananTekliflerToolStripMenuItem = new ToolStripMenuItem();
            teklifOnaylaToolStripMenuItem = new ToolStripMenuItem();
            yöneticiToolStripMenuItem = new ToolStripMenuItem();
            kullanıcıEkleToolStripMenuItem = new ToolStripMenuItem();
            istatistiklkerToolStripMenuItem = new ToolStripMenuItem();
            yedeklemeToolStripMenuItem = new ToolStripMenuItem();
            label34 = new Label();
            groupBox3 = new GroupBox();
            richTextBox1 = new RichTextBox();
            label6 = new Label();
            aciklamaTextBox = new RichTextBox();
            label7 = new Label();
            textBox4 = new TextBox();
            label5 = new Label();
            textBox3 = new TextBox();
            label4 = new Label();
            textBox2 = new TextBox();
            label1 = new Label();
            tarihTimerPicker = new DateTimePicker();
            textBox1 = new TextBox();
            label3 = new Label();
            label2 = new Label();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            menuStrip1.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(30, 102);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(600, 614);
            dataGridView1.TabIndex = 3;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { anaSayfaToolStripMenuItem, onaylananTekliflerToolStripMenuItem, teklifOnaylaToolStripMenuItem, yöneticiToolStripMenuItem, yedeklemeToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1904, 24);
            menuStrip1.TabIndex = 48;
            menuStrip1.Text = "menuStrip1";
            // 
            // anaSayfaToolStripMenuItem
            // 
            anaSayfaToolStripMenuItem.Name = "anaSayfaToolStripMenuItem";
            anaSayfaToolStripMenuItem.Size = new Size(71, 20);
            anaSayfaToolStripMenuItem.Text = "Ana Sayfa";
            anaSayfaToolStripMenuItem.Click += anaSayfaToolStripMenuItem_Click;
            // 
            // onaylananTekliflerToolStripMenuItem
            // 
            onaylananTekliflerToolStripMenuItem.Name = "onaylananTekliflerToolStripMenuItem";
            onaylananTekliflerToolStripMenuItem.Size = new Size(119, 20);
            onaylananTekliflerToolStripMenuItem.Text = "Onaylanan Teklifler";
            onaylananTekliflerToolStripMenuItem.Click += onaylananTekliflerToolStripMenuItem_Click;
            // 
            // teklifOnaylaToolStripMenuItem
            // 
            teklifOnaylaToolStripMenuItem.Name = "teklifOnaylaToolStripMenuItem";
            teklifOnaylaToolStripMenuItem.Size = new Size(86, 20);
            teklifOnaylaToolStripMenuItem.Text = "Teklif Onayla";
            teklifOnaylaToolStripMenuItem.Click += teklifOnaylaToolStripMenuItem_Click;
            // 
            // yöneticiToolStripMenuItem
            // 
            yöneticiToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { kullanıcıEkleToolStripMenuItem, istatistiklkerToolStripMenuItem });
            yöneticiToolStripMenuItem.Name = "yöneticiToolStripMenuItem";
            yöneticiToolStripMenuItem.Size = new Size(61, 20);
            yöneticiToolStripMenuItem.Text = "Yönetici";
            // 
            // kullanıcıEkleToolStripMenuItem
            // 
            kullanıcıEkleToolStripMenuItem.Name = "kullanıcıEkleToolStripMenuItem";
            kullanıcıEkleToolStripMenuItem.Size = new Size(143, 22);
            kullanıcıEkleToolStripMenuItem.Text = "Kullanıcı Ekle";
            // 
            // istatistiklkerToolStripMenuItem
            // 
            istatistiklkerToolStripMenuItem.Name = "istatistiklkerToolStripMenuItem";
            istatistiklkerToolStripMenuItem.Size = new Size(143, 22);
            istatistiklkerToolStripMenuItem.Text = "İstatistiklker";
            // 
            // yedeklemeToolStripMenuItem
            // 
            yedeklemeToolStripMenuItem.Name = "yedeklemeToolStripMenuItem";
            yedeklemeToolStripMenuItem.Size = new Size(76, 20);
            yedeklemeToolStripMenuItem.Text = "Yedekleme";
            // 
            // label34
            // 
            label34.AutoSize = true;
            label34.Font = new Font("Eras Demi ITC", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label34.Location = new Point(30, 54);
            label34.Name = "label34";
            label34.Size = new Size(256, 24);
            label34.TabIndex = 52;
            label34.Text = "Onay Bekleyen Siparişler";
            label34.Click += label34_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(richTextBox1);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(aciklamaTextBox);
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(textBox4);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(textBox3);
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(textBox2);
            groupBox3.Controls.Add(label1);
            groupBox3.Controls.Add(tarihTimerPicker);
            groupBox3.Controls.Add(textBox1);
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(button3);
            groupBox3.Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point, 162);
            groupBox3.Location = new Point(704, 102);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(642, 614);
            groupBox3.TabIndex = 53;
            groupBox3.TabStop = false;
            groupBox3.Text = "Ürün Bilgileri";
            // 
            // richTextBox1
            // 
            richTextBox1.BorderStyle = BorderStyle.FixedSingle;
            richTextBox1.Font = new Font("Century Gothic", 12F);
            richTextBox1.Location = new Point(432, 50);
            richTextBox1.Margin = new Padding(5);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(173, 159);
            richTextBox1.TabIndex = 70;
            richTextBox1.Text = "";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Eras Medium ITC", 14.25F);
            label6.Location = new Point(432, 23);
            label6.Name = "label6";
            label6.Size = new Size(69, 22);
            label6.TabIndex = 69;
            label6.Text = "Rotalar";
            // 
            // aciklamaTextBox
            // 
            aciklamaTextBox.BorderStyle = BorderStyle.FixedSingle;
            aciklamaTextBox.Font = new Font("Century Gothic", 12F);
            aciklamaTextBox.Location = new Point(26, 412);
            aciklamaTextBox.Margin = new Padding(5);
            aciklamaTextBox.Name = "aciklamaTextBox";
            aciklamaTextBox.ReadOnly = true;
            aciklamaTextBox.Size = new Size(318, 135);
            aciklamaTextBox.TabIndex = 68;
            aciklamaTextBox.Text = "";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Eras Medium ITC", 14.25F);
            label7.Location = new Point(26, 385);
            label7.Name = "label7";
            label7.Size = new Size(85, 22);
            label7.TabIndex = 67;
            label7.Text = "Açıklama";
            // 
            // textBox4
            // 
            textBox4.BorderStyle = BorderStyle.FixedSingle;
            textBox4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            textBox4.Location = new Point(26, 353);
            textBox4.Name = "textBox4";
            textBox4.ReadOnly = true;
            textBox4.Size = new Size(135, 27);
            textBox4.TabIndex = 66;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Eras Medium ITC", 14.25F);
            label5.Location = new Point(26, 328);
            label5.Name = "label5";
            label5.Size = new Size(97, 22);
            label5.TabIndex = 65;
            label5.Text = "Ürün Cinsi";
            // 
            // textBox3
            // 
            textBox3.BorderStyle = BorderStyle.FixedSingle;
            textBox3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            textBox3.Location = new Point(26, 284);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(135, 27);
            textBox3.TabIndex = 64;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Eras Medium ITC", 14.25F);
            label4.Location = new Point(26, 259);
            label4.Name = "label4";
            label4.Size = new Size(114, 22);
            label4.TabIndex = 63;
            label4.Text = "Ürün Miktarı";
            // 
            // textBox2
            // 
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            textBox2.Location = new Point(26, 212);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(135, 27);
            textBox2.TabIndex = 62;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Eras Medium ITC", 14.25F);
            label1.Location = new Point(26, 187);
            label1.Name = "label1";
            label1.Size = new Size(86, 22);
            label1.TabIndex = 61;
            label1.Text = "Ürün Adı";
            // 
            // tarihTimerPicker
            // 
            tarihTimerPicker.CalendarFont = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            tarihTimerPicker.Font = new Font("Century Gothic", 12F);
            tarihTimerPicker.Format = DateTimePickerFormat.Short;
            tarihTimerPicker.Location = new Point(27, 137);
            tarihTimerPicker.Name = "tarihTimerPicker";
            tarihTimerPicker.Size = new Size(121, 27);
            tarihTimerPicker.TabIndex = 55;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            textBox1.Location = new Point(26, 75);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(135, 27);
            textBox1.TabIndex = 60;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Eras Medium ITC", 14.25F);
            label3.Location = new Point(26, 112);
            label3.Name = "label3";
            label3.Size = new Size(53, 22);
            label3.TabIndex = 54;
            label3.Text = "Tarih";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Eras Medium ITC", 14.25F);
            label2.Location = new Point(26, 50);
            label2.Name = "label2";
            label2.Size = new Size(135, 22);
            label2.TabIndex = 54;
            label2.Text = "Firma / Kişi Adı";
            // 
            // button3
            // 
            button3.BackColor = Color.DarkSeaGreen;
            button3.Cursor = Cursors.Hand;
            button3.Location = new Point(442, 555);
            button3.Name = "button3";
            button3.Size = new Size(194, 53);
            button3.TabIndex = 59;
            button3.Text = "Onayla Ve Yazdır";
            button3.UseVisualStyleBackColor = false;
            // 
            // tickets
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(groupBox3);
            Controls.Add(label34);
            Controls.Add(menuStrip1);
            Controls.Add(dataGridView1);
            Name = "tickets";
            Text = "tickets";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dataGridView1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem anaSayfaToolStripMenuItem;
        private ToolStripMenuItem onaylananTekliflerToolStripMenuItem;
        private ToolStripMenuItem teklifOnaylaToolStripMenuItem;
        private ToolStripMenuItem yöneticiToolStripMenuItem;
        private ToolStripMenuItem kullanıcıEkleToolStripMenuItem;
        private ToolStripMenuItem istatistiklkerToolStripMenuItem;
        private ToolStripMenuItem yedeklemeToolStripMenuItem;
        private Label label34;
        private GroupBox groupBox3;
        private Button button3;
        private Label label2;
        private TextBox textBox1;
        private DateTimePicker tarihTimerPicker;
        private Label label3;
        private TextBox textBox3;
        private Label label4;
        private TextBox textBox2;
        private Label label1;
        private TextBox textBox4;
        private Label label5;
        private RichTextBox aciklamaTextBox;
        private Label label7;
        private RichTextBox richTextBox1;
        private Label label6;
    }
}