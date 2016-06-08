namespace Shipping.Service.Hub
{
    public class ShippingHub : Microsoft.AspNet.SignalR.Hub
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
