using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Found XX number of students with that query.", "Filter Report", MessageBoxButtons.OK);
        }

        private Boolean once = true;
        private void button1_Click(object sender, EventArgs e)
        {
            if (once)
            {
                MessageBox.Show("Found student information file on XX.", "Search Query Report", MessageBoxButtons.OK);
                once = false;
            }
            else
            {
                MessageBox.Show("We couldn't find the file on XX student. Please check the ID No. and the Surname if it's correct.", "Search Query Report", MessageBoxButtons.OK);
                once = true;
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you sure you want to update the this student's information?", "Confirmation Required", MessageBoxButtons.YesNo);
        }

        private void button10_Click(object sender, EventArgs e)
        {
     
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form5 enroll = new Form5();
            enroll.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form6 info = new Form6();
            info.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Found X matches.", "Search Result", MessageBoxButtons.OK);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Found X matches.", "Search Result", MessageBoxButtons.OK);
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Listed all X students.", "Search Result", MessageBoxButtons.OK);
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Form6 sample = new Form6();
            sample.ShowDialog();
        }

        private void label6_Click(object sender, EventArgs e)
        {
        }

    }
}