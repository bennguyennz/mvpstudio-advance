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

        ShareSkill shareSkillObj;

        //Add a skill
        internal void AddListing(int rowNumber, string worksheet)
        {
            shareSkillObj = new ShareSkill();
            btnShareSkill.Click();
            wait(2);
            shareSkillObj.EnterShareSkill(rowNumber, worksheet);
            wait(3);
        }

        //Verify add & edit
        internal void ViewListing(int rowNumber, string worksheet)
        {

            //Click on ManageListing
            GoToManageListings();
            wait(2);

            //Read data
            ExcelLib.PopulateInCollection(Base.ExcelPath, worksheet);
            string expectedTitle = ExcelLib.ReadData(rowNumber, "Title");

            //Click on button View
            string e_View = "//div[@id='listing-management-section']//tbody/tr[" + GetTitleIndex(expectedTitle) + "]/td[8]/div/button[1]";
            IWebElement btnView = driver.FindElement(By.XPath(e_View));
            btnView.Click();

            wait(2);
        }

        internal void EnterShareSkill_Invalid(int testData, string worksheet)
        {
            shareSkillObj = new ShareSkill();
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
            //Check if there is no listing's title
            string recordIndex = "";
            int titleCount = Titles.Count();
            if (titleCount.Equals(0))
            {
                Assert.Ignore("There is no listing record.");
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
                    Assert.Ignore("Listing '" + expectedTitle + "' is not found.");
                }
            }
            return recordIndex;
        }

        //Click on manage listing
        internal void GoToManageListings()
        {
            try
            {
                //Click Manage Listing
                manageListingsLink.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Manage Listing link is not found.", ex.Message);
            }
        }
    }
}
