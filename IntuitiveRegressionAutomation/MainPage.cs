using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace IntuitiveRegressionAutomation
{
    internal class MainPage : BasePage
    {
        //constructor
        public MainPage(IWebDriver driver) : base(driver, title: "ivector - home page") { }
       
        //properties
        public Actions HoverHelper => new Actions(Driver);

        public IWebElement CallCenterText => Driver.FindElement(By.LinkText("Call Centre"));

        public WebDriverWait Wait => new WebDriverWait(Driver, TimeSpan.FromSeconds(5));

        public IWebElement AddBookingText => Driver.FindElement(By.LinkText("Add Booking"));

        //methods
        public NewBookingPage NavigateToSearch()
        {
            if (IsVisible)
            {
                //Hover over Call Center, select Add booking from the menu to navigate to the New Booking page
                HoverHelper.MoveToElement(CallCenterText).Perform();
                Wait.Until(ExpectedConditions.ElementToBeClickable(AddBookingText));
                AddBookingText.Click();
                return new NewBookingPage(Driver);
            }
            else
            {
                Console.WriteLine($"Main page is not visible. Expected: {PageTitle}, " +
                    $"Actual: {Driver.Title}");
                return null;
            }
        }
    }
}