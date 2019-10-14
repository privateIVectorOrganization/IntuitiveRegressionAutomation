namespace IntuitiveRegressionAutomation
{
    internal class TestUser
    {
        //constructor
        public TestUser(string username, string password)
        {
            UserName = username;
            Password = password;
        }

        //properties
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}