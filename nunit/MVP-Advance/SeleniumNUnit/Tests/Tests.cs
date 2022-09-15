using NUnit.Framework;
using SeleniumNUnit.Pages;

namespace SeleniumNUnit.Tests
{
    internal class Tests : Global.Base
    {
        [Test]
        public void EnterLanguage()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            Profile ProfilePageObj = new Profile();


            ProfilePageObj.addLanguage(2, "Profile");

        }
         
        public void EditLanguage()
        {
          
        }
    }
}