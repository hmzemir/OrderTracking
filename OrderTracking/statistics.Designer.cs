
namespace OrderTracking
{
    partial class statistics
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
            menuStrip1 = new MenuStrip();
            anaSayfaToolStripMenuItem = new ToolStripMenuItem();
            onaylananTekliflerToolStripMenuItem = new ToolStripMenuItem();
            teklifOnaylaToolStripMenuItem = new ToolStripMenuItem();
            yöneticiToolStripMenuItem = new ToolStripMenuItem();
            kullanıcıEkleToolStripMenuItem = new ToolStripMenuItem();
            istatistiklkerToolStripMenuItem = new ToolStripMenuItem();
            yedeklemeToolStripMenuItem = new ToolStripMenuItem();
            tarihBaslangıc = new DateTimePicker();
            tarihBitis = new DateTimePicker();
            label2 = new Label();
            label1 = new Label();
            aramaText = new TextBox();
            label3 = new Label();
            arabtn = new Button();
            tarihSec = new CheckBox();
            isimAra = new CheckBox();
            verilerTablo = new DataGridView();
            label4 = new Label();
            toplamSiparisText = new Label();
            toplamTutarText = new Label();
            label6 = new Label();
            sadeceOnayCheck = new CheckBox();
            toplamUrunText = new Label();
            label7 = new Label();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)verilerTablo).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { anaSayfaToolStripMenuItem, onaylananTekliflerToolStripMenuItem, teklifOnaylaToolStripMenuItem, yöneticiToolStripMenuItem, yedeklemeToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1904, 24);
            menuStrip1.TabIndex = 49;
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
            yöneticiToolStripMenuItem.Click += yöneticiToolStripMenuItem_Click;
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
            // tarihBaslangıc
            // 
            tarihBaslangıc.CalendarFont = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            tarihBaslangıc.Font = new Font("Century Gothic", 12F);
            tarihBaslangıc.Format = DateTimePickerFormat.Short;
            tarihBaslangıc.Location = new Point(34, 73);
            tarihBaslangıc.Name = "tarihBaslangıc";
            tarihBaslangıc.Size = new Size(121, 27);
            tarihBaslangıc.TabIndex = 50;
            // 
            // tarihBitis
            // 
            tarihBitis.CalendarFont = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            tarihBitis.Font = new Font("Century Gothic", 12F);
            tarihBitis.Format = DateTimePickerFormat.Short;
            tarihBitis.Location = new Point(214, 73);
            tarihBitis.Name = "tarihBitis";
            tarihBitis.Size = new Size(121, 27);
            tarihBitis.TabIndex = 51;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Eras Medium ITC", 14.25F);
            label2.Location = new Point(34, 48);
            label2.Name = "label2";
            label2.Size = new Size(88, 22);
            label2.TabIndex = 52;
            label2.Text = "Başlangıç";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Eras Medium ITC", 14.25F);
            label1.Location = new Point(214, 48);
            label1.Name = "label1";
            label1.Size = new Size(43, 22);
            label1.TabIndex = 53;
            label1.Text = "Bitiş";
            // 
            // aramaText
            // 
            aramaText.BorderStyle = BorderStyle.FixedSingle;
            aramaText.Location = new Point(34, 202);
            aramaText.Name = "aramaText";
            aramaText.Size = new Size(162, 23);
            aramaText.TabIndex = 56;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Eras Medium ITC", 14.25F);
            label3.Location = new Point(34, 177);
            label3.Name = "label3";
            label3.Size = new Size(40, 22);
            label3.TabIndex = 57;
            label3.Text = "Ara";
            // 
            // arabtn
            // 
            arabtn.Font = new Font("Eras Demi ITC", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            arabtn.Location = new Point(34, 242);
            arabtn.Name = "arabtn";
            arabtn.Size = new Size(75, 31);
            arabtn.TabIndex = 58;
            arabtn.Text = "Ara";
            arabtn.UseVisualStyleBackColor = true;
            arabtn.Click += arabtn_Click;
            // 
            // tarihSec
            // 
            tarihSec.AutoSize = true;
            tarihSec.Font = new Font("Eras Medium ITC", 14.25F);
            tarihSec.Location = new Point(34, 106);
            tarihSec.Name = "tarihSec";
            tarihSec.Size = new Size(105, 26);
            tarihSec.TabIndex = 59;
            tarihSec.Text = "Tarih Seç";
            tarihSec.UseVisualStyleBackColor = true;
            tarihSec.CheckedChanged += tarihSec_CheckedChanged;
            // 
            // isimAra
            // 
            isimAra.AutoSize = true;
            isimAra.Font = new Font("Eras Medium ITC", 14.25F);
            isimAra.Location = new Point(145, 106);
            isimAra.Name = "isimAra";
            isimAra.Size = new Size(109, 26);
            isimAra.TabIndex = 60;
            isimAra.Text = "İsimle Ara";
            isimAra.UseVisualStyleBackColor = true;
            isimAra.CheckedChanged += isimAra_CheckedChanged;
            // 
            // verilerTablo
            // 
            verilerTablo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            verilerTablo.Location = new Point(463, 48);
            verilerTablo.Name = "verilerTablo";
            verilerTablo.Size = new Size(822, 497);
            verilerTablo.TabIndex = 61;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Eras Medium ITC", 14.25F);
            label4.Location = new Point(34, 335);
            label4.Name = "label4";
            label4.Size = new Size(130, 22);
            label4.TabIndex = 62;
            label4.Text = "Toplam Sipariş";
            // 
            // toplamSiparisText
            // 
            toplamSiparisText.AutoSize = true;
            toplamSiparisText.Font = new Font("Eras Medium ITC", 14.25F);
            toplamSiparisText.Location = new Point(34, 371);
            toplamSiparisText.Name = "toplamSiparisText";
            toplamSiparisText.Size = new Size(32, 22);
            toplamSiparisText.TabIndex = 63;
            toplamSiparisText.Text = "00";
            // 
            // toplamTutarText
            // 
            toplamTutarText.AutoSize = true;
            toplamTutarText.Font = new Font("Eras Medium ITC", 14.25F);
            toplamTutarText.Location = new Point(242, 371);
            toplamTutarText.Name = "toplamTutarText";
            toplamTutarText.Size = new Size(32, 22);
            toplamTutarText.TabIndex = 65;
            toplamTutarText.Text = "00";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Eras Medium ITC", 14.25F);
            label6.Location = new Point(242, 335);
            label6.Name = "label6";
            label6.Size = new Size(121, 22);
            label6.TabIndex = 64;
            label6.Text = "Toplam Tutar";
            // 
            // sadeceOnayCheck
            // 
            sadeceOnayCheck.AutoSize = true;
            sadeceOnayCheck.Font = new Font("Eras Medium ITC", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            sadeceOnayCheck.Location = new Point(34, 138);
            sadeceOnayCheck.Name = "sadeceOnayCheck";
            sadeceOnayCheck.Size = new Size(205, 26);
            sadeceOnayCheck.TabIndex = 66;
            sadeceOnayCheck.Text = "Sadece Onaylananlar";
            sadeceOnayCheck.UseVisualStyleBackColor = true;
            // 
            // toplamUrunText
            // 
            toplamUrunText.AutoSize = true;
            toplamUrunText.Font = new Font("Eras Medium ITC", 14.25F);
            toplamUrunText.Location = new Point(34, 447);
            toplamUrunText.Name = "toplamUrunText";
            toplamUrunText.Size = new Size(32, 22);
            toplamUrunText.TabIndex = 68;
            toplamUrunText.Text = "00";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Eras Medium ITC", 14.25F);
            label7.Location = new Point(34, 411);
            label7.Name = "label7";
            label7.Size = new Size(185, 22);
            label7.TabIndex = 67;
            label7.Text = "Toplam Yapılan Ürün";
            // 
            // statistics
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(toplamUrunText);
            Controls.Add(label7);
            Controls.Add(sadeceOnayCheck);
            Controls.Add(toplamTutarText);
            Controls.Add(label6);
            Controls.Add(toplamSiparisText);
            Controls.Add(label4);
            Controls.Add(verilerTablo);
            Controls.Add(isimAra);
            Controls.Add(tarihSec);
            Controls.Add(arabtn);
            Controls.Add(label3);
            Controls.Add(aramaText);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(tarihBitis);
            Controls.Add(tarihBaslangıc);
            Controls.Add(menuStrip1);
            Name = "statistics";
            Text = "statistics";
            Load += statistics_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)verilerTablo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void yöneticiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem anaSayfaToolStripMenuItem;
        private ToolStripMenuItem onaylananTekliflerToolStripMenuItem;
        private ToolStripMenuItem teklifOnaylaToolStripMenuItem;
        private ToolStripMenuItem yöneticiToolStripMenuItem;
        private ToolStripMenuItem kullanıcıEkleToolStripMenuItem;
        private ToolStripMenuItem istatistiklkerToolStripMenuItem;
        private ToolStripMenuItem yedeklemeToolStripMenuItem;
        private DateTimePicker tarihBaslangıc;
        private DateTimePicker tarihBitis;
        private Label label2;
        private Label label1;
        private TextBox aramaText;
        private Label label3;
        private Button arabtn;
        private CheckBox tarihSec;
        private CheckBox isimAra;
        private DataGridView verilerTablo;
        private Label label4;
        private Label toplamSiparisText;
        private Label toplamTutarText;
        private Label label6;
        private CheckBox sadeceOnayCheck;
        private Label toplamUrunText;
        private Label label7;
    }
}