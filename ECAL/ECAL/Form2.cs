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
using System.Text.RegularExpressions;


namespace ECAL
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            textBox2.Validating += textBox2_Validating;
            textBox4.Validating += textBox4_Validating;
        }

        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        private void textBox2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string email = textBox2.Text;

            if (!IsValidEmail(email))
            {
                label9.Visible = true;
                textBox2.Clear();
                e.Cancel = true;
                textBox2.Focus();
            }
            else
            {
                label9.Visible = false;
            }
        }

        private void textBox4_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string password = textBox3.Text;   
            string confirmPassword = textBox4.Text; 

            if (confirmPassword != password)
            {
                label8.Visible = true; 
                textBox4.Clear();  
                e.Cancel = true;  
                textBox4.Focus();
            }
            else
            {
                label8.Visible = false; 
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                string connectionString = "Server=LAPTOP-TGI88RFU\\MSSQLSERVER01;Database=ecal_db;Integrated Security=True;";

                string query = "INSERT INTO users_tb (UserName, Email, Password) VALUES (@UserName, @Email, @Password)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserName", textBox1.Text);
                        command.Parameters.AddWithValue("@Email", textBox2.Text);
                        command.Parameters.AddWithValue("@Password", textBox3.Text);

                        try
                        {
                            connection.Open();

                            int result = command.ExecuteNonQuery();

                            if (result > 0)
                            {
                                MessageBox.Show("Registered successfully!");
                            }
                            else
                            {
                                MessageBox.Show("Registered unsuccessfully!");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An error occurred: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                label10.Visible = true;
                return;
            }
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
