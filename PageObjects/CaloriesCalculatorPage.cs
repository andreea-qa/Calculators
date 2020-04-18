using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Calculators.PageObjects
{
    public class CaloriesCalculatorPage
    {
        private ChromeDriver chromeDriver;
        public CaloriesCalculatorPage(ChromeDriver driver) => chromeDriver = driver;

        private IWebElement MetricSystem => chromeDriver.FindElement(By.XPath("//a[contains(text(),'Metric')]"));
        private IWebElement Age => chromeDriver.FindElementById("cage");
        private IWebElement Height => chromeDriver.FindElementById("cheightmeter");
        private IWebElement WeightKg => chromeDriver.FindElementById("ckg");
        private IWebElement Male => chromeDriver.FindElementById("csex1");
        private IWebElement Female => chromeDriver.FindElementById("csex2");
        private SelectElement ActivityDropdown => new  SelectElement(chromeDriver.FindElementById("cactivity"));
        private IWebElement CalculateBtn => chromeDriver.FindElementByXPath("//input[@value='Calculate']");
        private IWebElement errorArea => chromeDriver.FindElementByXPath("//div[@id='contentout']//div[3]");
        public void SelectMetric()
        {
            MetricSystem.Click();
        }

        public void EnterAge(string age)
        {
            Age.Clear();
            Age.SendKeys(age);
        }

        public void EnterHeight(string height)
        {
            Height.Clear();
            Height.SendKeys(height);
        }

        public void EnterWeight(string weight)
        {
            WeightKg.Clear();
            WeightKg.SendKeys(weight);
        }

        public void SelectGender(string gender)
        {
            switch (gender)
            {
                case "Male":
                    Male.Click();
                    break;
                case "Female":
                    Female.Click();
                    break;

            }
        }

        public void SelectActivity(string option)
        {
            switch (option)
            {
                case "Very Active":
                    ActivityDropdown.SelectByText("Very Active: intense exercise 6-7 times/week");
                    break;
            }
            
        }

        internal bool? IsErrorMessageDisplayed(string message)
        {
            return errorArea.Text.Contains(message);
        }

        public void CalculateResult()
        {
            CalculateBtn.Click();
        }
    }
}
