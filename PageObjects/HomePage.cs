//this is an automation assignment even though is made public on github for assessment, its content at solely for the intended client

namespace BDDAutomationTask.PageObjects
{
    using BDDAutomationTask.Hooks;
    using OpenQA.Selenium;
    public class HomePage
    {
        public IWebDriver driver;

        public HomePage()
        {
            driver = WebHooks.driver;
        }
  
        private By shop = By.XPath("//a[@title='Shop']");
        private By acceptAll = By.XPath("//a[normalize-space()='Accept all']");
        private By savePreference = By.XPath("//a[normalize-space()='Save preferences']");
        IWebElement cookies => driver.FindElement(By.XPath("//div[@id='cc-window']//div[3]"));
        
        public void CookiesPreference()
        {
            if (cookies.Displayed)
            {
                driver.FindElement(savePreference).Click();
            }

            else
            {
                driver.FindElement(acceptAll).Click();
            }
        }
        public void SelectProduct()
        {
            driver.FindElement(shop).Click();
        }
    }
}
