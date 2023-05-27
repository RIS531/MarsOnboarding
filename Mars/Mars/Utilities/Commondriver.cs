using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace Mars_onboarding.Utilities
{
    [Binding]
    public  class Commondriver
    {
        public  static IWebDriver driver = default!;
        

        [AfterScenario]
        public static void AfterScenario()
        {
            driver.Quit();

        }



    }
}