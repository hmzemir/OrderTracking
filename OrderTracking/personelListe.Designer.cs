namespace OrderTracking
{
    partial class personelListe
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
            yetkiCombo = new ComboBox();
            label1 = new Label();
            personeladıTextbox = new TextBox();
            label2 = new Label();
            araBtn = new Button();
            personellerDGV = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)personellerDGV).BeginInit();
            SuspendLayout();
            // 
            // yetkiCombo
            // 
            yetkiCombo.FormattingEnabled = true;
            yetkiCombo.Location = new Point(25, 120);
            yetkiCombo.Name = "yetkiCombo";
            yetkiCombo.Size = new Size(121, 23);
            yetkiCombo.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Eras Demi ITC", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(25, 20);
            label1.Name = "label1";
            label1.Size = new Size(97, 18);
            label1.TabIndex = 76;
            label1.Text = "Personel Adı";
            // 
            // personeladıTextbox
            // 
            personeladıTextbox.BorderStyle = BorderStyle.FixedSingle;
            personeladıTextbox.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            personeladıTextbox.Location = new Point(25, 41);
            personeladıTextbox.Name = "personeladıTextbox";
            personeladıTextbox.Size = new Size(199, 27);
            personeladıTextbox.TabIndex = 75;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Eras Demi ITC", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(25, 99);
            label2.Name = "label2";
            label2.Size = new Size(43, 18);
            label2.TabIndex = 77;
            label2.Text = "Yetki";
            // 
            // araBtn
            // 
            araBtn.Font = new Font("Eras Medium ITC", 14.25F);
            araBtn.Location = new Point(25, 159);
            araBtn.Name = "araBtn";
            araBtn.Size = new Size(79, 32);
            araBtn.TabIndex = 78;
            araBtn.Text = "Ara";
            araBtn.UseVisualStyleBackColor = true;
            araBtn.Click += araBtn_Click;
            // 
            // personellerDGV
            // 
            personellerDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            personellerDGV.Location = new Point(274, 41);
            personellerDGV.Name = "personellerDGV";
            personellerDGV.Size = new Size(546, 437);
            personellerDGV.TabIndex = 79;
            // 
            // personelListe
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(861, 521);
            Controls.Add(personellerDGV);
            Controls.Add(araBtn);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(personeladıTextbox);
            Controls.Add(yetkiCombo);
            Name = "personelListe";
            Text = "personelListe";
            ((System.ComponentModel.ISupportInitialize)personellerDGV).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox yetkiCombo;
        private Label label1;
        private TextBox personeladıTextbox;
        private Label label2;
        private Button araBtn;
        private DataGridView personellerDGV;
    }
}