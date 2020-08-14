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

        private IWebElement ErrorMessage => chromeDriver.FindElementByXPath("//*[@id=\"content\"]/div[2]/font");
        private string getDay (DateTime date)
        {
            return date.Day.ToString();
        }
        private string getMonth (DateTime date)
        {
            return date.ToString("MMM");
        }

        private string getYear (DateTime date)
        {
            return date.Year.ToString();
        }

        public void EnterBirthDay(DateTime date)
        {
            BirthDay.SelectByText(getDay(date));
            BirthMonth.SelectByText(getMonth(date));
            string initValue = BirthYear.GetAttribute("value");
            BirthYear.SendKeys(Keys.Backspace + Keys.Backspace + Keys.Backspace + Keys.Backspace + getYear(date));
        }

        internal void EnterCurrrentDate(DateTime date)
        {
            CurrentDate.SelectByText(getDay(date));
            CurrentMonth.SelectByText(getMonth(date));
            string initValue = CurrentYear.GetAttribute("value");
            CurrentYear.SendKeys(Keys.Backspace + Keys.Backspace + Keys.Backspace + Keys.Backspace + getYear(date));

        }

        internal bool? IsAgeCorrect(string age)
        {
            return Age.Text.Contains(age);
        }

        internal bool? ContainsErrorMessage(string message)
        {
            return ErrorMessage.Text.Equals(message);
        }
    }
}
