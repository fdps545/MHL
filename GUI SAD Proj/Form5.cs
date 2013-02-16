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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Details successfully updated.", "Update Successful", MessageBoxButtons.OK);
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sibling info successfully added.", "Update Successful", MessageBoxButtons.OK);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("School info successfully deleted.", "Update Successful", MessageBoxButtons.OK);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sibling info successfully edited.", "Update Successful", MessageBoxButtons.OK);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sibling info successfully deleted.", "Update Successful", MessageBoxButtons.OK);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("School info successfully added.", "Update Successful", MessageBoxButtons.OK);

        }

        private void button9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("School info successfully editted.", "Update Successful", MessageBoxButtons.OK);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form7 paymentinfo = new Form7();
            paymentinfo.ShowDialog();
        }
    }
}
