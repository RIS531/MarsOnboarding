using Mars_onboarding.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SpecFlow.Internal.Json;

namespace Mars_onboarding.Pages
{
    public class LoginPage:Commondriver
    {
        private readonly By SignInButton = By.XPath("//a[@class='item']");
        private readonly By EmailInputBox = By.Name("email");
        private static IWebElement PasswordInputBox => driver.FindElement(By.Name("password"));
        private static IWebElement LoginButton => driver.FindElement(By.XPath("//button[text()='Login']"));

        public void LoginTasks()
        {
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(50));
            
            driver.Navigate().GoToUrl("http://localhost:5000/");
            driver.Manage().Window.Maximize();
            wait.Until(ExpectedConditions.ElementToBeClickable(SignInButton)).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(EmailInputBox)).Click();
            driver.FindElement(EmailInputBox).SendKeys("sdzc@gmail.com");
            PasswordInputBox.SendKeys("1234567");
            LoginButton.Click();
        }
        
    }
}
