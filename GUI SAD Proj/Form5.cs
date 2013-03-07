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
        }

        private void button6_Click(object sender, EventArgs e)
        {
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

        private void button5_Click(object sender, EventArgs e)
        {
            Student b = instance.findStudent(Convert.ToInt32(textBox27.Text));
            if (b.id_no == 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to enroll this student?", "Confirmation Required", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
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
                    string dreceived = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                    //other contacts
                    //glevel, border, pscheme, sy, and paid is ??
                    //missing birthday, birth order, previous school name, previous school grade, date received, requirement status
                    string border = comboBox5.Text;
                    string glevel = comboBox1.Text;
                    string pscheme = "1";
                    string sy = "1";
                    string bday = comboBox2.Text + "-" + comboBox3.Text + "-" + comboBox4.Text;
                    string pschool = "STC";
                    string pgrade = "2";
                    string rstatus = "yes";
                    string pstatus = "yes";

                    instance.addStudent(id_no, fname, mname, lname, glevel, section, nickname, bday, sex, border, address, htel, otel, pschool, pgrade, dreceived, rstatus, pscheme, sy, pstatus);
                    instance.addFather(Convert.ToInt32(textBox27.Text), textBox10.Text, textBox11.Text, textBox12.Text, textBox13.Text);
                    instance.addMother(Convert.ToInt32(textBox27.Text), textBox14.Text, textBox15.Text, textBox16.Text, textBox17.Text);
                    //instance.addGuardian(Convert.ToInt32(textBox18.Text), textBox18.Text, textBox19.Text, textBox20.Text, textBox21.Text);

                    MessageBox.Show("Details successfully updated.", "Update Successful", MessageBoxButtons.OK);
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Details successfully updated.", "Update Successful", MessageBoxButtons.OK);
            }
        }

        public void updateStudent()
        {
            int id_no = 103523;
            Student a = instance.findStudent(id_no);
            textBox27.Text = Convert.ToString(a.id_no);
            textBox1.Text = a.lname;
            textBox2.Text = a.fname;
            textBox3.Text = a.mname;
            comboBox1.Text = a.glevel;
            textBox26.Text = a.section;
            comboBox2.Text = Convert.ToString(a.bday.Year);
            comboBox3.Text = Convert.ToString(a.bday.Month);
            comboBox4.Text = Convert.ToString(a.bday.Day);
            if (a.sex == "male")
                radioButton1.Checked = true;
            else
                radioButton2.Checked = true;
            comboBox5.Text = a.border;
            textBox6.Text = a.address;
            textBox7.Text = a.htel;
            textBox8.Text = a.otel;

            Father f = instance.findFather(id_no);
            textBox10.Text = f.name;
            textBox11.Text = f.contact_no;
            textBox12.Text = f.address;
            textBox13.Text = f.occupation;

            Mother m = instance.findMother(id_no);
            textBox14.Text = m.name;
            textBox15.Text = m.contact_no;
            textBox16.Text = m.address;
            textBox17.Text = m.occupation;

            Guardian q = instance.findGuardian(id_no);
            textBox18.Text = q.name;
            textBox19.Text = q.contact_no;
            textBox20.Text = q.address;
            textBox21.Text = q.occupation;


        }        
    }
}
