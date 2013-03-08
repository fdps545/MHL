CHANGES

Section in Filter Search was changed into textbox
Changed the layout of the Enrollment Form
	added ID Number field
	added School Year field
	Birthday field for Siblings was changed into dropdown since it's a hassle to use dateTimePicker
Grade in Student Profile is no longer in tab format. Instead, the DataGridView has been expanded

	
COMMENTS / SUGGESTIONS
	
Additional information for payment has no property. payment_scheme_type and payment_status are different.
Data handling for Requirements in the Enrollment Form is problematic. There are a lot of fields but the database only accepts one data item
Class Schedule isn't a property but it's still part of the enrollment form. How do we handle this data?
Previous Schools have multiple data items. It should have its own entity?
Delete miscellaneous_contacts since it can be expanded as properties (misc_contact_name, misc_contact_number) for student.
Should grade_mark be int or varchar still?
Should we add a School Year column in the Grades of Student Profile?

THINGS STILL NEED TO FIX / REMINDERS FOR ARA

Refresh/Update - every time you edit the details, you have to refresh everything before the changes become visible
Make button5_Click method in Form5 more efficient
Look at the comments for Form5