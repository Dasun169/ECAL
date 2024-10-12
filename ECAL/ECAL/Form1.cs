using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ECAL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=LAPTOP-TGI88RFU\\MSSQLSERVER01;Database=ecal_db;Integrated Security=True;";
            string username = textBox1.Text;
            string password = textBox2.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Password FROM users_tb WHERE UserName = @UserName";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", username);

                    var result = command.ExecuteScalar();

                    if (result == null)
                    {
                        label4.Visible = true;
                        textBox1.Clear();
                        textBox1.Focus();
                        textBox2.Clear();
                    }
                    else
                    {
                        label4.Visible = false;
                        string storedPassword = result.ToString();
                        if (password != storedPassword)
                        {
                            label5.Visible = true;
                            textBox2.Clear();
                            textBox2.Focus();
                        }
                        else
                        {
                            label5.Visible = false;

                            Form3 form3 = new Form3(username);
                            form3.Show();
                            this.Hide();
                        }
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label4.Visible = false;
            label5.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
