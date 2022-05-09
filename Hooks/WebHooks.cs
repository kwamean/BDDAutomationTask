//this is an automation assignment as such though is public on github for assessment is content at solely for the intended client

namespace BDDAutomationTask.Hooks
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using System.IO;
    using System.Reflection;
    using TechTalk.SpecFlow;

    [Binding]
    public class WebHooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        public static IWebDriver driver;

        [BeforeScenario]
        public void BeforeScenario()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Manage().Window.Maximize();
            //TODO: implement logic that has to run before executing each scenario
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
            //TODO: implement logic that has to run after executing each scenario
        }
    }
}
