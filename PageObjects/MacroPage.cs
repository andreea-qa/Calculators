using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;

namespace Calculators.PageObjects
{
    class MacroPage
    {
        private ChromeDriver chromeDriver;
        public MacroPage(ChromeDriver driver) => chromeDriver = driver;

        private IWebElement CreateYourOwnTab => chromeDriver.FindElementByXPath("//td[contains(text(),'Create Your Own')]");
        private IWebElement ProteinSlider => chromeDriver.FindElementById("proteinrange");
        private IWebElement ProteinValue => chromeDriver.FindElementById("resultprotein");
        public void NavigateToMakeYourOwn()
        {
            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            CreateYourOwnTab.Click();
        }

        public void SelectMinimumProtein()
        {
            int proteinValue = Int32.Parse(ProteinSlider.GetAttribute("value"));
            Actions action = new Actions(chromeDriver);
            //action.ClickAndHold(ProteinSlider);
            action.DragAndDropToOffset(ProteinSlider, -proteinValue, 0).Perform();
            action.Release().Build();
        }

        internal bool IsProteinValue(int p0)
        {
            return Int32.Parse(ProteinValue.Text) == p0;
        }

        internal void SelectMaximumProtein()
        {
            int proteinValue = Int32.Parse(ProteinSlider.GetAttribute("value"));
            int proteinMaxValue = Decimal.ToInt32(decimal.Parse(ProteinSlider.GetAttribute("max")));
            Actions action = new Actions(chromeDriver);
            //action.ClickAndHold(ProteinSlider);
            action.DragAndDropToOffset(ProteinSlider, proteinMaxValue, 0).Perform();
            action.Release().Build();
        }
    }
}
