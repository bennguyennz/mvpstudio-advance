using NUnit.Framework;
using SeleniumSpecFlow.Pages.ProfilePages;
using System;
using TechTalk.SpecFlow;

namespace SeleniumSpecFlow
{
    [Binding]
    public class ContactStepDefinitions
    {
        Contact contactObj;
        public ContactStepDefinitions()
        {
            contactObj = new Contact();
        }

        [Given(@"I edit my contact details '([^']*)' '([^']*)' '([^']*)' '([^']*)' '([^']*)'")]
        public void GivenIEditMyContactDetails(string firstName, string lastName, string availability, string hours, string earnTarget)
        {
            contactObj.EditMyContactDetails(firstName, lastName, availability, hours, earnTarget);
        }

        [Then(@"My contact details should be edited as '([^']*)' '([^']*)' '([^']*)' '([^']*)' '([^']*)'")]
        public void ThenMyContactDetailsShouldBeEditedAs(string firstName, string lastName, string availabilityType, string hour, string earnTarget)
        {
            //Check message
            string assertMessage = "Availability updated";
            string message = contactObj.GetMessage();
            Assert.AreEqual(assertMessage, message,  "Expected message and Actual message do not match.");

            //Check Full Name
            string assertFullName = firstName + " " + lastName;
            string editedFullName = contactObj.GetFullName();
            Assert.AreEqual(assertFullName, editedFullName, "Expected full name and Actual full name do not match");

            //Check availability
            string editedAvailibilityType = contactObj.GetAvailabilityType();
            Assert.AreEqual(availabilityType, editedAvailibilityType, "Expected availability type and Actual availability type do not match.");

            //Check Hours
            string editedHour = contactObj.GetAvailityHour();
            Assert.AreEqual(hour, editedHour, "Expected availability hour and Actual availability hour do not match.");

            //Check Earn Targe
            string editedEarnTarget = contactObj.GetAvailityTarget();
            Assert.AreEqual(earnTarget, editedEarnTarget, "Expected earn target and Actual earn target do not match.");
        }
    }
}
