using Mars_onboarding.Utilities;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;

namespace Mars.Pages
{
    public class SellerCertificatePage:Commondriver
    {
        public string? PopCertificate;
        private bool UserCertificateCheck;
        readonly WebDriverWait wait;
        private string? StoreCertificate;
        private readonly By CertificateBtn = By.XPath("//a[text()='Certifications']");
        private static IWebElement AddNewBtn => driver.FindElement(By.XPath("//div[@data-tab='fourth']//th//div[@class='ui teal button ']"));
        private static IWebElement CertificateTextBox => driver.FindElement(By.XPath("//input[@placeholder='Certificate or Award']"));
        private static IWebElement CertificatefromTextBox => driver.FindElement(By.XPath("//div[@data-tab='fourth']//input[@class='received-from capitalize']"));

        private static IWebElement CertificateYear => driver.FindElement(By.Name("certificationYear"));
        private static IWebElement AddBtn => driver.FindElement(By.XPath("//input[@value='Add']"));
        private static IWebElement CancelBtn => driver.FindElement(By.XPath("//input[@value='Cancel']"));
        private ReadOnlyCollection<IWebElement> WebElements => driver.FindElements(AllCertificateRowColumns);
        private readonly By AllCertificateRowColumns = By.TagName("td");
        public By AlertBy = By.XPath("//div[@class='ns-box-inner']");
        public  IWebElement Alertpopup => driver.FindElement(AlertBy);
       
        public SellerCertificatePage()
        {
            UserCertificateCheck = false;
            wait = new(driver, new TimeSpan(0, 0, 100));
        }

        public void AddCertificate(string certificate, string certificatefrom,string certificateyear)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(CertificateBtn)).Click();
            StoreCertificate = certificate;
            wait.Until(ExpectedConditions.ElementToBeClickable(AddNewBtn)).Click();
            CertificateTextBox.Click();
            CertificateTextBox.Clear();
            CertificateTextBox.SendKeys(certificate);
            CertificatefromTextBox.Click();
            CertificatefromTextBox.Clear();
            CertificatefromTextBox.SendKeys(certificatefrom);
            SelectElement Languageleveldropdownlistbox = new(CertificateYear);
            Languageleveldropdownlistbox.SelectByText(certificateyear);
            wait.Until(ExpectedConditions.ElementToBeClickable(AddBtn)).Click();
                
               if( wait.Until(ExpectedConditions.ElementToBeClickable(AlertBy)).Text.Equals("This information is already exist."))
               {
                    wait.Until(ExpectedConditions.ElementToBeClickable(CancelBtn)).Click();
               }
              else
              { 
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
               // PopCertificate = Alertpopup.Text;
                driver.SwitchTo().ActiveElement();

              }
        }
        public void ReturnAllElementsByLocator()
        {

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3000);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(AllCertificateRowColumns));
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(AllCertificateRowColumns));

        }

        public void CheckCertificateAddedToUser()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(CertificateBtn)).Click();
            ReturnAllElementsByLocator();

            for (int i = 0; i < WebElements.Count; i++)
            {
                if (WebElements[i].Text.Equals(StoreCertificate))
                {
                    UserCertificateCheck = true;
                    break;
                }
            }
        }

        public void CertificateActionAssertion()
        {
            CheckCertificateAddedToUser();
            UserCertificateCheck.Should().BeTrue();

        }

    }
}
