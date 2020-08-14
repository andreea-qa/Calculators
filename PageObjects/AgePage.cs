using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace Calculators.PageObjects
{
    class AgePage
    {
        private ChromeDriver chromeDriver;
        public AgePage(ChromeDriver driver) => chromeDriver = driver;
        private SelectElement BirthDay => new SelectElement(chromeDriver.FindElementById("today_Day_ID"));
        private SelectElement BirthMonth => new SelectElement(chromeDriver.FindElementById("today_Month_ID"));
        private IWebElement BirthYear => chromeDriver.FindElementById("today_Year_ID");
        private SelectElement CurrentDate => new SelectElement(chromeDriver.FindElementById("ageat_Day_ID"));
        private SelectElement CurrentMonth => new SelectElement(chromeDriver.FindElementById("ageat_Month_ID"));
        private IWebElement CurrentYear => chromeDriver.FindElementById("ageat_Year_ID");
        private IWebElement Age => chromeDriver.FindElementByClassName("verybigtext");

       
        public void EnterBirthDay(DateTime date)
        {
            BirthDay.SelectByText(date.Day.ToString());
            BirthMonth.SelectByText(date.ToString("MMM"));
            string initValue = BirthYear.GetAttribute("value");
            BirthYear.SendKeys(Keys.Backspace + Keys.Backspace + Keys.Backspace + Keys.Backspace + date.Year.ToString());
        }

        internal void EnterCurrrentDate(DateTime date)
        {
            CurrentDate.SelectByText(date.Day.ToString());
            CurrentMonth.SelectByText(date.ToString("MMM"));
            string initValue = CurrentYear.GetAttribute("value");
            CurrentYear.SendKeys(Keys.Backspace + Keys.Backspace + Keys.Backspace + Keys.Backspace + date.Year.ToString());

        }

        internal bool IsAgeCorrect(string age)
        {
            return Age.Text.Contains(age);
        }
    }
}
