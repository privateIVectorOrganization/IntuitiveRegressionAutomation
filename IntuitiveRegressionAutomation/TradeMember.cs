namespace IntuitiveRegressionAutomation
{
    internal class TradeMember
    {
        //constructor
        public TradeMember(string name, string contact, PaymentType payType)
        {
            Name = name;
            ContactPerson = contact;
            PaymentType = payType;
        }

        //properties
        public string Name { get; set; }
        public string ContactPerson { get; set; }

        public PaymentType PaymentType { get; set; }
    }
}