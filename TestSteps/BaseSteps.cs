using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using Calculators.PageObjects;
using BoDi;

namespace Calculators.TestSteps
{
    [Binding]
    public class WebDriverHooks
    {
        private readonly IObjectContainer container;

        public WebDriverHooks(IObjectContainer container)
        {
            this.container = container;
        }

        protected BasePage basePage; 
        protected CaloriesCalculatorPage caloriesCalculatorPage;
        protected ResultsPage resultsPage;


        [BeforeScenario]
        public void NavigateToApp()
        {
            ChromeDriver driver = new ChromeDriver();
            basePage = new BasePage(driver);
            caloriesCalculatorPage = new CaloriesCalculatorPage(driver);
            resultsPage = new ResultsPage(driver); 
            basePage.openPage();
            container.RegisterInstanceAs<ChromeDriver>(driver);
        }

        [AfterScenario]
        public void CloseSession()
        {
            /*var driver = container.Resolve<ChromeDriver>();

            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            } */
        }

        


    }
}
