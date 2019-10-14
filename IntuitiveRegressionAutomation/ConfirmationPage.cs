using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace IntuitiveRegressionAutomation
{
    internal class ConfirmationPage : BasePage
    {
        //constructor
        public ConfirmationPage(IWebDriver driver) : base(driver, 
            title: "ivector : call centre - confirmation") { }

        //properties
        public IWebElement TermsAndConditionsBox => Driver.FindElement(By.Id("chkConfirm"));

        public IWebElement SaveAndConfirmButton => Driver.FindElement(By.Id("btnSaveAndConfirm"));

        //method
        internal PassengersPage ConfirmAndSubmit()
        {
            if (IsVisible)
            {
                TermsAndConditionsBox.Click();
                SaveAndConfirmButton.Click();
                return new PassengersPage(Driver);
            }
            else
            {
                Console.WriteLine($"Confirmation Page is not visible. Expected: {PageTitle}, " +
                    $"Actual: {Driver.Title}");
                return null;
            }
        }
    }
}