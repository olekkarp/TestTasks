using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestTasks.Pages;

namespace TestTasks.Tests
{
    public class BaseTest
    {
        private WebDriver driver;
        private static readonly String url = "https://www.booking.com";

        [TestInitialize()]
        public void StartChrome()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
        }

        [TestCleanup()]
        public void CloseChrome()
        {
            driver.Close();
        }

        public WebDriver GetDriver() { return driver; }

        public HomePage GetHomePage() { return new HomePage(GetDriver()); }

        public SearchResultPage GetSearchResultPage() { return new SearchResultPage(GetDriver()); }
    }
}
