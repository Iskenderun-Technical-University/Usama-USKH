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
    public partial class NotePanel : UserControl
    {
        public NotePanel()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Write_Note note = new Write_Note();
            note.ShowDialog();
        }
    }
}
