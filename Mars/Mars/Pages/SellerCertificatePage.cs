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
        private IWebElement CertificateButton => driver.FindElement(CertificateBtn);

        private static IWebElement AddNewBtn => driver.FindElement(By.XPath("//div[@data-tab='fourth']//th//div[@class='ui teal button ']"));
        private static IWebElement CertificateTextBox => driver.FindElement(By.XPath("//input[@placeholder='Certificate or Award']"));
        private static IWebElement CertificatefromTextBox => driver.FindElement(By.XPath("//div[@data-tab='fourth']//input[@class='received-from capitalize']"));

        private static IWebElement CertificateYear => driver.FindElement(By.Name("certificationYear"));
        private static IWebElement AddBtn => driver.FindElement(By.XPath("//input[@value='Add']"));
      
        private ReadOnlyCollection<IWebElement> WebElements => driver.FindElements(AllCertificateRowColumns);
        private readonly By AllCertificateRowColumns = By.TagName("td");

        private static readonly string Alertpopuppath = "//div[@class='ns-box-inner']";
        public static IWebElement Alertpopup => driver.FindElement(By.XPath(Alertpopuppath));

        public SellerCertificatePage()
        {
            UserCertificateCheck = false;
            wait = new(driver, new TimeSpan(0, 0, 100));
        }

        public void AddCertificate(string certificate, string certificatefrom,string certificateyear)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(CertificateBtn));
            CertificateButton.Click();
            StoreCertificate = certificate;
            wait.Until(ExpectedConditions.ElementToBeClickable(AddNewBtn));
            AddNewBtn.Click();
            CertificateTextBox.Click();
            CertificateTextBox.Clear();
            CertificateTextBox.SendKeys(certificate);
            CertificatefromTextBox.Click();
            CertificatefromTextBox.Clear();
            CertificatefromTextBox.SendKeys(certificatefrom);
            SelectElement languageleveldropdownlistbox = new(CertificateYear);
            languageleveldropdownlistbox.SelectByText(certificateyear);
            wait.Until(ExpectedConditions.ElementToBeClickable(AddBtn));
            AddBtn.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            PopCertificate = Alertpopup.Text;
            driver.SwitchTo().ActiveElement();
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
            CertificateButton.Click();

            ReturnAllElementsByLocator();

            for (int i = 0; i < WebElements.Count; i++)
            {

                string value = WebElements[i].Text;
                if (WebElements[i].Text.Equals(StoreCertificate))
                {

                    Console.WriteLine("value of text:>" + value);
                    Console.WriteLine("count" + WebElements.Count);
                    Console.WriteLine("inside forrrr webtext:>" + WebElements[i].Text);
                    Console.WriteLine("storelanguage:>" + StoreCertificate);
                    Console.WriteLine("i number" + i);
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
