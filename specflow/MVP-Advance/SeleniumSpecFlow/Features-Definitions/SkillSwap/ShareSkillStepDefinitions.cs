using NUnit.Framework;
using SeleniumSpecFlow.Pages.SkillSwap;
using System;
using TechTalk.SpecFlow;
using static SeleniumSpecFlow.Pages.SkillSwap.ShareSkill;

namespace SeleniumSpecFlow
{
    [Binding]
    public class ShareSkillStepDefinitions
    {
        ShareSkill shareSkillObj;
        [Given(@"I click button ShareSkill")]
        public void GivenIClickButtonShareSkill()
        {
            shareSkillObj = new ShareSkill();
            shareSkillObj.ClickButtonShareSkill();
        }
 
        [When(@"I enter '([^']*)' '([^']*)' '([^']*)' '([^']*)' '([^']*)' '([^']*)' '([^']*)' '([^']*)' '([^']*)' '([^']*)' '([^']*)' '([^']*)' '([^']*)' '([^']*)' '([^']*)' '([^']*)'")]
        public void WhenIEnter(string title, string description, string category, string subcategory, string tags, string serviceType,
            string locationType, string startDate, string endDate, string availableDays, string startTime, string endTime, string skillTrade,
            string skillExchange, string credit, string active)
        {
            shareSkillObj.EnterShareSkill(title, description, category, subcategory, tags, serviceType,
           locationType, startDate, endDate, availableDays, startTime, endTime, skillTrade,
           skillExchange, credit, active);
        }

        [Then(@"I view my skill details based on '([^']*)'")]
        public void ThenIViewMySkillDetailsBasedOn(string title)
        {
            shareSkillObj.ViewMySkillDetails(title);
        }

        [Then(@"My skill listing should be created as '([^']*)' '([^']*)' '([^']*)' '([^']*)' '([^']*)' '([^']*)' '([^']*)' '([^']*)' '([^']*)' '([^']*)' '([^']*)'")]
        public void ThenMySkillListingShouldBeCreatedAs(string title, string description, string category, string subcategory, string serviceType, string locationType, string skillTrade, string skillExchange, string credit, string startDate, string endDate)
        {
            Listing web = new Listing();
            shareSkillObj.GetWeb(out web);
            //Assertions
            Assert.Multiple(() =>
            {

                //Verify expected Title vs actual Title
                Assert.AreEqual(title, web.title);

                //Verify expected Description vs actual Description
                Assert.AreEqual(description, web.description);

                //Verify expected Category vs actual Category
                Assert.AreEqual(category, web.category);

                //Verify expected Subcategory vs actual Subcategory
                Assert.AreEqual(subcategory, web.subcategory);

                //Verify expected ServiceType vs actual ServiceType
                if (serviceType == "One-off service")
                    serviceType = "One-off";
                if (serviceType.Equals("Hourly basis service"))
                    serviceType = "Hourly";
                Assert.AreEqual(serviceType, web.serviceType);

                //Verify expected StartDate vs actual StartDate
                Assert.AreEqual(startDate, web.startDate);

                //Verify expected EndDate vs actual EndDate
                Assert.AreEqual(endDate, web.endDate);

                //Verify expected LocationType vs actual LocationType
                if (locationType.Equals("On-site"))
                    locationType = "On-Site";
                Assert.AreEqual(locationType, web.locationType);

                //Verify Skills Trade
                if (skillTrade == "Credit")
                    Assert.AreEqual("None Specified", shareSkillObj.GetSkillTrade("Credit"));
                else
                    Assert.AreEqual(skillExchange, shareSkillObj.GetSkillTrade("Skill-exchange"));
            });
        }
    }
}
