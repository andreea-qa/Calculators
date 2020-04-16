using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using Calculators.PageObjects;

namespace Calculators.TestSteps
{
    public class BaseSteps
    {
        protected static ChromeDriver driver;
        protected BasePage basePage; 
        protected CaloriesCalculatorPage caloriesCalculatorPage;
        protected ResultsPage resultsPage = new ResultsPage(driver);


        [BeforeScenario]
        public void NavigateToApp()
        {
            driver = new ChromeDriver(@"C:\Andreea\Automation C#");
            basePage = new BasePage(driver);
            caloriesCalculatorPage = new CaloriesCalculatorPage(driver);
            resultsPage = new ResultsPage(driver); 
            basePage.openPage();
        }

        [AfterScenario]
        public void CloseSession()
        {
            driver.Quit();
        }

        [Given(@"I go to the Calories Calculator")]
        public void GivenIGoToTheCaloriesCalculator()
        {
            basePage.navigatToCaloriesCalc();
        }

    }
}
