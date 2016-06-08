using System;
using Microsoft.AspNet.SignalR.Client.Hubs;
using NServiceBus;
using Shared.Events;
using Shared.OrderRepository;

namespace Website.Handler.AcceptOrder
{
    public class AcceptOrderHandler : IHandleMessages<OrderAcceptedEvent>
    {
        #region Fields

        private readonly OrderRepository _repository;

        #endregion

        #region C-Tor

        public AcceptOrderHandler()
        {
            this._repository = new OrderRepository();
        }

        #endregion

        #region IHandleMessage implementation

        public void Handle(OrderAcceptedEvent message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine("WEBSITE");
            Console.WriteLine("Order {0} accepted and forwarded for shipping...", message.OrderId);
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

            hub.Invoke("OrderAccepted", orderId).Wait();
        }

        #endregion
    }
}