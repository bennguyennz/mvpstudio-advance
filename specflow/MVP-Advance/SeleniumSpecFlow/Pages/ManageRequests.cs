using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SeleniumSpecFlow.Utilities.GlobalDefinitions;
using static SeleniumSpecFlow.Utilities.CommonDriver;
using static SeleniumSpecFlow.Utilities.WaitHelpers;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using SeleniumSpecFlow.Utilities;

namespace SeleniumSpecFlow.Pages
{
    internal class ManageRequests
    {

        #region POM for manage requests
        private IWebElement btnSignOut => driver.FindElement(By.LinkText("Sign Out"));
        private IWebElement tbxSearchSkills => driver.FindElement(By.XPath("//input[@placeholder='Search skills']"));
        private IList<IWebElement> titles => driver.FindElements(By.XPath("//div[@class='row']//a[@class='service-info']/p"));
        private IWebElement btnRequest => driver.FindElement(By.XPath("//div[contains(@class,'button')]"));
        private IWebElement messageRequest => driver.FindElement(By.TagName("textarea"));
        private IWebElement btnYes => driver.FindElement(By.XPath("//button[1][@role='button']"));
        private IWebElement btnNo => driver.FindElement(By.XPath("//button[2][@role='button']"));
        private IWebElement manageRequests => driver.FindElement(By.XPath("//div[@class='ui dropdown link item']"));
        private IWebElement ddwnSentRequests => driver.FindElement(By.LinkText("Sent Requests"));
        private IWebElement ddwnReceivedRequests => driver.FindElement(By.LinkText("Received Requests"));
        private IList<IWebElement> assertSentTitles => driver.FindElements(By.XPath("//div[@id='sent-request-section']//tbody/tr/td[2]/a"));
        private IList<IWebElement> assertReceivedTitles => driver.FindElements(By.XPath("//div[@id='received-request-section']//tbody/tr/td[2]/a"));
        private string categoryColumn = "//th[contains(text(),'Category')]";
        #endregion
        public void SendRequest()
        {
            //Populate excel data
            ExcelLib.PopulateInCollection(ExcelPath, "ManageRequests");
            string skill = ExcelLib.ReadData(2, "Title");
            string message = ExcelLib.ReadData(2, "Message");

            //Switch account buyer
            SwitchAccount(3);

            //Enter skill into Search skill textbox
            tbxSearchSkills.SendKeys(skill);
            tbxSearchSkills.SendKeys(Keys.Enter);
            wait(3);

            //Look for the matching skill and click on it.
            for (int i = 0; i < titles.Count(); i++)
            {
                if (titles[i].Text.Equals(skill))
                {
                    titles[i].Click();
                    wait(3);

                    //Enter message
                    messageRequest.SendKeys(message);

                    //Click on request button
                    btnRequest.Click();
                    wait(3);

                    //Confirm
                    btnYes.Click();
                }
                else
                    Assert.Ignore("No skill found");
            }
        }

        public void SwitchAccount(int accNumber)
        {
            //Initiate a Signin Object
            Login logInObj = new Login();

            //SignOut initial account to login a different account to make a request
            btnSignOut.Click();
            wait(3);
            logInObj.LogInSteps(accNumber);
        }

        public void ClickSentRequests()
        {
            //Log in the Seller account
            SwitchAccount(3);

            //Mousehover 
            Actions action = new Actions(driver);
            action.MoveToElement(manageRequests).Perform();
            wait(3);

            //Click "Sent Rquests" option
            ddwnSentRequests.Click();

            //Wait for table to be displayed
            WaitHelpers.WaitToBeVisible(driver, "XPath", categoryColumn, 10);
        }

        public void ClickReceivedRequests()
        {
            //Log in the Seller account
            SwitchAccount(2);

            //Mousehover 
            Actions action = new Actions(driver);
            action.MoveToElement(manageRequests).Perform();
            wait(3);

            //Click "Received Rquests" option
            ddwnReceivedRequests.Click();

            //wait for table to be displayed
            WaitHelpers.WaitToBeVisible(driver, "XPath", categoryColumn, 10);
        }

        public void WithdrawRequest()
        {
            //Populate Excel and get request name
            ExcelLib.PopulateInCollection(ExcelPath, "ManageRequests");
            string skill = ExcelLib.ReadData(2, "Title");

            //Click sent requests
            ClickSentRequests();

            //Get skill index in Sent Requests table
            string index = "//div[@id='sent-request-section']//tbody/tr[" + GetSentSkillIndex(skill) + "]/td[8]/button";

            //Click button Withdraw of correspondent skill
            IWebElement btnWithdraw = driver.FindElement(By.XPath(index));
            btnWithdraw.Click();
        }

        public void DeclineRequest()
        {
            //Populate Excel and get request name
            ExcelLib.PopulateInCollection(ExcelPath, "ManageRequests");
            string skill = ExcelLib.ReadData(2, "Title");

            //Get skill index in Sent Requests table
            string index = "//div[@id='received-request-section']//tbody/tr[" + GetReceivedSkillIndex(skill) + "]/td[8]/button[2]";

            //Click button Decline
            IWebElement btnDelecine = driver.FindElement(By.XPath(index));
            btnDelecine.Click();
        }

        public void AcceptRequest()
        {
            //Populate Excel and get request name
            ExcelLib.PopulateInCollection(ExcelPath, "ManageRequests");
            string skill = ExcelLib.ReadData(2, "Title");

            //Get skill index in Sent Requests table
            string index = "//div[@id='received-request-section']//tbody/tr[" + GetReceivedSkillIndex(skill) + "]/td[8]/button[1]";

            //Click button "Accept"
            IWebElement btnAccept = driver.FindElement(By.XPath(index));
            btnAccept.Click();
            driver.Navigate().Refresh();
        }

        public void CompleteReceivedRequest()
        {
            //Populate Excel and get request name
            ExcelLib.PopulateInCollection(ExcelPath, "ManageRequests");
            string skill = ExcelLib.ReadData(2, "Title");

            //Get skill index in Sent Requests table
            string index = "//div[@id='received-request-section']//tbody/tr[" + GetReceivedSkillIndex(skill) + "]/td[8]/button";
            WaitHelpers.WaitToBeClickable(driver, "XPath", index, 5);

            //Click button "Complete"
            IWebElement btnComplete = driver.FindElement(By.XPath(index));
            btnComplete.Click();
            Thread.Sleep(3);
        }

        public void CompleteSentRequest()
        {
            //Populate Excel and get request name
            ExcelLib.PopulateInCollection(ExcelPath, "ManageRequests");
            string skill = ExcelLib.ReadData(2, "Title");

            //Get skill index in Sent Requests table
            string index = "//div[@id='sent-request-section']//tbody/tr[" + GetSentSkillIndex(skill) + "]/td[8]/button";

            WaitHelpers.WaitToBeClickable(driver, "XPath", index, 5);
            //Click button "Complete"
            IWebElement btnComplete = driver.FindElement(By.XPath(index));
            btnComplete.Click();
        }

        public string GetSentSkillStatus(string skill)
        {
            //Click sent requests
            ClickSentRequests();

            //Get skill index in sent Request table
            string index = "//div[@id='sent-request-section']//tbody/tr[" + GetSentSkillIndex(skill) + "]/td[5]";

            //return current Status
            IWebElement statusText = driver.FindElement(By.XPath(index));
            return statusText.Text;
        }

        public string GetReceivedSkillStatus(string skill)
        {
            //Log in the Seller account
            SwitchAccount(2);

            //Click sent requests
            ClickReceivedRequests();

            WaitHelpers.WaitToBeVisible(driver, "XPath", categoryColumn, 10);

            //Get skill index in sent Request table
            string index = "//div[@id='received-request-section']//tbody/tr[" + GetReceivedSkillIndex(skill) + "]/td[5]";

            //return current Status
            IWebElement status = driver.FindElement(By.XPath(index));
            return status.Text;
        }

        public string GetReceivedSkillIndex(string skill)
        {
            for (int i = 0; i < assertReceivedTitles.Count(); i++)
            {
                if (assertReceivedTitles[i].Text.Equals(skill))
                {
                    return (i + 1).ToString();
                }
                else
                    return "Cannot find the matching skill";
            }
            return "There's no skill which is requested.";
        }

        public string GetSentSkillIndex(string skill)
        {
            for (int i = 0; i < assertSentTitles.Count(); i++)
            {
                if (assertSentTitles[i].Text.Equals(skill))
                {
                    return (i + 1).ToString();
                }
                else
                    return "Cannot find the matching skill";
            }
            return "There's no skill which is requested.";
        }

    }
}
