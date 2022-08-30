using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SeleniumSpecFlow.Utilities.CommonDriver;
using static SeleniumSpecFlow.Utilities.GlobalDefinitions;

namespace SeleniumSpecFlow.Pages
{
    public class Login
    {
        #region Page objects
        private IWebElement SignInBtn => driver.FindElement(By.XPath("//A[@class='item'][text()='Sign In']"));
        private IWebElement Email => driver.FindElement(By.XPath("(//INPUT[@type='text'])[2]"));
        private IWebElement Password => driver.FindElement(By.XPath("//INPUT[@type='password']"));
        private IWebElement LoginBtn => driver.FindElement(By.XPath("//BUTTON[@class='fluid ui teal button'][text()='Login']"));
        #endregion

        public void LogInSteps()
        {
            //Populate excel data
            ExcelLib.PopulateInCollection(ExcelPath, "SignIn");

            //Click Signin button
            SignInBtn.Click();

            //Enter email
            Email.SendKeys(ExcelLib.ReadData(2, "Username"));

            //Enter password
            Password.SendKeys(ExcelLib.ReadData(2, "Password"));

            //Click Login button
            LoginBtn.Click();
        }
    }
}
