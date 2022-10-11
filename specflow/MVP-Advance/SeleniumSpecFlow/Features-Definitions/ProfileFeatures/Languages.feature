Feature: Language

As a seller,
I want the feature to add my language Details
So that the people seeking for some skills can look into my details. 

Background: I logged into the web portal

@AddLanguage
Scenario Outline: 1-Add a Language. 
   Given I click on tab Languages
   When I click button AddNew
   And I enter '<Language>' '<Level>' 
   Then I am able to see my '<Language>' '<Level>' in my Lnaguages tab
  
  Examples:
    | Language | Level  |
    | English  | Fluent |

@EditLanguage
Scenario Outline: 2-Edit a Language
	Given I click on tab Languages
	When I click on button Edit '<Language1>'
	And I edit a '<Language2>' '<Level>' 
	Then The existing language is edited as '<Language2>' '<Level>'

Examples:
      | Language1 | Language2 | Level |
      | English   | Tamil     | Basic |
      

@DeleteLanguage
Scenario Outline: 3-Delete a Language
	Given I click on tab Languages
	When I click on button Delete '<Language>'
	Then The '<Language>' should be deleted successfully

 Examples:
       | Language | Level   |     
       | Tamil    | Basic   |  
       
