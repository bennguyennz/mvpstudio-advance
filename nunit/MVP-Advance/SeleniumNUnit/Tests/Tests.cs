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

        [Test]
        public void WhenIEnterListingAndVerifyListing()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            manageListingObj = new ManageListings();
            manageListingObj.AddListing(2, "ManageListings");
            VerifyListingDetails(2, "ManageListings");
        }

        [Test]
        public void WhenIEditContactAndVerifyContact()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            profileObj = new Profile();
            profileObj.EditMyContactDetails(2,"Profile");
            VerifyContactDetails(2, "Profile");
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
    }
}