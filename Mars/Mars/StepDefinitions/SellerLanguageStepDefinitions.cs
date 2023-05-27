using Mars_onboarding.Utilities;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using Mars_onboarding.Pages;

namespace Mars.StepDefinitions
{
    [Binding]
    public class SellerLanguageStepDefinitions:Commondriver
    {

       readonly LoginPage LoginPageObj;
        readonly SellerLanguagePage SellerLanguagePageObj;
        public SellerLanguageStepDefinitions()
        {
            driver = new ChromeDriver();
            LoginPageObj = new LoginPage();
            SellerLanguagePageObj = new SellerLanguagePage();
        }

        [Given(@":User login to website")]
        public void GivenUserLoginToWebsite()
        {
            LoginPageObj.LoginTasks();
        }

        [When(@"User add a  '([^']*)' and '([^']*)'")]
        public void WhenUserAddAAnd(string language, string languagelevel)
        {
            SellerLanguagePageObj.AddLanguage(language, languagelevel);
        }

        [Then(@"User language is added successfully on the user profile")]
        public void ThenUserLanguageIsAddedSuccessfullyOnTheUserProfile()
        {
            SellerLanguagePageObj.LanguageActionAssertion();


        }

        [When(@"User update  a '([^']*)' to '([^']*)' and '([^']*)'")]
        public void WhenUserUpdateAToAnd(string userlanguage, string updatedlanguage, string updatelanguagelevel)
        {
            SellerLanguagePageObj.UpdateLanguage(userlanguage, updatedlanguage, updatelanguagelevel);
        }

        [Then(@"The language is updated successfully on the user profile")]
        public void ThenTheLanguageIsUpdatedSuccessfullyOnTheUserProfile()
        {
            SellerLanguagePageObj.LanguageActionAssertion();
        }

        [When(@"User delete a '([^']*)'")]
        public void WhenUserDeleteA(string dellanguage)
        {
            SellerLanguagePageObj.DeleteLanguage(dellanguage);
        }

        [Then(@"The language is deleted successfully")]
        public void ThenTheLanguageIsDeletedSuccessfully()
        {
           
            SellerLanguagePageObj.LanguageDeleteAssertion();
        }
    }
}
