namespace Website.Service.Hub
{
    public class WebsiteHub : Microsoft.AspNet.SignalR.Hub
    {
        public void Test(string message)
        {
            Clients.All.test(message);
        }

        public void OrderShipped(string orderId)
        {
            Clients.All.orderStateChanged(orderId, "SHIPPED");
        }

        public void OrderAccepted(string orderId)
        {
            Clients.All.orderStateChanged(orderId, "ACCEPTED");
        }
    }
}
