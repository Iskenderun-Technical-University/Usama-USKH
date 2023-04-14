using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_iste
{
    public partial class Account : Form
    {
        public Account()
        {
            InitializeComponent();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            NotePanel note = new NotePanel();
            note.label1.Text = "Title Note";
            note.Parent = flowLayoutPanel1;
        }

        private void Account_Load(object sender, EventArgs e)
        {
            for(int i= 0; i < 5; i++)
            {
                guna2GradientButton1.PerformClick();

            }
        }
    }
}
