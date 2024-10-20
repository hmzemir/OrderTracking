namespace OrderTracking
{
    partial class addRole
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
            yetkiEklebtn = new Button();
            yetkiadıTextbox = new TextBox();
            label1 = new Label();
            yetkiListeLabel = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // yetkiEklebtn
            // 
            yetkiEklebtn.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            yetkiEklebtn.Location = new Point(33, 91);
            yetkiEklebtn.Name = "yetkiEklebtn";
            yetkiEklebtn.Size = new Size(91, 35);
            yetkiEklebtn.TabIndex = 73;
            yetkiEklebtn.Text = "Yetki Ekle";
            yetkiEklebtn.UseVisualStyleBackColor = true;
            // 
            // yetkiadıTextbox
            // 
            yetkiadıTextbox.BorderStyle = BorderStyle.FixedSingle;
            yetkiadıTextbox.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            yetkiadıTextbox.Location = new Point(33, 47);
            yetkiadıTextbox.Name = "yetkiadıTextbox";
            yetkiadıTextbox.Size = new Size(199, 27);
            yetkiadıTextbox.TabIndex = 72;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Eras Demi ITC", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(33, 26);
            label1.Name = "label1";
            label1.Size = new Size(71, 18);
            label1.TabIndex = 74;
            label1.Text = "Yetki Adı";
            // 
            // yetkiListeLabel
            // 
            yetkiListeLabel.AutoSize = true;
            yetkiListeLabel.Font = new Font("Eras Light ITC", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            yetkiListeLabel.Location = new Point(37, 190);
            yetkiListeLabel.Name = "yetkiListeLabel";
            yetkiListeLabel.Size = new Size(82, 18);
            yetkiListeLabel.TabIndex = 76;
            yetkiListeLabel.Text = "yetki isimleri";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Eras Demi ITC", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(37, 157);
            label3.Name = "label3";
            label3.Size = new Size(77, 23);
            label3.TabIndex = 75;
            label3.Text = "Yetkiler";
            // 
            // addRole
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(348, 312);
            Controls.Add(yetkiListeLabel);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(yetkiEklebtn);
            Controls.Add(yetkiadıTextbox);
            Name = "addRole";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "addRole";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button yetkiEklebtn;
        private TextBox yetkiadıTextbox;
        private Label label1;
        private Label yetkiListeLabel;
        private Label label3;
    }
}