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
    public partial class Form2 : Form
    {
        Methods instance;

        public Form2()
        {
            instance = new Methods();
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
            if (DialogResult == DialogResult.Yes)
            {
                MessageBox.Show("Details successfully updated.", "Update Successful", MessageBoxButtons.OK);
            }
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
            string type = "";
            string input = "";
            if (textBox1.Text == "" && textBox2.Text == "")
            {
                MessageBox.Show("Please type the ID number or the surname.", "Error", MessageBoxButtons.OK);
            }
            else if (textBox1.Text == "")
            {
                type = "last_name";
                input = textBox2.Text;
                listIt(instance.querySearch(type, input));
            }
            else
            {
                type = "id_number";
                input = textBox1.Text;
                listIt(instance.querySearch(type, input));
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            listIt(instance.filter(comboBox4.Text, comboBox5.Text, comboBox6.Text));
            MessageBox.Show("Found X matches.", "Search Result", MessageBoxButtons.OK);
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            listIt(instance.listAll());
            MessageBox.Show("Listed all X students.", "Search Result", MessageBoxButtons.OK);
        }

        public void listIt(List<Student> student_coll)
        {
            dataGridView1.Rows.Clear();
            foreach (Student a in student_coll)
                dataGridView1.Rows.Add(a.id_no, a.lname, a.fname, a.glevel, a.section, a.paid);
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            //search this
            int id_no = 103523;
            Student a = instance.findStudent(id_no);
            Form6 sample = new Form6();
            string name = a.lname + ", " + a.fname + " " + a.mname;
            sample.updateIt(name, a.id_no);
            sample.ShowDialog();
        }

        private void label6_Click(object sender, EventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
            instance.deleteDetails(103332);
        }

    }
}