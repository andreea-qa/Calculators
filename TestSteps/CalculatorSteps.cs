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
    public class CalculatorSteps : BaseSteps
    {
        
        private BasePage basePage = new BasePage(driver);
        
        [Given(@"I select the Metric system")]
        public void GivenISelectTheMetricSystem()
        {
            caloriesCalculatorPage.SelectMetric();
        }
           
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
