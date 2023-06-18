using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.IO;

namespace Checkers
{
    public partial class MainMenu : Form
    {
        public static bool IsRestart { get; set; }
        public MainMenu()
        {
            InitializeComponent();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Text = "Шашки";
            IsRestart = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tempFolderPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(tempFolderPath);
            byte[] guiFileBytes = Properties.Resources.Shashki;
            string filePath = Path.Combine(tempFolderPath, "fag.gui");
            File.WriteAllBytes(filePath, guiFileBytes);

            if (System.IO.File.Exists(filePath))
            {
                Process.Start(filePath);
            }
            else
            {
                MessageBox.Show("Guide file not found.");
            }
        }


        public void GameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Отображаем форму главного меню после закрытия формы игры
            if(!IsRestart)
                this.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Game gameForm = new Game();
            gameForm.FormClosed += GameForm_FormClosed;

            // Отображаем форму игры
            gameForm.Show();
            this.Hide();
        }

        private void RulesForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Отображаем форму главного меню после закрытия формы игры
            this.Show();
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            Rules rulesForm = new Rules();
            rulesForm.FormClosed += RulesForm_FormClosed;

            // Отображаем форму игры
            rulesForm.Show();
            this.Hide();
        }
    }
}
