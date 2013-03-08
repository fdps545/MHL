CHANGES

Section in Filter Search was changed into textbox
Changed the layout of the enrollment form
	added ID Number field
	added School Year field
	Birthday field for Siblings was changed into dropdown since it's a hassle to use dateTimePicker

	
COMMENTS/SUGGESTIONS
	
Additional information for payment has no property. payment_scheme_type and payment_status are different.
Data handling for Requirements in the Enrollment Form is problematic. There are a lot of fields but the database only accepts one data item
Class Schedule isn't a property but it's still part of the enrollment form. How do we handle this data?
Previous Schools have multiple data items. It should have its own entity?
Delete miscellaneous_contacts since it can be expanded as properties (misc_contact_name, misc_contact_number) for student.