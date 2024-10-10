using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ECAL
{
    public partial class Form3 : Form
    {
        int num_of_days = 0;
        int units = 0;
        int importCharge = 0;
        int fixedCharge = 0;
        int total = 0;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
                textBox1.Enabled = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
                textBox1.Enabled = true;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = false;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                try
                {
                    DateTime lastReading = dateTimePicker1.Value;
                    DateTime currentReading = dateTimePicker2.Value;

                    if (lastReading >= currentReading)
                    {
                        throw new Exception("The last reading date must be earlier than the current reading date.");
                    }

                    num_of_days = (currentReading - lastReading).Days;

                    if (num_of_days == 0)
                    {
                        throw new Exception("The number of days cannot be zero.");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Date Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (radioButton2.Checked)
            {
                try
                {
                    num_of_days = int.Parse(textBox1.Text);

                    if (num_of_days == 0)
                    {
                        throw new Exception("The number of days cannot be zero.");
                    }

                }
                catch (FormatException)
                {
                    MessageBox.Show("Please enter valid integer values for the number of days.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (radioButton4.Checked)
            {
                try
                {
                    int previousMeterReading = int.Parse(textBox2.Text);
                    int currentMeterReading = int.Parse(textBox3.Text);

                    units = currentMeterReading - previousMeterReading;

                    if (units < 0)
                    {
                        throw new Exception("Current meter reading must be greater than previous meter reading.");
                    }

                }
                catch (FormatException)
                {
                    MessageBox.Show("Please enter valid integer values for the meter readings.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (radioButton3.Checked)
            {
                try
                {
                    units = int.Parse(textBox4.Text);

                    if (units < 0)
                    {
                        throw new Exception("Units cannot be negative.");
                    }

                }
                catch (FormatException)
                {
                    MessageBox.Show("Please enter valid integer values for units.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (num_of_days <= 0)
            {
                MessageBox.Show("The number of days must be greater than zero to calculate the bill.", "Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit if num_of_days is zero or negative
            }

            if (num_of_days < 54)
            {
                if ((units / num_of_days) > 6)
                {
                    fixedCharge = 2000;
                    importCharge = (15 * num_of_days * 2) + (18 * num_of_days) + (30 * num_of_days) + (42 * num_of_days * 2) + (65 * (units - (num_of_days * 6)));
                    total = fixedCharge + importCharge;

                    MessageBox.Show("Total fee : " + total, "Electricity Bill Fee");
                }
                else if ((units / num_of_days) > 4)
                {
                    fixedCharge = 1500;
                    importCharge = (15 * num_of_days * 2) + (18 * num_of_days) + (30 * num_of_days) + (42 * (units - (num_of_days * 4)));
                    total = fixedCharge + importCharge;

                    MessageBox.Show("Total fee : " + total, "Electricity Bill Fee");
                }
                else if ((units / num_of_days) > 3)
                {
                    fixedCharge = 1000;
                    importCharge = (15 * num_of_days * 2) + (18 * num_of_days) + (30 * (units - (num_of_days * 3)));
                    total = fixedCharge + importCharge;

                    MessageBox.Show("Total fee : " + total, "Electricity Bill Fee");
                }
                else if ((units / num_of_days) > 2)
                {
                    fixedCharge = 400;
                    importCharge = (15 * num_of_days * 2) + (18 * (units - (num_of_days * 2)));
                    total = fixedCharge + importCharge;

                    MessageBox.Show("Total fee : " + total, "Electricity Bill Fee");
                }
                else if ((units / num_of_days) > 1)
                {
                    fixedCharge = 250;
                    importCharge = (6 * num_of_days) + (9 * (units - num_of_days));
                    total = fixedCharge + importCharge;

                    MessageBox.Show("Total fee : " + total, "Electricity Bill Fee");
                }
                else
                {
                    fixedCharge = 100;
                    importCharge = 6 * units;
                    total = fixedCharge + importCharge;

                    MessageBox.Show("Total fee : " + total, "Electricity Bill Fee");
                }
            }
            else
            {
                if ((units / num_of_days) > 6)
                {
                    fixedCharge = 2000 * (num_of_days / 30);
                    importCharge = (15 * num_of_days * 2) + (18 * num_of_days) + (30 * num_of_days) + (42 * num_of_days * 2) + (65 * (units - (num_of_days * 6)));
                    total = fixedCharge + importCharge;

                    MessageBox.Show("Total fee : " + total, "Electricity Bill Fee");
                }
                else if ((units / num_of_days) > 4)
                {
                    fixedCharge = 1500 * (num_of_days / 30);
                    importCharge = (15 * num_of_days * 2) + (18 * num_of_days) + (30 * num_of_days) + (42 * (units - (num_of_days * 4)));
                    total = fixedCharge + importCharge;

                    MessageBox.Show("Total fee : " + total, "Electricity Bill Fee");
                }
                else if ((units / num_of_days) > 3)
                {
                    fixedCharge = 1000 * (num_of_days / 30);
                    importCharge = (15 * num_of_days * 2) + (18 * num_of_days) + (30 * (units - (num_of_days * 3)));
                    total = fixedCharge + importCharge;

                    MessageBox.Show("Total fee : " + total, "Electricity Bill Fee");
                }
                else if ((units / num_of_days) > 2)
                {
                    fixedCharge = 400 * (num_of_days / 30);
                    importCharge = (15 * num_of_days * 2) + (18 * (units - (num_of_days * 2)));
                    total = fixedCharge + importCharge;

                    MessageBox.Show("Total fee : " + total, "Electricity Bill Fee");
                }
                else if ((units / num_of_days) > 1)
                {
                    fixedCharge = 250 * (num_of_days / 30);
                    importCharge = (6 * num_of_days) + (9 * (units - num_of_days));
                    total = fixedCharge + importCharge;

                    MessageBox.Show("Total fee : " + total, "Electricity Bill Fee");
                }
                else
                {
                    fixedCharge = 100 * (num_of_days / 30);
                    importCharge = 6 * units;
                    total = fixedCharge + importCharge;

                    MessageBox.Show("Total fee : " + total, "Electricity Bill Fee");
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
