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
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = true;
            dateTimePicker2.Enabled = true;
            textBox1.Enabled = false;

            DateTime lastReading = dateTimePicker1.Value;
            DateTime currentReading = dateTimePicker2.Value;

            num_of_days = (currentReading - lastReading).Days;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
            textBox1.Enabled = true;

            num_of_days = int.Parse(textBox1.Text);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = false;

            int previousMeterReading = int.Parse(textBox2.Text);
            int currentMeterReading = int.Parse(textBox3.Text);
            units = currentMeterReading - previousMeterReading;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = true;

            units = int.Parse(textBox4.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (num_of_days < 54)
            {
                if ((units / num_of_days) > 6)
                {
                    fixedCharge = 2000;
                    importCharge = (15 * num_of_days * 2) + (18 * num_of_days) + (30 * num_of_days) + (42 * num_of_days * 2) + (65 * (units - (num_of_days * 6)));
                    total = fixedCharge + importCharge;
                }
                else if ((units / num_of_days) > 4)
                {
                    fixedCharge = 1500;
                    importCharge = (15 * num_of_days * 2) + (18 * num_of_days) + (30 * num_of_days) + (42 * (units - (num_of_days * 4)));
                    total = fixedCharge + importCharge;
                }
                else if ((units / num_of_days) > 3)
                {
                    fixedCharge = 1000;
                    importCharge = (15 * num_of_days * 2) + (18 * num_of_days) + (30 * (units - (num_of_days * 3)));
                    total = fixedCharge + importCharge;
                }
                else if ((units / num_of_days) > 2)
                {
                    fixedCharge = 400;
                    importCharge = (15 * num_of_days * 2) + (18 * (units - (num_of_days * 2)));
                    total = fixedCharge + importCharge;
                }
                else if ((units / num_of_days) > 1)
                {
                    fixedCharge = 250;
                    importCharge = (6 * num_of_days) + (9 * (units - num_of_days));
                    total = fixedCharge + importCharge;
                }
                else
                {
                    fixedCharge = 100;
                    importCharge = 6 * units;
                    total = fixedCharge + importCharge;
                }
            }
            else
            {
                if ((units / num_of_days) > 6)
                {
                    fixedCharge = 2000 * (num_of_days / 30);
                    importCharge = (15 * num_of_days * 2) + (18 * num_of_days) + (30 * num_of_days) + (42 * num_of_days * 2) + (65 * (units - (num_of_days * 6)));
                    total = fixedCharge + importCharge;
                }
                else if ((units / num_of_days) > 4)
                {
                    fixedCharge = 1500 * (num_of_days / 30);
                    importCharge = (15 * num_of_days * 2) + (18 * num_of_days) + (30 * num_of_days) + (42 * (units - (num_of_days * 4)));
                    total = fixedCharge + importCharge;
                }
                else if ((units / num_of_days) > 3)
                {
                    fixedCharge = 1000 * (num_of_days / 30);
                    importCharge = (15 * num_of_days * 2) + (18 * num_of_days) + (30 * (units - (num_of_days * 3)));
                    total = fixedCharge + importCharge;
                }
                else if ((units / num_of_days) > 2)
                {
                    fixedCharge = 400 * (num_of_days / 30);
                    importCharge = (15 * num_of_days * 2) + (18 * (units - (num_of_days * 2)));
                    total = fixedCharge + importCharge;
                }
                else if ((units / num_of_days) > 1)
                {
                    fixedCharge = 250 * (num_of_days / 30);
                    importCharge = (6 * num_of_days) + (9 * (units - num_of_days));
                    total = fixedCharge + importCharge;
                }
                else
                {
                    fixedCharge = 100 * (num_of_days / 30);
                    importCharge = 6 * units;
                    total = fixedCharge + importCharge;
                }
            }
        }
    }
}
