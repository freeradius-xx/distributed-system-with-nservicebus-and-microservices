using System;
using Microsoft.AspNet.SignalR.Client.Hubs;
using NServiceBus;
using Shared.Events;
using Shared.OrderRepository;

namespace Shipping.Handler.OrderProcessor
{
    public class ProcessOrderHandler : IHandleMessages<OrderAcceptedEvent>
    {
        #region Fields

        private readonly OrderRepository _repository;

        #endregion

        #region C-Tor

        public ProcessOrderHandler()
        {
            this._repository = new OrderRepository();
        }

        #endregion

        #region IHandleMessage implementation

        public void Handle(OrderAcceptedEvent message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine("SHIPPING");
            Console.WriteLine("Order {0} in process...", message.OrderId);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;

            this.NotifyClientAboutOrder(message.OrderId);
        }

        #endregion

        #region Helpers

        private void NotifyClientAboutOrder(Guid orderId)
        {
            var connection = new HubConnection("http://localhost:2222/signalr");
            var hub = connection.CreateHubProxy("ShippingHub");
            connection.Start().Wait();

            hub.Invoke("NewOrder", orderId).Wait();
        }

        #endregion
    }
}
