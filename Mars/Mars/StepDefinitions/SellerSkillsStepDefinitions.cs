using Mars.Pages;
using Mars_onboarding.Pages;
using Mars_onboarding.Utilities;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace Mars.StepDefinitions
{
    [Binding]
    public class SellerSkillsStepDefinitions:Commondriver
    {
        readonly LoginPage LoginPageObj;
        readonly SellerSkillPage SellerSkillPageObj;
        public SellerSkillsStepDefinitions()
        {
            driver = new ChromeDriver();
            LoginPageObj = new LoginPage();
            SellerSkillPageObj = new SellerSkillPage();
        }

        [Given(@":User login to TradeWebsite")]
        public void GivenUserLoginToTradeWebsite()
        {
            LoginPageObj.LoginTasks();
        }
        [When(@"User add a '([^']*)' and '([^']*)'")]
        public void WhenUserAddAAnd(string skill, string skilllevel)
        {
            SellerSkillPageObj.AddSkill(skill, skilllevel);
        }

        [Then(@"User skill is added successfully on the user profile")]
        public void ThenUserSkillIsAddedSuccessfullyOnTheUserProfile()
        {
            SellerSkillPageObj.SkillActionAssertion();
        }

        [When(@"User update a '([^']*)' to '([^']*)' and '([^']*)'")]
        public void WhenUserUpdateAToAnd(string userskill, string updateskill , string updateskilllevel)
        {
            SellerSkillPageObj.UpdateSkill(userskill, updateskill, updateskilllevel);
        }

        [Then(@"The skill is updated successfully on the user profile")]
        public void ThenTheSkillIsUpdatedSuccessfullyOnTheUserProfile()
        {
            SellerSkillPageObj.SkillActionAssertion();
        }

        [When(@"User delete a  '([^']*)'")]
        public void WhenUserDeleteA(string deleteskill)
        {
            SellerSkillPageObj.DeleteSkill(deleteskill);
        }

        [Then(@"The skill is deleted successfully on the user profile")]
        public void ThenTheSkillIsDeletedSuccessfullyOnTheUserProfile()
        {
            SellerSkillPageObj.SkillDeleteAssertion();
        }
    }
}
