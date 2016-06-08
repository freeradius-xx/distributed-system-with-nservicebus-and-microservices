using System;
using Microsoft.AspNet.SignalR.Client.Hubs;
using NServiceBus;
using Shared.Events;
using Shared.OrderRepository;

namespace Website.Handler.ShippingProcessor
{
    public class ShippingHandler : IHandleMessages<OrderShippedEvent>
    {
        #region Fields

        private readonly OrderRepository _repository;

        #endregion

        #region C-Tor

        public ShippingHandler()
        {
            this._repository = new OrderRepository();
        }

        #endregion

        #region IHandleMessage implementation

        public void Handle(OrderShippedEvent message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine("WEBSITE");
            Console.WriteLine("Order {0} shipped...", message.OrderId);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;

            this.NotifyClientAboutOrder(message.OrderId);
        }

        #endregion

        #region Helpers

        private void NotifyClientAboutOrder(Guid orderId)
        {
            var connection = new HubConnection("http://localhost:3333/signalr");
            var hub = connection.CreateHubProxy("WebsiteHub");
            connection.Start().Wait();

            hub.Invoke("OrderShipped", orderId).Wait();
        }

        #endregion
    }
}
