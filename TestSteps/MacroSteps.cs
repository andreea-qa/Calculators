using Calculators.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace Calculators.TestSteps
{
    [Binding]
    public class MacroSteps 
    {
        private readonly ChromeDriver driver;
        private readonly BasePage basePage;
        private readonly MacroPage macroPage;
        public MacroSteps(ChromeDriver driver)
        {
            // Assign 'driver' to private field or use it to initialize a page object
            this.driver = driver;

            // Initialize Selenium page object
            this.basePage = new BasePage(driver);
            this.macroPage = new MacroPage(driver);
        }
        [Given(@"I go to the Macro Calculator")]
        public void GivenIGoToTheMacroCalculator()
        {
            basePage.NavigateToMacroCalc();
        }

        [When(@"I navigate to Create Your Own tab")]
        public void WhenINavigateToCreateYourOwnTab()
        {
            macroPage.NavigateToMakeYourOwn();
        }

        [When(@"I move the protein slider to the Minimum")]
        public void WhenIMoveTheProteinSliderToTheMinimum()
        {
            macroPage.SelectMinimumProtein();
        }

        [Then(@"the protein value should be (.*)")]
        public void ThenTheProteinValueShouldBe(int p0)
        {
            Assert.IsTrue(macroPage.IsProteinValue(p0));
        }

        [When(@"I move the protein slider to the Maximum")]
        public void WhenIMoveTheProteinSliderToTheMaximum()
        {
            macroPage.SelectMaximumProtein();
        }


    }
}
