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
            btnYeniRotaEkle.Location = new Point(12, 369);
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
            flowLayoutPanelAltRotalar.Size = new Size(200, 100);
            flowLayoutPanelAltRotalar.TabIndex = 59;
            // 
            // btnKaydet
            // 
            btnKaydet.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnKaydet.Location = new Point(275, 312);
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
            btnTemizle.Location = new Point(275, 369);
            btnTemizle.Name = "btnTemizle";
            btnTemizle.Size = new Size(119, 51);
            btnTemizle.TabIndex = 61;
            btnTemizle.Text = "Temizle";
            btnTemizle.UseVisualStyleBackColor = true;
            btnTemizle.Click += btnTemizle_Click;
            // 
            // yeniRota
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(418, 441);
            Controls.Add(btnTemizle);
            Controls.Add(btnKaydet);
            Controls.Add(flowLayoutPanelAltRotalar);
            Controls.Add(btnYeniRotaEkle);
            Controls.Add(label1);
            Controls.Add(txtRotaBaslik);
            Name = "yeniRota";
            Text = "yeniRota";
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
    }
}