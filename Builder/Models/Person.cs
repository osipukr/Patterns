namespace Builder.Models
{
    public class Person
    {
        // Address
        public string StreetAddress;
        public string City;

        // Employment
        public string CompanyName;
        public string Position;

        public override string ToString() =>
            $"{nameof(StreetAddress)}: {StreetAddress}\n" +
            $"{nameof(City)}: {City}\n" +
            $"{nameof(CompanyName)}: {CompanyName}\n" +
            $"{nameof(Position)}: {Position}";
    }
}