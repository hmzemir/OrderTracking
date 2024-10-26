namespace OrderTracking
{
    partial class roleConfig
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
            yetkilerCombo = new ComboBox();
            kayitBtn = new Button();
            sayfalarPanel = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Eras Medium ITC", 14.25F);
            label1.Location = new Point(35, 25);
            label1.Name = "label1";
            label1.Size = new Size(82, 22);
            label1.TabIndex = 52;
            label1.Text = "Yetki Seç";
            // 
            // yetkilerCombo
            // 
            yetkilerCombo.Font = new Font("Eras Medium ITC", 12F, FontStyle.Italic);
            yetkilerCombo.FormattingEnabled = true;
            yetkilerCombo.Location = new Point(35, 50);
            yetkilerCombo.Name = "yetkilerCombo";
            yetkilerCombo.Size = new Size(121, 27);
            yetkilerCombo.TabIndex = 53;
            yetkilerCombo.SelectedIndexChanged += yetkilerCombo_SelectedIndexChanged;
            // 
            // kayitBtn
            // 
            kayitBtn.Font = new Font("Eras Medium ITC", 14.25F);
            kayitBtn.Location = new Point(35, 467);
            kayitBtn.Name = "kayitBtn";
            kayitBtn.Size = new Size(79, 32);
            kayitBtn.TabIndex = 79;
            kayitBtn.Text = "Kaydet";
            kayitBtn.UseVisualStyleBackColor = true;
            kayitBtn.Click += kayitBtn_Click;
            // 
            // sayfalarPanel
            // 
            sayfalarPanel.Location = new Point(35, 97);
            sayfalarPanel.Name = "sayfalarPanel";
            sayfalarPanel.Size = new Size(185, 364);
            sayfalarPanel.TabIndex = 80;
            // 
            // roleConfig
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 520);
            Controls.Add(sayfalarPanel);
            Controls.Add(kayitBtn);
            Controls.Add(yetkilerCombo);
            Controls.Add(label1);
            Name = "roleConfig";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "roleConfig";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private ComboBox yetkilerCombo;
        private Button kayitBtn;
        private FlowLayoutPanel sayfalarPanel;
    }
}