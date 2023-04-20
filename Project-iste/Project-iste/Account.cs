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
    public partial class Account : Form
    {
        Write_Note Write = new Write_Note();
        Form1 form1 = new Form1();
        
        DataTable dt = new DataTable();
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\osama\source\repos\my_github\Usama-USKH\Project-iste\Project-iste\Database1.mdf;Integrated Security=True");

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
            NotePanel note1 = new NotePanel();
          //  note1.label1.Text = "Title Note";
            note1.Parent = flowLayoutPanel1;
        }

 

        private void Account_Load(object sender, EventArgs e)
        {
            label2.Text = Form1.userid;
            guna2GradientButton2.Enabled = false;
            guna2GradientButton1.Enabled = false;
            Write_Note write = new Write_Note();
            con.Open();
            string query = "select * from NoteWrite Where UserName = '" + label2.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adb = new SqlDataAdapter(cmd);
            adb.Fill(dt);
            con.Close();


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                NotePanel note1 = new NotePanel();
                note1.label1.Text = dt.Rows[i][2].ToString();
                note1.richTextBox1.Text = dt.Rows[i][3].ToString();
                note1.Parent = flowLayoutPanel1;
            }
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            
           
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Write_Note note2 = new Write_Note();
            note2.label1.Text = label2.Text;
            note2.ShowDialog();
        }
    }
}
