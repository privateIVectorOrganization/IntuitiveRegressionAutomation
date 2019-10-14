using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace IntuitiveRegressionAutomation
{
    internal class LoginPage : BasePage
    {
        //constructor
        public LoginPage(IWebDriver driver) : base(driver, title: "ivector - login") { }

        //properties
        public IWebElement LoginField => Driver.FindElement(By.Id("txtEmail"));

        public IWebElement PasswordField => Driver.FindElement(By.Id("txtPassword"));

        public IWebElement LoginButton => Driver.FindElement(By.Id("btnLogin"));

        public WebDriverWait Wait => new WebDriverWait(Driver, TimeSpan.FromSeconds(5));

        public By HomePageLink => By.LinkText("Home");

        //methods
        internal void GoTo()
        {
            Driver.Navigate().GoToUrl("http://training.ivector.co.uk");
        }

        internal MainPage FillOutFormAndSubmit(TestUser user)
        {
            if (IsVisible)
            {
                //provide login credentials (email, password), submit data
                LoginField.SendKeys(user.UserName);
                PasswordField.SendKeys(user.Password);
                LoginButton.Click();
                Wait.Until(ExpectedConditions.ElementIsVisible(HomePageLink));
                return new MainPage(Driver);
            }
            else
            {
                Console.WriteLine($"Login page not visible. Expected: {PageTitle}, " +
                    $"Actual: {Driver.Title}");
                return null;
            }
        }
    }
}