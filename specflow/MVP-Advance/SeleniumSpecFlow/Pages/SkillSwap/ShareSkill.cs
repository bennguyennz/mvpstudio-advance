﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumSpecFlow.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SeleniumSpecFlow.Utilities.CommonDriver;
using static SeleniumSpecFlow.Utilities.WaitHelpers;

namespace SeleniumSpecFlow.Pages.SkillSwap
{
    internal class ShareSkill
    {
        #region Page Objects for EnterShareSkill

        //ShareSkill Button
        private IWebElement btnShareSkill => driver.FindElement(By.LinkText("Share Skill"));

        //Manage Listings
        private IWebElement manageListingsLink => driver.FindElement(By.XPath("//a[@href='/Home/ListingManagement']"));

        //Title
        private IList<IWebElement> Titles => driver.FindElements(By.XPath("//div[@id='listing-management-section']//tbody/tr/td[3]"));

        //Title textbox
        private IWebElement Title => driver.FindElement(By.Name("title"));

        //Description textbox
        private IWebElement Description => driver.FindElement(By.Name("description"));

        //Category Dropdown
        private IWebElement CategoryDropDown => driver.FindElement(By.Name("categoryId"));

        //SubCategory Dropdown
        private IWebElement SubCategoryDropDown => driver.FindElement(By.Name("subcategoryId"));

        //Tag names textbox
        private IWebElement Tags => driver.FindElement(By.XPath("//form[@class='ui form']/div[4]/div[2]/div/div/div/div/input"));

        //Entered displayed Tags
        private IList<IWebElement> displayedTags => driver.FindElements(By.XPath("//form[@class='ui form']/div[4]/div[2]/div/div/div/span/a"));
        //form[@class='ui form']/div[4]/div[2]/div/div/div/span/a

        //Service type radio button
        private IList<IWebElement> radioServiceType => driver.FindElements(By.Name("serviceType"));

        //Location Type radio button
        private IList<IWebElement> radioLocationType => driver.FindElements(By.Name("locationType"));

        //Start Date dropdown
        private IWebElement StartDateDropDown => driver.FindElement(By.Name("startDate"));

        //End Date dropdown
        private IWebElement EndDateDropDown => driver.FindElement(By.Name("endDate"));

        //Available days
        private IList<IWebElement> Days => driver.FindElements(By.XPath("//input[@name='Available']"));

        //Starttime
        private IList<IWebElement> StartTime => driver.FindElements(By.Name("StartTime"));

        //EndTime
        private IList<IWebElement> EndTime => driver.FindElements(By.Name("EndTime"));


        //StartTime dropdown
        private IWebElement StartTimeDropDown => driver.FindElement(By.XPath("//div[3]/div[2]/input[1]"));

        //EndTime dropdown
        private IWebElement EndTimeDropDown => driver.FindElement(By.XPath("//div[3]/div[3]/input[1]"));

        //Skill Trade option
        private IList<IWebElement> radioSkillTrade => driver.FindElements(By.Name("skillTrades"));

        //Skill Exchange
        private IWebElement SkillExchange => driver.FindElement(By.XPath("//div[@class='form-wrapper']//input[@type='text']"));
        private IList<IWebElement> skillExchangeTags => driver.FindElements(By.XPath("//form[@class='ui form']/div[8]/div[4]/div/div/div/div/span/a"));


        //Credit textbox
        private IWebElement CreditAmount => driver.FindElement(By.XPath("//input[@placeholder='Amount']"));

        //Work Samples button
        private IWebElement btnWorkSamples => driver.FindElement(By.XPath("//i[@class='huge plus circle icon padding-25']"));

        //Active option
        private IList<IWebElement> radioActive => driver.FindElements(By.XPath("//input[@name='isActive']"));

        //Save button
        private IWebElement Save => driver.FindElement(By.XPath("//input[@value='Save']"));

        #endregion

        #region Page Objects for VerifyShareSkill
        //Title
        private IWebElement actualTitle => driver.FindElement(By.XPath("//span[@class='skill-title']"));

        //Description
        private IWebElement actualDescription => driver.FindElement(By.XPath("//div[text()='Description']//following-sibling::div"));

        //Category
        private IWebElement actualCategory => driver.FindElement(By.XPath("//div[text()='Category']//following-sibling::div"));

        //Subcategory
        private IWebElement actualSubcategory => driver.FindElement(By.XPath("//div[text()='Subcategory']//following-sibling::div"));

        //Service Type
        private IWebElement actualServiceType => driver.FindElement(By.XPath("//div[text()='Service Type']//following-sibling::div"));

        //Start Date
        private IWebElement actualStartDate => driver.FindElement(By.XPath("//div[text()='Start Date']//following-sibling::div"));

        //End Date
        private IWebElement actualEndDate => driver.FindElement(By.XPath("//div[text()='End Date']//following-sibling::div"));

        //Location Type
        private IWebElement actualLocationType => driver.FindElement(By.XPath("//div[text()='Location Type']//following-sibling::div"));

        //Skill Trade
        private IWebElement actualSkillsTrade => driver.FindElement(By.XPath("//div[text()='Skills Trade']//following-sibling::div"));

        //Skill Exchange
        private IWebElement actualSkillExchange => driver.FindElement(By.XPath("//div[text()='Skills Trade']//following-sibling::div/span"));
        #endregion

        public void ClickButtonShareSkill()
        {
            btnShareSkill.Click();
            wait(3);
        }
        public void EnterShareSkill(string title, string description, string category, string subcategory, string tags, string serviceType,
            string locationType, string startDate, string endDate, string availableDays, string startTime, string endTime, string skillTrade,
            string skillExchange, string credit, string active)
        {

            //Enter Title 
            Title.SendKeys(title);

            //Enter Description
            Description.SendKeys(description);

            //Select category
            var selectCategory = new SelectElement(CategoryDropDown);
            selectCategory.SelectByText(category);

            //Select Subcategory
            var selectSubcategory = new SelectElement(SubCategoryDropDown);
            selectSubcategory.SelectByText(subcategory);

            //Enter tag
            Tags.Click();
            Tags.SendKeys(tags);
            Tags.SendKeys(Keys.Return);

            //Select Service type
            SelectServiceType(serviceType);

            //Select Location type
            SelectLocationType(locationType);

            //Enter Start date
            StartDateDropDown.SendKeys(startDate);

            //Enter End date
            EndDateDropDown.SendKeys(endDate);

            //Enter Available days and hours
            EnterAvailableDaysAndHours((availableDays), (startTime), (endTime));

            //Select Skill Trade: "Credeit" or "Skill-exchange"
            SelectSkillTrade(skillTrade, skillExchange, credit);

            //Click button Upload Work Samples
            UploadWorkSamples();

            //Click Active or Hidden
            ClickActiveOption(active);

            //Click on Save
            Save.Click();

        }
        //Select Service type
        internal void SelectServiceType(string serviceTypeText)
        {
            string elementValue = "0";
            if (serviceTypeText.Equals("One-off service"))
                elementValue = "1";

            for (int i = 0; i < radioServiceType.Count(); i++)
            {
                string actualElementValue = radioServiceType[i].GetAttribute("Value");
                if (elementValue.Equals(actualElementValue))
                    radioServiceType[i].Click();
            }
        }

        //Select Location type
        internal void SelectLocationType(string locationTypeText)
        {
            //Select Location type
            string elementValue = "0";
            if (locationTypeText.Equals("Online"))
                elementValue = "1";

            for (int i = 0; i < radioLocationType.Count(); i++)
            {
                string actualElementValue = radioLocationType[i].GetAttribute("Value");
                if (elementValue.Equals(actualElementValue))
                    radioLocationType[i].Click();
            }
        }

        //Enter Available days and hours
        internal void EnterAvailableDaysAndHours(string availableDaysText, string startTimeText, string endTimeText)
        {
            //Enter available Days array = 
            string indexValue = "";

            switch (availableDaysText)
            {
                case "Sun":
                    indexValue = "0";
                    break;
                case "Mon":
                    indexValue = "1";
                    break;
                case "Tue":
                    indexValue = "2";
                    break;
                case "Wed":
                    indexValue = "3";
                    break;
                case "Thu":
                    indexValue = "4";
                    break;
                case "Fri":
                    indexValue = "5";
                    break;
                case "Sat":
                    indexValue = "6";
                    break;
                default:
                    Assert.Ignore("Day is invalid.");
                    break;
            }

            for (int i = 0; i < Days.Count; i++)
            {
                if (indexValue.Equals(Days[i].GetAttribute("index")))
                {
                    Days[i].Click();

                    StartTime[i].SendKeys(startTimeText);
                    EndTime[i].SendKeys(endTimeText);
                }
            }
        }

        //Select Skill trade
        internal void SelectSkillTrade(string skillTradeText, string skillExchangeText, string creditText)
        {
            //Select "Skill Trade" options
            string elementValue = "true";

            if (skillTradeText.Equals("Credit"))
                elementValue = "false";

            for (int i = 0; i < radioSkillTrade.Count(); i++)
            {
                string actualElementValue = radioSkillTrade[i].GetAttribute("value");
                if (elementValue.Equals(actualElementValue))
                {
                    //Select "Skill exchange" or "Credit"
                    radioSkillTrade[i].Click();
                    wait(1);

                    if (skillTradeText.Equals("Skill-exchange"))
                    {
                        //Enter tags for Skill-exchange
                        SkillExchange.Click();
                        SkillExchange.SendKeys(skillExchangeText);
                        SkillExchange.SendKeys(Keys.Return);
                    }
                    else
                    {
                        //Enter Credit amount
                        CreditAmount.SendKeys(creditText);
                    }
                }
            }
        }

        //Upload Work samples
        internal void UploadWorkSamples()
        {
            btnWorkSamples.Click();
            wait(3);

            //Run AutoIT-script to execute file uploading
            using (Process exeProcess = Process.Start(GlobalDefinitions.AutoScriptPath))
            {
                exeProcess.WaitForExit();
            }
        }

        //Click Active or Hidden
        internal void ClickActiveOption(string ActiveOptionText)
        {
            string elementValue = "true";
            if (ActiveOptionText.Equals("Hidden"))
                elementValue = "false";

            for (int i = 0; i < radioActive.Count(); i++)
            {
                string actualElementValue = radioActive[i].GetAttribute("Value");
                if (elementValue.Equals(actualElementValue))
                    radioActive[i].Click();
            }
        }

        internal void ViewMySkillDetails(string title)
        {
            //Click on ManageListing
            GoToManageListings();
            wait(2);

            //Click on button View
            string e_View = "//div[@id='listing-management-section']//tbody/tr[" + GetTitleIndex(title) + "]/td[8]/div/button[1]";
            IWebElement btnView = driver.FindElement(By.XPath(e_View));
            btnView.Click();
            wait(2);
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

        #region struct and sub-methods for assertions
        internal struct Listing
        {
            public string title;
            public string description;
            public string category;
            public string subcategory;
            public string startDate;
            public string endDate;
            public string serviceType;
            public string locationType;

        }
        internal void GetWeb(out Listing webData)
        {
            webData.title = actualTitle.Text;
            webData.description = actualDescription.Text;
            webData.category = actualCategory.Text;
            webData.subcategory = actualSubcategory.Text;
            webData.startDate = SplitJointDate(actualStartDate.Text);
            webData.endDate = SplitJointDate(actualEndDate.Text);
            webData.serviceType = actualServiceType.Text;
            webData.locationType = actualLocationType.Text;
        }
        #endregion

        internal string GetSkillTrade(string skillTradeOption)
        {
            if (skillTradeOption == "Credit")
                return actualSkillsTrade.Text;
            else
                return actualSkillExchange.Text;
        }

        private string SplitJointDate(string date)
        {
            string[] arrayDate = date.Split('-');
            string newDate = arrayDate[2] + '/' + arrayDate[1] + '/' + arrayDate[0];
            return newDate;
        }
    }
}