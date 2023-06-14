using System.Diagnostics;
using System;
using System.Windows.Forms;

namespace Checkers
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string guideFilePath = @"C:\User\artem\Source\Repos\Checkers\Checkers\Shashki.gui"; // Замените путь на полный путь к файлу guide.gui

            if (System.IO.File.Exists(guideFilePath))
            {
                Process.Start(guideFilePath);
            }
            else
            {
                MessageBox.Show("Guide file not found.");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void GameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Отображаем форму главного меню после закрытия формы игры
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
