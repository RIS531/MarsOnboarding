using Mars_onboarding.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SpecFlow.Internal.Json;

namespace Mars_onboarding.Pages
{
    public class LoginPage:Commondriver
    {
        private readonly By signInButton = By.XPath("//a[@class='item']");
        private readonly By emailInputBox = By.Name("email");
        private readonly By passwordInputBox = By.Name("password");
        private readonly By loginButton = By.XPath("//button[text()='Login']");

        public void LoginTasks()
        {
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(50));
            
            driver.Navigate().GoToUrl("http://localhost:5000/");
            driver.Manage().Window.Maximize();
            wait.Until(ExpectedConditions.ElementToBeClickable(signInButton));
            driver.FindElement(signInButton).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(emailInputBox));
            
            driver.FindElement(emailInputBox).Click();
           
            driver.FindElement(emailInputBox).SendKeys("sdzc@gmail.com");

            driver.FindElement(passwordInputBox).SendKeys("1234567");
            driver.FindElement(loginButton).Click();
        }
        
    }
}
