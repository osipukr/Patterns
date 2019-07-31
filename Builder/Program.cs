using System;
using Builder.Builders;

namespace Builder
{
    public sealed class Program
    {
        public static void Main()
        {
            var personBuilder = new PersonBuilder();
            var person = personBuilder
                .Lives.In("London")
                      .At("London Road")
                .Works.At("Adidas")
                      .AsA("Manager")
                .Build();

            Console.WriteLine(person);
        }
    }
}