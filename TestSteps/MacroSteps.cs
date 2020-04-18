using Calculators.PageObjects;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace Calculators.TestSteps
{
    [Binding]
    public class MacroSteps 
    {
        private readonly ChromeDriver driver;
        private readonly BasePage basePage;
        private readonly ResultsPage resultsPage;
        public MacroSteps(ChromeDriver driver)
        {
            // Assign 'driver' to private field or use it to initialize a page object
            this.driver = driver;

            // Initialize Selenium page object
            this.basePage = new BasePage(driver);
            this.resultsPage = new ResultsPage(driver);
        }
        [Given(@"I go to the Macro Calculator")]
        public void GivenIGoToTheMacroCalculator()
        {
            basePage.NavigateToMacroCalc();
        }

        [When(@"I navigate to Create Your Own tab")]
        public void WhenINavigateToCreateYourOwnTab()
        {
            resultsPage.NavigateToMakeYourOwn();
        }

    }
}
