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
            arabtn = new Button();
            sahiparamaText = new TextBox();
            label8 = new Label();
            richTextBox1 = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)onayBekleyenlerDGV).BeginInit();
            menuStrip1.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // onayBekleyenlerDGV
            // 
            onayBekleyenlerDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            onayBekleyenlerDGV.Location = new Point(34, 136);
            onayBekleyenlerDGV.Margin = new Padding(3, 4, 3, 4);
            onayBekleyenlerDGV.Name = "onayBekleyenlerDGV";
            onayBekleyenlerDGV.RowHeadersWidth = 51;
            onayBekleyenlerDGV.Size = new Size(563, 819);
            onayBekleyenlerDGV.TabIndex = 3;
            onayBekleyenlerDGV.CellClick += onayBekleyenlerDGV_CellClick;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { anaSayfaToolStripMenuItem, onaylananTekliflerToolStripMenuItem, teklifOnaylaToolStripMenuItem, yöneticiToolStripMenuItem, yedeklemeToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 3, 0, 3);
            menuStrip1.Size = new Size(1924, 30);
            menuStrip1.TabIndex = 48;
            menuStrip1.Text = "menuStrip1";
            // 
            // anaSayfaToolStripMenuItem
            // 
            anaSayfaToolStripMenuItem.Name = "anaSayfaToolStripMenuItem";
            anaSayfaToolStripMenuItem.Size = new Size(89, 24);
            anaSayfaToolStripMenuItem.Text = "Ana Sayfa";
            anaSayfaToolStripMenuItem.Click += anaSayfaToolStripMenuItem_Click;
            // 
            // onaylananTekliflerToolStripMenuItem
            // 
            onaylananTekliflerToolStripMenuItem.Name = "onaylananTekliflerToolStripMenuItem";
            onaylananTekliflerToolStripMenuItem.Size = new Size(149, 24);
            onaylananTekliflerToolStripMenuItem.Text = "Onaylanan Teklifler";
            onaylananTekliflerToolStripMenuItem.Click += onaylananTekliflerToolStripMenuItem_Click;
            // 
            // teklifOnaylaToolStripMenuItem
            // 
            teklifOnaylaToolStripMenuItem.Name = "teklifOnaylaToolStripMenuItem";
            teklifOnaylaToolStripMenuItem.Size = new Size(108, 24);
            teklifOnaylaToolStripMenuItem.Text = "Teklif Onayla";
            teklifOnaylaToolStripMenuItem.Click += teklifOnaylaToolStripMenuItem_Click;
            // 
            // yöneticiToolStripMenuItem
            // 
            yöneticiToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { kullanıcıEkleToolStripMenuItem, istatistiklkerToolStripMenuItem });
            yöneticiToolStripMenuItem.Name = "yöneticiToolStripMenuItem";
            yöneticiToolStripMenuItem.Size = new Size(75, 24);
            yöneticiToolStripMenuItem.Text = "Yönetici";
            // 
            // kullanıcıEkleToolStripMenuItem
            // 
            kullanıcıEkleToolStripMenuItem.Name = "kullanıcıEkleToolStripMenuItem";
            kullanıcıEkleToolStripMenuItem.Size = new Size(179, 26);
            kullanıcıEkleToolStripMenuItem.Text = "Kullanıcı Ekle";
            kullanıcıEkleToolStripMenuItem.Click += kullanıcıEkleToolStripMenuItem_Click;
            // 
            // istatistiklkerToolStripMenuItem
            // 
            istatistiklkerToolStripMenuItem.Name = "istatistiklkerToolStripMenuItem";
            istatistiklkerToolStripMenuItem.Size = new Size(179, 26);
            istatistiklkerToolStripMenuItem.Text = "İstatistiklker";
            // 
            // yedeklemeToolStripMenuItem
            // 
            yedeklemeToolStripMenuItem.Name = "yedeklemeToolStripMenuItem";
            yedeklemeToolStripMenuItem.Size = new Size(95, 24);
            yedeklemeToolStripMenuItem.Text = "Yedekleme";
            yedeklemeToolStripMenuItem.Click += yedeklemeToolStripMenuItem_Click;
            // 
            // label34
            // 
            label34.AutoSize = true;
            label34.Font = new Font("Eras Demi ITC", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label34.Location = new Point(34, 75);
            label34.Name = "label34";
            label34.Size = new Size(330, 31);
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
            groupBox3.Location = new Point(617, 136);
            groupBox3.Margin = new Padding(3, 4, 3, 4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 4, 3, 4);
            groupBox3.Size = new Size(803, 819);
            groupBox3.TabIndex = 53;
            groupBox3.TabStop = false;
            groupBox3.Text = "Ürün Bilgileri";
            // 
            // rotaPanel
            // 
            rotaPanel.Font = new Font("Segoe UI", 11.25F);
            rotaPanel.Location = new Point(318, 67);
            rotaPanel.Margin = new Padding(3, 4, 3, 4);
            rotaPanel.Name = "rotaPanel";
            rotaPanel.Size = new Size(465, 476);
            rotaPanel.TabIndex = 79;
            // 
            // karlıToplamLabel
            // 
            karlıToplamLabel.AutoSize = true;
            karlıToplamLabel.Font = new Font("Eras Medium ITC", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            karlıToplamLabel.Location = new Point(475, 607);
            karlıToplamLabel.Name = "karlıToplamLabel";
            karlıToplamLabel.Size = new Size(59, 23);
            karlıToplamLabel.TabIndex = 77;
            karlıToplamLabel.Text = "00.00";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Eras Medium ITC", 14.25F);
            label10.Location = new Point(318, 604);
            label10.Name = "label10";
            label10.Size = new Size(148, 27);
            label10.TabIndex = 78;
            label10.Text = "Karlı Toplam:";
            // 
            // kdvliAdetLabel
            // 
            kdvliAdetLabel.AutoSize = true;
            kdvliAdetLabel.Font = new Font("Eras Medium ITC", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            kdvliAdetLabel.Location = new Point(503, 704);
            kdvliAdetLabel.Name = "kdvliAdetLabel";
            kdvliAdetLabel.Size = new Size(59, 23);
            kdvliAdetLabel.TabIndex = 76;
            kdvliAdetLabel.Text = "00.00";
            // 
            // kdvadet
            // 
            kdvadet.AutoSize = true;
            kdvadet.Font = new Font("Eras Medium ITC", 14.25F);
            kdvadet.Location = new Point(318, 700);
            kdvadet.Name = "kdvadet";
            kdvadet.Size = new Size(199, 27);
            kdvadet.TabIndex = 75;
            kdvadet.Text = "KDV'li Adet Fiyatı:";
            // 
            // kdvliToplamLabel
            // 
            kdvliToplamLabel.AutoSize = true;
            kdvliToplamLabel.Font = new Font("Eras Medium ITC", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            kdvliToplamLabel.Location = new Point(475, 656);
            kdvliToplamLabel.Name = "kdvliToplamLabel";
            kdvliToplamLabel.Size = new Size(59, 23);
            kdvliToplamLabel.TabIndex = 74;
            kdvliToplamLabel.Text = "00.00";
            // 
            // kdvli
            // 
            kdvli.AutoSize = true;
            kdvli.Font = new Font("Eras Medium ITC", 14.25F);
            kdvli.Location = new Point(318, 653);
            kdvli.Name = "kdvli";
            kdvli.Size = new Size(167, 27);
            kdvli.TabIndex = 73;
            kdvli.Text = "KDV li Toplam:";
            // 
            // rotaToplamLabel
            // 
            rotaToplamLabel.AutoSize = true;
            rotaToplamLabel.Font = new Font("Eras Medium ITC", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            rotaToplamLabel.Location = new Point(511, 561);
            rotaToplamLabel.Name = "rotaToplamLabel";
            rotaToplamLabel.Size = new Size(59, 23);
            rotaToplamLabel.TabIndex = 71;
            rotaToplamLabel.Text = "00.00";
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Font = new Font("Eras Medium ITC", 14.25F);
            label28.Location = new Point(318, 559);
            label28.Name = "label28";
            label28.Size = new Size(209, 27);
            label28.TabIndex = 72;
            label28.Text = "Rota Toplam Fiyat:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Eras Medium ITC", 14.25F);
            label6.Location = new Point(318, 31);
            label6.Name = "label6";
            label6.Size = new Size(87, 27);
            label6.TabIndex = 69;
            label6.Text = "Rotalar";
            // 
            // aciklamaTextBox
            // 
            aciklamaTextBox.BorderStyle = BorderStyle.FixedSingle;
            aciklamaTextBox.Font = new Font("Century Gothic", 12F);
            aciklamaTextBox.Location = new Point(30, 549);
            aciklamaTextBox.Margin = new Padding(6, 7, 6, 7);
            aciklamaTextBox.Name = "aciklamaTextBox";
            aciklamaTextBox.ReadOnly = true;
            aciklamaTextBox.Size = new Size(221, 179);
            aciklamaTextBox.TabIndex = 68;
            aciklamaTextBox.Text = "";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Eras Medium ITC", 14.25F);
            label7.Location = new Point(30, 513);
            label7.Name = "label7";
            label7.Size = new Size(109, 27);
            label7.TabIndex = 67;
            label7.Text = "Açıklama";
            // 
            // uruncinsiText
            // 
            uruncinsiText.BorderStyle = BorderStyle.FixedSingle;
            uruncinsiText.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            uruncinsiText.Location = new Point(30, 471);
            uruncinsiText.Margin = new Padding(3, 4, 3, 4);
            uruncinsiText.Name = "uruncinsiText";
            uruncinsiText.ReadOnly = true;
            uruncinsiText.Size = new Size(154, 32);
            uruncinsiText.TabIndex = 66;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Eras Medium ITC", 14.25F);
            label5.Location = new Point(30, 437);
            label5.Name = "label5";
            label5.Size = new Size(120, 27);
            label5.TabIndex = 65;
            label5.Text = "Ürün Cinsi";
            // 
            // urunmiktarıText
            // 
            urunmiktarıText.BorderStyle = BorderStyle.FixedSingle;
            urunmiktarıText.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            urunmiktarıText.Location = new Point(30, 379);
            urunmiktarıText.Margin = new Padding(3, 4, 3, 4);
            urunmiktarıText.Name = "urunmiktarıText";
            urunmiktarıText.ReadOnly = true;
            urunmiktarıText.Size = new Size(154, 32);
            urunmiktarıText.TabIndex = 64;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Eras Medium ITC", 14.25F);
            label4.Location = new Point(30, 345);
            label4.Name = "label4";
            label4.Size = new Size(142, 27);
            label4.TabIndex = 63;
            label4.Text = "Ürün Miktarı";
            // 
            // urunadiText
            // 
            urunadiText.BorderStyle = BorderStyle.FixedSingle;
            urunadiText.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            urunadiText.Location = new Point(30, 283);
            urunadiText.Margin = new Padding(3, 4, 3, 4);
            urunadiText.Name = "urunadiText";
            urunadiText.ReadOnly = true;
            urunadiText.Size = new Size(154, 32);
            urunadiText.TabIndex = 62;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Eras Medium ITC", 14.25F);
            label1.Location = new Point(30, 249);
            label1.Name = "label1";
            label1.Size = new Size(107, 27);
            label1.TabIndex = 61;
            label1.Text = "Ürün Adı";
            // 
            // tarihTimerPicker
            // 
            tarihTimerPicker.CalendarFont = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            tarihTimerPicker.Font = new Font("Century Gothic", 12F);
            tarihTimerPicker.Format = DateTimePickerFormat.Short;
            tarihTimerPicker.Location = new Point(31, 183);
            tarihTimerPicker.Margin = new Padding(3, 4, 3, 4);
            tarihTimerPicker.Name = "tarihTimerPicker";
            tarihTimerPicker.Size = new Size(138, 32);
            tarihTimerPicker.TabIndex = 55;
            // 
            // sahipText
            // 
            sahipText.BorderStyle = BorderStyle.FixedSingle;
            sahipText.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            sahipText.Location = new Point(30, 100);
            sahipText.Margin = new Padding(3, 4, 3, 4);
            sahipText.Name = "sahipText";
            sahipText.ReadOnly = true;
            sahipText.Size = new Size(154, 32);
            sahipText.TabIndex = 60;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Eras Medium ITC", 14.25F);
            label3.Location = new Point(30, 149);
            label3.Name = "label3";
            label3.Size = new Size(66, 27);
            label3.TabIndex = 54;
            label3.Text = "Tarih";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Eras Medium ITC", 14.25F);
            label2.Location = new Point(30, 67);
            label2.Name = "label2";
            label2.Size = new Size(169, 27);
            label2.TabIndex = 54;
            label2.Text = "Firma / Kişi Adı";
            // 
            // onaylabtn
            // 
            onaylabtn.BackColor = Color.DarkSeaGreen;
            onaylabtn.Cursor = Cursors.Hand;
            onaylabtn.Font = new Font("Impact", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            onaylabtn.Location = new Point(575, 740);
            onaylabtn.Margin = new Padding(3, 4, 3, 4);
            onaylabtn.Name = "onaylabtn";
            onaylabtn.Size = new Size(222, 71);
            onaylabtn.TabIndex = 59;
            onaylabtn.Text = "Onayla Ve Yazdır";
            onaylabtn.UseVisualStyleBackColor = false;
            onaylabtn.Click += onaylabtn_Click;
            // 
            // arabtn
            // 
            arabtn.Font = new Font("Eras Demi ITC", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            arabtn.Location = new Point(1599, 252);
            arabtn.Margin = new Padding(3, 4, 3, 4);
            arabtn.Name = "arabtn";
            arabtn.Size = new Size(86, 41);
            arabtn.TabIndex = 59;
            arabtn.Text = "Ara";
            arabtn.UseVisualStyleBackColor = true;
            // 
            // sahiparamaText
            // 
            sahiparamaText.BorderStyle = BorderStyle.FixedSingle;
            sahiparamaText.Location = new Point(1499, 201);
            sahiparamaText.Margin = new Padding(3, 4, 3, 4);
            sahiparamaText.Name = "sahiparamaText";
            sahiparamaText.Size = new Size(185, 27);
            sahiparamaText.TabIndex = 58;
            sahiparamaText.KeyUp += sahiparamaText_KeyUp;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Eras Demi ITC", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(1499, 152);
            label8.Name = "label8";
            label8.Size = new Size(207, 31);
            label8.TabIndex = 57;
            label8.Text = "Firma / Kisi Ara";
            // 
            // richTextBox1
            // 
            richTextBox1.BorderStyle = BorderStyle.FixedSingle;
            richTextBox1.Enabled = false;
            richTextBox1.Font = new Font("Century Gothic", 12F);
            richTextBox1.Location = new Point(1454, 431);
            richTextBox1.Margin = new Padding(6, 7, 6, 7);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(267, 211);
            richTextBox1.TabIndex = 70;
            richTextBox1.Text = "";
            // 
            // tickets
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1924, 1055);
            Controls.Add(arabtn);
            Controls.Add(sahiparamaText);
            Controls.Add(label8);
            Controls.Add(groupBox3);
            Controls.Add(label34);
            Controls.Add(menuStrip1);
            Controls.Add(onayBekleyenlerDGV);
            Controls.Add(richTextBox1);
            Margin = new Padding(3, 4, 3, 4);
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
        private RichTextBox richTextBox1;
    }
}