using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;


namespace IntuitiveRegressionAutomation
{
    internal class PassengersPage : BasePage
    {
        //constructor
        public PassengersPage(IWebDriver driver) : base(driver,
            title: "ivector : call centre - passengers") { }

        //properties
        public Actions Tracker => new Actions(Driver);

        public IWebElement ConfirmationButton => Driver.FindElement(By.Id("btnConfirmBooking"));

        public WebDriverWait Wait => new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

        public By PaymentPanel => (By.Id("btnMakePayment"));

        public By BookingContainer => By.Id("hldBooking");

        public IWebElement BookingDetails => Driver.FindElement(By.Id("aBookingDetails"));

        //method
        internal PaymentPage SubmitConfirmationCardAgent()
        {
            if (IsVisible)
            {
                Confirm();
                Wait.Until(ExpectedConditions.ElementIsVisible(PaymentPanel));
                return new PaymentPage(Driver);
            }
            else
            {
                Console.WriteLine($"Passengers Page is not visible. Expected: {PageTitle}, " +
                    $"Actual: {Driver.Title}");
                return null;
            }
        }



        internal BookingMenuPage SubmitConfirmationInvoice()
        {
            if (IsVisible)
            {
                Confirm();
                Wait.Until(ExpectedConditions.ElementToBeClickable(BookingDetails));
                BookingDetails.Click();
                Wait.Until(ExpectedConditions.ElementIsVisible(BookingContainer));
                return new BookingMenuPage(Driver);
            }
            else
            {
                Console.WriteLine($"Passengers Page is not visible. Expected: {PageTitle}, " +
                    $"Actual: {Driver.Title}");
                return null;
            }
        }

        private void Confirm()
        {
            Tracker.MoveToElement(ConfirmationButton).Perform();
            ConfirmationButton.Click();
        }
    }
}