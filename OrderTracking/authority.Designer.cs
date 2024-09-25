namespace OrderTracking
{
    partial class authority
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
            label2 = new Label();
            label1 = new Label();
            kullanıcıadıTextbox = new TextBox();
            yetkicombo = new ComboBox();
            kullanıcıEkle = new Button();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Eras Demi ITC", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(98, 160);
            label2.Name = "label2";
            label2.Size = new Size(111, 18);
            label2.TabIndex = 64;
            label2.Text = "Verilecek Yetki";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Eras Demi ITC", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(98, 92);
            label1.Name = "label1";
            label1.Size = new Size(97, 18);
            label1.TabIndex = 63;
            label1.Text = "Kullanıcı Adı";
            // 
            // kullanıcıadıTextbox
            // 
            kullanıcıadıTextbox.BorderStyle = BorderStyle.FixedSingle;
            kullanıcıadıTextbox.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            kullanıcıadıTextbox.Location = new Point(98, 113);
            kullanıcıadıTextbox.Name = "kullanıcıadıTextbox";
            kullanıcıadıTextbox.Size = new Size(199, 27);
            kullanıcıadıTextbox.TabIndex = 62;
            // 
            // yetkicombo
            // 
            yetkicombo.Font = new Font("Segoe UI", 11.25F);
            yetkicombo.FormattingEnabled = true;
            yetkicombo.Items.AddRange(new object[] { "Admin", "Kullanıcı" });
            yetkicombo.Location = new Point(98, 195);
            yetkicombo.Name = "yetkicombo";
            yetkicombo.Size = new Size(121, 28);
            yetkicombo.TabIndex = 65;
            // 
            // kullanıcıEkle
            // 
            kullanıcıEkle.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            kullanıcıEkle.Location = new Point(223, 283);
            kullanıcıEkle.Name = "kullanıcıEkle";
            kullanıcıEkle.Size = new Size(74, 34);
            kullanıcıEkle.TabIndex = 66;
            kullanıcıEkle.Text = "Ekle";
            kullanıcıEkle.UseVisualStyleBackColor = true;
            kullanıcıEkle.Click += kullanıcıEkle_Click;
            // 
            // authority
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(423, 459);
            Controls.Add(kullanıcıEkle);
            Controls.Add(yetkicombo);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(kullanıcıadıTextbox);
            Name = "authority";
            Text = "authority";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Label label1;
        private TextBox kullanıcıadıTextbox;
        private ComboBox yetkicombo;
        private Button kullanıcıEkle;
    }
}