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

        [When(@"I enter my skill details")]
        public void WhenIEnterMySkillDetails()
        {
            shareSkillObj.EnterShareSkill(2, "ManageListings");
        }

        [Then(@"I view my skill details based on title")]
        public void ThenIViewMySkillDetailsBasedOnTitle()
        {
            shareSkillObj.ViewMySkillDetails(2, "ManageListings");
        }

        [Then(@"My skill listing should be created properly")]
        public void ThenMySkillListingShouldBeCreatedProperly()
        {
            Listing web = new Listing();
            Listing excel = new Listing();
            shareSkillObj.GetWeb(out web);
            shareSkillObj.GetExcel(2, "ManageListings", out excel);
            //Assertions
            Assert.Multiple(() =>
            {

                //Verify expected Title vs actual Title
                Assert.AreEqual(excel.title, web.title);

                //Verify expected Description vs actual Description
                Assert.AreEqual(excel.description, web.description);

                //Verify expected Category vs actual Category
                Assert.AreEqual(excel.category, web.category);

                //Verify expected Subcategory vs actual Subcategory
                Assert.AreEqual(excel.subcategory, web.subcategory);

                //Verify expected ServiceType vs actual ServiceType
                if (excel.serviceType.Equals("One-off service"))
                    excel.serviceType = "One-off";
                if (excel.serviceType.Equals("Hourly basis service"))
                    excel.serviceType = "Hourly";
                Assert.AreEqual(excel.serviceType, web.serviceType);

                //Verify expected StartDate vs actual StartDate
                Assert.AreEqual(excel.startDate, web.startDate);

                //Verify expected EndDate vs actual EndDate
                Assert.AreEqual(excel.endDate, web.endDate);

                //Verify expected LocationType vs actual LocationType
                if (excel.locationType.Equals("On-site"))
                    excel.locationType = "On-Site";
                Assert.AreEqual(excel.locationType, web.locationType);

                //Verify Skills Trade
                if (excel.skillTrade.Equals("Credit"))
                    Assert.AreEqual("None Specified", shareSkillObj.GetSkillTrade("Credit"));
                else
                    Assert.AreEqual(excel.skillExchange, shareSkillObj.GetSkillTrade("Skill-exchange"));
            });
        }
    }
}
