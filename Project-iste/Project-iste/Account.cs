using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Project_iste
{
    public partial class Account : Form
    {
        public static Account account = new Account();
        Write_Note Write = new Write_Note();
        Form1 form1 = new Form1();
        
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\osama\source\repos\my_github\Usama-USKH\Project-iste\Project-iste\Database1.mdf;Integrated Security=True");

        public Account()
        {
            InitializeComponent();
        }

        public static bool check(string str)
        {
            return (String.IsNullOrEmpty(str) ||
                str.Trim().Length == 0) ? true : false;
        }


        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            Write_Note note = new Write_Note();
            note.ShowDialog();
        }

 

        private void Account_Load(object sender, EventArgs e)
        {
            label2.Text = Form1.userid;
            Write_Note write = new Write_Note();
            con.Open();
            string query = "select * from NoteWrite Where UserName = '" + label2.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adb = new SqlDataAdapter(cmd);
            adb.Fill(dt);
            string query2 = "select Title from NoteWrite Where UserName = '" + label2.Text.ToString() + "'";
            SqlCommand cmd2 = new SqlCommand(query2, con);
            SqlDataAdapter adb2 = new SqlDataAdapter(cmd2);
            adb2.Fill(dt2);
            foreach (DataRow dr in dt2.Rows)
            {
                comboBox1.Items.Add(dr["Title"].ToString());
            }
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
            flowLayoutPanel1.Controls.Clear();
            comboBox1.Items.Clear();
            con.Open();
            string query2 = "select Title from NoteWrite Where UserName = '" + label2.Text.ToString() + "'";
            SqlCommand cmd = new SqlCommand(query2, con);
            SqlDataAdapter adb = new SqlDataAdapter(cmd);
            adb.Fill(dt3);
            foreach (DataRow dr in dt3.Rows)
            {
                comboBox1.Items.Add(dr["Title"].ToString());
            }
            con.Close();
            dt3.Clear();
            

        }


        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if(check(comboBox1.Text) == true)
            {
                MessageBox.Show("You can't Delete Nothing!!","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                con.Open();
                string query = "Delete from NoteWrite Where Title = '" + comboBox1.Text.ToString() + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Deleted Successfully please Refresh The Form To See Your Update!!!");

                this.Close();
                Account account= new Account();
                account.Show();
            }
         
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
         
        }

         

    }
}
