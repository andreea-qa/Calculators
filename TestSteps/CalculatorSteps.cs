using TechTalk.SpecFlow; 
using Calculators.PageObjects;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using Calculators.TestSteps;

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


    }
}
