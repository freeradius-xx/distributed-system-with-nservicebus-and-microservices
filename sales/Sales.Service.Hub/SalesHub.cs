namespace Sales.Service.Hub
{
    public class SalesHub : Microsoft.AspNet.SignalR.Hub
    {
        public void NewOrder(string order)
        {
            Clients.All.incomingOrder(order);
        }

        public void Test(string message)
        {
            Clients.All.test(message);
        }
    }
}
