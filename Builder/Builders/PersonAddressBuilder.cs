using Builder.Models;

namespace Builder.Builders
{
    public class PersonAddressBuilder : PersonBuilder
    {
        public PersonAddressBuilder(Person person) => Person = person;

        public PersonAddressBuilder At(string street)
        {
            Person.StreetAddress = street;

            return this;
        }

        public PersonAddressBuilder In(string city)
        {
            Person.City = city;

            return this;
        }
    }
}