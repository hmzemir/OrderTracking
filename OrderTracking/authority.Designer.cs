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
            label3 = new Label();
            yetkiliListeLabel = new Label();
            label4 = new Label();
            kullanıcılarLabel = new Label();
            yetkiEklebtn = new Button();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Eras Demi ITC", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(31, 102);
            label2.Name = "label2";
            label2.Size = new Size(111, 18);
            label2.TabIndex = 64;
            label2.Text = "Verilecek Yetki";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Eras Demi ITC", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(31, 28);
            label1.Name = "label1";
            label1.Size = new Size(97, 18);
            label1.TabIndex = 63;
            label1.Text = "Kullanıcı Adı";
            // 
            // kullanıcıadıTextbox
            // 
            kullanıcıadıTextbox.BorderStyle = BorderStyle.FixedSingle;
            kullanıcıadıTextbox.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            kullanıcıadıTextbox.Location = new Point(31, 63);
            kullanıcıadıTextbox.Name = "kullanıcıadıTextbox";
            kullanıcıadıTextbox.Size = new Size(199, 27);
            kullanıcıadıTextbox.TabIndex = 62;
            // 
            // yetkicombo
            // 
            yetkicombo.Font = new Font("Segoe UI", 11.25F);
            yetkicombo.FormattingEnabled = true;
            yetkicombo.Items.AddRange(new object[] { "Admin", "Kullanıcı" });
            yetkicombo.Location = new Point(31, 133);
            yetkicombo.Name = "yetkicombo";
            yetkicombo.Size = new Size(121, 28);
            yetkicombo.TabIndex = 65;
            yetkicombo.SelectedIndexChanged += yetkicombo_SelectedIndexChanged;
            // 
            // kullanıcıEkle
            // 
            kullanıcıEkle.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            kullanıcıEkle.Location = new Point(31, 183);
            kullanıcıEkle.Name = "kullanıcıEkle";
            kullanıcıEkle.Size = new Size(91, 35);
            kullanıcıEkle.TabIndex = 66;
            kullanıcıEkle.Text = "Yetki Ver";
            kullanıcıEkle.UseVisualStyleBackColor = true;
            kullanıcıEkle.Click += kullanıcıEkle_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Eras Demi ITC", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(31, 291);
            label3.Name = "label3";
            label3.Size = new Size(87, 23);
            label3.TabIndex = 67;
            label3.Text = "Yetkililer";
            // 
            // yetkiliListeLabel
            // 
            yetkiliListeLabel.AutoSize = true;
            yetkiliListeLabel.Font = new Font("Eras Light ITC", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            yetkiliListeLabel.Location = new Point(31, 324);
            yetkiliListeLabel.Name = "yetkiliListeLabel";
            yetkiliListeLabel.Size = new Size(58, 18);
            yetkiliListeLabel.TabIndex = 68;
            yetkiliListeLabel.Text = "Yetkililer";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Eras Demi ITC", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(31, 447);
            label4.Name = "label4";
            label4.Size = new Size(110, 23);
            label4.TabIndex = 69;
            label4.Text = "Kullanıcılar";
            // 
            // kullanıcılarLabel
            // 
            kullanıcılarLabel.AutoSize = true;
            kullanıcılarLabel.Font = new Font("Eras Light ITC", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            kullanıcılarLabel.Location = new Point(31, 481);
            kullanıcılarLabel.Name = "kullanıcılarLabel";
            kullanıcılarLabel.Size = new Size(73, 18);
            kullanıcılarLabel.TabIndex = 70;
            kullanıcılarLabel.Text = "kullanıcılar";
            // 
            // yetkiEklebtn
            // 
            yetkiEklebtn.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            yetkiEklebtn.Location = new Point(31, 229);
            yetkiEklebtn.Name = "yetkiEklebtn";
            yetkiEklebtn.Size = new Size(91, 35);
            yetkiEklebtn.TabIndex = 71;
            yetkiEklebtn.Text = "Yetki Ekle";
            yetkiEklebtn.UseVisualStyleBackColor = true;
            yetkiEklebtn.Click += yetkiEklebtn_Click;
            // 
            // authority
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1189, 617);
            Controls.Add(yetkiEklebtn);
            Controls.Add(kullanıcılarLabel);
            Controls.Add(label4);
            Controls.Add(yetkiliListeLabel);
            Controls.Add(label3);
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
        private Label label3;
        private Label yetkiliListeLabel;
        private Label label4;
        private Label kullanıcılarLabel;
        private Button yetkiEklebtn;
    }
}