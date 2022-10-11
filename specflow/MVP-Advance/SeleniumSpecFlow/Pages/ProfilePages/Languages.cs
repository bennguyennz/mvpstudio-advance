using NUnit.Framework;
using OpenQA.Selenium;
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
    public class Languages
    {
        #region page objects

        private IWebElement buttonAddNew => driver.FindElement(By.XPath(e_buttonAddNew));
        private IWebElement addedLanguage => driver.FindElement(By.Name("name"));
        private IWebElement addedLevel => driver.FindElement(By.Name("level"));
        private IWebElement buttonAdd => driver.FindElement(By.XPath(e_buttonAdd));
        private IWebElement language => driver.FindElement(By.XPath(e_language));
        private IWebElement dropdownLevel => driver.FindElement(By.XPath(e_level));
        private IWebElement buttonStartUpdate => driver.FindElement(By.XPath(e_buttonStartUpdate));
        private IWebElement editedLanguage => driver.FindElement(By.Name("name"));
        private IWebElement editedLevel => driver.FindElement(By.Name("level"));
        private IWebElement buttonCompleteUpdate => driver.FindElement(By.XPath(e_buttonCompleteUpdate));
        private IWebElement buttonDelete => driver.FindElement(By.XPath(e_buttonDelete));
        private IWebElement message => driver.FindElement(By.XPath(e_message));
        private IWebElement tabOption => driver.FindElement(By.XPath("//div[@class = 'ui top attached tabular menu']/a[1]"));
        private IList<IWebElement> languages => driver.FindElements(By.XPath("//table[@class ='ui fixed table']//tbody/tr/td[1]"));
        
        private string e_buttonAddNew = "//div[@class='form-wrapper']//div[@class ='ui teal button ']";
        private string e_buttonAdd = "//div[@class='six wide field']//input[@class ='ui teal button']";
        private string e_language = "//div[@class='form-wrapper']//table[@class ='ui fixed table']//tbody[last()]/tr/td[1]";
        private string e_level = "//div[@class='form-wrapper']//table[@class ='ui fixed table']//tbody[last()]/tr/td[2]";
        private string e_buttonStartUpdate = "//div[@class='form-wrapper']//table[@class ='ui fixed table']//tbody[last()]/tr//td[3]/span[1]/i  ";
        private string e_buttonCompleteUpdate = "//table[@class ='ui fixed table']//input[@class='ui teal button'] ";
        private string e_buttonDelete = "//table[@class ='ui fixed table']//tbody[last()]/tr//td[3]/span[2]/i";
        private string e_message = "//div[@class='ns-box-inner']";
        private string e_tab = "//div[@class='ui top attached tabular menu']";

        #endregion

        public void ClickOnTabLanguages()
        {
            //Wait for tabs to be visible
            WaitHelpers.WaitToBeVisible(driver, "XPath", e_tab, 3);
            tabOption.Click();
        }

        public void ClickButtonAddNew()
        {
            //click on Add New
            WaitHelpers.WaitToBeClickable(driver, "XPath", e_buttonAddNew, 5);
            buttonAddNew.Click();
        }

        public void EnterLanguage(string Language, string Level)
        {
            //Enter language
            addedLanguage.SendKeys(Language);

            //Enter language level
            var addedlevel = new SelectElement(addedLevel);
            addedlevel.SelectByValue(Level);

            //Click on add
            WaitHelpers.WaitToBeClickable(driver, "XPath", e_buttonAdd, 5);
            buttonAdd.Click();

        }
        public string GetMessage()
        {
            WaitHelpers.WaitToBeVisible(driver, "XPath", e_message, 5);
            return message.Text;

        }
        public string GetNewLanguage()
        {
            try
            {
                //Get text from last record
                WaitHelpers.WaitToBeVisible(driver, "XPath",e_language, 3);
                return language.Text;
            }
            catch (Exception)
            {
                return "Certificate element not found";
            }
        }


        public string GetNewLevel()
        {
            try
            {
                //Get text from last record
                WaitHelpers.WaitToBeVisible(driver, "XPath", e_level, 3);
                return dropdownLevel.Text;
            }
            catch (Exception)
            {
                return "Certificate element not found";
            }
        }

        public void ClickEdit(string Language1)
        { 
            string e_Edit = "//table[@class ='ui fixed table']//tbody[" + GetLanguageIndex(Language1) + "]/tr//td[3]/span[1]/i ";
            IWebElement btnEdit = driver.FindElement(By.XPath(e_Edit));
            btnEdit.Click();
            
        }

        public int GetLanguageIndex(string Language)
        {
            int index = 0;
            int titleCount = languages.Count();
            if (titleCount.Equals(0))
                Assert.Ignore("There is no language record.");
            else
            {
                for (int i = 0; i < titleCount; i++)
                {
                    if (languages[i].Text.Equals(Language))
                    {
                        index = i + 1;
                        break;
                    }
                }
                if (index.Equals(0))
                {
                    Assert.Ignore("Language " + Language + "is not found.");
                }
            }
            return index;
        }
        public void EditLanguage(string Language2, string Level)
        {
            //Edit language
            editedLanguage.Clear();
            editedLanguage.SendKeys(Language2);

            //Edit language level
            var editlevel = new SelectElement(editedLevel);
            editlevel.SelectByValue(Level);

            //Click on Update
            WaitHelpers.WaitToBeClickable(driver, "XPath", e_buttonCompleteUpdate, 5);
            buttonCompleteUpdate.Click();
        }
        public void ClickDelete(string Language)
        {
            string e_Delete = "//table[@class ='ui fixed table']//tbody[" + GetLanguageIndex(Language) + "]/tr//td[3]/span[2]/i";
            IWebElement btnDelete = driver.FindElement(By.XPath(e_Delete));
            btnDelete.Click();
        }



    }
}
