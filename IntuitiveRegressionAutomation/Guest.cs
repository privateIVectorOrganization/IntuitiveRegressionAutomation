namespace IntuitiveRegressionAutomation
{
    internal class Guest
    {
        //constructor
        public Guest(string title, string firstName, string lastName, string dateOfBirth)
        {
            Title = title;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = dateOfBirth;
        }

        //properties
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
    }
}