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
		
		public int glevel
		{
			get;
			set;
		}
		
		public string nickname
		{
			get;
			set;
		}
		
		public string bmonth 
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
		
		public int border 
		{
			get;
			set;
		}
		
		public string address
		{
			get;
			set;
		}
		
		public int htel 
		{
			get;
			set;
		}
		
		public int otel
		{
			get;
			set;
		}
		
		public OContact father 
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
		}
		
		public string pschool 
		{
			get;
			set;
		}
		
		public int pgrade 
		{
			get;
			set;
		}
		
		public string rdate
        {
			get;
			set;
		}
		
		public bool rstatus 
		{
			get;
			set;
		}
		
		public string pscheme
		{
			get;
			set;
		}
		
		public DateTime systart
		{
			get;
			set;
		}
		
		public DateTime syend
		{
			get;
			set;
		}
		
		public bool pstatus
		{
			get;
			set;
		}
		
		public DateTime yerolled 
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
	
	public class OContact
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
		
		public int contact_no
		{
			get;
			set;
		}
		
		public string adress
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
		public string name
		{
			get;
			set;
		}
		
		public int date
		{
			get;
			set;
		}
		
		public string type
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
		public string name
		{
			get;
			set;
		}
		
		public int date
		{
			get;
			set;
		}
		
		public int id_no
		{
			get;
			set;
		}
		
		public int mark
		{
			get;
			set;
		}
	}

	public class Methods
	{
		MySqlConnection conn;
		
		public Methods(string p)
		{
            conn = new MySqlConnection("server=localhost;database=mydatabase;uid=root;pwd=root;");
		}

        //put your queries here
	}
}