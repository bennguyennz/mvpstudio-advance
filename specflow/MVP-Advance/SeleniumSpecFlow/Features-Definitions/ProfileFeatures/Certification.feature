Feature: Certification

As a Seller I want the feature to manage my certification details.
So that I am able to add, edit or delete my certification records.

Background: I logged into the web portal

@Certifications
Scenario Outline: 1-Add a certification
	Given I click on tab Certifications
	When I click button Add_New
	And I enter '<Certificate>' '<From>' '<Year>'
	Then I am able to see my '<Certificate>' '<From>' '<Year>' in my Certifications tab

	Examples: 
	| Certificate  | From       | Year |
	| ISTQB CTFL   | ISTQB NZ   | 2022 |
	| Test Analyst | MVP Studio | 2021 |

@Certifications
Scenario Outline: 2-Edit a certification
	Given I click on tab Certifications
	When I click button Edit '<Certificate1>'
	And I edit a '<Certificate2>' '<From>' '<Year>'
	Then The existing certificate is edited as '<Certificate2>' '<From>' '<Year>'

	Examples: 
	| Certificate1 | Certificate2                     | From             | Year |
	| Test Analyst | Professional Expert Test Analyst | Industry Connect | 2022 |

@Certifications
Scenario Outline: 3-Delete a certification
	Given I click on tab Certifications
	When I click button Delete '<Certificate>'
	Then The '<Certificate>' should be deleted

	Examples: 
	| Certificate                      | From             | Year |
	| ISTQB CTFL                       | ISTQB NZ         | 2022 |
	| Professional Expert Test Analyst | Industry Connect | 2022 |