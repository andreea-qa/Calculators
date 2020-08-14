using Calculators.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace Calculators.TestSteps
{
    [Binding]
    public class AgeSteps
    {
        private readonly ChromeDriver driver;
        private readonly BasePage basePage;
        private readonly AgePage agePage;
        private readonly ResultsPage resultsPage;
        public AgeSteps(ChromeDriver driver)
        {  
            this.driver = driver;
            this.basePage = new BasePage(driver);
            this.agePage = new AgePage(driver);
            this.resultsPage = new ResultsPage(driver);
        }
        [Given(@"I go to the Age Calculator")]
        public void GivenIGoToTheAgeCalculator()
        {
            basePage.NavigateToAgeCalc();
        }

        [Given(@"I enter the birth date (.*) from the dropdowns")]
        public void GivenIEnterTheBirthDateFromTheDropdowns(DateTime birthday)
        {
            /*string day = birthday.Day.ToString();
            string month = birthday.ToString("MMM");
            string year = birthday.Year.ToString(); */
            agePage.EnterBirthDay(birthday);
        }
        
        [Given(@"the current date is (.*)")]
        public void GivenTheCurrentDateIs(DateTime currentDay)
        {
            /*string day = currentDay.Day.ToString();
            string month = currentDay.ToString("MMM");
            string year = currentDay.Year.ToString(); */
            agePage.EnterCurrrentDate(currentDay);
        }
        
        [Given(@"I enter the birth date (.*)/(.*) from the calendar")]
        public void GivenIEnterTheBirthDateFromTheCalendar(string p0, int p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I enter the birth date (.*) week ahead")]
        public void GivenIEnterTheBirthDateWeekAhead(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the age should be (.*)")]
        public void ThenTheAgeShouldBeYearsMonthsDays(string age)
        {
            Assert.IsTrue(agePage.IsAgeCorrect(age));
        }
    }
}
