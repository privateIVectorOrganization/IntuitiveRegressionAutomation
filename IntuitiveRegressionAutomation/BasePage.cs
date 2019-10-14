using OpenQA.Selenium;
using System;
namespace IntuitiveRegressionAutomation
{
    internal class BasePage
    {
        //constructor
        public BasePage(IWebDriver driver, string title)
        {
            Driver = driver;
            PageTitle = title;
        }

        //properties
        public IWebDriver Driver { get; set; }

        public bool IsVisible
        { get { return Driver.Title.Contains(PageTitle); }
            set { } }

        public string PageTitle { get; private set; }
    }
}