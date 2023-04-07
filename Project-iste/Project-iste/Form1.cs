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
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\osama\source\repos\my_github\donem-c#\proje\bahar-proje\bahar-proje\Database1.mdf;Integrated Security=True");
        SqlCommand com;
        public Form1()
        {
            InitializeComponent();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string user = guna2TextBox1.Text;
            string password = guna2TextBox2.Text;
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.CommandText = "Select * from Login where Username='" + guna2TextBox1.Text +
                "'And password='" + guna2TextBox2.Text + "'";
            SqlDataReader reader = com.ExecuteReader();
            if (reader.Read())
            {
                this.Hide();
                Account account = new Account();
                account.Show();
            }
            else
            {
                MessageBox.Show("Invaild Login Details!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                guna2TextBox1.Clear(); guna2TextBox2.Clear(); guna2TextBox1.Focus();
            }
            con.Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == "" || guna2TextBox2.Text == "" || guna2TextBox1.Text == " " || guna2TextBox1.Text == "  " || guna2TextBox1.Text == "   " || guna2TextBox2.Text == " " || guna2TextBox2.Text == "  " || guna2TextBox2.Text == "   ")
            {
                MessageBox.Show("please enter the required data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                con.Open();
                string query = "INSERT INTO Login (UserName , Password) VALUES(@UserName,@Password) ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserName", guna2TextBox1.Text);
                cmd.Parameters.AddWithValue("@Password", guna2TextBox2.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                guna2TextBox1.Clear(); guna2TextBox2.Clear(); guna2TextBox1.Focus();
                MessageBox.Show("user saved");
            }
        }
    }
}
