using NUnit.Framework;
using SeleniumNUnit.Global;
using SeleniumNUnit.Pages;
using static SeleniumNUnit.Global.GlobalDefinitions;
using static SeleniumNUnit.Pages.ShareSkill;

namespace SeleniumNUnit.Tests
{
    internal class Tests : Global.Base
    {
        ManageListings manageListingObj;
        ShareSkill shareSkillObj;
        Profile profileObj;


        [Test, Order(1)]
        public void TC2_WhenIEditContactAndVerifyContact()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            profileObj = new Profile();
            profileObj.EditMyContactDetails(2, "Profile");
            VerifyContactDetails(2, "Profile");
        }

        [Test, Order(2)]
        public void EnterLanguage()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            profileObj = new Profile();
            profileObj.addLanguage(2, "Profile");
            VerifyAddLanguage(2, "Profile");

        }
        [Test, Order(3)]
        public void EditLanguage()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            profileObj = new Profile();
            profileObj.editLanguage(2, 3, "Profile");
            VerifyEditLanguage(3, "Profile");
        }
        [Test, Order(4)]
        public void deleteLanguage()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            profileObj = new Profile();
            profileObj.deleteLanguage(3, "Profile");
            VerifyDeleteLanguage(3, "Profile");

        }

        [Test, Order(5)]
        public void TC1_WhenIEnterListingAndVerifyListing()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            manageListingObj = new ManageListings();
            manageListingObj.AddListing(2, "ManageListings");
            VerifyListingDetails(2, "ManageListings");
        }


        [Test, Order(6)]
        public void TC4a_WhenIEnterNoDataThenIAssert()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            manageListingObj = new ManageListings();
            manageListingObj.EnterShareSkill_Invalid(2, "NegativeTC");
            AssertNoData(3, 4, "NegativeTC");//No need test data
        }

        [Test, Order(7)]
        public void TC3b_WhenIAddInvalidDataThenIAssert()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            manageListingObj = new ManageListings();
            manageListingObj.EnterShareSkill_Invalid(6, "NegativeTC"); //test data, esp. past start date
            AssertInvalidData(6, 7, 8, "NegativeTC"); //need test data
        }
        [Test, Order(8)]
        public void TC3c_WhenIAddInvalidDataThenIAssert()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            manageListingObj = new ManageListings();
            manageListingObj.EnterShareSkill_Invalid(10, "NegativeTC");//Test data, esp. past startdate, startdate>enddate
            AssertInvalidData(10, 11, 12, "NegativeTC"); //need test data
        }

 

        public void VerifyListingDetails(int rowNumber, string worksheet)
        {
            //Click on view Listing
            manageListingObj = new ManageListings();
            shareSkillObj = new ShareSkill();
            manageListingObj.ViewListing(rowNumber, worksheet);

            Listing excel = new Listing();
            Listing web = new Listing();


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
        public void VerifyContactDetails(int row, string worksheet)
        {
            //Populate excel data
            ExcelLib.PopulateInCollection(Base.ExcelPath, worksheet);
            string availability = ExcelLib.ReadData(row, "Availability");
            string hour = ExcelLib.ReadData(row, "Hours");
            string earnTarget = ExcelLib.ReadData(row, "EarnTarget");
            string sFirstName = ExcelLib.ReadData(row, "FirstName");
            string sLastName = ExcelLib.ReadData(row, "LastName");

            //Check message
            string assertMessage = "Availability updated";
            string message = profileObj.GetMessage();
            Assert.AreEqual(message,assertMessage, "Actual message and Expected message do not match.");

            //Check Full Name
            string fullName = sFirstName + " " + sLastName;
            Assert.AreEqual(fullName, profileObj.GetFullName(), "Actual full name and Expected full name do not match");

            //Check availability
            Assert.AreEqual(availability, profileObj.GetAvailabilityType(), "Actual availability type and Expected availability type do not match.");

            //Check Hours
            Assert.AreEqual(hour, profileObj.GetAvailityHour(), "Actual availability hour and expected availability hour do not match.");

            //Check Earn Targe
            Assert.AreEqual(earnTarget, profileObj.GetAvailityTarget(), "Actual earn target and Expected earn target do not match.");
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


        public void VerifyAddLanguage(int rowNumber,string Excelsheet)
        {
            ExcelLib.PopulateInCollection(Base.ExcelPath, Excelsheet);
            //Assertion
            Assert.That(profileObj.GetNewLanguage() == ExcelLib.ReadData(rowNumber, "Language"), "Actual Addlanguage and expected Addlanguage does not match");
            Assert.That(profileObj.GetNewLanguageLevel() == ExcelLib.ReadData(rowNumber, "LanguageLevel"), "Actual Addlanguage and expected Addlanguage does not match");
        }
        public void VerifyEditLanguage(int rowNumber1, string Excelsheet)
        {
            ExcelLib.PopulateInCollection(Base.ExcelPath, Excelsheet);
            //Assertion
            Assert.That(profileObj.GetEditNewLanguage() == ExcelLib.ReadData(rowNumber1, "Language"), "Actual Addlanguage and expected Addlanguage does not match");
            Assert.That(profileObj.GetEditNewLanguageLevel() == ExcelLib.ReadData(rowNumber1, "LanguageLevel"), "Actual Addlanguage and expected Addlanguage does not match");
        }

        public void VerifyDeleteLanguage(int rowNumber, string Excelsheet)
        {
            ExcelLib.PopulateInCollection(Base.ExcelPath, Excelsheet);
            //Assertion
            Assert.That(profileObj.GetDeleteLanguageIcon() != ExcelLib.ReadData(rowNumber, "Language"), "Actual Addlanguage and expected Addlanguage does not match");
        }
    }


}