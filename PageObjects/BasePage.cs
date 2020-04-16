using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Calculators.PageObjects
{

    public class BasePage : IDisposable
    {
        protected ChromeDriver chromeDriver;
        public BasePage(ChromeDriver driver) => chromeDriver = driver;
        
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
            chromeDriver.Navigate().GoToUrl("https://www.calculator.net/calorie-calculator.html");
        }
    }
}
