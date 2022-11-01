using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumSpecFlow.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SeleniumSpecFlow.Utilities.CommonDriver;
using static SeleniumSpecFlow.Utilities.WaitHelpers;

namespace SeleniumSpecFlow.Pages.ProfilePages
{
    internal class Contact
    {
        #region page elements
        private IWebElement message => driver.FindElement(By.XPath(e_message));
        private IWebElement editNameDropdown => driver.FindElement(By.XPath(e_buttonEditName));
        private IWebElement firstName => driver.FindElement(By.Name(e_firstName));
        private IWebElement lastName => driver.FindElement(By.Name("lastName"));
        private IWebElement buttonSave => driver.FindElement(By.XPath("//button[@class='ui teal button']"));
        private IWebElement fullName => driver.FindElement(By.XPath(e_fullName));
        private IWebElement buttonEditAvailabilityType => driver.FindElement(By.XPath("//div[@class='ui list']/div[2]/div/span/i"));
        private IWebElement availibilityTypeDropdown => driver.FindElement(By.XPath(e_vailabilityTypeDropdown));
        private IWebElement editAvailabilityHour => driver.FindElement(By.XPath("//div[@class='ui list']/div[3]/div/span/i"));
        private IWebElement availibilityHourDropdown => driver.FindElement(By.XPath(e_availibilityHourDropdown));
        private IWebElement editEarnTarget => driver.FindElement(By.XPath("//div[@class='ui list']/div[4]/div/span/i"));
        private IWebElement availibilityTargetDropdown => driver.FindElement(By.XPath(e_availabilityTargetDropdown));
        private IWebElement availabiltyType => driver.FindElement(By.XPath(e_availibilityType));
        private IWebElement availabiltyHour => driver.FindElement(By.XPath(e_availibilityHour));
        private IWebElement availabilityTarget => driver.FindElement(By.XPath(e_availibilityTarget));
        private IWebElement descriptionButton => driver.FindElement(By.XPath(e_descriptionButton));
        private IWebElement descriptionTextBox => driver.FindElement(By.XPath("//div[@class='field  ']/textarea"));
        private IWebElement saveButton => driver.FindElement(By.XPath("//button[@type='button']"));
        private IWebElement addedDescription => driver.FindElement(By.XPath(e_addedDescription));

        //Wait elements
        private string e_message = "//div[@class='ns-box-inner']";
        private string e_buttonEditName = "//div[@class='title']/i[@class='dropdown icon']";
        private string e_firstName = "firstName";
        private string e_fullName = "//div[@class = 'title']";
        private string e_vailabilityTypeDropdown = "//select[@name='availabiltyType']";
        private string e_availibilityHourDropdown = "//select[@name='availabiltyHour']";
        private string e_availabilityTargetDropdown = "//select[@name='availabiltyTarget']";
        private string e_availibilityType = "//div[@class='ui list']/div[2]/div/span";
        private string e_availibilityHour = "//div[@class='ui list']/div[3]/div/span";
        private string e_availibilityTarget = "//div[@class='ui list']/div[4]/div/span";
        private string e_descriptionButton = "//div[@class='content']/div/h3/span";
        private string e_addedDescription = "//div[@class='ui fluid card']/div/div[1]/span";
        #endregion

        public void EditMyContactDetails(string strFirstName, string strLastName, string availability, string hour, string earnTarget)
        {
            switch (availability)
            {
                case "Part Time":
                    availability = "0";
                    break;
                case "Full Time":
                    availability = "1";
                    break;
            }
            switch (hour)
            {
                case "Less than 30hours a week":
                    hour = "0";
                    break;
                case "More than 30hours a week":
                    hour = "1";
                    break;
                case "As needed":
                    hour = "2";
                    break;
            }
            switch (earnTarget)
            {
                case "Less than $500 per month":
                    earnTarget = "0";
                    break;
                case "Between $500 and $1000 per month":
                    earnTarget = "1";
                    break;
                case "More than $1000 per month":
                    earnTarget = "2";
                    break;
            }

            //wait for dropdown icon to be clickable
            WaitHelpers.WaitToBeClickable(driver, "XPath", e_buttonEditName, 10);

            //Click on dropdown icon before Full name
            editNameDropdown.Click();

            //Edit first name
            WaitHelpers.WaitToBeClickable(driver, "Name", e_firstName, 10);

            firstName.Click();
            firstName.Clear();
            firstName.SendKeys(strFirstName);

            //edit last name
            lastName.Click();
            lastName.Clear();
            lastName.SendKeys(strLastName);

            wait(10);
            //click Save
            buttonSave.Click();

            //Wait for Save completed and Name appears.
            WaitHelpers.WaitToBeVisible(driver, "XPath", e_fullName, 10);

            //Click edit Availibility Type
            Actions action = new Actions(driver);
            action.MoveToElement(buttonEditAvailabilityType).Click().Build().Perform();

            //Select type
            WaitHelpers.WaitToBeVisible(driver, "XPath", e_vailabilityTypeDropdown, 10);
            var availabilityType = new SelectElement(availibilityTypeDropdown);
            availabilityType.SelectByValue(availability);

            //Click on edit Hours
            editAvailabilityHour.Click();

            //Select hours
            WaitHelpers.WaitToBeVisible(driver, "XPath", e_availibilityHourDropdown, 3);
            var availabilityHour = new SelectElement(availibilityHourDropdown);
            availabilityHour.SelectByValue(hour);

            //Click on Edit Earn Targe
            editEarnTarget.Click();

            //Select Earn Target
            WaitHelpers.WaitToBeVisible(driver, "XPath", e_availabilityTargetDropdown, 3);
            var availabiltyTarget = new SelectElement(availibilityTargetDropdown);
            availabiltyTarget.SelectByValue(earnTarget);
        }

        public string GetMessage()
        {
            WaitHelpers.WaitToBeVisible(driver, "XPath", e_message, 3);
            return message.Text;
        }

        public string GetFullName()
        {
            WaitHelpers.WaitToBeVisible(driver, "XPath", e_fullName, 3);
            return fullName.Text;
        }

        public string GetAvailabilityType()
        {
            WaitHelpers.WaitToBeVisible(driver, "XPath", e_availibilityType, 3);
            return availabiltyType.Text;
        }

        public string GetAvailityHour()
        {
            WaitHelpers.WaitToBeVisible(driver, "XPath", e_availibilityHour, 3);
            return availabiltyHour.Text;
        }

        public string GetAvailityTarget()
        {
            WaitHelpers.WaitToBeVisible(driver, "XPath", e_availibilityTarget, 3);
            return availabilityTarget.Text;
        }
    }
}
