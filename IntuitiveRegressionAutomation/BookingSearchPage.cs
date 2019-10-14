using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace IntuitiveRegressionAutomation
{
    internal class BookingSearchPage : BasePage
    {
        //constructor
        public BookingSearchPage(IWebDriver driver) : base(driver, 
            title: "ivector : call centre - booking search") { }

        //properties
        public IWebElement HotelSelector => Driver.FindElement(By.Id("radHotel"));

        public IWebElement HotelNameField => Driver.FindElement(By.Id("acpProperty"));

        public SelectElement ArrivalMonthSelector => new SelectElement(Driver.FindElement(By.Id("calArrivalDate_MonthYear")));

        public SelectElement ArrivalDaySelector => new SelectElement(Driver.FindElement(By.Id("calArrivalDate_Day")));

        public SelectElement DurationSelector => new SelectElement(Driver.FindElement(By.Id("ddlDuration")));

        public SelectElement NumberOfRoomsSelector => new SelectElement(Driver.FindElement(By.Id("ddlRooms")));

        public SelectElement NumberOfAdultsSelector => new SelectElement(Driver.FindElement(By.Id("ddlRoom1Adults")));

        public SelectElement NumberOfChildrenSelector => new SelectElement(Driver.FindElement(By.Id("ddlRoom1Children")));

        public SelectElement NumberOfInfantsSelector => new SelectElement(Driver.FindElement(By.Id("ddlRoom1Infants")));

        public IWebElement AllPropertySourceCheckBox => Driver.FindElement(By.Id("cdlPropertySuppliersSelectAll"));

        public IWebElement OwnPropertyCheckBox => Driver.FindElement(By.Id("cdlPropertySupplierschk1"));

        public IWebElement SearchButton => Driver.FindElement(By.Id("btnSearch"));

        public IWebElement HotelNameContainer => Driver.FindElement(By.Id("acpPropertyContainer"));

        public WebDriverWait Wait => new WebDriverWait(Driver, TimeSpan.FromSeconds(5));

        public By ResultHolder => By.Id("divResultsHolder");

        //methods
        internal SearchResultPage FillOutFormAndSubmit(BookingConfiguration bookingConfig)
        {
            if (IsVisible)
            {
                //choose type of booking
                SetBookingType(bookingConfig);
                //hotel name
                HotelNameField.SendKeys(bookingConfig.HotelName);
                Wait.Until(ExpectedConditions.ElementToBeClickable(HotelNameContainer));
                HotelNameField.SendKeys(Keys.Enter);
                //date of arrival and duration
                ArrivalMonthSelector.SelectByText(bookingConfig.ArrivalMonth);
                ArrivalDaySelector.SelectByText(bookingConfig.ArrivalDay);
                DurationSelector.SelectByText(bookingConfig.Duration);
                //guest configuration settings
                NumberOfRoomsSelector.SelectByText(bookingConfig.NumberOfRooms.ToString());
                NumberOfAdultsSelector.SelectByText(bookingConfig.NumberOfAdultsRoom1.ToString());
                NumberOfChildrenSelector.SelectByText(bookingConfig.NumberOfChildrenRoom1.ToString());
                NumberOfInfantsSelector.SelectByText(bookingConfig.NumberOfInfantsRoom1.ToString());
                //property source setting
                AllPropertySourceCheckBox.Click();
                OwnPropertyCheckBox.Click();
                //submit search
                SearchButton.Click();
                Wait.Until(ExpectedConditions.ElementIsVisible(ResultHolder));
                return new SearchResultPage(Driver);
            }
            else
            {
                Console.WriteLine($"Booking Search page is not visible. Expected: {PageTitle}, " +
                    $"Actual: {Driver.Title}");
                return null;
            }
        }

        private void SetBookingType(BookingConfiguration bookingConfig)
        {
            switch (bookingConfig.BookType)
            {
                case BookingType.FlightAndHotel:
                    break;
                case BookingType.Flight:
                    break;
                case BookingType.Hotel:
                    HotelSelector.Click();
                    break;
                case BookingType.Transfer:
                    break;
                case BookingType.Extra:
                    break;
                case BookingType.CarHire:
                    break;
                case BookingType.AdHocProperty:
                    break;
                default:
                    break;
            }
        }
    }
}