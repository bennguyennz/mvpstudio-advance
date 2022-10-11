using NUnit.Framework;
using SeleniumSpecFlow.Pages.ProfilePages;
using System;
using TechTalk.SpecFlow;

namespace SeleniumSpecFlow
{
    [Binding]
    public class LanguagesStepDefinitions
    {
        Languages LanguageObj;

        [Given(@"I click on tab Languages")]
        public void GivenIClickOnTabLanguages()
        {
            LanguageObj = new Languages();
            LanguageObj.ClickOnTabLanguages();
        }

        [When(@"I click button AddNew")]
        public void WhenIClickButtonAddNew()
        {
            LanguageObj.ClickButtonAddNew();
        }

        [When(@"I enter '([^']*)' '([^']*)'")]
        public void WhenIEnter(string Language, string Level)
        {
            LanguageObj.EnterLanguage(Language, Level);
        }

        [Then(@"I am able to see my '([^']*)' '([^']*)' in my Lnaguages tab")]
        public void ThenIAmAbleToSeeMyInMyLnaguagesTab(string Language, string Level)
        {
            //Check message
            string assertMessage = Language + " has been added to your languages";
            string message = LanguageObj.GetMessage();
            Assert.That(message == assertMessage, "Actual message and Expected message do not match");

            //Check Language
            string addedLanguage = LanguageObj.GetNewLanguage();
            Assert.That(addedLanguage == Language, "Actual language and expected language do not match");
            
            //Check Language level
            string addedLanguageLevel= LanguageObj.GetNewLevel();
            Assert.That(addedLanguageLevel == Level, "Actual languagelevel and expected languageLevel do not match");

        }

        [When(@"I click on button Edit '([^']*)'")]
        public void WhenIClickOnButtonEdit(string Language1)
        {
            LanguageObj.ClickEdit(Language1);
        }

        [When(@"I edit a '([^']*)' '([^']*)'")]
        public void WhenIEditA(string Language2, string Level)
        {
           LanguageObj.EditLanguage(Language2, Level);  
        }

        [Then(@"The existing language is edited as '([^']*)' '([^']*)'")]
        public void ThenTheExistingLanguageIsEditedAs(string Language2, string Level)
        {

            ////Check message
            string assertMessage = Language2 + " has been updated to your languages";
            string message = LanguageObj.GetMessage();
            Assert.That(message == assertMessage, "Actual message and Expected edit message do not match");

            //Check edited language
            string editedLanguage = LanguageObj.GetNewLanguage();
            Assert.That(editedLanguage == Language2, "Actual edited language and expected edited language do not match");

            //Check Language level
            string editedLanguageLevel = LanguageObj.GetNewLevel();
            Assert.That(editedLanguageLevel == Level, "Actual edited languagelevel and expected edited languageLevel do not match");

        }

        [When(@"I click on button Delete '([^']*)'")]
        public void WhenIClickOnButtonDelete(string Language)
        {
            LanguageObj.ClickDelete(Language);
        }

        [Then(@"The '([^']*)' should be deleted successfully")]
        public void ThenTheShouldBeDeletedSuccessfully(string Language)
        {
            //Check detete message
            string assertMessage = Language + " has been deleted from your languages";
            string message = LanguageObj.GetMessage();
            Assert.That(message == assertMessage, "Actual message and expected message do not match");

            //check language has been deteted successfully
            string deletedLanguage = LanguageObj.GetNewLanguage();
            Assert.That(deletedLanguage != Language, "Language has not been deleted.");
        }
    }
}
