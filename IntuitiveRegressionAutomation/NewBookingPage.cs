using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace IntuitiveRegressionAutomation
{
    internal class NewBookingPage : BasePage
    {
        //constructor
        public NewBookingPage(IWebDriver driver) : base(driver, 
            title: "ivector : call centre - new booking") { }

        //properties
        public WebDriverWait Wait => new WebDriverWait(Driver, TimeSpan.FromSeconds(5));

        public IWebElement TradeSearchField => Driver.FindElement(By.Id("txtTradeSearch"));

        public IWebElement TradeSearchButton => Driver.FindElement(By.Id("btnTradeSearch"));

        public IWebElement TraderSelector => Driver.FindElement(By.Id("lst836_3"));

        public SelectElement ContactPersonSelector => new SelectElement(Driver.FindElement(By.Id("sddTradeContactID")));

        public Actions Tracker => new Actions(Driver);

        public IWebElement ContinueButton => Driver.FindElement(By.Id("btnContinue"));

        //method
        internal BookingSearchPage FillOutFormAndSubmit(TradeMember member)
        {
            if (IsVisible)
            {
                Wait.Until(ExpectedConditions.ElementToBeClickable(TradeSearchField));
                TradeSearchField.SendKeys(member.Name);
                TradeSearchButton.Click();
                TraderSelector.Click();
                ContactPersonSelector.SelectByText(member.ContactPerson);
                Tracker.MoveToElement(ContinueButton).Perform();
                ContinueButton.Click();
                return new BookingSearchPage(Driver);
            }
            else
            {
                Console.WriteLine($"New Booking page is not visible. Expected: {PageTitle}, " +
                    $"Actual: {Driver.Title}");
                return null;
            }
        }
    }
}