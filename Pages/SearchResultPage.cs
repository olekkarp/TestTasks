using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace TestTasks.Pages
{
    public class SearchResultPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//div[@data-testid = 'location']//span[contains(text(), 'New York')]")]
        private IList<IWebElement> addressesOfHotelsList;

        [FindsBy(How = How.XPath, Using = "//button[@data-testid = 'occupancy-config']")]
        private IWebElement occupancyConfig;


        [FindsBy(How = How.XPath, Using = "//div[@data-testid = 'price-for-x-nights']")]
        private IList<IWebElement> configForEachItem;

        public SearchResultPage(WebDriver driver) : base(driver) { }

        public IList<IWebElement> GetListOFHotelsAddresses()
        {
            return addressesOfHotelsList;
        }

        public IList<IWebElement> GetListConfigForEachItem()
        {
            return configForEachItem;
        }

        public string GetOccupancyConfigResult()
        {
            return occupancyConfig.Text;
        }

        public string GetDateTextFromSearchResult(string str)
        {
            return driver.FindElement(By.XPath($"//button[@data-testid = 'date-display-field-{str}']")).Text;
        }
    }
}
