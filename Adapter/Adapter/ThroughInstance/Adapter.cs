namespace Adapter.Adapter.ThroughInstance
{
    public class Adapter : ISender
    {
        private readonly Requester _requester = new Requester();

        public void Send(string message) => _requester.SendRequest(message);
    }
}