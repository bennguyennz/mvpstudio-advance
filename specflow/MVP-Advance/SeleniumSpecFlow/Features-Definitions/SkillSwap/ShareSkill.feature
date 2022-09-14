Feature: ShareSkill

As a Seller, I want the feature to manage my listing details
So that I am able to add, edit or delete my listing details.

Background: I logged into the web portal

@ShareShill
Scenario Outline: Enter Share Skill
	Given I click button ShareSkill
	When I enter '<Title>' '<Description>' '<Category>' '<Subcategory>' '<Tags>' '<serviceType>' '<locationType>' '<startDate>' '<endDate>' '<Days>' '<startTime>' '<endTime>' '<skillTrade>' '<skillExchange>' '<Credit>' '<Active>'
	Then I view my skill details based on '<Title>'
	And My skill listing should be created as '<Title>' '<Description>' '<Category>' '<Subcategory>' '<serviceType>' '<locationType>' '<skillTrade>' '<skillExchange>' '<Credit>' '<startDate>' '<endDate>' 

	Examples: 
	| Title                                 | Description                                                                                                           | Category           | Subcategory | Tags     | serviceType          | locationType | startDate  | endDate    | Days | startTime | endTime | skillTrade     | skillExchange        | Credit | Active |
	| SpecFlow Feature Demo                 | A session discussing about Automated testing using SpecFlow, BDD, POM. Requirements: Visual studio Community version. | Programming & Tech | QA          | SpecFlow | One-off service      | On-site      | 20/11/2022 | 23/11/2022 | Mon  | 1100am    | 0100pm  | Credit         | None                 | 10     | Active |
	| ExcelDataReader AutoIT XPath Siblings | A session about sharing experiences about how to work with ExcelDataReader, AutoIT, XPath Siblings                    | Business           | Other       | AutoIT   | Hourly basis service | Online       | 10/12/2022 | 28/12/2022 | Wed  | 0200pm    | 0700pm  | Skill-exchange | Software Development | None   | Hidden |
