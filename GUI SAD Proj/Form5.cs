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
        int id_no;
        List<Sibling> siblings;
        List<Misc_Contacts> contacts;
        List<Previous_School> schools;

        public Form5()
        {
            InitializeComponent();
            int year1 = DateTime.Now.Year;
            int year2 = year1 + 1;
            string sy = year1 + "-" + year2;
            textBox23.Text = sy;
            siblings = new List<Sibling>();
            contacts = new List<Misc_Contacts>();
            schools = new List<Previous_School>();
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
                Sibling s = new Sibling();
                s.id_no = id_no;
                s.name = textBox22.Text;
                s.bdate = comboBox9.Text + "-" + comboBox8.Text + "-" + comboBox7.Text;
                siblings.Add(s);
                dataGridView1.Rows.Add(s.name, s.bdate);
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
                DateTime date = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
                comboBox9.Text = date.Year.ToString();
                comboBox8.Text = date.Month.ToString();
                comboBox7.Text = date.Day.ToString();
                button14.Enabled = true;
                string name = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBox22.Text = name;
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to update this student's information?", "Confirmation Required", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                siblings.RemoveAll(x => x.name == dataGridView1.Rows[0].Cells[0].Value.ToString());
                dataGridView1.Rows.RemoveAt(this.dataGridView1.SelectedRows[0].Index);
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
            Student b = instance.findStudent(Convert.ToInt32(id_no));
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
                Misconduct ms = instance.findMisconduct(id_no);
                List<Student_Grade> sgs = instance.findStudentGradeAcademic(id_no);
                instance.deleteDetails(id_no);
                createStudent();
                foreach (Student_Grade sg in sgs)
                {
                    instance.addStudentGrade(sg.id_no, sg.subject_name, sg.sy, sg.grade_mark, sg.grade_type);
                }
                instance.addMisconduct(id_no, ms.fname, ms.mname, ms.lname, ms.details);
                MessageBox.Show("Details successfully updated.", "Update Successful", MessageBoxButtons.OK);
                Close();
            }
        }

        public void createStudent()
        {
            id_no = Convert.ToInt32(textBox27.Text);
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
            string sched = comboBox6.Text;

            instance.addStudent(id_no, fname, mname, lname, glevel, section, nickname, bday, sex, border, address, htel, otel, dreceived, rstatus, pscheme, sy, pstatus, sched);
            instance.addFather(id_no, textBox10.Text, textBox11.Text, textBox12.Text, textBox13.Text);
            instance.addMother(id_no, textBox14.Text, textBox15.Text, textBox16.Text, textBox17.Text);
            instance.addGuardian(id_no, textBox18.Text, textBox19.Text, textBox20.Text, textBox21.Text);
            foreach (Sibling s in siblings)
            {
                DateTime temp = Convert.ToDateTime(s.bdate);
                string sbdate = temp.Year + "-" + temp.Month + "-" + temp.Day;
                instance.addSibling(id_no, s.name, sbdate);
            }
            foreach (Misc_Contacts ms in contacts)
            {
                instance.addMiscContacts(id_no, ms.fname, ms.contact, ms.address, ms.occupation);
            }
            foreach (Previous_School ps in schools)
            {
                instance.addPSchool(id_no, ps.name, ps.grade);
            }

        }

        public void updateStudent(int id_number)
        {
            id_no = id_number;
            Student a = instance.findStudent(id_number);
            textBox27.Text = Convert.ToString(id_number);
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
            textBox23.Text = a.sy;
            dateTimePicker2.Value = Convert.ToDateTime(a.rdate);
            richTextBox2.Text = a.paid;
            
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

            comboBox6.Text = a.schedule;

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

            siblings = instance.findSiblings(id_no);
            dataGridView1.Rows.Clear();
            foreach (Sibling s in siblings)
            {
                DateTime date = Convert.ToDateTime(s.bdate);
                string bday = date.Year + "-" + date.Month + "-" + date.Day;
                dataGridView1.Rows.Add(s.name, bday);
                Sibling sx = new Sibling();
            }

            foreach (Control ctrl in groupBox10.Controls)
            {
                if (ctrl.GetType() == typeof(RadioButton))
                {
                    if ( ((RadioButton)ctrl).Text.ToLower()==a.pscheme.ToLower() )
                        ((RadioButton)ctrl).Checked = true;
                }
            }

            contacts = instance.findContacts(id_no);
            foreach (Misc_Contacts ms in contacts)
            {
                dataGridView3.Rows.Add(ms.fname, ms.contact, ms.address, ms.occupation);
            }

            schools = instance.findPSchool(id_no);
            foreach (Previous_School ps in schools)
            {
                dataGridView2.Rows.Add(ps.name, ps.grade);
            }

        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            Misc_Contacts ms = new Misc_Contacts();
            string name = textBox29.Text;
            string contact = textBox25.Text;
            string add = textBox28.Text;
            string occupation = textBox24.Text;
            dataGridView3.Rows.Add(name, contact, add, occupation);
            ms.id_no = id_no;
            ms.fname= name;
            ms.contact = contact;
            ms.address = add;
            ms.occupation = occupation;
            contacts.Add(ms);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox29.Text = dataGridView3.SelectedRows[0].Cells[0].Value.ToString();
            textBox25.Text = dataGridView3.SelectedRows[0].Cells[1].Value.ToString();
            textBox28.Text = dataGridView3.SelectedRows[0].Cells[2].Value.ToString();
            textBox24.Text = dataGridView3.SelectedRows[0].Cells[3].Value.ToString();
            button12.Enabled = true;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string name = textBox29.Text;
            string contact = textBox25.Text;
            string add = textBox28.Text;
            string occupation = textBox24.Text;
            dataGridView3.Rows.RemoveAt(this.dataGridView3.SelectedRows[0].Index);
            dataGridView3.Rows.Add(name, contact, add, occupation);
            Misc_Contacts ms = new Misc_Contacts();
            ms.id_no = id_no;
            ms.fname = name;
            ms.contact = contact;
            ms.address = add;
            ms.occupation = occupation;
            contacts.Add(ms);
            button12.Enabled = false;
            
        }

        private void button14_Click(object sender, EventArgs e)
        {
            siblings.RemoveAll(x => x.name == dataGridView1.Rows[0].Cells[0].Value.ToString());
            dataGridView1.Rows.RemoveAt(this.dataGridView1.SelectedRows[0].Index);
            Sibling s = new Sibling();
            s.id_no = id_no;
            s.name = textBox22.Text;
            s.bdate = comboBox9.Text + "-" + comboBox8.Text + "-" + comboBox7.Text;
            siblings.Add(s);
            textBox22.Clear();
            comboBox9.ResetText(); comboBox8.ResetText(); comboBox7.ResetText();
            dataGridView1.Rows.Add(s.name, s.bdate);
            button12.Enabled = false;
        }


        private void button13_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to update this student's information?", "Confirmation Required", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                contacts.RemoveAll(x => x.fname == dataGridView3.Rows[0].Cells[0].Value.ToString());
                dataGridView3.Rows.RemoveAt(this.dataGridView3.SelectedRows[0].Index);
                MessageBox.Show("Details successfully updated.", "Update Successful", MessageBoxButtons.OK);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to update this student's information?", "Confirmation Required", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                schools.RemoveAll(x => x.name == dataGridView2.Rows[0].Cells[0].Value.ToString());
                dataGridView2.Rows.RemoveAt(this.dataGridView2.SelectedRows[0].Index);
                MessageBox.Show("Details successfully updated.", "Update Successful", MessageBoxButtons.OK);
            }
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            dataGridView2.Rows.Add(textBox5.Text, textBox9.Text);
            Previous_School ps = new Previous_School();
            ps.id_no = id_no;
            ps.name = textBox5.Text;
            ps.grade = textBox9.Text;
            schools.Add(ps);
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            textBox5.Text = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
            textBox9.Text = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
            button3.Enabled = true;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            schools.RemoveAll(x => x.name == dataGridView2.Rows[0].Cells[0].Value.ToString());
            Previous_School ps = new Previous_School();
            ps.id_no = id_no;
            ps.name = textBox5.Text;
            ps.grade = textBox9.Text;
            schools.Add(ps);
            dataGridView2.Rows.RemoveAt(this.dataGridView2.SelectedRows[0].Index);
            dataGridView2.Rows.Add(textBox5.Text, textBox9.Text);
            textBox5.Clear();
            textBox9.Clear();
            button3.Enabled = false;
        }

    }
}
