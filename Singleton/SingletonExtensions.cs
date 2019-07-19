using System;

namespace Singleton
{
    public static class SingletonExtensions
    {
        public static Singleton Print(this Singleton singleton, Action<string> print)
        {
            print(singleton.ToString());

            return singleton;
        }
    }
}