using NUnit.Framework;
using SeleniumSpecFlow.Pages.ProfilePages;
using System;
using TechTalk.SpecFlow;

namespace SeleniumSpecFlow
{
    [Binding]
    public class CertificationStepDefinitions
    {
        //Define Pages and Objects
        Certification CertificationObj;

        [Given(@"I click on tab Certifications")]
        public void GivenIClickOnTabCertifications()
        {
            CertificationObj = new Certification();
            CertificationObj.ClickOnTabCertifications();
        }

        [When(@"I click button Add_New")]
        public void WhenIClickButtonAdd_New()
        {
            CertificationObj.ClickButtonAddNew();
        }

        [When(@"I enter '([^']*)' '([^']*)' '([^']*)'")]
        public void WhenIEnter(string certificate, string from, string year)
        {
            CertificationObj.EnterCertificate(certificate, from, year);
        }

        [Then(@"I am able to see my '([^']*)' '([^']*)' '([^']*)' in my Certifications tab")]
        public void ThenIAmAbleToSeeMyInMyCertificationsTab(string certificate, string from, string year)
        {
            //Check message
            string assertMessage = certificate + " has been added to your certification";
            string message = CertificationObj.GetMessage();
            Assert.That(message == assertMessage, "Actual message and Expected message do not match.");

            //Check certificate
            string addedCertificate = CertificationObj.GetCertificate(certificate);
            Assert.That(addedCertificate == certificate, "Actual certificate and Expected certificate do not match.");

            //Check certifcation from
            string addedCertificationFrom = CertificationObj.GetCertificationFrom();
            Assert.That(addedCertificationFrom == from, "Actual certification from and Expected certification from do not match.");

            //Check year
            string addedYear = CertificationObj.GetCertificationYear();
            Assert.That(addedYear == year, "Actual certification year and Expected certification year do not match.");
        }

        [When(@"I click button Edit '([^']*)'")]
        public void WhenIClickButtonEdit(string certificate1)
        {
            CertificationObj.ClickEdit(certificate1);
        }

        [When(@"I edit a '([^']*)' '([^']*)' '([^']*)'")]
        public void WhenIEditA(string certificate2, string from, string year)
        {
            CertificationObj.EditCertificate(certificate2, from, year);
        }

        [Then(@"The existing certificate is edited as '([^']*)' '([^']*)' '([^']*)'")]
        public void ThenTheExistingCertificateIsEditedAs(string certificate2, string from, string year)
        {
            //Check message
            string assertMessage = certificate2 + " has been updated to your certification";
            string message = CertificationObj.GetMessage();
            Assert.That(message == assertMessage, "Actual message and Expected message do not match.");

            //Check certifcate
            string assertCertificate = CertificationObj.GetCertificate(certificate2);
            Assert.That(assertCertificate == certificate2, "Actual certificate and Expected certificate do not match.");

            //check certification form
            string editedCertificationFrom = CertificationObj.GetCertificationFrom();
            Assert.That(editedCertificationFrom == from, "Actual certifier and Expected certifier do not match.");

            //check certification year
            string editedYear = CertificationObj.GetCertificationYear();
            Assert.That(editedYear == year, "Actual certification year and Expected certification year do not match.");
        }

        [When(@"I click button Delete '([^']*)'")]
        public void WhenIClickButtonDelete(string certificate)
        {
            CertificationObj.ClickDelete(certificate);
        }

        [Then(@"The '([^']*)' should be deleted")]
        public void ThenTheCertificateShouldBeDeleted(string certificate)
        {
            //check message
            string assertMessage = certificate + " has been deleted from your certification";
            string message = CertificationObj.GetMessage();
            Assert.That(message == assertMessage, "Actual message and Expected message do not match.");

            //check certificate has been deleted successfully
            string deletedCertificate = CertificationObj.GetCertificate(certificate);
            Assert.That(deletedCertificate != certificate, "Certificate hasn't been deleted.");
        }

    }
}
