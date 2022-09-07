using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace TestTasks.Pages
{
    public class HomePage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//input[@type = 'search']")]
        private IWebElement searchField;

        [FindsBy(How = How.XPath, Using = "//div[@class = 'xp__button']")]
        private IWebElement searchButton;

        [FindsBy(How = How.XPath, Using = "//div[@class = 'xp__dates-inner']")]
        private IWebElement dateFieldButton;

        [FindsBy(How = How.XPath, Using = "//button[@data-modal-id = 'language-selection']")]
        private IWebElement changeLanguageButton;

        [FindsBy(How = How.XPath, Using = "//div[@data-bui-ref = 'calendar-next']")]
        private IWebElement calendarNextButton;

        [FindsBy(How = How.XPath, Using = "//label[@id = 'xp__guests__toggle']")]
        private IWebElement roomsAndOccupancy;

        public HomePage(WebDriver driver) : base(driver) { }

        public void OpenPage(String url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void ClickRoomsAndOccupancy()
        {
            roomsAndOccupancy.Click();
        }

        public void AddOrMinusAdditinalOptions(string increaseOrDecrease, string whatToChange)
        {
            driver.FindElement(By.XPath($"//button[@aria-label = '{increaseOrDecrease} number of {whatToChange}']")).Click(); //Increase or Decrease, Adults or Children or Rooms
        }

        public void SelectAgeOfTheChild(string age)
        {
            SelectElement dropDown = new SelectElement(driver.FindElement(By.XPath("//select[@name = 'age']")));
            dropDown.SelectByValue(age);
        }

        public void ChangeLanguage(string language)
        {
            changeLanguageButton.Click();
            driver.FindElement(By.XPath($"//div[contains(text(), '{language}')]")).Click();
        }

        public void EnterSearchCity(string cityName)
        {
            searchField.SendKeys(cityName);
        }

        public void CLickSubmitButton()
        {
            searchButton.Click();
        }

        public void ClickDateFieldButton()
        {
            dateFieldButton.Click();
        }

        public void ClickNextCalendarButton()
        {
            calendarNextButton.Click();
        }

        public void EnterDates(string checkInDate, string checkOutDate) 
        {
            driver.FindElement(By.XPath($"//span[@aria-label = '{checkInDate}']")).Click();
            driver.FindElement(By.XPath($"//span[@aria-label = '{checkOutDate}']")).Click();
        }
    }
}
