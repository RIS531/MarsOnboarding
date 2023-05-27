using Mars.Pages;
using Mars_onboarding.Pages;
using Mars_onboarding.Utilities;
using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;

namespace Mars.StepDefinitions
{
    [Binding]
    public class SellerCertificationsStepDefinitions : Commondriver
    {

        readonly LoginPage LoginPageObj;
        readonly SellerCertificatePage SellerCertificatePageObj;

        public SellerCertificationsStepDefinitions()
        {
            driver = new ChromeDriver();
            LoginPageObj = new LoginPage();
            SellerCertificatePageObj = new SellerCertificatePage();
        }

        [Given(@"I logged into skillswap successfully")]
        public void GivenILoggedIntoSkillswapSuccessfully()
        {
            LoginPageObj.LoginTasks();

        }

        [When(@"user add a '([^']*)' and '([^']*)','([^']*)'")]
        public void WhenUserAddAAnd(string certificate, string certificatefrom, string year)
        {
            SellerCertificatePageObj.AddCertificate(certificate,certificatefrom,year);
            
        }

        [Then(@"User add certification successfully")]
        public void ThenUserAddCertificationSuccessfully()
        {
            SellerCertificatePageObj.CertificateActionAssertion();   
        }
    }
}
