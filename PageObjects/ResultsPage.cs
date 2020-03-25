using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Calculators.PageObjects
{
    class ResultsPage
    {
        private ChromeDriver chromeDriver;
        public ResultsPage(ChromeDriver driver) => chromeDriver = driver;
        private IWebElement MaintainResult => chromeDriver.FindElementByXPath("(//div[@class='verybigtext']/b)[1]");

        public bool IsMaintainResultCorrect(string result)
        {
            return MaintainResult.Text == result;
        }

    }
}
