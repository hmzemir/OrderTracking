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
            textBox2 = new TextBox();
            label1 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
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
            // textBox2
            // 
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            textBox2.Location = new Point(104, 234);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(199, 27);
            textBox2.TabIndex = 60;
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
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            textBox1.Location = new Point(104, 166);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(199, 27);
            textBox1.TabIndex = 58;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            button1.Location = new Point(229, 277);
            button1.Name = "button1";
            button1.Size = new Size(74, 34);
            button1.TabIndex = 62;
            button1.Text = "Ekle";
            button1.UseVisualStyleBackColor = true;
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
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(label1);
            Controls.Add(textBox1);
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
        private TextBox textBox2;
        private Label label1;
        private TextBox textBox1;
        private Button button1;
        private Label label3;
    }
}