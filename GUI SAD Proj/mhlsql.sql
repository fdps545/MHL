DROP database mhl;
CREATE DATABASE mhl;
USE mhl;

/*everything is not null*/
CREATE TABLE student(
id_number INT(15) UNIQUE NOT NULL PRIMARY KEY,
first_name VARCHAR(60) ,
middle_initial VARCHAR(3) ,
last_name VARCHAR(60) ,
grade_level VARCHAR(20) ,
section VARCHAR(15) ,
nickname VARCHAR(15),
birthday DATE ,
sex VARCHAR(1) ,
birth_order VARCHAR(10) ,
home_address VARCHAR(255),
home_phone VARCHAR(15),
office_phone VARCHAR(15),
previous_school_name VARCHAR(60) ,
previous_school_grade_level VARCHAR(60) ,
date_received DATE ,
requirements_status VARCHAR(5),
payment_scheme_type VARCHAR(20),
school_year VARCHAR(10),
payment_status VARCHAR(255)
)ENGINE=INNODB; 

CREATE TABLE father_information(
id_number INT(15) NOT NULL PRIMARY KEY,
father_full_name VARCHAR(255) NOT NULL,
father_contact_number VARCHAR(15),
father_address VARCHAR(255),
father_occupation VARCHAR(100),
FOREIGN KEY (id_number) REFERENCES student(id_number)
);

CREATE TABLE mother_information(
id_number INT(15) NOT NULL PRIMARY KEY,
mother_full_name VARCHAR(255) NOT NULL,
mother_contact_number VARCHAR(15),
mother_address VARCHAR(255),
mother_occupation VARCHAR(100),
FOREIGN KEY (id_number) REFERENCES student(id_number)
);

CREATE TABLE guardian_information(
id_number INT(15) NOT NULL PRIMARY KEY,
guardian_full_name VARCHAR(255),
guardian_contact_number VARCHAR(15),
guardian_address VARCHAR(255),
guardian_occupation VARCHAR(100),
FOREIGN KEY (id_number) REFERENCES student(id_number)
);

CREATE TABLE sibling_information(
id_number INT(15) NOT NULL PRIMARY KEY,
sibling_full_name VARCHAR(255),
sibling_birthday DATE,
FOREIGN KEY (id_number) REFERENCES student(id_number)
);

CREATE TABLE account(
account_username VARCHAR(25) PRIMARY KEY NOT NULL,
account_password VARCHAR(25) NOT NULL
);

CREATE TABLE account_permissions(
account_username VARCHAR(25),
permissions VARCHAR(255),
PRIMARY KEY (account_username),
FOREIGN KEY (account_username) REFERENCES account(account_username)
);

CREATE TABLE subjects(
subject_name VARCHAR(30) NOT NULL,
school_year VARCHAR(15) NOT NULL,
PRIMARY KEY (subject_name, school_year)
)ENGINE=INNODB;

CREATE TABLE student_grade(
id_number INT(15) NOT NULL,
subject_name VARCHAR(60) NOT NULL,
school_year VARCHAR(15) NOT NULL,
grade_mark VARCHAR(10) NOT NULL,
grade_type VARCHAR(15) NOT NULL,
PRIMARY KEY (id_number, subject_name, grade_type),
FOREIGN KEY (id_number) REFERENCES student(id_number),
FOREIGN KEY (subject_name, school_year) REFERENCES subjects(subject_name, school_year)
);

CREATE TABLE miscellaneous_contacts(
id_number INT(15) NOT NULL PRIMARY KEY,
misc_contact_full_name VARCHAR(255) NOT NULL,
misc_contact_number VARCHAR(15),
misc_contact_address VARCHAR(255),
nuisc_contact_occupation VARCHAR(100),
PRIMARY KEY (id_number),
FOREIGN KEY (id_number) REFERENCES student(id_number)
);

CREATE TABLE misconduct_details(
id_number INT(15),
mis_first_name VARCHAR(50),
mis_mi VARCHAR(3),
mis_last_name VARCHAR(50),
misconduct_details VARCHAR(255),
PRIMARY KEY (id_number),
FOREIGN KEY (id_number) REFERENCES student(id_number)
);

INSERT INTO student(
id_number,
first_name,
middle_initial,
last_name,
grade_level,
section,
nickname,
birthday,
sex,
birth_order,
home_address,
office_phone,
home_phone,
previous_school_name,
previous_school_grade_level,
date_received,
requirements_status,
payment_scheme_type,
school_year,
payment_status
)
VALUES(
'104339',
'Francis Dominic',
'P.',
'Santos',
'Senior Casa',
'Block S1',
'Dom',
"1994-05-03",
'M',
'1st',
'Taguig City',
'5451482',
'1231231',
'UPRHS',
'4th Year Highschool',
"2013-04-03",
'10011',
'Annual',
'2013-2014',
'Unpaid'
);

INSERT INTO student(
id_number,
first_name,
middle_initial,
last_name,
grade_level,
section,
nickname,
birthday,
sex,
birth_order,
home_address,
office_phone,
home_phone,
previous_school_name,
previous_school_grade_level,
date_received,
requirements_status,
payment_scheme_type,
school_year,
payment_status
)
VALUES(
'103523',
'Dayanara',
'F.',
'Simon',
'Senior Casa',
'Block S1',
'Ara',
"1993-11-21",
'F',
'1st',
'Quezon City',
'7148266',
'09053933582',
'STC',
'4th Year Highschool',
"2013-04-03",
'11111',
'Annual',
'2013-2014',
'Paid'
);

INSERT INTO father_information(
id_number, father_full_name, father_contact_number, father_address, father_occupation
)
VALUES
(
'104339', 'Andre Bernabe Santos', '123123132', 'Camp Aguinaldo', 'Lt. Colonel'
);

INSERT INTO mother_information(
id_number, mother_full_name, mother_contact_number, mother_address, mother_occupation
)
VALUES
(
'104339', 'Maria Amanda P. Santos', '09189502498', 'Calamba City', 'School Directress'
);

INSERT INTO guardian_information(
id_number, guardian_full_name, guardian_contact_number, guardian_address, guardian_occupation
)
VALUES
(
'104339', 'Chuck Norris', '09178554590', 'Katipunan Avenue', 'Roundhouser'
);

INSERT INTO sibling_information(
id_number, sibling_full_name, sibling_birthday
)
VALUES(
'104339', 'Matthew Nathan Santos', "2000-05-08"
);

INSERT INTO subjects(
subject_name,school_year
)
VALUES(
'Calculus', '2013-2014'
);

INSERT INTO student_grade(
id_number, subject_name, school_year, grade_mark, grade_type
)
VALUES(
'104339', 'Calculus', '2013-2014', '92', 'Academic'
);

INSERT INTO miscellaneous_contacts(
id_number, m_contact_first_name, m_contact_mi, m_contact_last_name, m_contact_information
)
VALUES (
'104339', 'Mis Contact', 'P.', 'Norris', '091588473'
);


INSERT INTO misconduct_details(
id_number, mis_first_name, mis_mi, mis_last_name, misconduct_details
)
VALUES (
'104339', 'Francis Dominic', 'P.', 'Santos', 'Did not say good morning to the teacher.'
);




