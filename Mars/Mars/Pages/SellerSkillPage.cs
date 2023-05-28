using Mars_onboarding.Utilities;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.ObjectModel;


namespace Mars.Pages
{
    public class SellerSkillPage:Commondriver
    {

        public string? PopSkill;
        private bool UserSkillCheck;
        readonly WebDriverWait wait;
        private string? StoreSkill;
        private string SkillToUpdate = default!;
        private string SkillToDelete = default!;

        private readonly By SkillBtn = By.XPath("//a[text()='Skills']");
        private static IWebElement AddNewBtn => driver.FindElement(By.XPath("//div[@data-tab='second']//div[@class='ui teal button']"));
        private static IWebElement SkillTextBox => driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
        private static IWebElement LevelDropDown => driver.FindElement(By.Name("level"));
        private static IWebElement AddBtn => driver.FindElement(By.XPath("//input[@value='Add']"));
        private static IWebElement CancelBtn => driver.FindElement(By.XPath("//input[@value='Cancel']"));
        private static IWebElement UpdateBtn => driver.FindElement(By.XPath("//input[@value='Update']"));
        private IWebElement UpdateSkillButtonIcon => driver.FindElement(By.XPath("//table[@class='ui fixed table']//td[text()='" + SkillToUpdate + "']//following-sibling::td/span/i[@class='outline write icon']"));
        private IWebElement DeleteSkillButtonIcon => driver.FindElement(By.XPath("//table[@class='ui fixed table']//td[text()='" + SkillToDelete + "']//following-sibling::td/span/i[@class='remove icon']"));
        private ReadOnlyCollection<IWebElement> WebElements => driver.FindElements(AllSkillRowColumns);
        private readonly By AllSkillRowColumns = By.TagName("td");
        public By AlertBy = By.XPath("//div[@class='ns-box-inner']");
        public  IWebElement Alertpopup => driver.FindElement(AlertBy);

        public SellerSkillPage()
        {
            UserSkillCheck = false;
            wait = new(driver, new TimeSpan(0, 0, 100));
        }
        
        public void AddSkill(string skill, string skilllevel)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(SkillBtn)).Click();
            StoreSkill = skill;
            wait.Until(ExpectedConditions.ElementToBeClickable(AddNewBtn)).Click();
            SkillTextBox.Click();
            SkillTextBox.Clear();
            SkillTextBox.SendKeys(skill);
            SelectElement Languageleveldropdownlistbox = new(LevelDropDown);
            Languageleveldropdownlistbox.SelectByText(skilllevel);
            wait.Until(ExpectedConditions.ElementToBeClickable(AddBtn)).Click();
            if (wait.Until(ExpectedConditions.ElementToBeClickable(AlertBy)).Text.Equals("This information is already exist."))
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(CancelBtn)).Click();
            }

            else
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                // PopSkill = Alertpopup.Text;
                driver.SwitchTo().ActiveElement();
            }
            
          
        }
        public void ReturnAllElementsByLocator()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3000);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(AllSkillRowColumns));
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(AllSkillRowColumns));
         }

        public void CheckSkillAddedToUser()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(SkillBtn)).Click();
            ReturnAllElementsByLocator();
            for (int i = 0; i < WebElements.Count; i++)
            {
                if (WebElements[i].Text.Equals(StoreSkill))
                {
                    UserSkillCheck = true;
                    break;
                }
            }
        }
        public void SkillActionAssertion()
        {
            CheckSkillAddedToUser();
            UserSkillCheck.Should().BeTrue();

        }
        public void SkillDeleteAssertion()
        {
            CheckSkillAddedToUser();
            UserSkillCheck.Should().BeFalse();

        }
        public void DeleteSkill(string delskill)
        {
            SkillToDelete = delskill;
            wait.Until(ExpectedConditions.ElementToBeClickable(SkillBtn)).Click();
            ReturnAllElementsByLocator();
            for (int i = 0; i < WebElements.Count; i++)
            {
                if (WebElements[i].Text.Equals(delskill) && i < WebElements.Count)
                {
                    wait.Until(ExpectedConditions.ElementToBeClickable(DeleteSkillButtonIcon)).Click();
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                    PopSkill = Alertpopup.Text;
                    break;
                }
            }

        }
        public void UpdateSkill(string userskill, string updatedskill, string updateskilllevel)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(SkillBtn)).Click();
            StoreSkill = updatedskill;
            SkillToUpdate = userskill;
            CheckSkillAddedToUser();
            if (UserSkillCheck==false)
            {
                ReturnAllElementsByLocator();

                for (int i = 0; i < WebElements.Count; i++)
                {
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1000);
                    if (WebElements[i].Text.Equals(userskill) && i < WebElements.Count)
                    {
                        wait.Until(ExpectedConditions.ElementToBeClickable(UpdateSkillButtonIcon)).Click();
                        SkillTextBox.Clear();
                        SkillTextBox.SendKeys(updatedskill);

                        SelectElement Skillleveldropdownlistbox = new(LevelDropDown);
                        Skillleveldropdownlistbox.SelectByText(updateskilllevel);
                        wait.Until(ExpectedConditions.ElementToBeClickable(UpdateBtn)).Click();
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                        PopSkill = Alertpopup.Text;
                        break;
                    }
                }

                driver.Navigate().Refresh();
            }

        }
    }

}

