using OpenQA.Selenium;

namespace IntuitiveRegressionAutomation
{
    internal class BookingMenuPage : BasePage
    {
        public BookingMenuPage(IWebDriver driver) : base(driver, 
            title: "ivector : call centre - booking details") { }
    }
}