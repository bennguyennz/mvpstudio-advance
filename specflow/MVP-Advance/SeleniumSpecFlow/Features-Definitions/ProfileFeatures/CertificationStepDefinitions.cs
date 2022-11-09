using NUnit.Framework;
using SeleniumSpecFlow.Pages.ProfilePages;
using System;
using System.Reflection.Metadata.Ecma335;
using TechTalk.SpecFlow;

namespace SeleniumSpecFlow
{
    [Binding]
    public class CertificationStepDefinitions
    {
        //Define Pages and Objects
        Certification certificationObj;
        public CertificationStepDefinitions()
        {
            certificationObj = new Certification();
        }

        [Given(@"I click on tab Certifications")]
        public void GivenIClickOnTabCertifications()
        {
            certificationObj.ClickOnTabCertifications();
        }

        [When(@"I click button Add_New")]
        public void WhenIClickButtonAdd_New()
        {
            certificationObj.ClickButtonAddNew();
        }

        [When(@"I enter '([^']*)' '([^']*)' '([^']*)'")]
        public void WhenIEnter(string certificate, string from, string year)
        {
            certificationObj.EnterCertificate(certificate, from, year);
        }

        [Then(@"I am able to see my '([^']*)' '([^']*)' '([^']*)' in my Certifications tab")]
        public void ThenIAmAbleToSeeMyInMyCertificationsTab(string certificate, string from, string year)
        {
            //Check message
            string assertMessage = certificate + " has been added to your certification";
            string message = certificationObj.GetMessage();
            Assert.That(message == assertMessage, "Actual message and Expected message do not match.");

            //Check certificate
            string addedCertificate = certificationObj.GetCertificate(certificate);
            Assert.That(addedCertificate == certificate, "Actual certificate and Expected certificate do not match.");

            //Check certifcation from
            string addedCertificationFrom = certificationObj.GetCertificationFrom();
            Assert.That(addedCertificationFrom == from, "Actual certification from and Expected certification from do not match.");

            //Check year
            string addedYear = certificationObj.GetCertificationYear();
            Assert.That(addedYear == year, "Actual certification year and Expected certification year do not match.");
        }

        [When(@"I click button Edit '([^']*)'")]
        public void WhenIClickButtonEdit(string certificate1)
        {
            string certificateIndex = certificationObj.GetCertificateIndex(certificate1);
            if (certificateIndex == "There is no certificate record." || certificateIndex == "Certificate is not found.")
            {
                Assert.Fail(certificateIndex);
            }
            certificationObj.ClickEdit(certificateIndex);
        }

        [When(@"I edit a '([^']*)' '([^']*)' '([^']*)'")]
        public void WhenIEditA(string certificate2, string from, string year)
        {
            certificationObj.EditCertificate(certificate2, from, year);
        }

        [Then(@"The existing certificate is edited as '([^']*)' '([^']*)' '([^']*)'")]
        public void ThenTheExistingCertificateIsEditedAs(string certificate2, string from, string year)
        {
            //Check message
            string assertMessage = certificate2 + " has been updated to your certification";
            string message = certificationObj.GetMessage();
            Assert.AreEqual(message, assertMessage, "Expected message and Actual message do not match.");

            //Check certifcate
            string assertCertificate = certificationObj.GetCertificate(certificate2);
            Assert.AreEqual(certificate2, assertCertificate, "Expected certificate and Actual certificate do not match.");

            //check certification form
            string editedCertificationFrom = certificationObj.GetCertificationFrom();
            Assert.AreEqual(from, editedCertificationFrom, "Expected certifier and Actual certifier do not match.");

            //check certification year
            string editedYear = certificationObj.GetCertificationYear();
            Assert.AreEqual(year, editedYear, "Expected certification year and Actual certification year do not match.");
        }

        [When(@"I click button Delete '([^']*)'")]
        public void WhenIClickButtonDelete(string certificate)
        {
            string certificateIndex = certificationObj.GetCertificateIndex(certificate);
            if (certificateIndex == "There is no certificate record." || certificateIndex == "Certificate is not found.")
            {
                Assert.Fail(certificateIndex);
            }
            certificationObj.ClickDelete(certificateIndex);
        }

        [Then(@"The '([^']*)' should be deleted")]
        public void ThenTheCertificateShouldBeDeleted(string certificate)
        {
            //check message
            string assertMessage = certificate + " has been deleted from your certification";
            string message = certificationObj.GetMessage();
            Assert.That(message == assertMessage, "Actual message and Expected message do not match.");

            //check certificate has been deleted successfully
            string deletedCertificate = certificationObj.GetCertificate(certificate);
            Assert.That(deletedCertificate != certificate, "Certificate hasn't been deleted.");
        }

    }
}
