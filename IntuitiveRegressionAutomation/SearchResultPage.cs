using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace IntuitiveRegressionAutomation
{
    internal class SearchResultPage : BasePage
    {
        //constructor
        public SearchResultPage(IWebDriver driver) : base(driver, 
            title: "ivector : call centre - results") { }

        //properties
        public WebDriverWait Wait => new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

        public IWebElement BookButton => Driver.FindElement(By.ClassName("book"));

        public By OptionsPanel => By.Id("hldOptions");

        //method
        internal OptionsPage SelectRoomAndSubmit()
        {
            if (IsVisible)
            {
                Wait.Until(ExpectedConditions.ElementToBeClickable(BookButton));
                BookButton.Click();
                Wait.Until(ExpectedConditions.ElementIsVisible(OptionsPanel));
                return new OptionsPage(Driver);
            }
            else
            {
                Console.WriteLine($"Search Result page not visible. Expected: {PageTitle}, " +
                    $"Actual: {Driver.Title}");
                return null;
            }
        }
    }
}