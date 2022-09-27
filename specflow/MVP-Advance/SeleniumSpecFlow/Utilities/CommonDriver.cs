using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using SeleniumSpecFlow.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using static SeleniumSpecFlow.Utilities.GlobalDefinitions;
using static SeleniumSpecFlow.Utilities.WaitHelpers;

//[assembly: Parallelizable(ParallelScope.Fixtures)]
//[assembly: LevelOfParallelism(2)]

namespace SeleniumSpecFlow.Utilities
{
    [Binding]
    public class CommonDriver
    {
        //[ThreadStatic]
        public static IWebDriver driver;
        Login loginObj;

        [BeforeScenario]
        public void SetUp()
        {
            try
            {
                //Initiate driver
                switch (Browser)
                {
                    case 1:
                        driver = new FirefoxDriver();
                        break;

                    case 2:
                        driver = new ChromeDriver();

                        //Maximise the window
                        driver.Manage().Window.Maximize();
                        break;
                }
                wait(3);

                //Load Excel
                ExcelLib.PopulateInCollection(ExcelPath, "SignIn");

                //Navigate to Url
                driver.Navigate().GoToUrl(ExcelLib.ReadData(2, "Url"));

                //Signin
                loginObj = new Login();
                loginObj.LogInSteps(2);
                wait(3);
            }
            catch (TimeoutException e)
            {
                wait(5);
                Assert.Ignore(e.Message);
            }
        }

        [AfterScenario]
        public void TearDown()
        {
            driver.Close();
        }


    }
}
