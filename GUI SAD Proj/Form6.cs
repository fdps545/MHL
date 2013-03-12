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
    public partial class Form6 : Form
    {
        public Student a;
        public Methods instance = new Methods();
        public int id_no = 0;
        
        public int returnIDNO()
        {
            return Convert.ToInt32(label3.Text);
        }

        public Form6(int id_no)
        {
            InitializeComponent();
            a = instance.findStudent(id_no);
            label3.Text = a.id_no.ToString();
            label5.Text = a.sy;
            label4.Text = a.lname + ", " + a.fname + " " + a.mname;
            textBox1.Text = a.sy;
            listSubjectGrades(id_no);
        }

        private void button5_Click(object sender, EventArgs e)
        {            
            Form5 enroll = new Form5();
            enroll.updateStudent(Convert.ToInt32(label3.Text));
            enroll.ShowDialog();
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

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to update this student's information?", "Confirmation Required", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                instance.addStudentGrade(a.id_no, textBox27.Text, textBox1.Text, textBox26.Text, comboBox1.Text);
                listSubjectGrades(a.id_no);
                foreach (Control ctrl in groupBox2.Controls)
                {
                    if (ctrl.GetType() == typeof(TextBox))
                        ((TextBox)ctrl).Clear();
                }
                textBox1.Text = a.sy;
                MessageBox.Show("Details successfully updated.", "Update Successful", MessageBoxButtons.OK);
            }
        }
        

        private void button11_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you sure you want to update this student's information?", "Confirmation Required", MessageBoxButtons.YesNo);
            if (DialogResult == DialogResult.Yes)
            {
                MessageBox.Show("Details successfully updated.", "Update Successful", MessageBoxButtons.OK);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Are you sure you want to update this student's information?", "Confirmation Required", MessageBoxButtons.YesNo);
            if (rs == DialogResult.Yes)
            {
                instance.deleteStudentGrade(a.id_no, getSubjectName, getSchoolYear);
                instance.addStudentGrade(a.id_no, textBox27.Text, textBox1.Text, textBox26.Text, comboBox1.Text);
                listSubjectGrades(a.id_no);
                foreach (Control ctrl in groupBox2.Controls)
                {
                    if (ctrl.GetType() == typeof(TextBox))
                        ((TextBox)ctrl).Clear();
                }
                button3.Enabled = false;
                textBox1.Text = a.sy;
                MessageBox.Show("Details successfully updated.", "Update Successful", MessageBoxButtons.OK);
            }
        }

        private void button10_Click(object sender, EventArgs e)
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

        private void button9_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to update this student's information?", "Confirmation Required", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                int id_no = Convert.ToInt32(label3.Text.ToString());
                string sn = dataGridView3.SelectedRows[0].Cells[0].Value.ToString();
                string sy = dataGridView3.SelectedRows[0].Cells[2].Value.ToString();
                instance.deleteStudentGrade(id_no, sn, sy);
                listSubjectGrades(Convert.ToInt32(label3.Text));
                MessageBox.Show("Details successfully updated.", "Update Successful", MessageBoxButtons.OK);
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {
        }

        public void listSubjectGrades(int id_no)
        {
            dataGridView3.Rows.Clear();
            List<Student_Grade> sgs = instance.findStudentGradeAcademic(id_no);
            foreach (Student_Grade sg in sgs)
                dataGridView3.Rows.Add(sg.subject_name, sg.grade_mark, sg.sy, sg.grade_type );
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            textBox27.Text = dataGridView3.SelectedRows[0].Cells[0].Value.ToString();
            textBox26.Text = dataGridView3.SelectedRows[0].Cells[1].Value.ToString();
            textBox1.Text = dataGridView3.SelectedRows[0].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView3.SelectedRows[0].Cells[3].Value.ToString();
            getSubjectName = textBox27.Text;
            getSchoolYear = textBox1.Text;
            button3.Enabled = true;
        }

        public string getSchoolYear
        {
            get;
            set;
        }

        public string getSubjectName
        {
            get;
            set;
        }
    }
}
