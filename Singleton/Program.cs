using System;
using System.Threading;

namespace Singleton
{
    public class Program
    {
        private const int Count = 10;

        public static void Main()
        {
            for (var i = 0; i < Count; i++)
            {
                new Thread(() => Singleton.Create().Print(Console.WriteLine)).Start();
            }
        }
    }
}