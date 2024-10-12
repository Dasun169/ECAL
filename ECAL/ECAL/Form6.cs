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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ECAL
{
    public partial class Form6 : Form
    {
        string user_name;
        public Form6(string userName)
        {
            InitializeComponent();
            user_name = userName;
        }
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            RetrieveAndDisplayData(user_name);
        }

        private void RetrieveAndDisplayData(string username)
        {
            string connectionString = "Server=LAPTOP-TGI88RFU\\MSSQLSERVER01;Database=ecal_db;Integrated Security=True;";
            string query = "SELECT LastReading, CurrentReading, Units, TotalFee FROM history_tb WHERE UserName = @UserName";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", username);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        flowLayoutPanel1.Controls.Clear(); // Clear previous controls

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                // Create a panel for each record to group the labels
                                Panel panel = new Panel
                                {
                                    Width = 310, // Slightly less than the form's width
                                    Height = 100, // Adjust height as necessary
                                    BorderStyle = BorderStyle.FixedSingle,
                                    Margin = new Padding(5) // Add some margin around the panel
                                };

                                // Assuming reader["LastReading"] and reader["CurrentReading"] are DateTime objects
                                DateTime lastReadingDate = Convert.ToDateTime(reader["LastReading"]);
                                DateTime currentReadingDate = Convert.ToDateTime(reader["CurrentReading"]);

                                // Format the labels
                                Label lastReadingLabel = new Label
                                {
                                    Text = $"Last Reading: {lastReadingDate.ToShortDateString()}", // Displays only the date
                                    AutoSize = true,
                                    Location = new Point(10, 10) // Set position within the panel
                                };

                                Label currentReadingLabel = new Label
                                {
                                    Text = $"Current Reading: {currentReadingDate.ToShortDateString()}", // Displays only the date
                                    AutoSize = true,
                                    Location = new Point(10, 30)
                                };

                                // Format units as kWh (assuming reader["Units"] is an integer)
                                int units = Convert.ToInt32(reader["Units"]);
                                Label unitsLabel = new Label
                                {
                                    Text = $"Consumed Units: {units} kWh", // Display units in kWh format
                                    AutoSize = true,
                                    Location = new Point(10, 50)
                                };

                                // Format total fee to display currency (assuming reader["TotalFee"] is a decimal or double)
                                decimal totalFee = Convert.ToDecimal(reader["TotalFee"]);
                                Label totalFeeLabel = new Label
                                {
                                    Text = $"Monthly Fee/LKR: Rs.{totalFee:F2}", // Display total fee in Rs.1000.00 format
                                    AutoSize = true,
                                    Location = new Point(10, 70)
                                };

                                // Add the labels to the panel (assuming you have a FlowLayoutPanel named flowLayoutPanel)
                                panel.Controls.Add(lastReadingLabel);
                                panel.Controls.Add(currentReadingLabel);
                                panel.Controls.Add(unitsLabel);
                                panel.Controls.Add(totalFeeLabel);


                                flowLayoutPanel1.Controls.Add(panel);
                            }
                        }
                        else
                        {
                            MessageBox.Show("No records found for this user.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btn_history_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
