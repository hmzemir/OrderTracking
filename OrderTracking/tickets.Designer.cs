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
            onayBekleyenlerDGV = new DataGridView();
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
            rotaPanel = new Panel();
            karlıToplamLabel = new Label();
            label10 = new Label();
            kdvliAdetLabel = new Label();
            kdvadet = new Label();
            kdvliToplamLabel = new Label();
            kdvli = new Label();
            rotaToplamLabel = new Label();
            label28 = new Label();
            label6 = new Label();
            aciklamaTextBox = new RichTextBox();
            label7 = new Label();
            uruncinsiText = new TextBox();
            label5 = new Label();
            urunmiktarıText = new TextBox();
            label4 = new Label();
            urunadiText = new TextBox();
            label1 = new Label();
            tarihTimerPicker = new DateTimePicker();
            sahipText = new TextBox();
            label3 = new Label();
            label2 = new Label();
            onaylabtn = new Button();
            richTextBox1 = new RichTextBox();
            arabtn = new Button();
            sahiparamaText = new TextBox();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)onayBekleyenlerDGV).BeginInit();
            menuStrip1.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // onayBekleyenlerDGV
            // 
            onayBekleyenlerDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            onayBekleyenlerDGV.Location = new Point(30, 102);
            onayBekleyenlerDGV.Name = "onayBekleyenlerDGV";
            onayBekleyenlerDGV.Size = new Size(493, 614);
            onayBekleyenlerDGV.TabIndex = 3;
            onayBekleyenlerDGV.CellClick += onayBekleyenlerDGV_CellClick;
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
            kullanıcıEkleToolStripMenuItem.Click += kullanıcıEkleToolStripMenuItem_Click;
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
            yedeklemeToolStripMenuItem.Click += yedeklemeToolStripMenuItem_Click;
            // 
            // label34
            // 
            label34.AutoSize = true;
            label34.Font = new Font("Eras Demi ITC", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label34.Location = new Point(30, 56);
            label34.Name = "label34";
            label34.Size = new Size(256, 24);
            label34.TabIndex = 52;
            label34.Text = "Onay Bekleyen Siparişler";
            label34.Click += label34_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(rotaPanel);
            groupBox3.Controls.Add(karlıToplamLabel);
            groupBox3.Controls.Add(label10);
            groupBox3.Controls.Add(kdvliAdetLabel);
            groupBox3.Controls.Add(kdvadet);
            groupBox3.Controls.Add(kdvliToplamLabel);
            groupBox3.Controls.Add(kdvli);
            groupBox3.Controls.Add(rotaToplamLabel);
            groupBox3.Controls.Add(label28);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(aciklamaTextBox);
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(uruncinsiText);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(urunmiktarıText);
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(urunadiText);
            groupBox3.Controls.Add(label1);
            groupBox3.Controls.Add(tarihTimerPicker);
            groupBox3.Controls.Add(sahipText);
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(onaylabtn);
            groupBox3.Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point, 162);
            groupBox3.Location = new Point(540, 102);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(703, 614);
            groupBox3.TabIndex = 53;
            groupBox3.TabStop = false;
            groupBox3.Text = "Ürün Bilgileri";
            // 
            // rotaPanel
            // 
            rotaPanel.Font = new Font("Segoe UI", 11.25F);
            rotaPanel.Location = new Point(278, 50);
            rotaPanel.Name = "rotaPanel";
            rotaPanel.Size = new Size(407, 357);
            rotaPanel.TabIndex = 79;
            // 
            // karlıToplamLabel
            // 
            karlıToplamLabel.AutoSize = true;
            karlıToplamLabel.Font = new Font("Eras Medium ITC", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            karlıToplamLabel.Location = new Point(416, 455);
            karlıToplamLabel.Name = "karlıToplamLabel";
            karlıToplamLabel.Size = new Size(49, 19);
            karlıToplamLabel.TabIndex = 77;
            karlıToplamLabel.Text = "00.00";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Eras Medium ITC", 14.25F);
            label10.Location = new Point(278, 453);
            label10.Name = "label10";
            label10.Size = new Size(117, 22);
            label10.TabIndex = 78;
            label10.Text = "Karlı Toplam:";
            // 
            // kdvliAdetLabel
            // 
            kdvliAdetLabel.AutoSize = true;
            kdvliAdetLabel.Font = new Font("Eras Medium ITC", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            kdvliAdetLabel.Location = new Point(440, 528);
            kdvliAdetLabel.Name = "kdvliAdetLabel";
            kdvliAdetLabel.Size = new Size(49, 19);
            kdvliAdetLabel.TabIndex = 76;
            kdvliAdetLabel.Text = "00.00";
            // 
            // kdvadet
            // 
            kdvadet.AutoSize = true;
            kdvadet.Font = new Font("Eras Medium ITC", 14.25F);
            kdvadet.Location = new Point(278, 525);
            kdvadet.Name = "kdvadet";
            kdvadet.Size = new Size(156, 22);
            kdvadet.TabIndex = 75;
            kdvadet.Text = "KDV'li Adet Fiyatı:";
            // 
            // kdvliToplamLabel
            // 
            kdvliToplamLabel.AutoSize = true;
            kdvliToplamLabel.Font = new Font("Eras Medium ITC", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            kdvliToplamLabel.Location = new Point(416, 492);
            kdvliToplamLabel.Name = "kdvliToplamLabel";
            kdvliToplamLabel.Size = new Size(49, 19);
            kdvliToplamLabel.TabIndex = 74;
            kdvliToplamLabel.Text = "00.00";
            // 
            // kdvli
            // 
            kdvli.AutoSize = true;
            kdvli.Font = new Font("Eras Medium ITC", 14.25F);
            kdvli.Location = new Point(278, 490);
            kdvli.Name = "kdvli";
            kdvli.Size = new Size(132, 22);
            kdvli.TabIndex = 73;
            kdvli.Text = "KDV li Toplam:";
            // 
            // rotaToplamLabel
            // 
            rotaToplamLabel.AutoSize = true;
            rotaToplamLabel.Font = new Font("Eras Medium ITC", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            rotaToplamLabel.Location = new Point(447, 421);
            rotaToplamLabel.Name = "rotaToplamLabel";
            rotaToplamLabel.Size = new Size(49, 19);
            rotaToplamLabel.TabIndex = 71;
            rotaToplamLabel.Text = "00.00";
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Font = new Font("Eras Medium ITC", 14.25F);
            label28.Location = new Point(278, 419);
            label28.Name = "label28";
            label28.Size = new Size(163, 22);
            label28.TabIndex = 72;
            label28.Text = "Rota Toplam Fiyat:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Eras Medium ITC", 14.25F);
            label6.Location = new Point(278, 23);
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
            aciklamaTextBox.Size = new Size(194, 135);
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
            // uruncinsiText
            // 
            uruncinsiText.BorderStyle = BorderStyle.FixedSingle;
            uruncinsiText.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            uruncinsiText.Location = new Point(26, 353);
            uruncinsiText.Name = "uruncinsiText";
            uruncinsiText.ReadOnly = true;
            uruncinsiText.Size = new Size(135, 27);
            uruncinsiText.TabIndex = 66;
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
            // urunmiktarıText
            // 
            urunmiktarıText.BorderStyle = BorderStyle.FixedSingle;
            urunmiktarıText.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            urunmiktarıText.Location = new Point(26, 284);
            urunmiktarıText.Name = "urunmiktarıText";
            urunmiktarıText.ReadOnly = true;
            urunmiktarıText.Size = new Size(135, 27);
            urunmiktarıText.TabIndex = 64;
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
            // urunadiText
            // 
            urunadiText.BorderStyle = BorderStyle.FixedSingle;
            urunadiText.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            urunadiText.Location = new Point(26, 212);
            urunadiText.Name = "urunadiText";
            urunadiText.ReadOnly = true;
            urunadiText.Size = new Size(135, 27);
            urunadiText.TabIndex = 62;
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
            // sahipText
            // 
            sahipText.BorderStyle = BorderStyle.FixedSingle;
            sahipText.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            sahipText.Location = new Point(26, 75);
            sahipText.Name = "sahipText";
            sahipText.ReadOnly = true;
            sahipText.Size = new Size(135, 27);
            sahipText.TabIndex = 60;
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
            // onaylabtn
            // 
            onaylabtn.BackColor = Color.DarkSeaGreen;
            onaylabtn.Cursor = Cursors.Hand;
            onaylabtn.Location = new Point(349, 555);
            onaylabtn.Name = "onaylabtn";
            onaylabtn.Size = new Size(194, 53);
            onaylabtn.TabIndex = 59;
            onaylabtn.Text = "Onayla Ve Yazdır";
            onaylabtn.UseVisualStyleBackColor = false;
            onaylabtn.Click += onaylabtn_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.BorderStyle = BorderStyle.FixedSingle;
            richTextBox1.Font = new Font("Century Gothic", 12F);
            richTextBox1.Location = new Point(1292, 242);
            richTextBox1.Margin = new Padding(5);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(234, 159);
            richTextBox1.TabIndex = 70;
            richTextBox1.Text = "";
            // 
            // arabtn
            // 
            arabtn.Font = new Font("Eras Demi ITC", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            arabtn.Location = new Point(1399, 189);
            arabtn.Name = "arabtn";
            arabtn.Size = new Size(75, 31);
            arabtn.TabIndex = 59;
            arabtn.Text = "Ara";
            arabtn.UseVisualStyleBackColor = true;
            // 
            // sahiparamaText
            // 
            sahiparamaText.BorderStyle = BorderStyle.FixedSingle;
            sahiparamaText.Location = new Point(1312, 151);
            sahiparamaText.Name = "sahiparamaText";
            sahiparamaText.Size = new Size(162, 23);
            sahiparamaText.TabIndex = 58;
            sahiparamaText.KeyUp += sahiparamaText_KeyUp;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Eras Demi ITC", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(1312, 114);
            label8.Name = "label8";
            label8.Size = new Size(162, 24);
            label8.TabIndex = 57;
            label8.Text = "Firma / Kisi Ara";
            // 
            // tickets
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(arabtn);
            Controls.Add(sahiparamaText);
            Controls.Add(label8);
            Controls.Add(groupBox3);
            Controls.Add(label34);
            Controls.Add(menuStrip1);
            Controls.Add(onayBekleyenlerDGV);
            Controls.Add(richTextBox1);
            Name = "tickets";
            Text = "tickets";
            Load += tickets_Load;
            ((System.ComponentModel.ISupportInitialize)onayBekleyenlerDGV).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView onayBekleyenlerDGV;
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
        private Button onaylabtn;
        private Label label2;
        private TextBox sahipText;
        private DateTimePicker tarihTimerPicker;
        private Label label3;
        private TextBox urunmiktarıText;
        private Label label4;
        private TextBox urunadiText;
        private Label label1;
        private TextBox uruncinsiText;
        private Label label5;
        private RichTextBox aciklamaTextBox;
        private Label label7;
        private RichTextBox richTextBox1;
        private Label label6;
        private Button arabtn;
        private TextBox sahiparamaText;
        private Label label8;
        private Label rotaToplamLabel;
        private Label label28;
        private Label kdvliToplamLabel;
        private Label kdvli;
        private Label kdvliAdetLabel;
        private Label kdvadet;
        private Label karlıToplamLabel;
        private Label label10;
        private Panel rotaPanel;
    }
}