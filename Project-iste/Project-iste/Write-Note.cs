using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_iste
{
    public partial class Write_Note : Form
    {
        NotePanel note = new NotePanel();
       
        public Write_Note()
        {
            InitializeComponent();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Write_Note_Load(object sender, EventArgs e)
        {
            guna2TextBox1.Text = note.label1.Text;
        }
    }
}
