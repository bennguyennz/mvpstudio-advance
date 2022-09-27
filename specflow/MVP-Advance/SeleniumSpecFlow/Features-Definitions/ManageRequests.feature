Feature: Manage Requests

As a user I want the feature to manage my requests.
So that (after request was made) I am able to withdraw, decline, accept and delete requests.

Background: Seller logged into the web portal

@ManageRequests
Scenario: 1-Withdraw Request
	Given The Buyer sent a request to the Seller
	When The Buyer clicks Manage sent requests
	And The Buyer clicks button Withdraw a request
	Then The Buyer is able to see the request as withdrawn

@ManageRequests
Scenario: 2-Decline Request
	Given The Buyer sent a request to the Seller
	When The Seller clicks Manage received Requests
	And The Seller clicks button Decline a request
	Then The Seller is able to see the request as declined

@ManageRequests
Scenario: 3-Accept Request
	Given The Buyer sent a request to the Seller
	When The Seller clicks Manage received Requests
	And The Seller clicks button Accept a request
	Then The Seller is able to see the request as accepted

@ManageRequests
Scenario: 4-Complete Request
	Given The Buyer sent a request to the Seller
	When The Seller clicks Manage received Requests
	When The Seller clicks button Accept a request
	When The Seller clicks Complete a request
	When The Buyer clicks Manage sent requests
	And The Buyer clicks Complete a request
	Then The Buyer is able to see the request as completed
	When The Seller clicks Manage received Requests
	Then The Seller is able to see the request as completed
