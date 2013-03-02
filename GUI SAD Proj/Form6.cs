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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form5 enroll = new Form5();
            enroll.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you sure you want to update this?", "Confirmation Required", MessageBoxButtons.YesNo);
            MessageBox.Show("Misconduct successfully updated.", "Update Successful", MessageBoxButtons.OK);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you sure you want to update this?", "Confirmation Required", MessageBoxButtons.YesNo);
            MessageBox.Show("Subject successfully added.", "Update Successful", MessageBoxButtons.OK);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you sure you want to update this?", "Confirmation Required", MessageBoxButtons.YesNo);
            MessageBox.Show("Subject successfully deleted.", "Update Successful", MessageBoxButtons.OK);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you sure you want to update this?", "Confirmation Required", MessageBoxButtons.YesNo);
            MessageBox.Show("Subject successfully edited.", "Update Successful", MessageBoxButtons.OK);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you sure you want to update this?", "Confirmation Required", MessageBoxButtons.YesNo);
            MessageBox.Show("Subject successfully added.", "Update Successful", MessageBoxButtons.OK);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you sure you want to update this?", "Confirmation Required", MessageBoxButtons.YesNo);
            MessageBox.Show("Subject successfully edited.", "Update Successful", MessageBoxButtons.OK);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you sure you want to update this?", "Confirmation Required", MessageBoxButtons.YesNo);
            MessageBox.Show("Subject successfully deleted.", "Update Successful", MessageBoxButtons.OK);
        }
    }
}
