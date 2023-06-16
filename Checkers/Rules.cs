using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Checkers
{
    public partial class Rules : Form
    {
        public Rules()
        {
            InitializeComponent();

            this.FormClosing += Rules_FormClosing;
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Rules_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }
    }
}
