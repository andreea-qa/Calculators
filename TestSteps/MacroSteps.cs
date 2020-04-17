using Calculators.PageObjects;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace Calculators.TestSteps
{
    [Binding]
    public class MacroSteps 
    {
        private static ChromeDriver Driver;

        public MacroSteps(ChromeDriver driver)
        {
            Driver = driver;
        }

        ResultsPage resultsPage = new ResultsPage(Driver);

        [When(@"I navigate to Create Your Own tab")]
        public void WhenINavigateToCreateYourOwnTab()
        {
            resultsPage.NavigateToMakeYourOwn();
        }

    }
}
