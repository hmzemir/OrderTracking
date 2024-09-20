namespace OrderTracking
{
    partial class orders
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
            label34 = new Label();
            menuStrip1 = new MenuStrip();
            anaSayfaToolStripMenuItem = new ToolStripMenuItem();
            onaylananTekliflerToolStripMenuItem = new ToolStripMenuItem();
            teklifOnaylaToolStripMenuItem = new ToolStripMenuItem();
            yöneticiToolStripMenuItem = new ToolStripMenuItem();
            kullanıcıEkleToolStripMenuItem = new ToolStripMenuItem();
            istatistiklkerToolStripMenuItem = new ToolStripMenuItem();
            yedeklemeToolStripMenuItem = new ToolStripMenuItem();
            label1 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(33, 94);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(948, 542);
            dataGridView1.TabIndex = 0;
            // 
            // label34
            // 
            label34.AutoSize = true;
            label34.Font = new Font("Eras Demi ITC", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label34.Location = new Point(33, 67);
            label34.Name = "label34";
            label34.Size = new Size(206, 24);
            label34.TabIndex = 52;
            label34.Text = "Onaylanan Teklifler";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { anaSayfaToolStripMenuItem, onaylananTekliflerToolStripMenuItem, teklifOnaylaToolStripMenuItem, yöneticiToolStripMenuItem, yedeklemeToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1904, 24);
            menuStrip1.TabIndex = 53;
            menuStrip1.Text = "menuStrip1";
            // 
            // anaSayfaToolStripMenuItem
            // 
            anaSayfaToolStripMenuItem.Name = "anaSayfaToolStripMenuItem";
            anaSayfaToolStripMenuItem.Size = new Size(71, 20);
            anaSayfaToolStripMenuItem.Text = "Ana Sayfa";
            anaSayfaToolStripMenuItem.Click += anaSayfaToolStripMenuItem_Click_1;
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Eras Demi ITC", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(1121, 94);
            label1.Name = "label1";
            label1.Size = new Size(162, 24);
            label1.TabIndex = 54;
            label1.Text = "Firma / Kisi Ara";
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Location = new Point(1121, 131);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(162, 23);
            textBox1.TabIndex = 55;
            // 
            // button1
            // 
            button1.Font = new Font("Eras Demi ITC", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(1208, 169);
            button1.Name = "button1";
            button1.Size = new Size(75, 31);
            button1.TabIndex = 56;
            button1.Text = "Ara";
            button1.UseVisualStyleBackColor = true;
            // 
            // orders
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            Controls.Add(label34);
            Controls.Add(dataGridView1);
            Name = "orders";
            Text = "orders";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label34;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem anaSayfaToolStripMenuItem;
        private ToolStripMenuItem onaylananTekliflerToolStripMenuItem;
        private ToolStripMenuItem teklifOnaylaToolStripMenuItem;
        private ToolStripMenuItem yöneticiToolStripMenuItem;
        private ToolStripMenuItem kullanıcıEkleToolStripMenuItem;
        private ToolStripMenuItem istatistiklkerToolStripMenuItem;
        private ToolStripMenuItem yedeklemeToolStripMenuItem;
        private Label label1;
        private TextBox textBox1;
        private Button button1;
    }
}