using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace OrderTracking
{
    public partial class databaseSave : Form
    {
        private System.Windows.Forms.Timer backupTimer;  // System.Timers yerine Windows.Forms.Timer kullanıyoruz
        private string connectionString = "Data Source=TETrA\\SQLEXPRESS;Initial Catalog=orderTracking;Integrated Security=True;Encrypt=False"; // Bağlantı dizesini ayarla

        public databaseSave()
        {
            InitializeComponent();
        }

        private void btnBackupNow_Click(object sender, EventArgs e)
        {
            string backupPath = txtBackupPath.Text;  // Yedekleme yolunu text kutusundan al
            if (!Directory.Exists(backupPath))
            {
                MessageBox.Show("Lütfen geçerli bir yedekleme yolu seçin.");
                return;
            }

            // Yeni bir klasör oluşturmak ve yedekleme işlemini başlatmak
            BackupDatabase(backupPath);
        }

        private void chkAutoBackup_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutoBackup.Checked)
            {
                TimeSpan interval = TimeSpan.FromDays(1); // Örneğin günlük yedekleme
                StartAutoBackup(interval, txtBackupPath.Text);
            }
            else
            {
                StopAutoBackup();
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    txtBackupPath.Text = folderDialog.SelectedPath;
                }
            }
        }

        private void BackupDatabase(string backupPath)
        {
            // Yedekleme için yeni klasör adını oluştur (tarih ve saat bilgisine göre)
            string folderName = $"Backup_{DateTime.Now:yyyyMMdd_HHmmss}";
            string fullBackupFolderPath = Path.Combine(backupPath, folderName);

            // Klasör yoksa oluştur
            if (!Directory.Exists(fullBackupFolderPath))
            {
                Directory.CreateDirectory(fullBackupFolderPath);
            }

            // Yedek dosyasının tam yolunu oluştur
            string backupFileName = Path.Combine(fullBackupFolderPath, $"DatabaseBackup.bak");

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string backupQuery = $"BACKUP DATABASE [orderTracking] TO DISK = '{backupFileName}'";

                    using (SqlCommand cmd = new SqlCommand(backupQuery, con))
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show($"Yedekleme tamamlandı: {backupFileName}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Yedekleme işlemi sırasında bir hata oluştu: {ex.Message}\nDetaylar: {ex.InnerException?.Message}");
            }
        }

        private void StartAutoBackup(TimeSpan interval, string backupPath)
        {
            if (backupTimer == null)
            {
                backupTimer = new System.Windows.Forms.Timer();
                backupTimer.Interval = (int)interval.TotalMilliseconds;
                backupTimer.Tick += (sender, e) => BackupDatabase(backupPath); // Tick event'i ile tetiklenecek
                backupTimer.Start();
            }
        }

        private void StopAutoBackup()
        {
            backupTimer?.Stop();
            backupTimer = null;  // Timer'ı durdurduktan sonra null'lamak iyidir
        }
    }
}
