using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Calculators.PageObjects
{

    public class BasePage : IDisposable
    {
        protected ChromeDriver chromeDriver;
        private const string siteURL = "https://www.calculator.net/";
        public BasePage(ChromeDriver driver) => chromeDriver = driver;
        private IWebElement calorieslink => chromeDriver.FindElementByLinkText("Calorie Calculator");
        private IWebElement SearchBar => chromeDriver.FindElementById("calcSearchTerm");
        private IWebElement SearchBtn => chromeDriver.FindElementById("bluebtn");
        private IWebElement MacroLink => chromeDriver.FindElementByLinkText("Macro Calculator");
        public void Dispose()
        {
            if (chromeDriver != null)
            {
                chromeDriver.Dispose();
                chromeDriver = null;
            }
        }
           

        public void openPage()
        {
            chromeDriver.Navigate().GoToUrl(siteURL);
        }

        public void navigatToCaloriesCalc()
        {
            calorieslink.Click();
        }

        public void NavigateToMacroCalc()
        {
            SearchBar.SendKeys("macro");
            SearchBtn.Click();
            MacroLink.Click();
        }
    }
}
