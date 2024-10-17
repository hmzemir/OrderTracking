namespace OrderTracking
{
    partial class yeniRota
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
            label1 = new Label();
            txtRotaBaslik = new TextBox();
            btnYeniRotaEkle = new Button();
            flowLayoutPanelAltRotalar = new FlowLayoutPanel();
            btnKaydet = new Button();
            btnTemizle = new Button();
            rotalarCombo = new ComboBox();
            label2 = new Label();
            rotaAdlariLabel = new Label();
            btnSil = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Eras Demi ITC", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(24, 22);
            label1.Name = "label1";
            label1.Size = new Size(88, 18);
            label1.TabIndex = 56;
            label1.Text = "Rota Başlık";
            // 
            // txtRotaBaslik
            // 
            txtRotaBaslik.BorderStyle = BorderStyle.FixedSingle;
            txtRotaBaslik.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            txtRotaBaslik.Location = new Point(24, 43);
            txtRotaBaslik.Name = "txtRotaBaslik";
            txtRotaBaslik.Size = new Size(111, 27);
            txtRotaBaslik.TabIndex = 55;
            // 
            // btnYeniRotaEkle
            // 
            btnYeniRotaEkle.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnYeniRotaEkle.Location = new Point(12, 528);
            btnYeniRotaEkle.Name = "btnYeniRotaEkle";
            btnYeniRotaEkle.Size = new Size(119, 51);
            btnYeniRotaEkle.TabIndex = 58;
            btnYeniRotaEkle.Text = "Yeni Alt Rota Ekle";
            btnYeniRotaEkle.UseVisualStyleBackColor = true;
            btnYeniRotaEkle.Click += btnYeniRotaEkle_Click;
            // 
            // flowLayoutPanelAltRotalar
            // 
            flowLayoutPanelAltRotalar.Location = new Point(24, 108);
            flowLayoutPanelAltRotalar.Name = "flowLayoutPanelAltRotalar";
            flowLayoutPanelAltRotalar.Size = new Size(232, 357);
            flowLayoutPanelAltRotalar.TabIndex = 59;
            // 
            // btnKaydet
            // 
            btnKaydet.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnKaydet.Location = new Point(137, 471);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(119, 51);
            btnKaydet.TabIndex = 60;
            btnKaydet.Text = "Kaydet";
            btnKaydet.UseVisualStyleBackColor = true;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // btnTemizle
            // 
            btnTemizle.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnTemizle.Location = new Point(137, 528);
            btnTemizle.Name = "btnTemizle";
            btnTemizle.Size = new Size(119, 51);
            btnTemizle.TabIndex = 61;
            btnTemizle.Text = "Temizle";
            btnTemizle.UseVisualStyleBackColor = true;
            btnTemizle.Click += btnTemizle_Click;
            // 
            // rotalarCombo
            // 
            rotalarCombo.FormattingEnabled = true;
            rotalarCombo.Location = new Point(362, 43);
            rotalarCombo.Name = "rotalarCombo";
            rotalarCombo.Size = new Size(121, 23);
            rotalarCombo.TabIndex = 62;
            rotalarCombo.SelectedIndexChanged += rotalarCombo_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Eras Demi ITC", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(362, 22);
            label2.Name = "label2";
            label2.Size = new Size(68, 18);
            label2.TabIndex = 63;
            label2.Text = "Rota Seç";
            // 
            // rotaAdlariLabel
            // 
            rotaAdlariLabel.AutoSize = true;
            rotaAdlariLabel.Font = new Font("Eras Medium ITC", 14.25F);
            rotaAdlariLabel.Location = new Point(362, 80);
            rotaAdlariLabel.Name = "rotaAdlariLabel";
            rotaAdlariLabel.Size = new Size(93, 22);
            rotaAdlariLabel.TabIndex = 64;
            rotaAdlariLabel.Text = "rotaAdları";
            // 
            // btnSil
            // 
            btnSil.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnSil.Location = new Point(387, 528);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(119, 51);
            btnSil.TabIndex = 65;
            btnSil.Text = "Sil";
            btnSil.UseVisualStyleBackColor = true;
            btnSil.Click += btnSil_Click;
            // 
            // yeniRota
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(518, 591);
            Controls.Add(btnSil);
            Controls.Add(rotaAdlariLabel);
            Controls.Add(label2);
            Controls.Add(rotalarCombo);
            Controls.Add(btnTemizle);
            Controls.Add(btnKaydet);
            Controls.Add(flowLayoutPanelAltRotalar);
            Controls.Add(btnYeniRotaEkle);
            Controls.Add(label1);
            Controls.Add(txtRotaBaslik);
            Name = "yeniRota";
            Text = "yeniRota";
            Load += yeniRota_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtRotaBaslik;
        private Button btnYeniRotaEkle;
        private FlowLayoutPanel flowLayoutPanelAltRotalar;
        private Button btnKaydet;
        private Button btnTemizle;
        private ComboBox rotalarCombo;
        private Label label2;
        private Label rotaAdlariLabel;
        private Button btnSil;
    }
}