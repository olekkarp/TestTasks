using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestTasks.Tests
{
    [TestClass]
    public class Tests : BaseTest
    {
        [TestMethod]
        public void Scenario1()
        {
            GetHomePage().WaitForPageLoadComplate(20);
            GetHomePage().ChangeLanguage("English (UK)");
            GetHomePage().WaitForPageLoadComplate(20);
            GetHomePage().EnterSearchCity("New York");

            GetHomePage().ClickDateFieldButton();
            GetHomePage().ClickNextCalendarButton();
            GetHomePage().ClickNextCalendarButton();
            GetHomePage().EnterDates("1 December 2022", "31 December 2022"); //Date have to be this form "Day Month Year"

            GetHomePage().CLickSubmitButton();
            GetHomePage().WaitForPageLoadComplate(20);

            foreach (var address in GetSearchResultPage().GetListOFHotelsAddresses())
            {
                Assert.IsTrue(address.Text.Contains("New York"));
            }

            Assert.IsTrue(GetSearchResultPage().GetDateTextFromSearchResult("start").Contains("1 December")); //there should be end or start
            Assert.IsTrue(GetSearchResultPage().GetDateTextFromSearchResult("end").Contains("31 December")); //there should be end or start
        }

        [TestMethod]
        public void Scenario2()
        {
            GetHomePage().WaitForPageLoadComplate(20);
            GetHomePage().ChangeLanguage("English (UK)");
            GetHomePage().WaitForPageLoadComplate(20);

            GetHomePage().EnterSearchCity("Kyiv");

            GetHomePage().ClickDateFieldButton();
            GetHomePage().EnterDates("15 September 2022", "25 September 2022");

            GetHomePage().ClickRoomsAndOccupancy();
            GetHomePage().AddOrMinusAdditinalOptions("Increase", "Adults");
            GetHomePage().AddOrMinusAdditinalOptions("Increase", "Adults");
            GetHomePage().AddOrMinusAdditinalOptions("Increase", "Rooms");
            GetHomePage().AddOrMinusAdditinalOptions("Decrease", "Adults");
            GetHomePage().AddOrMinusAdditinalOptions("Increase", "Children");
            GetHomePage().SelectAgeOfTheChild("10");

            GetHomePage().CLickSubmitButton();
            GetHomePage().WaitForPageLoadComplate(20);

            Assert.IsTrue(GetSearchResultPage().GetOccupancyConfigResult().Contains("3 adults · 1 child · 2 rooms"));
            foreach (var item in GetSearchResultPage().GetListConfigForEachItem())
            {
                var kek = item.Text;
                Assert.IsTrue(item.Text.Contains("10 nights, 3 adults, 1 child"));
            }
        }
    }
}
