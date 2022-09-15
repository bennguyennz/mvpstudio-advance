using NUnit.Framework;
using SeleniumNUnit.Pages;

namespace SeleniumNUnit.Tests
{
    internal class Tests : Global.Base
    {
        Profile ProfilePageObj = new Profile();

        [Test, Order(1)]
        public void EnterLanguage()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);         
            ProfilePageObj.addLanguage(2, "Profile");

        }
        [Test, Order(2)]
        public void EditLanguage()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            ProfilePageObj.editLanguage(2,3, "Profile");
        }
        [Test, Order(3)]
        public void deleteLanguage()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            ProfilePageObj.deleteLanguage(3);

        }
    }
}