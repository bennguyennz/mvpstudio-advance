using NUnit.Framework;
using SeleniumSpecFlow.Pages;
using System;
using TechTalk.SpecFlow;
using static SeleniumSpecFlow.Utilities.GlobalDefinitions;

namespace SeleniumSpecFlow
{
    [Binding]
    public class ManageRequestsStepDefinitions
    {
        ManageRequests manageRequestsObj;
        public ManageRequestsStepDefinitions()
        {
            manageRequestsObj = new ManageRequests();
        }
        [Given(@"The Buyer sent a request to the Seller")]
        public void GivenABuyerSentARequestToTheSeller()
        {
            int log = manageRequestsObj.SendRequest();
            if (log < 0)
            {
                Assert.Fail("No request found");
            }
        }

        [When(@"The Buyer clicks Manage sent requests")]
        public void WhenTheBuyerClickManageSentRequest()
        {
            manageRequestsObj.ClickSentRequests();
        }

        [When(@"The Buyer clicks button Withdraw a request")]
        public void WhenTheBuyerClickButtonWithdrawFromARequest()
        {
            manageRequestsObj.WithdrawRequest();
        }

        [Then(@"The Buyer is able to see the request as withdrawn")]
        public void ThenTheBuyerAmAbleToSeeMyRequestAsWithdrawn()
        {
            ExcelLib.PopulateInCollection(ExcelPath, "ManageRequests");
            string skill = ExcelLib.ReadData(2, "Title");
            string statusCheck = manageRequestsObj.GetSentSkillStatus(skill);
            Assert.AreEqual("Withdrawn", statusCheck, "Actual status and expected status do not match");
        }

        [When(@"The Seller clicks Manage received Requests")]
        public void WhenTheSellerClicksManageReceivedRequests()
        {
            manageRequestsObj.ClickReceivedRequests();
        }

        [When(@"The Seller clicks button Decline a request")]
        public void WhenTheSellerClicksButtonDeclineARequest()
        {
            manageRequestsObj.DeclineRequest();
        }

        [Then(@"The Seller is able to see the request as declined")]
        public void ThenTheSellerIsAbleToSeeTheRequestAsDeclined()
        {
            ExcelLib.PopulateInCollection(ExcelPath, "ManageRequests");
            string skill = ExcelLib.ReadData(2, "Title");
            string statusCheck = manageRequestsObj.GetReceivedSkillStatus(skill);
            Assert.AreEqual("Declined", statusCheck, "Actual status and expected status do not match.");
        }

        [When(@"The Seller clicks button Accept a request")]
        public void WhenTheSellerClicksButtonAcceptARequest()
        {
            manageRequestsObj.AcceptRequest();
        }

        [Then(@"The Seller is able to see the request as accepted")]
        public void ThenTheSellerIsAbleToSeeTheRequestAsAccepted()
        {
            ExcelLib.PopulateInCollection(ExcelPath, "ManageRequests");
            string skill = ExcelLib.ReadData(2, "Title");
            string statusCheck = manageRequestsObj.GetReceivedSkillStatus(skill);
            Assert.AreEqual("Accepted", statusCheck, "Expected status and Actual status do not match.");
        }

        [When(@"The Seller clicks Complete a request")]
        public void WhenTheSellerClicksCompleteARequest()
        {
            manageRequestsObj.CompleteReceivedRequest();
        }

        [When(@"The Buyer clicks Complete a request")]
        public void WhenTheBuyerClicksCompleteARequest()
        {
            manageRequestsObj.CompleteSentRequest();
        }

        [Then(@"The Buyer is able to see the request as completed")]
        public void ThenTheBuyerIsAbleToSeeTheRequestAsCompleted()
        {
            ExcelLib.PopulateInCollection(ExcelPath, "ManageRequests");
            string skill = ExcelLib.ReadData(2, "Title");
            string statusCheck = manageRequestsObj.GetSentSkillStatus(skill);
            Assert.AreEqual("Completed", statusCheck, "Expected status and Actual status do not match.");
        }

        [Then(@"The Seller is able to see the request as completed")]
        public void ThenTheSellerIsAbleToSeeTheRequestAsCompleted()
        {
            ExcelLib.PopulateInCollection(ExcelPath, "ManageRequests");
            string skill = ExcelLib.ReadData(2, "Title");
            string statusReceivedCheck = manageRequestsObj.GetReceivedSkillStatus(skill);
            Assert.AreEqual("Completed", statusReceivedCheck, "Expected status and Actual status do not match.");
        }

    }
}
