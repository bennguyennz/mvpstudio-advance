Feature: Contact

A short summary of the feature

Background: I logged into the web portal

@Profile
Scenario: 1-Add profile contact details
	Given I edit my contact details '<First Name>' '<Last Name>' '<Availability>' '<Hours>' '<Earn Target>'
	Then My contact details should be edited as '<First Name>' '<Last Name>' '<Availability>' '<Hours>' '<Earn Target>'

	Examples:
	| First Name | Last Name | Availability | Hours                    | Earn Target                      |
	| Binh       | Nguyen    | Part Time    | Less than 30hours a week | Less than $500 per month         |
	| Binh       | Nguyeen   | Full Time    | More than 30hours a week | Between $500 and $1000 per month |
	| Binh       | Nguyen    | Full Time    | As needed                | More than $1000 per month        |