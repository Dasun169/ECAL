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
    public partial class Form5 : Form
    {
        private int _num_of_days;
        private int _units;
        private float _importCharge;
        private float _fixedCharge;
        private float _total;
        private DateTime _lastReading;
        private DateTime _currentReading;
        public Form5(int num_of_days, int units, float importCharge, float fixedCharge, float total)
        {
            InitializeComponent();
            _num_of_days = num_of_days;
            _units = units;
            _importCharge = importCharge;
            _fixedCharge = fixedCharge;
            _total = total;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            label1.Text = _num_of_days.ToString();
            label2.Text = _units.ToString();
            label3.Text = "Rs." + _importCharge.ToString("F2");
            label4.Text = "Rs." + _fixedCharge.ToString("F2");
            label5.Text = "Rs." + _total.ToString("F2");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_calculate_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }

        private void btn_history_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
            this.Hide();
        }
    }
}
