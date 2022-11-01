using NUnit.Framework;
using SeleniumNUnit.Global;
using SeleniumNUnit.Pages;
using static SeleniumNUnit.Global.GlobalDefinitions;
using static SeleniumNUnit.Pages.ShareSkill;

namespace SeleniumNUnit.Tests
{
    internal class ShareSkillTests : Global.Base
    {
        ManageListings manageListingObj;
        ShareSkill shareSkillObj;

        public ShareSkillTests()
        {
            manageListingObj = new ManageListings();
            shareSkillObj = new ShareSkill();
        }

        [Test, Order(5)]
        public void TC4a_WhenIEnterListingAndVerifyListing()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            manageListingObj.AddListing(2, "ManageListings");
            VerifyListingDetails(2, "ManageListings");
        }


        [Test, Order(6)]
        public void TC5a_WhenIEnterNoDataThenIAssert()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            manageListingObj.EnterShareSkill_Invalid(2, "NegativeTC");
            AssertNoData(3, 4, "NegativeTC");//No need test data
        }

        [Test, Order(7)]
        public void TC5c_WhenIAddInvalidDataThenIAssert()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            manageListingObj.EnterShareSkill_Invalid(6, "NegativeTC");
            AssertInvalidData(6, 7, 8, "NegativeTC");
        }
        [Test, Order(8)]
        public void TC5d_WhenIAddInvalidDataThenIAssert()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            manageListingObj.EnterShareSkill_Invalid(10, "NegativeTC");
            AssertInvalidData(10, 11, 12, "NegativeTC");
        }

        #region Assertions for EnterShareSkills
        public void VerifyListingDetails(int rowNumber, string worksheet)
        {
            //Read data
            ExcelLib.PopulateInCollection(Base.ExcelPath, worksheet);
            string title = ExcelLib.ReadData(rowNumber, "Title");

            //Get position of the listing title to be verified
            string titleIndex = manageListingObj.GetTitleIndex(title);
            if (titleIndex == "There is no listing record." || titleIndex == "Listing is not found.")
            {
                Assert.Fail(titleIndex);
            }

            //Click on view Listing
            manageListingObj.ViewListing(titleIndex);

            //struct objects initialisations
            Listing excel = new Listing();
            Listing web = new Listing();

            //Get struct values
            shareSkillObj.GetExcel(rowNumber, worksheet, out excel);
            shareSkillObj.GetWeb(out web);

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
                string serviceTypeText = "Hourly";
                if (excel.serviceType == "One-off service")
                    serviceTypeText = "One-off";
                Assert.AreEqual(serviceTypeText, web.serviceType);

                //Verify expected StartDate vs actual StartDate
                string expectedStartDate = DateTime.Parse(excel.startDate).ToString("yyyy-MM-dd");
                Assert.AreEqual(expectedStartDate, web.startDate);

                //Verify expected EndDate vs actual EndDate
                string expectedEndDate = DateTime.Parse(excel.endDate).ToString("yyyy-MM-dd");
                Assert.AreEqual(expectedEndDate, web.endDate);

                //Verify expected LocationType vs actual LocationType
                string expectedLocationType = excel.locationType;
                if (expectedLocationType.Equals("On-site"))
                    expectedLocationType = "On-Site";
                Assert.AreEqual(expectedLocationType, web.locationType);

                //Verify Skills Trade
                if (excel.skillTrade == "Credit")
                    Assert.AreEqual("None Specified", shareSkillObj.GetSkillTrade("Credit"));
                else
                    Assert.AreEqual(excel.skillExchange, shareSkillObj.GetSkillTrade("Skill-exchange"));
            });

        }

        public void AssertNoData(int excelMessage, int seleniumMessage, string worksheet)
        {
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
        public void AssertInvalidData(int testdata, int excelMessage, int seleniumMessage, string worksheet)
        {
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
        #endregion

    }
}