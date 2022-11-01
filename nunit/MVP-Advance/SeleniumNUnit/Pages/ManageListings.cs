using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumNUnit.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SeleniumNUnit.Global.GlobalDefinitions;
using static SeleniumNUnit.Global.WaitHelpers;

namespace SeleniumNUnit.Pages
{
    internal class ManageListings
    {
        #region Manage listing's page objects
        //ShareSkill Button
        private IWebElement btnShareSkill => driver.FindElement(By.LinkText("Share Skill"));

        //Manage Listings
        private IWebElement manageListingsLink => driver.FindElement(By.XPath("//a[@href='/Home/ListingManagement']"));

        //Message warning no listing
        private IWebElement warningMessage => driver.FindElement(By.XPath("//h3[contains(text(),'You do not have any service listings!')]"));

        //Wait element
        private string eTable = "//div[@id='listing-management-section']//table/thead/tr/th[1]";

        //Title
        private IList<IWebElement> Titles => driver.FindElements(By.XPath("//div[@id='listing-management-section']//tbody/tr/td[3]"));

        //View button
        private IWebElement view => driver.FindElement(By.XPath("(//i[@class='eye icon'])[1]"));

        //Edit button
        private IWebElement edit => driver.FindElement(By.XPath("(//i[@class='outline write icon'])[1]"));

        //Yes/No button
        private IList<IWebElement> clickActionsButton => driver.FindElements(By.XPath("//div[@class='actions']/button"));

        //Save button
        private IWebElement btnSave => driver.FindElement(By.XPath("//input[@value='Save']"));
        #endregion

        //Object initilization
        ShareSkill shareSkillObj;
        public ManageListings()
        {
            shareSkillObj = new ShareSkill();
        }

        //Add a skill
        internal void AddListing(int rowNumber, string worksheet)
        {
            btnShareSkill.Click();
            wait(2);
            shareSkillObj.EnterShareSkill(rowNumber, worksheet);
            wait(3);
        }

        //Verify add & edit
        internal void ViewListing(string titleIndex)
        {
            //Wait for table to display
            WaitForElement(driver, By.XPath(eTable), 5);

            //Click on button View
            string e_View = "//div[@id='listing-management-section']//tbody/tr[" + titleIndex + "]/td[8]/div/button[1]";
            IWebElement btnView = driver.FindElement(By.XPath(e_View));
            btnView.Click();

            wait(2);
        }

        internal void EnterShareSkill_Invalid(int testData, string worksheet)
        {
            //Click on button ShareSkill
            btnShareSkill.Click();
            wait(1);

            //Enter invalid data
            shareSkillObj.EnterShareSkill_InvalidData(testData, "NegativeTC");
            Thread.Sleep(2000);
        }

        //Functions to check title is existing and return title's position in manage listing
        internal string GetTitleIndex(string expectedTitle)
        {
            //Click Manage Listing
            manageListingsLink.Click();

            //Check if there is no listing's title
            string recordIndex = "";
            int titleCount = Titles.Count();
            if (titleCount.Equals(0))
            {
                return "There is no listing record.";
            }
            else
            {
                //Find title: Break loop when finding a title. Output: recordIndex
                for (int i = 0; i < titleCount; i++)
                {
                    string actualTitle = Titles[i].Text;
                    if (actualTitle.Equals(expectedTitle))
                    {
                        recordIndex = (i + 1).ToString();
                        break;
                    }
                }
                //If title-to-delete is not found
                if (recordIndex.Equals(""))
                {
                    string errorMessage = "Listing is not found.";
                    return errorMessage;
                }
            }
            return recordIndex;
        }
    }
}
