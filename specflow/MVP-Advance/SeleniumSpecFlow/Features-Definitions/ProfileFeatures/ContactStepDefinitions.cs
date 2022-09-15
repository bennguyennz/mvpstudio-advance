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

        [Given(@"I edit my contact details '([^']*)' '([^']*)' '([^']*)' '([^']*)' '([^']*)'")]
        public void GivenIEditMyContactDetails(string firstName, string lastName, string availability, string hours, string earnTarget)
        {
            contactObj = new Contact();
            contactObj.EditMyContactDetails(firstName, lastName, availability, hours, earnTarget);
        }

        [Then(@"My contact details should be edited as '([^']*)' '([^']*)' '([^']*)' '([^']*)' '([^']*)'")]
        public void ThenMyContactDetailsShouldBeEditedAs(string firstName, string lastName, string availabilityType, string hour, string earnTarget)
        {
            //Check message
            string assertMessage = "Availability updated";
            string message = contactObj.GetMessage();
            Assert.That(message == assertMessage, "Actual message and Expected message do not match.");

            //Check Full Name
            string assertFullName = firstName + " " + lastName;
            string editedFullName = contactObj.GetFullName();
            Assert.That(editedFullName == assertFullName, "Actual full name and Expected full name do not match");

            //Check availability
            string editedAvailibilityType = contactObj.GetAvailabilityType();
            Assert.That(editedAvailibilityType == availabilityType, "Actual availability type and Expected availability type do not match.");

            //Check Hours
            string editedHour = contactObj.GetAvailityHour();
            Assert.That(editedHour == hour, "Actual availability hour and expected availability hour do not match.");

            //Check Earn Targe
            string editedEarnTarget = contactObj.GetAvailityTarget();
            Assert.That(editedEarnTarget == earnTarget, "Actual earn target and Expected earn target do not match.");
        }
    }
}
