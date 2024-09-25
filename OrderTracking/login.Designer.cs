namespace OrderTracking
{
    partial class login
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
            kullanıcıadıTextbox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            sifreTextbox = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // label34
            // 
            label34.AutoSize = true;
            label34.Font = new Font("Eras Demi ITC", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label34.Location = new Point(152, 64);
            label34.Name = "label34";
            label34.Size = new Size(119, 43);
            label34.TabIndex = 52;
            label34.Text = "Login";
            // 
            // kullanıcıadıTextbox
            // 
            kullanıcıadıTextbox.BorderStyle = BorderStyle.FixedSingle;
            kullanıcıadıTextbox.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            kullanıcıadıTextbox.Location = new Point(117, 182);
            kullanıcıadıTextbox.Name = "kullanıcıadıTextbox";
            kullanıcıadıTextbox.Size = new Size(199, 27);
            kullanıcıadıTextbox.TabIndex = 53;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Eras Demi ITC", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(117, 161);
            label1.Name = "label1";
            label1.Size = new Size(97, 18);
            label1.TabIndex = 54;
            label1.Text = "Kullanıcı Adı";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Eras Demi ITC", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(117, 229);
            label2.Name = "label2";
            label2.Size = new Size(54, 18);
            label2.TabIndex = 56;
            label2.Text = "Parola";
            // 
            // sifreTextbox
            // 
            sifreTextbox.BorderStyle = BorderStyle.FixedSingle;
            sifreTextbox.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            sifreTextbox.Location = new Point(117, 250);
            sifreTextbox.Name = "sifreTextbox";
            sifreTextbox.Size = new Size(199, 27);
            sifreTextbox.TabIndex = 55;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            button1.Location = new Point(152, 304);
            button1.Name = "button1";
            button1.Size = new Size(119, 51);
            button1.TabIndex = 57;
            button1.Text = "Giriş Yap";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(423, 459);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(sifreTextbox);
            Controls.Add(label1);
            Controls.Add(kullanıcıadıTextbox);
            Controls.Add(label34);
            Name = "login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label34;
        private TextBox kullanıcıadıTextbox;
        private Label label1;
        private Label label2;
        private TextBox sifreTextbox;
        private Button button1;
    }
}