Feature: ShareSkill

As a Seller, I want the feature to manage my listing details
So that I am able to add, edit or delete my listing details.

Background: I logged into the web portal

@ShareShill
Scenario: Enter Share Skill
	Given I click button ShareSkill
	When I enter my skill details
	Then I view my skill details based on title
	And My skill listing should be created properly