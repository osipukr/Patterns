using Builder.Models;

namespace Builder.Builders
{
    public class PersonBuilder
    {
        protected Person Person = new Person();

        public PersonAddressBuilder Lives => new PersonAddressBuilder(Person);
        public PersonJobBuilder Works => new PersonJobBuilder(Person);

        public Person Build() => Person;
    }
}