namespace IntuitiveRegressionAutomation
{
    internal class LeadGuest : Guest
    {
        //constructor
        public LeadGuest(string title, string firstName, string lastName, string dateOfBirth, 
            string emergencyPhone)  : base(title, firstName, lastName, dateOfBirth)
        {
            EmergencyPhone = emergencyPhone;
        }

        //property
        public string EmergencyPhone { get; set; }
    }
}