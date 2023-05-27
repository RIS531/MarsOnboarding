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
        public bool LanguageDeleted;

        private readonly By languageBtn = By.XPath("//a[text()='Languages']");
        private IWebElement LanguageBtn => driver.FindElement(languageBtn);
        
        private static IWebElement AddNewBtn => driver.FindElement(By.XPath("//div[text()='Add New']"));
        private static IWebElement LanguageTextBox => driver.FindElement(By.XPath("//input[@placeholder='Add Language']"));
        private static IWebElement LevelDropDown => driver.FindElement(By.Name("level"));
        private static IWebElement AddBtn=> driver.FindElement(By.XPath("//input[@value='Add']"));
        private static IWebElement UpdateBtn => driver.FindElement(By.XPath("//input[@value='Update']"));
        private  IWebElement UpdateLanguageButtonIcon => driver.FindElement(By.XPath("//table[@class='ui fixed table']//td[text()='" + LanguageToUpdate + "']//following-sibling::td/span/i[@class='outline write icon']"));
        private IWebElement DeleteLanguageButtonIcon => driver.FindElement(By.XPath("//table[@class='ui fixed table']//td[text()='" + LanguageToDelete + "']//following-sibling::td/span/i[@class='remove icon']"));
        private ReadOnlyCollection<IWebElement> WebElements => driver.FindElements(AlllanguageRowColumns);
        private readonly By AlllanguageRowColumns =By.TagName("td");
        
        private static readonly string Alertpopuppath = "//div[@class='ns-box-inner']";
        public static IWebElement Alertpopup =>driver.FindElement(By.XPath(Alertpopuppath));
       public SellerLanguagePage()
        {
            UserLanguageCheck = false;
            wait = new(driver,new TimeSpan(0,0,100));
            LanguageDeleted = false;
           
        }
       public void AddLanguage(string language, string languagelevel)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(languageBtn));
            LanguageBtn.Click();
            storelanguage = language;
            wait.Until(ExpectedConditions.ElementToBeClickable(AddNewBtn));
            AddNewBtn.Click();
            LanguageTextBox.Click();
            LanguageTextBox.Clear();
            LanguageTextBox.SendKeys(language);
            SelectElement languageleveldropdownlistbox = new(LevelDropDown);
            languageleveldropdownlistbox.SelectByText(languagelevel);
            wait.Until(ExpectedConditions.ElementToBeClickable(AddBtn));
            AddBtn.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            PopLanguage = Alertpopup.Text;
            driver.SwitchTo().ActiveElement();
        }
        public void ReturnAllElementsByLocator()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3000);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(AlllanguageRowColumns));
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(AlllanguageRowColumns));
        }
        public void CheckLanguageAddedToUser()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(languageBtn)).Click();
            LanguageBtn.Click();
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
            wait.Until(ExpectedConditions.ElementToBeClickable(languageBtn));
            LanguageBtn.Click();
            ReturnAllElementsByLocator();
            for (int i = 0; i < WebElements.Count; i++)
            {
                if (WebElements[i].Text.Equals(dellanguage) && i < WebElements.Count)
                {
                    wait.Until(ExpectedConditions.ElementToBeClickable(DeleteLanguageButtonIcon));
                    DeleteLanguageButtonIcon.Click();
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                    PopLanguage = Alertpopup.Text;
                    break;
                }
            }
            
        }
        public void UpdateLanguage(string userlanguage, string updatedlanguage, string updatelanguagelevel)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(languageBtn));
            LanguageBtn.Click();
            storelanguage = updatedlanguage;
            LanguageToUpdate = userlanguage;
            ReturnAllElementsByLocator();

            for (int i = 0; i < WebElements.Count; i++)
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1000);
                if (WebElements[i].Text.Equals(userlanguage) && i < WebElements.Count)
                {
                    wait.Until(ExpectedConditions.ElementToBeClickable(UpdateLanguageButtonIcon));
                    UpdateLanguageButtonIcon.Click();
                    LanguageTextBox.Clear();
                    LanguageTextBox.SendKeys(updatedlanguage);
                    SelectElement languageleveldropdownlistbox = new(LevelDropDown);
                    languageleveldropdownlistbox.SelectByText(updatelanguagelevel);
                    wait.Until(ExpectedConditions.ElementToBeClickable(UpdateBtn));
                    UpdateBtn.Click();
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                    PopLanguage = Alertpopup.Text;
                    break;
                }
            }

            driver.Navigate().Refresh();

        }
    }
}
