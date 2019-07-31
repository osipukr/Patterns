using System;

namespace Adapter
{
    public class Requester
    {
        public void SendRequest(string message) => Console.WriteLine(message);
    }
}