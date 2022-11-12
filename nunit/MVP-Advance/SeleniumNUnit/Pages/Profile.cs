using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
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
    internal class Profile
    {
        #region page objec model (POM)
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

        #region  Initialize Web Elements 
        //Click on Edit button
        private IWebElement AvailabilityTimeEdit => driver.FindElement(By.XPath("//span[contains(text(),'Part Time'));//i[@class='right floated outline small write icon']"));

        //Click on Availability Time dropdown
        private IWebElement AvailabilityTime => driver.FindElement(By.Name("availabiltyType"));

        //Click on Availability Time option
        private IWebElement AvailabilityTimeOpt => driver.FindElement(By.XPath("//option[@value='0']"));

        //Click on Availability Hour dropdown
        private IWebElement AvailabilityHours => driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[1]/div/div[3]/div"));

        //Click on salary
        private IWebElement Salary => driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[1]/div/div[4]/div"));

        //Click on Location
        private IWebElement Location => driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[2]/div/div[2]/div"));

        //Choose Location
        private IWebElement LocationOpt => driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[2]/div/div[2]/div/div[2]"));

        //Click on City
        private IWebElement City => driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[2]/div/div[3]/div"));

        //Choose City
        private IWebElement CityOpt => driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[2]/div/div[3]/div/div[2]"));

        //Click on Add new to add new Language
        private IWebElement AddNewLangBtn => driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));

        //Enter the Language on text box
        private IWebElement AddLangText => driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[3]/div/div[2]/div/div/div[1]/input"));

        //Enter the Language on text box
        private IWebElement ChooseLang => driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[3]/div/div[2]/div/div/div[2]/select"));

        //Enter the Language on text box
        private IWebElement ChooseLangOpt => driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[3]/div/div[2]/div/div/div[2]/select/option[3]"));

        //Add Language
        private IWebElement AddLang => driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[3]/div/div[2]/div/div/div[3]/input[1]"));

        //Click on Add new to add new skill
        private IWebElement AddNewSkillBtn => driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[4]/div/div[2]/div/table/thead/tr/th[3]/div"));

        //Enter the Skill on text box
        private IWebElement AddSkillText => driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[4]/div/div[2]/div/div/div[1]/input"));

        //Click on skill level dropdown
        private IWebElement ChooseSkill => driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[4]/div/div[2]/div/div/div[2]/select"));

        //Choose the skill level option
        private IWebElement ChooseSkilllevel => driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[4]/div/div[2]/div/div/div[2]/select/option[3]"));

        //Add Skill
        private IWebElement AddSkill => driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[4]/div/div[2]/div/div/span/input[1]"));

        //Click on Add new to Educaiton
        private IWebElement AddNewEducation => driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[5]/div/div[2]/div/table/thead/tr/th[6]/div"));


        //Enter university in the text box
        private IWebElement EnterUniversity => driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[5]/div/div[2]/div/div/div[1]/div[1]/input"));


        //Choose the country
        private IWebElement ChooseCountry => driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[5]/div/div[2]/div/div/div[1]/div[2]/select"));

        //Choose the skill level option
        private IWebElement ChooseCountryOpt => driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[5]/div/div[2]/div/div/div[1]/div[2]/select/option[6]"));

        //Click on Title dropdown
        private IWebElement ChooseTitle => driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[5]/div/div[2]/div/div/div[2]/div[1]/select"));

        //Choose title
        private IWebElement ChooseTitleOpt => driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[5]/div/div[2]/div/div/div[2]/div[1]/select/option[5]"));

        //Degree
        private IWebElement Degree => driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[5]/div/div[2]/div/div/div[2]/div[2]/input"));

        //Year of graduation
        private IWebElement DegreeYear => driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[5]/div/div[2]/div/div/div[2]/div[3]/select"));

        //Choose Year
        private IWebElement DegreeYearOpt => driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[5]/div/div[2]/div/div/div[2]/div[3]/select/option[4]"));

        //Click on Add
        private IWebElement AddEdu => driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[5]/div/div[2]/div/div/div[3]/div/input[1]"));

        //Add new Certificate
        private IWebElement AddNewCerti => driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[6]/div/div[2]/div/table/thead/tr/th[4]/div"));

        //Enter Certification Name
        private IWebElement EnterCerti => driver.FindElement(By.Name("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[6]/div/div[2]/div/div/div[1]/div/input"));

        //Certified from
        private IWebElement CertiFrom => driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[6]/div/div[2]/div/div/div[2]/div[1]/input"));

        //Year
        private IWebElement CertiYear => driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[6]/div/div[2]/div/div/div[2]/div[2]/select"));

        //Choose Opt from Year
        private IWebElement CertiYearOpt => driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[6]/div/div[2]/div/div/div[2]/div[2]/select/option[5]"));

        //Add Ceritification
        private IWebElement AddCerti => driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[6]/div/div[2]/div/div/div[3]/input[1]"));

        //Add Desctiption
        private IWebElement Description => driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[8]/div/div[2]/div[1]/textarea"));

        //Click on Save Button
        private IWebElement Save => driver.FindElement(By.XPath("//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[8]/div/div[4]/span/button[1]"));

        #endregion

        #region Language Tab 

        //Identify language Tab and click
        private IWebElement languageTab => driver.FindElement(By.XPath("//div/section[2]/div/div/div/div[3]/form/div[1]/a[1]"));

        //Click on Add new to add new Language
        private IWebElement AddNewLangButton => driver.FindElement(By.XPath("//div/section[2]//div[3]/form/div[2]//div[2]/div/table/thead/tr/th[3]/div"));

        //Enter the Language on text box
        private IWebElement AddLanguageText => driver.FindElement(By.XPath("//div[@class='eight wide column']//input[@type='text']"));

        //Click on choose language level
        private IWebElement ChooseLanguage => driver.FindElement(By.XPath("//div/section[2]//div[3]/form/div[2]//div[2]//div[2]/select"));

        //Click on Add Language
        private IWebElement AddLanguage => driver.FindElement(By.XPath("//div[@class='eight wide column']//input[@type='button']"));

        //Populate excel data
        private IWebElement editLangIcon => driver.FindElement(By.XPath("//div/section[2]//div[3]/form/div[2]//div[2]/div/table/tbody/tr/td[3]/span[1]/i"));
        //Click on edit language icon
        private IWebElement editLangText => driver.FindElement(By.XPath("//div[@class='five wide field']//input[@type='text']"));
        //Click on Language level
        private IWebElement editChooseLang => driver.FindElement(By.XPath("//div/section[2]//div[3]/form/div[2]//div[2]/div/table/tbody/tr/td//div[2]/select"));

        //Click on update language
        private IWebElement updateLang => driver.FindElement(By.XPath("//span[@class='buttons-wrapper']//input[@type='button']"));
        //Click on delete icon
        private IWebElement deleteLangIcon => driver.FindElement(By.XPath("//div/section[2]//div[3]/form/div[2]//div/table/tbody/tr/td[3]/span[2]/i"));

        //Assertion
        //Check if the add language created
        private IWebElement newAddLanguage => driver.FindElement(By.XPath("//div/section[2]//div[3]/form/div[2]//div[2]/div/table/tbody[last()]/tr/td[1]"));
        private IWebElement newLanguageLevel => driver.FindElement(By.XPath("//div/section[2]//div[3]/form/div[2]//div[2]/div/table/tbody[last()]/tr/td[2]"));

        //Check if the edited language created
        private IWebElement editNewLanguage => driver.FindElement(By.XPath("//div/section[2]//div/div[3]/form/div[2]//div[2]/div/table/tbody[last()]/tr/td[1]"));      
        private IWebElement editNewLanguageLevel => driver.FindElement(By.XPath("//div/section[2]//div[3]/form/div[2]//div[2]/div/table/tbody[last()]/tr/td[2]"));

        //Check the edited record present or not in the language tab
        private IWebElement editedLanguageTab => driver.FindElement(By.XPath("//div/section[2]/div/div/div/div[3]/form/div[1]/a[1]"));

       
        //Error message after save
        private IWebElement LangErrorMessage => driver.FindElement(By.XPath("/html/body/div[1]"));

        
        #endregion




        internal void EditMyContactDetails(int row, string worksheet)
        {
            //Populate excel data
            ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");
            string availability = ExcelLib.ReadData(2, "Availability");
            string hour = ExcelLib.ReadData(2, "Hours");
            string earnTarget = ExcelLib.ReadData(2, "EarnTarget");
            string sFirstName = ExcelLib.ReadData(2, "FirstName");
            string sLastName = ExcelLib.ReadData(2, "LastName");
            switch (availability)
            {
                case "Part Time":
                    availability = "0";
                    break;
                case "Full Time":
                    availability = "1";
                    break;
                default:
                    Assert.Fail("Availability Type is not matching");
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
                default:
                    Assert.Fail("Hour is not matching");
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
                default:
                    Assert.Fail("Earn Target is not matching");
                    break;
            }

            //wait for dropdown icon to be clickable
            WaitHelpers.WaitToBeClickable(driver, "XPath", e_buttonEditName, 3);

            //Click on dropdown icon before Full name
            editNameDropdown.Click();

            //Edit first name
            WaitHelpers.WaitToBeClickable(driver, "Name", e_firstName, 3);

            firstName.Click();
            firstName.Clear();
            firstName.SendKeys(sFirstName);

            //edit last name
            lastName.Click();
            lastName.Clear();
            lastName.SendKeys(sLastName);

            //click Save
            buttonSave.Click();

            //Wait for Save completed and Name appears.
            WaitHelpers.WaitToBeVisible(driver, "XPath", e_fullName, 3);

            //Click edit Availibility Type
            Actions action = new Actions(driver);
            action.MoveToElement(buttonEditAvailabilityType).Click().Build().Perform();

            //Select type
            WaitHelpers.WaitToBeVisible(driver, "XPath", e_vailabilityTypeDropdown, 3);
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



        public void addLanguage(int rowNumber, string Excelsheet)
        {
            //Populate excel data
            ExcelLib.PopulateInCollection(Base.ExcelPath, Excelsheet);
            //Identify language Tab and click

            languageTab.Click();

            wait(2);
            //Click on Add new to add new Language
            AddNewLangButton.Click();

            //Enter the Language on text box
            AddLanguageText.SendKeys(ExcelLib.ReadData(rowNumber, "Language"));

            //Click on language level from language options
            var selectLanguageDropdown = new SelectElement(ChooseLanguage);
            selectLanguageDropdown.SelectByValue(ExcelLib.ReadData(rowNumber, "LanguageLevel"));

            //Click on Add language
            AddLanguage.Click();

        }
        public string GetNewLanguage()
        {
            return newAddLanguage.Text;
        }
        public string GetNewLanguageLevel()
        {
            return newLanguageLevel.Text;

        }


        public void editLanguage(int rowNumber, int rowNumber1, string Excelsheet)
        {
            //Populate excel data
            ExcelLib.PopulateInCollection(Base.ExcelPath, Excelsheet);

            //Identify language Tab and click
            languageTab.Click();

            wait(1);
            //Go to last page where new language created
            newAddLanguage.Click();

            //Read Data from Language page
            string ExpectedTitle = ExcelLib.ReadData(rowNumber, "Language");

            //Click on edit language icon
            editLangIcon.Click();

            //Edit the Language on text box
            editLangText.Clear();
            editLangText.SendKeys(ExcelLib.ReadData(rowNumber1, "Language"));
            wait(2);
            //Click on Language level         
            var selectLanguageDropdown = new SelectElement(editChooseLang);
            selectLanguageDropdown.SelectByValue(ExcelLib.ReadData(rowNumber1, "LanguageLevel"));

            //Click on update language
            wait(2);
            updateLang.Click();

          
        }

        public string GetEditNewLanguage()
        {
            return editNewLanguage.Text;
        }
        public string GetEditNewLanguageLevel()
        {
            return editNewLanguageLevel.Text;
        }

        public void deleteLanguage(int rowNumber, string Excelsheet)
        {
            //Populate excel data
            ExcelLib.PopulateInCollection(Base.ExcelPath, Excelsheet);

            wait(1);
            //Identify editedlanguage and click
            editedLanguageTab.Click();
            wait(2);
            //Click on delete icon
            deleteLangIcon.Click();

           
        }

        public string GetDeleteLanguageIcon()
        {
            return editedLanguageTab.Text;
        }



        public void InvalidLanguage_1(int rowNumber, string Excelsheet)
        {
            //Populate excel data
            ExcelLib.PopulateInCollection(Base.ExcelPath, Excelsheet);
 
            //Identify language Tab and click
            languageTab.Click();

            wait(2);
            //Click on Add new to add new Language
            AddNewLangButton.Click();

            //Click on language level from language options
            ChooseLanguage.Click();
           
            //Click on Add language
            AddLanguage.Click();
            wait(2);
            //Click on Error message
            LangErrorMessage.Click();

        }
        
        public void InvalidLanguage_2(int rowNumber, string Excelsheet)
        {
            //Populate excel data
            ExcelLib.PopulateInCollection(Base.ExcelPath, Excelsheet);
            //Identify language Tab and click

            languageTab.Click();

            wait(2);
            //Click on Add new to add new Language
            AddNewLangButton.Click();

            //Click on language level from language options      
            var selectLanguageDropdown = new SelectElement(ChooseLanguage);
            selectLanguageDropdown.SelectByValue(ExcelLib.ReadData(rowNumber, "LanguageLevel"));

            //Click on Add language
            AddLanguage.Click();
            wait(2);
            //Click on Error message
            LangErrorMessage.Click();

        }

        internal string GetErrorMessage()
        {
            return LangErrorMessage.Text;
        }

    }
}
