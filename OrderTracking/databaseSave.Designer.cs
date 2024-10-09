namespace OrderTracking
{
    partial class databaseSave
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
            txtBackupPath = new TextBox();
            btnBrowse = new Button();
            label2 = new Label();
            btnBackupNow = new Button();
            dtpSchedule = new DateTimePicker();
            cmbBackupInterval = new ComboBox();
            chkAutoBackup = new CheckBox();
            label1 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // txtBackupPath
            // 
            txtBackupPath.BorderStyle = BorderStyle.FixedSingle;
            txtBackupPath.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            txtBackupPath.Location = new Point(29, 53);
            txtBackupPath.Name = "txtBackupPath";
            txtBackupPath.Size = new Size(199, 27);
            txtBackupPath.TabIndex = 54;
            // 
            // btnBrowse
            // 
            btnBrowse.Font = new Font("Eras Medium ITC", 14.25F);
            btnBrowse.Location = new Point(29, 86);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(123, 38);
            btnBrowse.TabIndex = 55;
            btnBrowse.Text = "Gözat";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Eras Medium ITC", 14.25F);
            label2.Location = new Point(29, 28);
            label2.Name = "label2";
            label2.Size = new Size(103, 22);
            label2.TabIndex = 56;
            label2.Text = "Dosya Yolu";
            // 
            // btnBackupNow
            // 
            btnBackupNow.Font = new Font("Eras Medium ITC", 14.25F);
            btnBackupNow.Location = new Point(168, 86);
            btnBackupNow.Name = "btnBackupNow";
            btnBackupNow.Size = new Size(153, 38);
            btnBackupNow.TabIndex = 57;
            btnBackupNow.Text = "Hemen Yedekle";
            btnBackupNow.UseVisualStyleBackColor = true;
            btnBackupNow.Click += btnBackupNow_Click;
            // 
            // dtpSchedule
            // 
            dtpSchedule.CalendarFont = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            dtpSchedule.Font = new Font("Century Gothic", 12F);
            dtpSchedule.Format = DateTimePickerFormat.Short;
            dtpSchedule.Location = new Point(29, 167);
            dtpSchedule.Name = "dtpSchedule";
            dtpSchedule.Size = new Size(121, 27);
            dtpSchedule.TabIndex = 58;
            // 
            // cmbBackupInterval
            // 
            cmbBackupInterval.Font = new Font("Eras Medium ITC", 12F, FontStyle.Italic);
            cmbBackupInterval.FormattingEnabled = true;
            cmbBackupInterval.Items.AddRange(new object[] { "Günlük", "Haftalık", "Aylık" });
            cmbBackupInterval.Location = new Point(29, 237);
            cmbBackupInterval.Name = "cmbBackupInterval";
            cmbBackupInterval.Size = new Size(121, 27);
            cmbBackupInterval.TabIndex = 59;
            // 
            // chkAutoBackup
            // 
            chkAutoBackup.AutoSize = true;
            chkAutoBackup.Font = new Font("Eras Medium ITC", 14.25F);
            chkAutoBackup.Location = new Point(29, 293);
            chkAutoBackup.Name = "chkAutoBackup";
            chkAutoBackup.Size = new Size(175, 26);
            chkAutoBackup.TabIndex = 60;
            chkAutoBackup.Text = "Otomatik Yedekle";
            chkAutoBackup.UseVisualStyleBackColor = true;
            chkAutoBackup.CheckedChanged += chkAutoBackup_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Eras Medium ITC", 14.25F);
            label1.Location = new Point(29, 212);
            label1.Name = "label1";
            label1.Size = new Size(150, 22);
            label1.TabIndex = 61;
            label1.Text = "Yedekleme Sıklıgı";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Eras Medium ITC", 14.25F);
            label3.Location = new Point(29, 142);
            label3.Name = "label3";
            label3.Size = new Size(167, 22);
            label3.TabIndex = 62;
            label3.Text = "Yedekleme Zamanı";
            // 
            // databaseSave
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(chkAutoBackup);
            Controls.Add(cmbBackupInterval);
            Controls.Add(dtpSchedule);
            Controls.Add(btnBackupNow);
            Controls.Add(label2);
            Controls.Add(btnBrowse);
            Controls.Add(txtBackupPath);
            Name = "databaseSave";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "databaseSave";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtBackupPath;
        private Button btnBrowse;
        private Label label2;
        private Button btnBackupNow;
        private DateTimePicker dtpSchedule;
        private ComboBox cmbBackupInterval;
        private CheckBox chkAutoBackup;
        private Label label1;
        private Label label3;
    }
}