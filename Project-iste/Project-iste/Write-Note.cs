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
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\osama\source\repos\my_github\Usama-USKH\Project-iste\Project-iste\Database1.mdf;Integrated Security=True");
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
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

           con.Open();
           string query = "select Title from NoteWrite Where UserName = '" + label1.Text +"'";
           SqlCommand cmd = new SqlCommand(query,con);
           SqlDataAdapter adb = new SqlDataAdapter(cmd);
           adb.Fill(dt);
           con.Close();

           foreach(DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["Title"].ToString());
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "select Subject from NoteWrite Where Title = '" + comboBox1.Text + "'";
            SqlCommand cmd2 = new SqlCommand(query, con);
            SqlDataAdapter adb2 = new SqlDataAdapter(cmd2);
            adb2.Fill(dt2);
            con.Close();
            richTextBox1.Text = dt2.Rows[0][0].ToString();
        }
    }
}
