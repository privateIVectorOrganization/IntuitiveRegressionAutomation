using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace IntuitiveRegressionAutomation
{
    internal class OptionsPage : BasePage
    {
        //constructor
        public OptionsPage(IWebDriver driver) : base(driver, 
            title: "ivector : call centre - options") { }
        
        //properties 
        public IWebElement ContinueButton => Driver.FindElement(By.Id("btnContinueBottom"));        
        public WebDriverWait Wait => new WebDriverWait(Driver, TimeSpan.FromSeconds(10));



        //methods
        internal TransfersAndExtrasPage Submit()
        {
            if (IsVisible)
            {
                Wait.Until(ExpectedConditions.ElementToBeClickable(ContinueButton));
                ContinueButton.Click();
                return new TransfersAndExtrasPage(Driver);
            }
            else
            {
                Console.WriteLine($"Options Page is not visible. Expected: {PageTitle}, " +
                    $"Actual: {Driver.Title}");
                return null;
            }
        }

        
    }
}