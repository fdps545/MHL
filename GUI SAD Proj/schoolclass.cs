using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using MySql.Data.MySqlClient;

namespace SchoolClass
{
	public class Student
	{
		public int id_no
		{
			get;
			set;
		}
		
		public string fname
		{
			get;
			set;
		}
		
		public string mname
		{
			get;
			set;
		}
		
		public string lname
		{
			get;
			set;
		}
		
		public string glevel
		{
			get;
			set;
		}

        public string section
        {
            get;
            set;
        }

		public string nickname
		{
			get;
			set;
		}
				
		public DateTime bday 
		{
			get;
			set;
		}
		
        //derived, not in the database
		public int age 
		{
			get;
			set;
		}
		
		public string sex 
		{
			get;
			set;
		}
		
		public string border 
		{
			get;
			set;
		}
		
		public string address
		{
			get;
			set;
		}
		
		public string htel 
		{
			get;
			set;
		}
		
		public string otel
		{
			get;
			set;
		}
		
		public string pschool 
		{
			get;
			set;
		}
		
		public string pgrade 
		{
			get;
			set;
		}
		
		public DateTime rdate
        {
			get;
			set;
		}
		
		public string rstatus 
		{
			get;
			set;
		}
		
		public string pscheme
		{
			get;
			set;
		}
		
		public string sy
		{
			get;
			set;
		}
				
		public string paid
		{
			get;
			set;
		}
		
	}
	
	public class Account
	{
		public string username
		{
			get;
			set;
		}
		
		public string password
		{
			get;
			set;
		}
	}

    public class Father
    {
        public int id_no
        {
            get;
            set;
        }

        public string name
        {
            get;
            set;
        }

        public string contact_no
        {
            get;
            set;
        }

        public string address
        {
            get;
            set;
        }

        public string occupation
        {
            get;
            set;
        }
    }

    public class Mother
    {
        public int id_no
        {
            get;
            set;
        }

        public string name
        {
            get;
            set;
        }

        public string contact_no
        {
            get;
            set;
        }

        public string address
        {
            get;
            set;
        }

        public string occupation
        {
            get;
            set;
        }
    }

    public class Guardian
    {
        public int id_no
        {
            get;
            set;
        }

        public string name
        {
            get;
            set;
        }

        public string contact_no
        {
            get;
            set;
        }

        public string address
        {
            get;
            set;
        }

        public string occupation
        {
            get;
            set;
        }
    }

    public class Sibling
    {
        public int id_no
        {
            get;
            set;
        }

        public string name
        {
            get;
            set;
        }

        public string bdate
        {
            get;
            set;
        }
    }
	
	public class Misconduct
	{		
		public int id_no
		{
			get;
			set;
		}

		public string fname
		{
			get;
			set;
		}
		
		public string mname
		{
			get;
			set;
		}
		
		public string lname
		{
			get;
			set;
		}
		
		public string details
		{
			get;
			set;
		}
	}
	
	public class Subject
	{		
		public string subject_name
		{
			get;
			set;
		}
		
		public string sy
		{
			get;
			set;
		}
	}
	
	public class Student_Grade
	{
        public int id_no
        {
            get;
            set;
        }

		public string subject_name
		{
			get;
			set;
		}
		
		public string sy
		{
			get;
			set;
		}
		
		public string grade_mark
		{
			get;
			set;
		}

        public string grade_type
        { 
            get;
            set; 
        }
	}

    public class Misc_Contacts
    {
        public int id_no
        {
            get;
            set;
        }

        public string fname
        {
            get;
            set;
        }

        public string mname
        {
            get;
            set;
        }

        public string lname
        {
            get;
            set;
        }

        public string other_information
        {
            get;
            set;
        }
    }

	public class Methods
	{
		MySqlConnection conn;
		
		public Methods()
        {
            List<Student> student_coll = new List<Student>();
            conn = new MySqlConnection("server=localhost;database=mhl;uid=root;pwd=root;");
            listAll();
		}

        //t is the type: id no. or surname
        //q is the keyword for the search
        public List<Student> querySearch(string t, string q)
        {
            List<Student> student_coll = new List<Student>();
            conn.Open();
            string command = "select * from student where " + t + "='" + q + "'";
            MySqlCommand sqlcomm = new MySqlCommand(command, conn);
            MySqlDataReader r = sqlcomm.ExecuteReader();
            while (r.Read())
            {
                Student a = new Student();
                a.id_no = Convert.ToInt32(r.GetValue(0).ToString());
                a.fname = r.GetValue(1).ToString();
                a.mname = r.GetValue(2).ToString();
                a.lname = r.GetValue(3).ToString();
                a.glevel = r.GetValue(4).ToString();
                a.section = r.GetValue(5).ToString();
                a.nickname = r.GetValue(6).ToString();
                //yay
                a.sex = r.GetValue(8).ToString();
                a.border = r.GetValue(9).ToString();
                a.address = r.GetValue(10).ToString();
                a.htel = r.GetValue(11).ToString();
                a.otel = r.GetValue(12).ToString();
                a.pschool = r.GetValue(13).ToString();
                a.pgrade = r.GetValue(14).ToString();
                //yay
                a.rstatus = r.GetValue(16).ToString();
                a.pscheme = r.GetValue(17).ToString();
                a.sy = r.GetValue(18).ToString();
                a.paid = r.GetValue(19).ToString();

                student_coll.Add(a);
            }
            conn.Close();
            return student_coll;
        }

        public List<Student> filter(string glevel, string section, string paid)
        {
            string query = "";
            if (glevel != "")
                query += "grade_level='" + glevel + "'";
            if (section != "")
            {
                if (glevel != "")
                    query += "AND ";
                query += "section='" + section + "'";
            }
            if (paid != "")
            {
                if (glevel != "" || section != "")
                    query += "AND ";
                query += "payment_status='" + paid + "'";
            }
            query += ";";

            List<Student> student_coll = new List<Student>();
            conn.Open();
            string command = "select * from student where " + query;
            MySqlCommand sqlcomm = new MySqlCommand(command, conn);
            MySqlDataReader r = sqlcomm.ExecuteReader();
            while (r.Read())
            {
                Student a = new Student();
                a.id_no = Convert.ToInt32(r.GetValue(0).ToString());
                a.fname = r.GetValue(1).ToString();
                a.mname = r.GetValue(2).ToString();
                a.lname = r.GetValue(3).ToString();
                a.glevel = r.GetValue(4).ToString();
                a.section = r.GetValue(5).ToString();
                a.nickname = r.GetValue(6).ToString();
                //yay
                a.sex = r.GetValue(8).ToString();
                a.border = r.GetValue(9).ToString();
                a.address = r.GetValue(10).ToString();
                a.htel = r.GetValue(11).ToString();
                a.otel = r.GetValue(12).ToString();
                a.pschool = r.GetValue(13).ToString();
                a.pgrade = r.GetValue(14).ToString();
                //yay
                a.rstatus = r.GetValue(16).ToString();
                a.pscheme = r.GetValue(17).ToString();
                a.sy = r.GetValue(18).ToString();
                a.paid = r.GetValue(19).ToString();

                student_coll.Add(a);
            }
            conn.Close();
            return student_coll;
        }

        public List<Student> listAll()
        {
            conn.Open();
            List<Student> student_coll = new List<Student>();
            MySqlCommand sqlcomm = new MySqlCommand("select * from student", conn);
            MySqlDataReader r = sqlcomm.ExecuteReader();
            while (r.Read())
            {
                Student a = new Student();
                a.id_no =Convert.ToInt32(r.GetValue(0).ToString());
                a.fname = r.GetValue(1).ToString();
                a.mname = r.GetValue(2).ToString();
                a.lname = r.GetValue(3).ToString();
                a.glevel = r.GetValue(4).ToString();
                a.section = r.GetValue(5).ToString();
                a.nickname = r.GetValue(6).ToString();
                //yay
                a.sex = r.GetValue(8).ToString();
                a.border = r.GetValue(9).ToString();
                a.address = r.GetValue(10).ToString();
                a.htel = r.GetValue(11).ToString();
                a.otel = r.GetValue(12).ToString();
                a.pschool = r.GetValue(13).ToString();
                a.pgrade = r.GetValue(14).ToString();
                //yay
                a.rstatus = r.GetValue(16).ToString();
                a.pscheme = r.GetValue(17).ToString();
                a.sy = r.GetValue(18).ToString();
                a.paid = r.GetValue(19).ToString();
                               
                student_coll.Add(a);
            }
            conn.Close();
            return student_coll;
        }

        public void addStudent(int id_no, string fname, string mname, string lname, string glevel, string section, string nickname, string birthday, string sex, string birth_order, string address, string htel, string otel, string pschool, string pgrade, string dreceived, string rstatus, string pscheme, string sy, string pstatus)
        {
            
            conn.Open();
            List<Student> student_coll = new List<Student>();
            string command = "INSERT INTO student(id_number, first_name, middle_initial, last_name, grade_level, section, nickname, birthday, sex, birth_order, home_address, home_phone, office_phone, previous_school_name, previous_school_grade_level, date_received, requirements_status, payment_scheme_type, school_year, payment_status) values(" + id_no + ", '" + fname + "', '" + mname + "', '" + lname + "', '" + glevel + "', '" + section + "', '" + nickname + "', '" + birthday + "', '" + sex + "', '" +  birth_order + "', '" + address + "', '" + htel + "', '" + otel + "', '" + pschool + "', '" + pgrade + "', '" + dreceived + "', '" + rstatus + "', '" + pscheme + "', '" + sy + "', '" + pstatus + "');";
            MySqlCommand sqlcomm = new MySqlCommand(command, conn);
            sqlcomm.ExecuteReader();
            conn.Close();
        }

        public Student findStudent(int id_no)
        {
            Student a = new Student();
            conn.Open();
            string command = "SELECT * FROM student WHERE id_number=" + id_no + ";";
            MySqlCommand sqlcomm = new MySqlCommand(command, conn);
            MySqlDataReader r = sqlcomm.ExecuteReader(); 
            while (r.Read())
            {
                a.id_no = Convert.ToInt32(r.GetValue(0).ToString());
                a.fname = r.GetValue(1).ToString();
                a.mname = r.GetValue(2).ToString();
                a.lname = r.GetValue(3).ToString();
                a.glevel = r.GetValue(4).ToString();
                a.section = r.GetValue(5).ToString();
                a.nickname = r.GetValue(6).ToString();
                a.bday = DateTime.Parse(r.GetValue(7).ToString());
                a.sex = r.GetValue(8).ToString();
                a.border = r.GetValue(9).ToString();
                a.address = r.GetValue(10).ToString();
                a.htel = r.GetValue(11).ToString();
                a.otel = r.GetValue(12).ToString();
                a.pschool = r.GetValue(13).ToString();
                a.pgrade = r.GetValue(14).ToString();
                a.rdate = DateTime.Parse(r.GetValue(15).ToString());
                a.rstatus = r.GetValue(16).ToString();
                a.pscheme = r.GetValue(17).ToString();
                a.sy = r.GetValue(18).ToString();
                a.paid = r.GetValue(19).ToString();
            }
            conn.Close();
            return a;
        }

        public void addFather(int id_no, string fname, string contact, string address, string occupation)
        {
            conn.Open();
            string command = "INSERT INTO father_information(id_number, father_full_name, father_contact_number, father_address, father_occupation) values(" + id_no + ", '" + fname + "', '" + contact + "', '" + address + "', '" + occupation + "');";
            MySqlCommand sqlcomm = new MySqlCommand(command, conn);
            sqlcomm.ExecuteReader();
            conn.Close();
        }


        public void addMother(int id_no, string fname, string contact, string address, string occupation)
        {
            conn.Open();
            string command = "INSERT INTO mother_information(id_number, mother_full_name, mother_contact_number, mother_address, mother_occupation) values(" + id_no + ", '" + fname + "', '" + contact + "', '" + address + "', '" + occupation + "');";
            MySqlCommand sqlcomm = new MySqlCommand(command, conn);
            sqlcomm.ExecuteReader();
            conn.Close();
        }

        public void addGuardian(int id_no, string fname, string contact, string address, string occupation)
        {
            conn.Open();
            string command = "INSERT INTO guardian_information(id_number, guardian_full_name, guardian_contact_number, guardian_address, guardian_occupation) values(" + id_no + ", '" + fname + "', '" + contact + "', '" + address + "', '" + occupation + "');";
            MySqlCommand sqlcomm = new MySqlCommand(command, conn);
            sqlcomm.ExecuteReader();
            conn.Close();
        }

        public void addSibling(int id_no, string fname, string bday)
        {
            conn.Open();
            string command = "INSERT INTO sibling_information(id_number, sibling_full_name, sibling_birthday) values(" + id_no + ", '" + fname + "', '" + bday + "');";
            MySqlCommand sqlcomm = new MySqlCommand(command, conn);
            sqlcomm.ExecuteReader();
            conn.Close();
        }

        public void addStudentGrade(int id_no, string sn, string sy, string gm, string gtype)
        {
            addSubject(sn, sy);
            conn.Open();
            string command = "INSERT INTO student_grade(id_number, subject_name, school_year, grade_mark, grade_type) values(" + id_no + ", '" + sn + "', '" + sy + "', '" + gm + "', '" + gtype + "');";
            MySqlCommand sqlcomm = new MySqlCommand(command, conn);
            sqlcomm.ExecuteReader();
            conn.Close();

        }

        public void addSubject(string sn, string sy)
        {
            if (!findSubject(sn, sy))
            {
                conn.Open();
                string command = "INSERT INTO subjects(subject_name, school_year) values('" + sn + "', '" + sy + "');";
                MySqlCommand sqlcomm = new MySqlCommand(command, conn);
                sqlcomm.ExecuteReader();
                conn.Close();
            }
        }

        public bool findSubject(string sn, string sy)
        {
            bool doesExist = false;
            conn.Open();
            string command = "SELECT COUNT(*) FROM subjects WHERE subject_name='" + sn + "' AND school_year='" + sy + "';";
            MySqlCommand sqlcomm = new MySqlCommand(command, conn);
            int number = Convert.ToInt32(sqlcomm.ExecuteScalar());
            if (number > 0)
                doesExist = true;
            conn.Close();
            return doesExist;
        }

        public Father findFather(int id_no)
        {
            Father f = new Father();
            conn.Open();
            string command = "SELECT * FROM father_information WHERE id_number=" + id_no;
            MySqlCommand sqlcomm = new MySqlCommand(command, conn);
            MySqlDataReader r = sqlcomm.ExecuteReader();
            while (r.Read())
            {
                f.name = r.GetValue(1).ToString();
                f.contact_no = r.GetValue(2).ToString();
                f.address = r.GetValue(3).ToString();
                f.occupation = r.GetValue(4).ToString();
            }
            conn.Close();
            return f;
        }

        public Mother findMother(int id_no)
        {
            Mother f = new Mother();
            conn.Open();
            string command = "SELECT * FROM mother_information WHERE id_number=" + id_no;
            MySqlCommand sqlcomm = new MySqlCommand(command, conn);
            MySqlDataReader r = sqlcomm.ExecuteReader();
            while (r.Read())
            {
                f.name = r.GetValue(1).ToString();
                f.contact_no = r.GetValue(2).ToString();
                f.address = r.GetValue(3).ToString();
                f.occupation = r.GetValue(4).ToString();
            }
            conn.Close();
            return f;
        }

        public Guardian findGuardian(int id_no)
        {
            Guardian f = new Guardian();
            conn.Open();
            string command = "SELECT * FROM guardian_information WHERE id_number=" + id_no;
            MySqlCommand sqlcomm = new MySqlCommand(command, conn);
            MySqlDataReader r = sqlcomm.ExecuteReader();
            while (r.Read())
            {
                f.name = r.GetValue(1).ToString();
                f.contact_no = r.GetValue(2).ToString();
                f.address = r.GetValue(3).ToString();
                f.occupation = r.GetValue(4).ToString();
            }
            conn.Close();
            return f;
        }

        public List<Sibling> findSiblings(int id_no)
        {
            List<Sibling> coll = new List<Sibling>();
            conn.Open();
            string command = "SELECT * FROM sibling_information WHERE id_number=" + id_no;
            MySqlCommand sqlcomm = new MySqlCommand(command, conn);
            MySqlDataReader r = sqlcomm.ExecuteReader();
            while (r.Read())
            {
                Sibling s = new Sibling();
                s.id_no = Convert.ToInt32(r.GetValue(0).ToString());
                s.name = r.GetValue(1).ToString();
                s.bdate = r.GetValue(2).ToString();
                coll.Add(s);
            }
            conn.Close();
            return coll;
        }

        public Subject findSubject(string name)
        {
            Subject s = new Subject();
            conn.Open();
            string command = "SELECT * FROM subjects WHERE subject_name=" + name;
            MySqlCommand sqlcomm = new MySqlCommand(command, conn);
            MySqlDataReader r = sqlcomm.ExecuteReader();
            while (r.Read())
            {
                s.subject_name = r.GetValue(0).ToString();
                s.sy = r.GetValue(1).ToString();
            }
            conn.Close();
            return s;
        }

        public List<Student_Grade> findStudentGradeAcademic(int id_no)
        {
            List<Student_Grade> coll = new List<Student_Grade>();
            conn.Open();
            string command = "SELECT * FROM student_grade WHERE id_number=" + id_no;
            MySqlCommand sqlcomm = new MySqlCommand(command, conn);
            MySqlDataReader r = sqlcomm.ExecuteReader();
            while (r.Read())
            {
                Student_Grade s = new Student_Grade();
                if (r.GetValue(4).ToString().ToLower() == "academic")
                {
                    s.id_no = Convert.ToInt32(r.GetValue(0).ToString());
                    s.subject_name = r.GetValue(1).ToString();
                    s.sy = r.GetValue(2).ToString();
                    s.grade_mark = r.GetValue(3).ToString();
                    s.grade_type = r.GetValue(4).ToString();
                    coll.Add(s);
                }
            }
            conn.Close();
            return coll;
        }

        public void deleteStudent(int id_no)
        {
            conn.Open();
            string command = "DELETE FROM student WHERE id_number=" + id_no;
            MySqlCommand sqlcomm = new MySqlCommand(command, conn);
            sqlcomm.ExecuteReader();
            conn.Close();
        }

        public void deleteFather(int id_no)
        {
            conn.Open();
            string command = "DELETE FROM father_information WHERE id_number=" + id_no;
            MySqlCommand sqlcomm = new MySqlCommand(command, conn);
            sqlcomm.ExecuteReader();
            conn.Close();
        }

        public void deleteMother(int id_no)
        {
            conn.Open();
            string command = "DELETE FROM mother_information WHERE id_number=" + id_no;
            MySqlCommand sqlcomm = new MySqlCommand(command, conn);
            sqlcomm.ExecuteReader();
            conn.Close();
        }

        public void deleteGuardian(int id_no)
        {
            conn.Open();
            string command = "DELETE FROM guardian_information WHERE id_number=" + id_no;
            MySqlCommand sqlcomm = new MySqlCommand(command, conn);
            sqlcomm.ExecuteReader();
            conn.Close();
        }

        public void deleteStudentGrades(int id_no)
        {
            conn.Open();
            string command = "DELETE FROM student_grade WHERE id_number=" + id_no;
            MySqlCommand sqlcomm = new MySqlCommand(command, conn);
            sqlcomm.ExecuteReader();
            conn.Close();
        }

        public void deleteSibling(int id_no)
        {
            conn.Open();
            string command = "DELETE FROM sibling_information WHERE id_number=" + id_no;
            MySqlCommand sqlcomm = new MySqlCommand(command, conn);
            sqlcomm.ExecuteReader();
            conn.Close();
        }

        public void deleteMiscContacts(int id_no)
        {
            conn.Open();
            string command = "DELETE FROM miscellaneous_contacts WHERE id_number=" + id_no;
            MySqlCommand sqlcomm = new MySqlCommand(command, conn);
            sqlcomm.ExecuteReader();
            conn.Close();
        }

        public void deleteMisconduct(int id_no)
        {
            conn.Open();
            string command = "DELETE FROM misconduct_details WHERE id_number=" + id_no;
            MySqlCommand sqlcomm = new MySqlCommand(command, conn);
            sqlcomm.ExecuteReader();
            conn.Close();
        }

        public void deleteDetails(int id_no)
        {
            deleteFather(id_no);
            deleteMother(id_no);
            deleteGuardian(id_no);
            deleteSibling(id_no);
            deleteStudentGrades(id_no);
            deleteMiscContacts(id_no);
            deleteMisconduct(id_no);
            deleteStudent(id_no);
        }

        public int setIDNo()
        {
            int id_no = 0;
            conn.Open();
            string command = "SELECT COUNT(*) FROM student";
            MySqlCommand sqlcomm = new MySqlCommand(command, conn);
            int r = Convert.ToInt32(sqlcomm.ExecuteScalar());
            r += 1;
            string year = Convert.ToString(DateTime.Now.Year);
            string together = year.Substring(1, 3) + r.ToString().PadLeft(4, '0'); ;
            id_no = Convert.ToInt32(together);
            conn.Close();
            return id_no;
        }
	}
}