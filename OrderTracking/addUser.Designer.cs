namespace OrderTracking
{
    partial class addUser
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
            label34 = new Label();
            label2 = new Label();
            sıfreTextbox = new TextBox();
            label1 = new Label();
            kullanıcıadıTextbox = new TextBox();
            kullanıcıEkle = new Button();
            label3 = new Label();
            SuspendLayout();
            // 
            // label34
            // 
            label34.AutoSize = true;
            label34.Font = new Font("Eras Demi ITC", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label34.Location = new Point(81, 70);
            label34.Name = "label34";
            label34.Size = new Size(253, 43);
            label34.TabIndex = 53;
            label34.Text = "Kullanıcı Ekle";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Eras Demi ITC", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(104, 213);
            label2.Name = "label2";
            label2.Size = new Size(54, 18);
            label2.TabIndex = 61;
            label2.Text = "Parola";
            // 
            // sıfreTextbox
            // 
            sıfreTextbox.BorderStyle = BorderStyle.FixedSingle;
            sıfreTextbox.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            sıfreTextbox.Location = new Point(104, 234);
            sıfreTextbox.Name = "sıfreTextbox";
            sıfreTextbox.Size = new Size(199, 27);
            sıfreTextbox.TabIndex = 60;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Eras Demi ITC", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(104, 145);
            label1.Name = "label1";
            label1.Size = new Size(97, 18);
            label1.TabIndex = 59;
            label1.Text = "Kullanıcı Adı";
            // 
            // kullanıcıadıTextbox
            // 
            kullanıcıadıTextbox.BorderStyle = BorderStyle.FixedSingle;
            kullanıcıadıTextbox.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            kullanıcıadıTextbox.Location = new Point(104, 166);
            kullanıcıadıTextbox.Name = "kullanıcıadıTextbox";
            kullanıcıadıTextbox.Size = new Size(199, 27);
            kullanıcıadıTextbox.TabIndex = 58;
            // 
            // kullanıcıEkle
            // 
            kullanıcıEkle.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            kullanıcıEkle.Location = new Point(229, 277);
            kullanıcıEkle.Name = "kullanıcıEkle";
            kullanıcıEkle.Size = new Size(74, 34);
            kullanıcıEkle.TabIndex = 62;
            kullanıcıEkle.Text = "Ekle";
            kullanıcıEkle.UseVisualStyleBackColor = true;
            kullanıcıEkle.Click += kullanıcıEkle_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Cursor = Cursors.Hand;
            label3.Font = new Font("Eras Demi ITC", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(104, 287);
            label3.Name = "label3";
            label3.Size = new Size(89, 16);
            label3.TabIndex = 63;
            label3.Text = "Rastgele Şifre";
            label3.Click += label3_Click;
            // 
            // addUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(423, 459);
            Controls.Add(label3);
            Controls.Add(kullanıcıEkle);
            Controls.Add(label2);
            Controls.Add(sıfreTextbox);
            Controls.Add(label1);
            Controls.Add(kullanıcıadıTextbox);
            Controls.Add(label34);
            Name = "addUser";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "addUser";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label34;
        private Label label2;
        private TextBox sıfreTextbox;
        private Label label1;
        private TextBox kullanıcıadıTextbox;
        private Button kullanıcıEkle;
        private Label label3;
    }
}