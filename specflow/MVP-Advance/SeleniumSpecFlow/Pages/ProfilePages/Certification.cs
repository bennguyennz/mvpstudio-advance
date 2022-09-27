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
    public class Certification
    {
        #region page objects
        private IWebElement buttonAddNew => driver.FindElement(By.XPath(e_buttonAddNew));
        private IWebElement addedCertificate => driver.FindElement(By.Name("certificationName"));
        private IWebElement addedCertificationFrom => driver.FindElement(By.Name("certificationFrom"));
        private IWebElement dropdownYear => driver.FindElement(By.Name("certificationYear"));
        private IWebElement buttonCompleteAdd => driver.FindElement(By.XPath(e_CompleteAdd));
        private IWebElement certifcate => driver.FindElement(By.XPath(e_certificate));
        private IWebElement certificationFrom => driver.FindElement(By.XPath(e_certificateFrom));
        private IWebElement certificationYear => driver.FindElement(By.XPath(e_certificationYear));
        private IWebElement buttonStartUpdate => driver.FindElement(By.XPath(e_buttonStartUpdate));
        private IWebElement editedCertificate => driver.FindElement(By.Name("certificationName"));
        private IWebElement editedCertificationFrom => driver.FindElement(By.Name("certificationFrom"));
        private IWebElement buttonCompleteUpdate => driver.FindElement(By.XPath(e_buttonCompleteUpdate));
        private IWebElement buttonDelete => driver.FindElement(By.XPath(e_buttonDelete));
        private IWebElement message => driver.FindElement(By.XPath(e_message));
        private IWebElement tabOption => driver.FindElement(By.XPath("//div[@class = 'ui top attached tabular menu']/a[4]"));
        private IList <IWebElement> certificates => driver.FindElements(By.XPath("//div[@data-tab='fourth']//tbody/tr/td[1]"));

        //wait elements
        private string e_buttonAddNew = "//div[@data-tab='fourth']//div[@class ='ui teal button ']";
        private string e_certificate = "//div[@data-tab='fourth']/div/div/div/table/tbody[last()]/tr/td[1]";
        private string e_certificateFrom = "//div[@data-tab='fourth']/div/div/div/table/tbody[last()]/tr/td[2]";
        private string e_certificationYear = "//div[@data-tab='fourth']/div/div/div/table/tbody[last()]/tr/td[3]";
        private string e_tab = "//div[@class='ui top attached tabular menu']";
        private string e_CompleteAdd = "//div[@class='five wide field']/input[1]";
        private string e_buttonStartUpdate = "//div[@data-tab='fourth']/div/div[2]/div/table/tbody[last()]/tr/td[4]/span[1]";
        private string e_buttonCompleteUpdate = "//input[@value='Update']";
        private string e_buttonDelete = "//div[@data-tab='fourth']/div/div[2]/div/table/tbody[last()]/tr/td[4]/span[2]";
        private string e_message = "//div[@class='ns-box-inner']";
        #endregion

        public void ClickOnTabCertifications()
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

        public void EnterCertificate(string certificate, string certificationFrom, string year)
        {
            //Enter Certificate/Award
            addedCertificate.SendKeys(certificate);

            //Enter Certifier
            addedCertificationFrom.SendKeys(certificationFrom);

            //Select year
            var addedYear = new SelectElement(dropdownYear);
            addedYear.SelectByValue(year);

            //Click on Add
            WaitHelpers.WaitToBeClickable(driver, "XPath", e_CompleteAdd, 5);
            buttonCompleteAdd.Click();
        }
        public string GetMessage()
        {
            WaitHelpers.WaitToBeVisible(driver, "XPath", e_message, 10);
            return message.Text;
        }

        public string GetCertificate(string certificate)
        {
            string findCertificate = "null";
            int titleCount = certificates.Count();
            if (titleCount.Equals(0))
                return "No certificate is found";
            else
            {
                for (int i = 0; i < titleCount; i++)
                {
                    if (certificates[i].Text.Equals(certificate))
                    {
                        findCertificate = certificates[i].Text;
                        break;
                    }
                }
                if (findCertificate.Equals("null"))
                {
                    return "Certificate not found";
                }
            }
            return findCertificate;
        }

        public string GetCertificationFrom()
        {
            try
            {
                //Check on last record
                WaitHelpers.WaitToBeVisible(driver, "XPath", e_certificateFrom, 5);
                return certificationFrom.Text;
            }
            catch (Exception)
            {
                return "Certificate element not found";
            }
        }

        public string GetCertificationYear()
        {
            try
            {
                //Check on last record
                WaitHelpers.WaitToBeVisible(driver, "XPath", e_certificationYear, 5);
                return certificationYear.Text;
            }
            catch (Exception)
            {
                return "Certificate element not found";
            }
        }

        public void ClickEdit(string certifcate1)
        {

                string e_Edit = "//div[@data-tab='fourth']//tbody[" + GetCertificateIndex(certifcate1) + "]/tr/td[4]/span[1]";
                IWebElement btnEdit = driver.FindElement(By.XPath(e_Edit));
                btnEdit.Click();

        }

        public int GetCertificateIndex(string certificate)
        {
            int index = 0;
            int titleCount = certificates.Count();
            if (titleCount.Equals(0))
                Assert.Ignore("There is no certificate record.");
            else
            {
                for (int i = 0; i < titleCount; i++)
                {
                    if (certificates[i].Text.Equals(certificate))
                    { 
                        index = i + 1;
                        break;
                    }
                }
                if (index.Equals(0))
                {
                    Assert.Ignore("Certificate " + certificate + "is not found.");
                }
            }
            return index;
        }

        public void EditCertificate(string certificate2, string from, string year)
        {
            //Edit Certificate/Award
            editedCertificate.Clear();
            editedCertificate.SendKeys(certificate2);

            //Edit Certifier
            editedCertificationFrom.Clear();
            editedCertificationFrom.SendKeys(from);

            //Edit year
            var editedYear = new SelectElement(dropdownYear);
            editedYear.SelectByValue(year);

            //Click on Update
            WaitHelpers.WaitToBeClickable(driver, "XPath", e_buttonCompleteUpdate, 5);
            buttonCompleteUpdate.Click();

        }

        public void ClickDelete(string certificate)
        {

            string e_Delete = "//div[@data-tab='fourth']//tbody[" + GetCertificateIndex(certificate) + "]/tr/td[4]/span[2]";
            IWebElement btnDelete = driver.FindElement(By.XPath(e_Delete));
            btnDelete.Click();
        }
    }
}
