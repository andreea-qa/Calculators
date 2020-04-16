using System;
using TechTalk.SpecFlow;
using Calculators.PageObjects;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace Calculators
{
    [Binding]
    public class CalculatorSteps
    {
        private ChromeDriver driver;
        private BasePage basePage;
        private CaloriesCalculatorPage caloriesCalculatorPage;
        private ResultsPage resultsPage;

        [BeforeScenario]
        public void NavigateToApp()
        {
            driver = new ChromeDriver(@"C:\Andreea\Automation C#");
            basePage = new BasePage(driver);
            caloriesCalculatorPage = new CaloriesCalculatorPage(driver);
            resultsPage = new ResultsPage(driver);
            basePage.openPage();
        }

        [Given(@"I select the Metric system")]
        public void GivenISelectTheMetricSystem()
        {
            caloriesCalculatorPage.SelectMetric();
        }
        
        [Given(@"I enter the age (.*)")]
        public void GivenIEnterTheAge(string p0)
        {
            caloriesCalculatorPage.EnterAge(p0);
        }
        
        [Given(@"I enter the height (.*)")]
        public void GivenIEnterTheHeightb(string p0)
        {
            caloriesCalculatorPage.EnterHeight(p0);
        }
        
        [Given(@"I enter the weight (.*)")]
        public void GivenIEnterTheWeight(string p0)
        {
            caloriesCalculatorPage.EnterWeight(p0);
        }
        
        [Given(@"I select the gender (.*)")]
        public void GivenISelectTheGender(string p0)
        {
            caloriesCalculatorPage.SelectGender(p0);
        }
        
        [When(@"I press Calculate")]
        public void WhenIPressCalculate()
        {
            basePage.CalculateResult();
        }
        
        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(string p0)
        {
            Assert.IsTrue(resultsPage.IsMaintainResultCorrect(p0));
        }

        [Given(@"I select (.*) from the activity dropdown")]
        public void GivenISelectVeryActiveFromTheActivityDropdown(string activity)
        {
            caloriesCalculatorPage.SelectActivity(activity);
        }


        [AfterScenario]
        public void CloseSession()
        {
            driver.Quit();
        }
    }
}
