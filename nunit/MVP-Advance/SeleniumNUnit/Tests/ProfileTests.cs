using NUnit.Framework;
using SeleniumNUnit.Global;
using SeleniumNUnit.Pages;
using static SeleniumNUnit.Global.GlobalDefinitions;
using static SeleniumNUnit.Pages.ShareSkill;

namespace SeleniumNUnit.Tests
{
    internal class ProfileTests : Global.Base
    {

        Profile profileObj;
        public ProfileTests()
        {
            profileObj = new Profile();
        }

        [Test, Order(1)]
        public void TC1_EditAndVerifyContact()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            profileObj.EditMyContactDetails(2, "Profile");
            VerifyContactDetails(2, "Profile");
        }

        //[Test, Order(2)]
        public void TC2a_EnterLanguage()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            profileObj.addLanguage(2, "Profile");
            VerifyAddLanguage(2, "Profile");

        }
        //[Test, Order(3)]
        public void TC2b_EditLanguage()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            profileObj.editLanguage(2, 3, "Profile");
            VerifyEditLanguage(3, "Profile");
        }
        
        //[Test, Order(4)]
        public void TC2c_DeleteLanguage()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            profileObj.deleteLanguage(3, "Profile");
            VerifyDeleteLanguage(3, "Profile");

        }

        #region Assertions for profile
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
            Assert.AreEqual(message, assertMessage, "Actual message and Expected message do not match.");

            //Check Full Name
            string fullName = sFirstName + " " + sLastName;
            string actFullName = profileObj.GetFullName();
            Assert.AreEqual(fullName, actFullName, "Actual full name and Expected full name do not match");

            //Check availability
            Assert.AreEqual(availability, profileObj.GetAvailabilityType(), "Actual availability type and Expected availability type do not match.");

            //Check Hours
            Assert.AreEqual(hour, profileObj.GetAvailityHour(), "Actual availability hour and expected availability hour do not match.");

            //Check Earn Targe
            Assert.AreEqual(earnTarget, profileObj.GetAvailityTarget(), "Actual earn target and Expected earn target do not match.");
        }

        public void VerifyAddLanguage(int rowNumber,string Excelsheet)
        {
            ExcelLib.PopulateInCollection(Base.ExcelPath, Excelsheet);
            string language = profileObj.GetNewLanguage();
            string langguageLevel = profileObj.GetNewLanguageLevel();

            //Assertion
            Assert.That(language == ExcelLib.ReadData(rowNumber, "Language"), "Actual Addlanguage and expected Addlanguage does not match");
            Assert.That(langguageLevel == ExcelLib.ReadData(rowNumber, "LanguageLevel"), "Actual Addlanguage and expected Addlanguage does not match");
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

        #endregion
    }
}