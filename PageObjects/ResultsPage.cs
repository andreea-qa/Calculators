using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Calculators.PageObjects
{
    public class ResultsPage
    {
        private ChromeDriver chromeDriver;
        public ResultsPage(ChromeDriver driver) => chromeDriver = driver;
        private IWebElement MaintainResult => chromeDriver.FindElementByXPath("//div[@class='verybigtext']/b[1]");
        private IWebElement CreateYourOwnTab => chromeDriver.FindElementByXPath("//td[contains(text(),'Create Your Own')]");
        public bool IsMaintainResultCorrect(string result)
        {
            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return MaintainResult.Text == result;
        }

        public void NavigateToMakeYourOwn()
        {
            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            CreateYourOwnTab.Click();
        }
    }
}
