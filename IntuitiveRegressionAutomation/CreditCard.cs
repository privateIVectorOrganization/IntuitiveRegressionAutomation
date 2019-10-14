namespace IntuitiveRegressionAutomation
{
    internal class CreditCard
    {
        //constructor
        public CreditCard(string cardHolder, string type, string cardNumber, string securityCode,
            string expiryMonth, string expiryYear, bool isFullAmount, string address, string townCity,
            string country)
        {
            HolderName = cardHolder;
            Type = type;
            CardNumber = cardNumber;
            SecurityCode = securityCode;
            ExpiryMonth = expiryMonth;
            ExpiryYear = expiryYear;
            IsFullAmount = isFullAmount;
            StreetAddress = address;
            TownCity = townCity;
            Country = country;
        }

        //properties
        public string HolderName { get; set; }
        public string Type { get; set; }
        public string CardNumber { get; set; }
        public string SecurityCode { get; set; }
        public string ExpiryMonth { get; set; }
        public string ExpiryYear { get; set; }
        public bool IsFullAmount { get; set; }
        public string StreetAddress { get; set; }
        public string TownCity { get; set; }
        public string Country { get; set; }
    }
}