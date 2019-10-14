using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace IntuitiveRegressionAutomation
{
    internal class GuestDetailsPage : BasePage
    {

        //constructor
        public GuestDetailsPage(IWebDriver driver) : base(driver, 
            title: "ivector : call centre - guest details") { }

        //properties and field
        private string auditText = "Regression Test Booking";
        public WebDriverWait Wait => new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        public SelectElement LeadGuestTitleSelector => new SelectElement(Driver.FindElement(By.Id("ddlLeadGuestTitleID")));
        public IWebElement LeadGuestFirstNameTextBox => Driver.FindElement(By.Id("txtLeadGuestFirstName"));
        public IWebElement LeadGuestLastNameTextBox => Driver.FindElement(By.Id("txtLeadGuestLastName"));
        public IWebElement LeadGuestPhoneTextBox => Driver.FindElement(By.Id("txtLeadGuestPhone"));
        public IWebElement Guest1Title => Driver.FindElement(By.Id("ddlTitlePaxcon_-1_-1"));
        public IWebElement Guest1FirstName => Driver.FindElement(By.Id("txtFirstNamePaxcon_-1_-1"));
        public IWebElement Guest1LastName => Driver.FindElement(By.Id("txtLastNamePaxcon_-1_-1"));
        public IWebElement Guest1BirthDate => Driver.FindElement(By.Id("dtbDateOfBirthPaxcon_-1_-1"));
        public IWebElement Guest2Title => Driver.FindElement(By.Id("ddlTitlePaxcon_-1_-2"));
        public IWebElement Guest2FirstName => Driver.FindElement(By.Id("txtFirstNamePaxcon_-1_-2"));
        public IWebElement Guest2LastName => Driver.FindElement(By.Id("txtLastNamePaxcon_-1_-2"));
        public IWebElement Guest2BirthDate => Driver.FindElement(By.Id("dtbDateOfBirthPaxcon_-1_-2"));
        public IWebElement ContinueButton => Driver.FindElement(By.Id("btnContinue"));
        public IWebElement AuditNotePopUp => Driver.FindElement(By.Id("h3mdlAuditNotes"));
        public IWebElement AuditNoteTextBox => Driver.FindElement(By.Id("txtAuditNotes"));
        public IWebElement AuditNoteConfirmationButton => Driver.FindElement(By.Id("btnAddAuditNote"));
        public IWebElement ConfirmationWindow => Driver.FindElement(By.Id("hldConfirmation"));



        //methods
        internal void FillOutLeadGuestInfo(LeadGuest leadGuest)
        {
            if (IsVisible)
            {
                LeadGuestTitleSelector.SelectByText(leadGuest.Title);
                LeadGuestFirstNameTextBox.SendKeys(leadGuest.FirstName);
                LeadGuestLastNameTextBox.SendKeys(leadGuest.LastName);
                LeadGuestPhoneTextBox.SendKeys(leadGuest.EmergencyPhone);
                Guest1Title.SendKeys(leadGuest.Title);
                Guest1FirstName.SendKeys(leadGuest.FirstName);
                Guest1LastName.SendKeys(leadGuest.LastName);
                Guest1BirthDate.SendKeys(leadGuest.BirthDate);
            }
            else
            {
                Console.WriteLine($"Lead Guest page is not visible. Expected: {PageTitle}, " +
                    $"Actual: {Driver.Title}");
            }
        }

        internal void FillOutGuestInfo(Guest guest)
        {
            Guest2Title.SendKeys(guest.Title);
            Guest2FirstName.SendKeys(guest.FirstName);
            Guest2LastName.SendKeys(guest.LastName);
            Guest2BirthDate.SendKeys(guest.BirthDate);
        }

        internal ConfirmationPage FillAuditNotePopUpWindow()
        {
            ContinueButton.Click();
            Wait.Until(ExpectedConditions.ElementToBeClickable(AuditNotePopUp));
            AuditNoteTextBox.SendKeys(auditText);
            AuditNoteConfirmationButton.Click();
            Wait.Until(ExpectedConditions.ElementToBeClickable(ConfirmationWindow));
            return new ConfirmationPage(Driver);
        }
    }
}