using Builder.Models;

namespace Builder.Builders
{
    public class PersonJobBuilder : PersonBuilder
    {
        public PersonJobBuilder(Person person) => Person = person;

        public PersonJobBuilder At(string company)
        {
            Person.CompanyName = company;

            return this;
        }

        public PersonJobBuilder AsA(string position)
        {
            Person.Position = position;

            return this;
        }
    }
}