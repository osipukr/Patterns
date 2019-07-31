namespace Adapter.Adapter.ThroughClass
{
    public class Adapter : Requester, ISender
    {
        public void Send(string message) => SendRequest(message);
    }
}