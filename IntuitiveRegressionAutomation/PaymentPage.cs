using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace IntuitiveRegressionAutomation
{
    internal class PaymentPage : BasePage
    {
        //constructor
        public PaymentPage(IWebDriver driver) : base(driver,
            title: "ivector : call centre - payment") { }

        //properties
        public IWebElement CardHolderNameField => Driver.FindElement(By.Id("txtCCCardHoldersName"));

        public SelectElement CardTypeSelector => new SelectElement(Driver.FindElement(By.Id("ddlCCCardTypeID")));

        public WebDriverWait Wait => new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

        public IWebElement CardNumberField => Driver.FindElement(By.Id("txtCCCardNumber"));

        public IWebElement SecurityCodeField => Driver.FindElement(By.Id("txtCCSecurityCode"));

        public SelectElement ExpiryMonthSelector => new SelectElement(Driver.FindElement(By.Id("ddlCCExpireMonth")));

        public SelectElement ExpiryYearSelector => new SelectElement(Driver.FindElement(By.Id("ddlCCExpireYear")));

        public IWebElement WholeAmountPaymentSelector => Driver.FindElement(By.Id("radBalance"));

        public IWebElement BillingStreetAddressField => Driver.FindElement(By.Id("txtCCBillingAddress1"));

        public IWebElement BillingTownCityField => Driver.FindElement(By.Id("txtCCBillingTownCity"));

        public SelectElement BillingCountrySelector => new SelectElement(Driver.FindElement(By.Id("addCCBillingBookingCountryID")));

        public IWebElement PaymentButton => Driver.FindElement(By.Id("btnMakePayment"));

        public IWebElement BookingDetails => Driver.FindElement(By.Id("aBookingDetails"));

        public By BookingContainer => By.Id("hldBooking");

        internal BookingMenuPage FillOutFormAndSubmit(CreditCard card)
        {
            if (IsVisible)
            {
                //Holder name, card type
                CardHolderNameField.SendKeys(card.HolderName);
                CardTypeSelector.SelectByText(card.Type);
                Wait.Until(ExpectedConditions.ElementToBeClickable(CardNumberField));
                //Card number, security code, expiry month and year, whole amount selector
                CardNumberField.SendKeys(card.CardNumber);
                SecurityCodeField.SendKeys(card.SecurityCode);
                ExpiryMonthSelector.SelectByText(card.ExpiryMonth);
                ExpiryYearSelector.SelectByText(card.ExpiryYear);
                if (card.IsFullAmount)
                {
                    WholeAmountPaymentSelector.Click();
                }
                //billing address
                BillingStreetAddressField.SendKeys(card.StreetAddress);
                BillingTownCityField.SendKeys(card.TownCity);
                BillingCountrySelector.SelectByText(card.Country);
                //submit
                PaymentButton.Click();
                Wait.Until(ExpectedConditions.ElementToBeClickable(BookingDetails));
                BookingDetails.Click();
                Wait.Until(ExpectedConditions.ElementIsVisible(BookingContainer));
                return new BookingMenuPage(Driver);
            }
            else
            {
                Console.WriteLine($"Payment Page is not visible. Expected: {PageTitle}, " +
                    $"Actual: {Driver.Title}");
                return null;
            }
        }
    }
}