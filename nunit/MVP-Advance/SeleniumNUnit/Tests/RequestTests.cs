using NUnit.Framework;
using SeleniumNUnit.Global;
using SeleniumNUnit.Pages;
using static SeleniumNUnit.Global.GlobalDefinitions;
using static SeleniumNUnit.Pages.ShareSkill;

namespace SeleniumNUnit.Tests
{
    internal class RequestTests : Global.Base
    {
        ManageRequests manageRequestsObj;
        public RequestTests()
        {
            manageRequestsObj = new ManageRequests();
        }

        [Test]
        public void TC6a_WithdrawRequest()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);

            //Send a request from the buyer account
            manageRequestsObj.SendRequest();
            VerifySendRequest();

            //Withdraw the request from the same account
            manageRequestsObj.WithdrawRequest();
            VerifyWithdrawRequest();
        }
        [Test]
        public void TC6b_DeclineRequest()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);

            //Send a request from the buyer account
            manageRequestsObj.SendRequest();
            VerifySendRequest();

            //Decline the request from the seller account
            manageRequestsObj.DeclineRequest();
            VerifyDeclineRequest();
        }
        [Test]
        public void TC6c_AcceptRequest()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);

            //Send a request from the buyer account
            manageRequestsObj.SendRequest();
            VerifySendRequest();

            //Accept the request from the seller account
            manageRequestsObj.AcceptRequest();
            VerifyAcceptRequest();
        }

        [Test]
        public void TC6d_CompleteRequest()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);

            //Send a request from the buyer account
            manageRequestsObj.SendRequest();
            VerifySendRequest();

            //Accept the request from the seller account
            manageRequestsObj.AcceptRequest();
            VerifyAcceptRequest();

            //Complete the request from the seller account
            manageRequestsObj.CompleteReceivedRequest();

            //Complete the request from the buyer account
            manageRequestsObj.CompleteSentRequest();

            //Verify sent request as "completed"
            VerifyCompleteSentRequest();

            //Verify received request as "completed"
            VerifyCompleteReceivedRequest();
        }

        #region Assertions for Requests
        public void VerifySendRequest()
        {
            ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageRequests");
            string title = ExcelLib.ReadData(2, "Title");
            string statusCheck = manageRequestsObj.GetSentRequests();
            Assert.AreEqual(statusCheck, title, "Actual request and expected request do not match");
        }

        public void VerifyWithdrawRequest()
        {
            ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageRequests");
            string skill = ExcelLib.ReadData(2, "Title");
            string statusCheck = manageRequestsObj.GetSentSkillStatus(skill);
            Assert.AreEqual(statusCheck, "Withdrawn", "Actual status and expected status do not match");
        }

        public void VerifyDeclineRequest()
        {
            ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageRequests");
            string skill = ExcelLib.ReadData(2, "Title");
            string statusCheck = manageRequestsObj.GetReceivedSkillStatus(skill);
            Assert.AreEqual(statusCheck, "Declined", "Actual status and expected status do not match.");
        }

        public void VerifyAcceptRequest()
        {
            ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageRequests");
            string skill = ExcelLib.ReadData(2, "Title");
            string statusCheck = manageRequestsObj.GetReceivedSkillStatus(skill);
            Assert.AreEqual(statusCheck, "Accepted", "Actual status and expected status do not match.");
        }

        public void VerifyCompleteReceivedRequest()
        {
            ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageRequests");
            string skill = ExcelLib.ReadData(2, "Title");
            string statusCheck = manageRequestsObj.GetReceivedSkillStatus(skill);
            Assert.AreEqual(statusCheck, "Completed", "Actual status and expected status do not match.");
        }
        public void VerifyCompleteSentRequest()
        {
            ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageRequests");
            string skill = ExcelLib.ReadData(2, "Title");
            string statusCheck = manageRequestsObj.GetSentSkillStatus(skill);
            Assert.AreEqual(statusCheck, "Completed", "Actual status and expected status do not match.");
        }
        #endregion assertions for requests


    }
}