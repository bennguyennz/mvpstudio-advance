using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SeleniumNUnit.Global.GlobalDefinitions;

namespace SeleniumNUnit.Pages
{
    public class ShareSkill
    {
        #region Page Objects for EnterShareSkill
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

        #region Page Objects for error Messages

        //Title message
        private IWebElement errorTitle => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[1]/div/div[2]/div/div[2]/div"));

        //Description message
        private IWebElement errorDescription => driver.FindElement(By.XPath("//div[@class='tooltip-target ui grid']//div/div[2]/div[2]/div"));

        //Category message
        private IWebElement errorCategory => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div[2]"));

        //Subcategory message
        private IWebElement errorSubcategory => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div[2]/div[2]/div"));

        //Tags message
        private IWebElement errorTags => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[4]/div[2]/div[2]"));

        //StartDate message
        private IWebElement errorStartDate1 => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div[2]"));

        //StartDate mesage 2
        private IWebElement errorStartDate2 => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div[3]"));

        //Skill-Exchange tag
        private IWebElement errorSkillExchangeTags => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[4]/div[2]"));

        //Message
        private IWebElement message => driver.FindElement(By.XPath(e_message));
        private string e_message = "//div[@class='ns-box-inner']";

        #endregion
        public void EnterShareSkill(int rowNumber, string worksheet)
        {

        }

    }
}
