using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SchoolClass;

namespace WindowsFormsApplication1
{
    public partial class Form5 : Form
    {
        Methods instance = new Methods();
        public Form5()
        {
            InitializeComponent();
            textBox27.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {


            MessageBox.Show("Are you sure you want to enroll this student?", "Confirmation Required", MessageBoxButtons.YesNo);
            //confirm first before proceeding
                int id_no = Convert.ToInt32(textBox27.Text);
                string lname = textBox1.Text;
                string fname = textBox2.Text;
                string mname = textBox3.Text;
                string section = textBox26.Text;
                string nickname = textBox4.Text;
                string sex = "";
                if (radioButton1.Checked)
                    sex = "m";
                else
                    sex = "f";
                string address = textBox6.Text;
                string htel = textBox7.Text;
                string otel = textBox8.Text;
                //other contacts
                //glevel, border, pscheme, sy, and paid is ??
                //missing birthday, birth order, previous school name, previous school grade, date received, requirement status
                string border = "1";
                string glevel = "2";
                string pscheme = "1";
                string sy = "1";
                string bday = comboBox2.Text + "-" + comboBox3.Text + "-" + comboBox4.Text;
                string pschool = "STC";
                string pgrade = "2";
                DateTime drecei = new DateTime(2013, 11, 11);
                string dreceived = drecei.ToString("yyyy-MM-dd");
                string rstatus = "yes";
                string pstatus = "yes";

                instance.addStudent(id_no,fname,mname,lname,glevel,section,nickname,bday,sex,border,address,htel,otel,pschool,pgrade,dreceived,rstatus,pscheme,sy,pstatus);

                MessageBox.Show("Details successfully updated.", "Update Successful", MessageBoxButtons.OK);
                Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you sure you want to update this student's information?", "Confirmation Required", MessageBoxButtons.YesNo);
            if (DialogResult == DialogResult.Yes)
            {
                MessageBox.Show("Details successfully updated.", "Update Successful", MessageBoxButtons.OK);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you sure you want to update this student's information?", "Confirmation Required", MessageBoxButtons.YesNo);
            if (DialogResult == DialogResult.Yes)
            {
                MessageBox.Show("Details successfully updated.", "Update Successful", MessageBoxButtons.OK);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you sure you want to update this student's information?", "Confirmation Required", MessageBoxButtons.YesNo);
            if (DialogResult == DialogResult.Yes)
            {
                MessageBox.Show("Details successfully updated.", "Update Successful", MessageBoxButtons.OK);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you sure you want to update this student's information?", "Confirmation Required", MessageBoxButtons.YesNo);
            if (DialogResult == DialogResult.Yes)
            {
                MessageBox.Show("Details successfully updated.", "Update Successful", MessageBoxButtons.OK);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you sure you want to update this student's information?", "Confirmation Required", MessageBoxButtons.YesNo);
            if (DialogResult == DialogResult.Yes)
            {
                MessageBox.Show("Details successfully updated.", "Update Successful", MessageBoxButtons.OK);
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you sure you want to update this student's information?", "Confirmation Required", MessageBoxButtons.YesNo);
            if (DialogResult == DialogResult.Yes)
            {
                MessageBox.Show("Details successfully updated.", "Update Successful", MessageBoxButtons.OK);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form7 paymentinfo = new Form7();
            paymentinfo.ShowDialog();
        }

        
    }
}
