namespace IntuitiveRegressionAutomation
{
    internal class BookingConfiguration
    {
        //constructor
        public BookingConfiguration(BookingType booktype, string hotelName, string arrivalMonth, string arrivalDay, string duration, 
            int numberOfRooms, int room1Adults, int room1Children, int room1Infants, PropertySource source)
        {
            BookType = booktype;
            HotelName = hotelName;
            ArrivalMonth = arrivalMonth;
            ArrivalDay = arrivalDay;
            Duration = duration;
            NumberOfRooms = numberOfRooms;
            NumberOfAdultsRoom1 = room1Adults;
            NumberOfChildrenRoom1 = room1Children;
            NumberOfInfantsRoom1 = room1Infants;
            Source = source;
        }

        //properties - Booking Configuration data
        public BookingType BookType { get; set; }
        public string HotelName { get; set; }
        public string ArrivalMonth { get; set; }
        public string ArrivalDay { get; set; }
        public string Duration { get; set; }
        public int NumberOfRooms { get; set; }
        public int NumberOfAdultsRoom1 { get; set; }
        public int NumberOfChildrenRoom1 { get; set; }
        public int NumberOfInfantsRoom1 { get; set; }
        public PropertySource Source { get; set; }
    }
}