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
        public Methods instance = new Methods();

        public Form5()
        {
            InitializeComponent();
            int year1 = DateTime.Now.Year;
            int year2 = year1 + 1;
            string sy = year1 + "-" + year2;
            textBox23.Text = sy;
        }

        //used by form6
        public void setID(int id_no)
        {
            textBox27.Text = id_no.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Are you sure you want to update this student's information?", "Confirmation Required", MessageBoxButtons.YesNo);
            if (answer == DialogResult.Yes)
            {
                int id_no = Convert.ToInt32(textBox27.Text);
                string name = textBox22.Text;
                string bday = comboBox9.Text+"-"+comboBox8.Text+"-"+comboBox7.Text;
                dataGridView1.Rows.Add(name, bday);
                instance.addSibling(id_no, name, bday);
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
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Student b = instance.findStudent(Convert.ToInt32(textBox27.Text));
            if (b.id_no == 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to enroll this student?", "Confirmation Required", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    createStudent();
                    Close();
                }
            }
            else
            {
                instance.deleteDetails(Convert.ToInt32(textBox27.Text));
                createStudent();
                MessageBox.Show("Details successfully updated.", "Update Successful", MessageBoxButtons.OK);
            }
        }

        public void createStudent()
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
            string dreceived = dateTimePicker2.Value.ToString("yyyy-MM-dd");
            string border = comboBox5.Text;
            string glevel = comboBox1.Text;
            string pscheme = "";
            foreach (Control ctrl in groupBox10.Controls)
            {
                if (ctrl.GetType() == typeof(RadioButton))
                {
                    if (((RadioButton)ctrl).Checked)
                        pscheme = ((RadioButton)ctrl).Text;
                }
            }
            string sy = textBox23.Text;
            string bday = comboBox2.Text + "-" + comboBox3.Text + "-" + comboBox4.Text;
            string pschool = richTextBox2.Text;
            string pgrade = textBox5.Text;
            string rstatus = "";

            foreach (Control ctrl in groupBox9.Controls)
            {
                if (ctrl.GetType() == typeof(CheckBox))
                {
                    if (((CheckBox)ctrl).Checked)
                        rstatus = "1" + rstatus;
                    else
                        rstatus = "0" + rstatus;
                }
            }

            string pstatus = richTextBox2.Text;

            instance.addStudent(id_no, fname, mname, lname, glevel, section, nickname, bday, sex, border, address, htel, otel, pschool, pgrade, dreceived, rstatus, pscheme, sy, pstatus);
            instance.addFather(id_no, textBox10.Text, textBox11.Text, textBox12.Text, textBox13.Text);
            instance.addMother(id_no, textBox14.Text, textBox15.Text, textBox16.Text, textBox17.Text);
            instance.addGuardian(id_no, textBox18.Text, textBox19.Text, textBox20.Text, textBox21.Text);

            //add sibling
        }

        public void updateStudent(int id_no)
        {
            Student a = instance.findStudent(id_no);
            textBox27.Text = Convert.ToString(a.id_no);
            textBox1.Text = a.lname;
            textBox2.Text = a.fname;
            textBox3.Text = a.mname;
            textBox4.Text = a.nickname;
            comboBox1.Text = a.glevel;
            textBox26.Text = a.section;
            comboBox2.Text = Convert.ToString(a.bday.Year);
            comboBox3.Text = Convert.ToString(a.bday.Month);
            comboBox4.Text = Convert.ToString(a.bday.Day);
            if (a.sex.ToLower() == "m")
                radioButton1.Checked = true;
            else if (a.sex.ToLower() == "f")
                radioButton2.Checked = true;
            comboBox5.Text = a.border;
            textBox6.Text = a.address;
            textBox7.Text = a.htel;
            textBox8.Text = a.otel;
            textBox5.Text = a.pschool;
            textBox9.Text = a.pgrade;
            textBox23.Text = a.sy;
            dateTimePicker2.Value = Convert.ToDateTime(a.rdate);

            //make this efficient
            if (a.rstatus.Substring(0,1) == "1")
                checkBox1.Checked = true;
            if (a.rstatus.Substring(1,1) == "1")
                checkBox2.Checked = true;
            if (a.rstatus.Substring(2,1) == "1")
                checkBox3.Checked = true;
            if (a.rstatus.Substring(3,1) == "1")
                checkBox4.Checked = true;
            if (a.rstatus.Substring(4,1) == "1")
                checkBox5.Checked = true;

            
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

            List<Sibling> coll = instance.findSiblings(id_no);
            dataGridView1.Rows.Clear();
            foreach (Sibling s in coll)
                dataGridView1.Rows.Add(s.name, Convert.ToString(s.bdate));

            foreach (Control ctrl in groupBox10.Controls)
            {
                if (ctrl.GetType() == typeof(RadioButton))
                {
                    if ( ((RadioButton)ctrl).Text.ToLower()==a.pscheme.ToLower() )
                        ((RadioButton)ctrl).Checked = true;
                }
            }

            richTextBox2.Text = a.paid;
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            //textBox29.Text;
        }
    }
}
