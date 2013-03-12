Asterisk are the ones that are not yet solved/new ones

CHANGES

* Changed character limit for requirements_status in Student table (database)
* Section in Filter was changed back into dropdown menu
* deleted Age field in Enrollment Form
Section in Filter Search was changed into textbox
Changed the layout of the Enrollment Form
	added ID Number field
	added School Year field
	Birthday field for Siblings was changed into dropdown since it's a hassle to use dateTimePicker
Grade in Student Profile is no longer in tab format. Instead, the DataGridView has been expanded

	
COMMENTS / SUGGESTIONS
	
* Need foreign key for sibling other than id_no
* Need table for previous school
* Class Schedule isn't a property but it's still part of the enrollment form. How do we handle this data?
	No class_schedule property/table in database
* Previous Schools have multiple data items. It should have its own entity?
Additional information for payment has no property. payment_scheme_type and payment_status are different.
What if you want to delete the whole student file?
Data handling for Requirements in the Enrollment Form is problematic. There are a lot of fields but the database only accepts one data item
Delete miscellaneous_contacts since it can be expanded as properties (misc_contact_name, misc_contact_number) for student.
Should grade_mark be int or varchar still?
Should we add a School Year column in the Grades of Student Profile?
How do we edit grades? If you click the Edit button, does it bring you to a new form where you can edit the grade?
Can we make misconduct details a property of student? It's only one field entry (data that you keep appending) and not multiple data entries. Takes up resource in the database.


THINGS STILL NEED TO FIX / REMINDERS FOR ARA

x refresh/Update - every time you edit the details, you have to refresh everything before the changes become visible
add error handling
adding misc contacts
adding of schools
x re-adding of grades
re-adding of siblings
mass deletion vs single entry deletion
add class schedule