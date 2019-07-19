using System;

namespace Singleton
{
    public class Singleton
    {
        private static readonly Lazy<Singleton> Lazy = new Lazy<Singleton>(() => new Singleton());

        public string Value { get; private set; }

        private Singleton() => Value = Guid.NewGuid().ToString();

        public static Singleton Create() => Lazy.Value;

        public override string ToString() => Value;
    }
}