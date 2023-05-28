using FluentAssertions;
using Mars_onboarding.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;

namespace Mars_onboarding.Pages
{
    public class SellerLanguagePage:Commondriver
    {
        public string? PopLanguage;
        private bool UserLanguageCheck;
        readonly WebDriverWait wait;
        private string? storelanguage;
        private string LanguageToUpdate=default!;
        private string LanguageToDelete = default!;
        private readonly By LanguageBtn = By.XPath("//a[text()='Languages']");
        private static IWebElement AddNewBtn => driver.FindElement(By.XPath("//div[text()='Add New']"));
        private static IWebElement LanguageTextBox => driver.FindElement(By.XPath("//input[@placeholder='Add Language']"));
        private static IWebElement LevelDropDown => driver.FindElement(By.Name("level"));
        private static IWebElement AddBtn=> driver.FindElement(By.XPath("//input[@value='Add']"));
        private static IWebElement CancelBtn => driver.FindElement(By.XPath("//input[@value='Cancel']"));
        private static IWebElement UpdateBtn => driver.FindElement(By.XPath("//input[@value='Update']"));
        private  IWebElement UpdateLanguageButtonIcon => driver.FindElement(By.XPath("//table[@class='ui fixed table']//td[text()='" + LanguageToUpdate + "']//following-sibling::td/span/i[@class='outline write icon']"));
        private IWebElement DeleteLanguageButtonIcon => driver.FindElement(By.XPath("//table[@class='ui fixed table']//td[text()='" + LanguageToDelete + "']//following-sibling::td/span/i[@class='remove icon']"));
        private ReadOnlyCollection<IWebElement> WebElements => driver.FindElements(AlllanguageRowColumns);
        private readonly By AlllanguageRowColumns =By.TagName("td");

        public By AlertBy = By.XPath("//div[@class='ns-box-inner']");
        public IWebElement Alertpopup => driver.FindElement(AlertBy);
        public SellerLanguagePage()
        {
            UserLanguageCheck = false;
            wait = new(driver,new TimeSpan(0,0,100));
        }
       public void AddLanguage(string language, string languagelevel)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(LanguageBtn)).Click();
            storelanguage = language;
            wait.Until(ExpectedConditions.ElementToBeClickable(AddNewBtn)).Click();
            LanguageTextBox.Click();
            LanguageTextBox.Clear();
            LanguageTextBox.SendKeys(language);
            SelectElement Languageleveldropdownlistbox = new(LevelDropDown);
            Languageleveldropdownlistbox.SelectByText(languagelevel);
            wait.Until(ExpectedConditions.ElementToBeClickable(AddBtn)).Click();
            if (wait.Until(ExpectedConditions.ElementToBeClickable(AlertBy)).Text.Equals("This information is already exist."))
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(CancelBtn)).Click();
            }
                
            else
            {
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                    // PopLanguage = Alertpopup.Text;
                    driver.SwitchTo().ActiveElement();
            }
           
        }
        public void ReturnAllElementsByLocator()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3000);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(AlllanguageRowColumns));
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(AlllanguageRowColumns));
        }
        public void CheckLanguageAddedToUser()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(LanguageBtn)).Click();
            ReturnAllElementsByLocator();
           for (int i = 0; i < WebElements.Count; i++)
            {
               if (WebElements[i].Text.Equals(storelanguage))
                {
                    UserLanguageCheck = true;
                    break;
                }
            }
        }
       
        public void LanguageActionAssertion()
        {
            CheckLanguageAddedToUser();
            UserLanguageCheck.Should().BeTrue();
        }
        public void LanguageDeleteAssertion()
        {
            CheckLanguageAddedToUser();
            UserLanguageCheck.Should().BeFalse();
        }

        public void DeleteLanguage(string dellanguage)
        {
            LanguageToDelete = dellanguage;
            wait.Until(ExpectedConditions.ElementToBeClickable(LanguageBtn)).Click();
           
                ReturnAllElementsByLocator();
                for (int i = 0; i < WebElements.Count; i++)
                {
                    if (WebElements[i].Text.Equals(dellanguage) && i < WebElements.Count)
                    {
                        wait.Until(ExpectedConditions.ElementToBeClickable(DeleteLanguageButtonIcon)).Click();
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                        PopLanguage = Alertpopup.Text;
                        break;
                    }
                }
            
        }
        public void UpdateLanguage(string userlanguage, string updatedlanguage, string updatelanguagelevel)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(LanguageBtn)).Click();
            storelanguage = updatedlanguage;
            LanguageToUpdate = userlanguage;
            CheckLanguageAddedToUser();
            if (UserLanguageCheck==false)
            {
                ReturnAllElementsByLocator();

                for (int i = 0; i < WebElements.Count; i++)
                {
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1000);
                    if (WebElements[i].Text.Equals(userlanguage) && i < WebElements.Count)
                    {
                        wait.Until(ExpectedConditions.ElementToBeClickable(UpdateLanguageButtonIcon)).Click();
                        LanguageTextBox.Clear();
                        LanguageTextBox.SendKeys(updatedlanguage);
                        SelectElement languageleveldropdownlistbox = new(LevelDropDown);
                        languageleveldropdownlistbox.SelectByText(updatelanguagelevel);
                        wait.Until(ExpectedConditions.ElementToBeClickable(UpdateBtn)).Click();
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                        PopLanguage = Alertpopup.Text;
                        break;
                    }
                }

                driver.Navigate().Refresh();
            }

        }
    }
}
