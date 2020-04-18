using TechTalk.SpecFlow; 
using Calculators.PageObjects;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using Calculators.TestSteps;
using Calculators.Data;
using TechTalk.SpecFlow.Assist;

namespace Calculators
{
    [Binding]
    public class CalculatorSteps 
    {
        private readonly ChromeDriver driver;
        private readonly BasePage basePage;
        private readonly CaloriesCalculatorPage caloriesCalculatorPage;
        private readonly ResultsPage resultsPage;
        public CalculatorSteps(ChromeDriver driver)
        {
            // Assign 'driver' to private field or use it to initialize a page object
            this.driver = driver;

            // Initialize Selenium page object
            this.basePage = new BasePage(driver);
            this.caloriesCalculatorPage = new CaloriesCalculatorPage(driver);
            this.resultsPage = new ResultsPage(driver);
        }


        [Given(@"I go to the Calories Calculator")]
        public void GivenIGoToTheCaloriesCalculator()
        {
            basePage.navigatToCaloriesCalc();
        }

        [Given(@"I select the Metric system")]
        public void GivenISelectTheMetricSystem()
        {
            caloriesCalculatorPage.SelectMetric();
        }
         
        [Given(@"I press Calculate")]
        [When(@"I press Calculate")]
        public void WhenIPressCalculate()
        {
            caloriesCalculatorPage.CalculateResult();
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

        [Given(@"I enter the following data:")]
        public void GivenIEnterTheFollowingData(Table table)
        {
            var userValues = table.CreateInstance<UserSizeValues>();
            caloriesCalculatorPage.EnterAge(userValues.Age);
            caloriesCalculatorPage.EnterHeight(userValues.Height);
            caloriesCalculatorPage.EnterWeight(userValues.Weight);
            caloriesCalculatorPage.SelectGender(userValues.Gender);
        }

        [Then(@"I should see the (.*) message")]
        public void ThenIShouldSeeThePleaseProvideAnAgeBetweenAndMessage(string message)
        {
            Assert.IsTrue(caloriesCalculatorPage.IsErrorMessageDisplayed(message));
        }

    }
}
