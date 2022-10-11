Feature: ShareSkill

As a Seller, I want the feature to manage my listing details
So that I am able to add, edit or delete my listing details.

Background: I logged into the web portal

@ShareShill
Scenario: Enter Share Skill
	Given I click button ShareSkill
	When I enter my skill details
	And I view my skill details based on title
	Then My skill listing should be created properly

@ShareShill
Scenario: Enter Share Skill - No data
	Given I click button ShareSkill
	When I enter my skill details with no data
	Then I get a warning message to enter the input

@ShareShill
Scenario: Enter Share Skill - Invalid data
	Given I click button ShareSkill
	When I enter my skill details with first invalid data
	Then I get a warning message for first invalid data

@ShareShill
Scenario: Enter Share Skill - Invalid data 2
	Given I click button ShareSkill
	When I enter my skill details with second invalid data set
	Then I get a warning message for second invalid data

@EditShareSkill
Scenario: Edit Share Skill 
   Given I click button manage listing
   When I edit my skill details
	And I view my edit Shareskill details based on title
	Then My edit ShareSkill listing should be edited properly