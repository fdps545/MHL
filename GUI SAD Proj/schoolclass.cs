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
		
		/*public OContact father 
		{
			get;
			set;
		}
		
		public OContact mother 
		{
			get;
			set;
		}
		
		public OContact guardian 
		{
			get;
			set;
		}
		
		public string sibling_name
		{
			get;
			set;
		}
		
		public int sibling_age
		{
			get;
			set;
		}*/
		
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

        public string fullname
        {
            get;
            set;
        }

        public DateTime bdate
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
            store();
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

        public void filter(int glevel, string section, bool paid)
        {

        }

        public List<Student> store()
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
            //missing birthday, birth order, previous school name, previous school grade, date received, requirement status
            string command = "INSERT INTO student(id_number, first_name, middle_initial, last_name, grade_level, section, nickname, birthday, sex, birth_order, home_address, home_phone, office_phone, previous_school_name, previous_school_grade_level, date_received, requirements_status, payment_scheme_type, school_year, payment_status) values(" + id_no + ", '" + fname + "', '" + mname + "', '" + lname + "', '" + glevel + "', '" + section + "', '" + nickname + "', '" + birthday + "', '" + sex + "', '" +  birth_order + "', '" + address + "', '" + htel + "', '" + otel + "', '" + pschool + "', '" + pgrade + "', '" + dreceived + "', '" + rstatus + "', '" + pscheme + "', '" + sy + "', '" + pstatus + "');";
            MySqlCommand sqlcomm = new MySqlCommand(command, conn);
            MySqlDataReader r = sqlcomm.ExecuteReader();
            conn.Close();
        }

        public void addFather()
        {
        }

        public void addMother()
        {
        }

        public void addGuardian()
        {
        }

	}
}