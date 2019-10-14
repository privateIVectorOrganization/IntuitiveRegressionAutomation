using System;
using OpenQA.Selenium;

namespace IntuitiveRegressionAutomation
{
    internal class TransfersAndExtrasPage : BasePage
    {
        //constructor
        public TransfersAndExtrasPage(IWebDriver driver) : base(driver, title: "ivector : call centre - transfers") { }

        //properties
        public IWebElement ContinueButton => Driver.FindElement(By.Id("btnContinue"));

        //method
        internal GuestDetailsPage Submit()
        {
            if (IsVisible)
            {
                ContinueButton.Click();
                return new GuestDetailsPage(Driver);
            }
            else
            {
                Console.WriteLine($"Transfer and Extras Page is not visible. Expected: {PageTitle}, " +
                    $"Actual: {Driver.Title}");
                return null;
            }
        }
    }
}