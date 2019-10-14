using System;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace IntuitiveRegressionAutomation
{
    [TestFixture]
    [Category("Property Booking")]
    public class PropertyBookingFlowTest
    {
        //properties
        public IWebDriver Driver { get; set; }
        internal TradeMember Member { get; set; }
        internal CreditCard Card { get; set; }
        internal BookingConfiguration BookingConfig { get; set; }

        //methods
        [SetUp]
        public void Setup()
        {
            //provide driver location, maximize window
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            Driver = new ChromeDriver(path);
            Driver.Manage().Window.Maximize();
            //setup credit card
            Card = new CreditCard("Mr Test Test", "Visa", "4444333322221111", "737", "10", "20", true, "20 Test Street", "Budapest", "UK");
        }


        [Test]
        [Description("Make an Own stock booking for 1 adult, 1 night, 1 room, Credit Card payment")]
        [Property("Author", "SandorBucsi")]
        public void TC01_SingleRoomBookingFor1Adult()
        {
            BookingConfig = new BookingConfiguration(BookingType.Hotel, "S02 Test Property (Marbella)", "Nov '19", "15 (Fri)", "1",
                1, 1, 0, 0, PropertySource.Own);
            Member = new TradeMember("Sanyi Test Trade Member", "Sandor Bucsi", PaymentType.Invoice);

            var bookingMenuPage = BookingFlow();
            Assert.IsTrue(bookingMenuPage.IsVisible);
        }

        [Test]
        [Description("Make an Own stock booking for 2 adults, 3 nights, 1 room, Credit Card payment")]
        [Property("Author", "SandorBucsi")]
        public void TC02_SingleRoomBookingFor2Adults()
        {
            //configurations    
            BookingConfig = new BookingConfiguration(BookingType.Hotel, "S02 Test Property (Marbella)", "Nov '19", "27 (Wed)", "3",
                1, 2, 0, 0, PropertySource.Own);
            Member = new TradeMember("Sanyi Test Trade Member", "Sandor Bucsi", PaymentType.CreditCard);

            var bookingMenuPage = BookingFlow();
            Assert.IsTrue(bookingMenuPage.IsVisible);
        }

        private BookingMenuPage BookingFlow()
        {
            BookingSearchPage bookingSearchPage = BeforeSearch();
            OptionsPage optionPage = SearchPhase(bookingSearchPage);
            BookingMenuPage bookingMenuPage = PreBookPhase(optionPage);
            return bookingMenuPage;
        }

        private BookingSearchPage BeforeSearch()
        {
            //navigate Login page, check that it's loaded
            var loginPage = new LoginPage(Driver);
            loginPage.GoTo();

            //fill login credentials, submit data
            TestUser user = new TestUser("Regression@intuitivesystems.co.uk", "Regression");
            var mainPage = loginPage.FillOutFormAndSubmit(user);

            //navigate through main page
            var newBookingPage = mainPage.NavigateToSearch();

            //fill in Trade member data
            var bookingSearchPage = newBookingPage.FillOutFormAndSubmit(Member);
            return bookingSearchPage;
        }


        private OptionsPage SearchPhase(BookingSearchPage bookingSearchPage)
        {
            //fill in the booking search data, navigate to result, then to Option page
            var searchResultPage = bookingSearchPage.FillOutFormAndSubmit(BookingConfig);
            var optionPage = searchResultPage.SelectRoomAndSubmit();
            return optionPage;
        }

        private BookingMenuPage PreBookPhase(OptionsPage optionPage)
        {
            //navigate through Option and TransfersAndExtras pages

            var transfersAndExtrasPage = optionPage.Submit();

            //Filling lead guest and guest data
            var guestDetailsPage = transfersAndExtrasPage.Submit();
            FillGuest(guestDetailsPage, BookingConfig);
            var confirmationPage = guestDetailsPage.FillAuditNotePopUpWindow();

            //Property and Passenger Confirmation
            var passengersPage = confirmationPage.ConfirmAndSubmit();

            
            //in case of Credit Card Agent, a Payment page appears first - otherwise go straight to Booking details
            if (Member.PaymentType == PaymentType.CreditCard)
            {
                //Provide credit card information
                var paymentPage = passengersPage.SubmitConfirmationCardAgent();
                //View the complete booking's detail on the booking menu
                var bookingMenuPage = paymentPage.FillOutFormAndSubmit(Card);
                return bookingMenuPage;
            }
            else
            {
                //View the complete booking's detail on the booking menu
                var bookingMenuPage = passengersPage.SubmitConfirmationInvoice();
                return bookingMenuPage;
            }
        }

        private void FillGuest(GuestDetailsPage guestDetailsPage, BookingConfiguration configuration)
        {
            //Fill out lead guest info (1st room, 1st adult guest - mandatory (TC 01 - 10)
            LeadGuest leadGuest = new LeadGuest("Mr", "Test", "Test", "10 Feb 1979", "37314829992");
            guestDetailsPage.FillOutLeadGuestInfo(leadGuest);
            //Fill out 2nd adult guest information for 1st room, if that guest exists (TC 02 - 05, 07, 09, 10)
            if (configuration.NumberOfAdultsRoom1 >= 2)
            {
                Guest adult2 = new Guest("Mrs", "TBA", "TBA", "24 Jul 1986");
                guestDetailsPage.FillOutGuestInfo(adult2);
                //Fill out 3rd adult guest information for 1st room in case of 3A configuration (TC 07)
                if (configuration.NumberOfAdultsRoom1 == 3)
                {
                    Guest adult3 = new Guest("Mr", "TA", "TA", "11 Oct 1990");
                    
                }
                //Fill out 1st Child data in addition to 2 adults, if child exists (TC 03, 04, 09)
                if (configuration.NumberOfChildrenRoom1 >= 1)
                {
                    Guest child1 = new Guest("Mr", "Child", "Child", "11 Oct 2011");

                    //Fill out 2nd child information for 1st room in case of 2A2C configuration (TC 03)
                    if (configuration.NumberOfChildrenRoom1 == 2)
                    {
                        Guest child2 = new Guest("Mr", "SecChild", "SecChild", "20 Aug 2008");

                    }
                    //Fill out Infant information for 1st room in case of 2A1C1I configuration (TC 04, 09)
                    if (configuration.NumberOfInfantsRoom1 == 1)
                    {
                        Guest infant1 = new Guest("Mr", "Infant", "Infant", "15 Mar 2019");

                    }
                }
            }
            //Fill out Infant data for 1st room in case of 1A1I configuration (TC 08)
            if (configuration.NumberOfAdultsRoom1 == 1 && configuration.NumberOfInfantsRoom1 == 1)
            {
                Guest infant1 = new Guest("Mr", "Infant", "Infant", "15 Mar 2019");

            }
        }

    }
}
