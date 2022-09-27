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
            shareSkillObj.EnterShareSkill(3, "ManageListings");
        }

        [Then(@"I view my skill details based on title")]
        public void ThenIViewMySkillDetailsBasedOnTitle()
        {
            shareSkillObj.ViewMySkillDetails(3, "ManageListings");
        }

        [Then(@"My skill listing should be created properly")]
        public void ThenMySkillListingShouldBeCreatedProperly()
        {
            Listing web = new Listing();
            Listing excel = new Listing();
            shareSkillObj.GetWeb(out web);
            shareSkillObj.GetExcel(3, "ManageListings", out excel);
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

        [When(@"I enter my skill details with no data")]
        public void WhenIEnterMySkillDetailsWithNoData()
        {
            shareSkillObj.EnterShareSkill_InvalidData(2, "NegativeTC");
        }

        [Then(@"I get a warning message to enter the input")]
        public void ThenIGetAWarningMessageToEnterTheInput()
        {
            int excelMessage = 3; int seleniumMessage = 4; string worksheet = "NegativeTC";

            shareSkillObj = new ShareSkill();
            Listing xMessage = new Listing();
            Listing selenium = new Listing();
            Listing portal = new Listing();

            shareSkillObj.GetExcel(excelMessage, worksheet, out xMessage);
            shareSkillObj.GetExcel(seleniumMessage, worksheet, out selenium);
            shareSkillObj.GetPortalMessage(out portal);

            //Assertions
            Assert.Multiple(() =>
            {
                Assert.That(shareSkillObj.GetMessage().Equals(xMessage.isClickSaveFirst), selenium.isClickSaveFirst);

                //Check title message
                Assert.That((portal.title).Equals(xMessage.title), selenium.title);

                //Check description message
                Assert.That((portal.description).Equals(xMessage.description), selenium.description);

                //Check Category message
                Assert.That(shareSkillObj.GetCategoryError().Equals(xMessage.category), selenium.category);

                //Check tags message
                Assert.That((portal.tags).Equals(xMessage.tags), selenium.tags);

                //Check skill exchange tag message
                Assert.That(shareSkillObj.GetSkillExchangeError().Equals(xMessage.skillExchange), selenium.skillExchange);
            });
        }

        [When(@"I enter my skill details with first invalid data")]
        public void WhenIEnterMySkillDetailsWithFirstInvalidData()
        {
            shareSkillObj.EnterShareSkill_InvalidData(6, "NegativeTC");
        }

        [Then(@"I get a warning message for first invalid data")]
        public void ThenIGetAWarningMessageForFirstInvalidData()
        {
            int testdata = 6; int excelMessage = 7; int seleniumMessage = 8; string worksheet = "NegativeTC";

            shareSkillObj = new ShareSkill();
            Listing test = new Listing();
            Listing xMessage = new Listing();
            Listing selenium = new Listing();
            Listing portal = new Listing();
            shareSkillObj.GetExcel(testdata, worksheet, out test);
            shareSkillObj.GetExcel(excelMessage, worksheet, out xMessage);
            shareSkillObj.GetExcel(seleniumMessage, worksheet, out selenium);
            shareSkillObj.GetPortalMessage(out portal);

            //Assertions
            Assert.Multiple(() =>
            {
                //Check confirmation message
                Assert.That(shareSkillObj.GetMessage().Equals(xMessage.isClickSaveFirst), selenium.isClickSaveFirst);

                //Check title
                Assert.That((portal.title).Equals(xMessage.title), selenium.title);

                //Check description
                Assert.That((portal.description).Equals(xMessage.description), selenium.description);

                if (test.category == "Ignore")
                {
                    //Check category message
                    Assert.That(shareSkillObj.GetCategoryError().Equals(xMessage.category), selenium.category);
                }
                else
                //Assert subcategory
                {
                    Assert.That(shareSkillObj.GetSubcategoryError().Equals(xMessage.subcategory), selenium.subcategory);
                }

                //Check tags message
                Assert.That((portal.tags).Equals(xMessage.tags), selenium.tags);

                //Check date message
                if ((test.startDate != "Ignore") & (test.endDate != "Ignore")) //and startdate < today
                {
                    Assert.That(shareSkillObj.GetDateErrorMessage1().Equals(xMessage.startDate), selenium.startDate);
                    Assert.That(shareSkillObj.GetDateErrorMessage2().Equals(xMessage.endDate), selenium.endDate);
                }
                else
                {
                    if (test.startDate != "Ignore") //and startDate < today
                    {
                        Assert.That(shareSkillObj.GetDateErrorMessage2().Equals(xMessage.startDate), selenium.startDate);
                    }
                    if (test.endDate != "Ignore") //and start < enddate
                    {
                        Assert.That(shareSkillObj.GetDateErrorMessage2().Equals(xMessage.endDate), selenium.endDate);
                    }
                }

                //Check skill exchange tags or credit value
                if (test.skillTrade.Equals("Skill-exchange"))
                {
                    //Check skill exchange tag message
                    Assert.That(shareSkillObj.GetSkillExchangeError().Equals(xMessage.skillExchange), selenium.skillExchange);
                }
                else if (test.skillTrade.Equals("Credit"))
                {
                    //Check credit value
                    Assert.That(shareSkillObj.GetCredit() != test.credit, selenium.credit);
                }
                else
                {
                    //Check skill exchange tag message
                    Assert.That(shareSkillObj.GetSkillExchangeError().Equals(xMessage.skillExchange), selenium.skillExchange);
                }
            });
        }

        [When(@"I enter my skill details with second invalid data set")]
        public void WhenIEnterMySkillDetailsWithSecondInvalidDataSet()
        {
            shareSkillObj.EnterShareSkill_InvalidData(10, "NegativeTC");
        }

        [Then(@"I get a warning message for second invalid data")]
        public void ThenIGetAWarningMessageForSecondInvalidData()
        {
            int testdata = 10; int excelMessage = 11; int seleniumMessage = 12; string worksheet = "NegativeTC";

            shareSkillObj = new ShareSkill();
            Listing test = new Listing();
            Listing xMessage = new Listing();
            Listing selenium = new Listing();
            Listing portal = new Listing();
            shareSkillObj.GetExcel(testdata, worksheet, out test);
            shareSkillObj.GetExcel(excelMessage, worksheet, out xMessage);
            shareSkillObj.GetExcel(seleniumMessage, worksheet, out selenium);
            shareSkillObj.GetPortalMessage(out portal);

            //Assertions
            Assert.Multiple(() =>
            {
                //Check confirmation message
                Assert.That(shareSkillObj.GetMessage().Equals(xMessage.isClickSaveFirst), selenium.isClickSaveFirst);

                //Check title
                Assert.That((portal.title).Equals(xMessage.title), selenium.title);

                //Check description
                Assert.That((portal.description).Equals(xMessage.description), selenium.description);

                if (test.category == "Ignore")
                {
                    //Check category message
                    Assert.That(shareSkillObj.GetCategoryError().Equals(xMessage.category), selenium.category);
                }
                else
                //Assert subcategory
                {
                    Assert.That(shareSkillObj.GetSubcategoryError().Equals(xMessage.subcategory), selenium.subcategory);
                }

                //Check tags message
                Assert.That((portal.tags).Equals(xMessage.tags), selenium.tags);

                //Check date message
                if ((test.startDate != "Ignore") & (test.endDate != "Ignore")) //and startdate < today
                {
                    Assert.That(shareSkillObj.GetDateErrorMessage1().Equals(xMessage.startDate), selenium.startDate);
                    Assert.That(shareSkillObj.GetDateErrorMessage2().Equals(xMessage.endDate), selenium.endDate);
                }
                else
                {
                    if (test.startDate != "Ignore") //and startDate < today
                    {
                        Assert.That(shareSkillObj.GetDateErrorMessage2().Equals(xMessage.startDate), selenium.startDate);
                    }
                    if (test.endDate != "Ignore") //and start < enddate
                    {
                        Assert.That(shareSkillObj.GetDateErrorMessage2().Equals(xMessage.endDate), selenium.endDate);
                    }
                }

                //Check skill exchange tags or credit value
                if (test.skillTrade.Equals("Skill-exchange"))
                {
                    //Check skill exchange tag message
                    Assert.That(shareSkillObj.GetSkillExchangeError().Equals(xMessage.skillExchange), selenium.skillExchange);
                }
                else if (test.skillTrade.Equals("Credit"))
                {
                    //Check credit value
                    Assert.That(shareSkillObj.GetCredit() != test.credit, selenium.credit);
                }
                else
                {
                    //Check skill exchange tag message
                    Assert.That(shareSkillObj.GetSkillExchangeError().Equals(xMessage.skillExchange), selenium.skillExchange);
                }
            });
        }

    }
}
