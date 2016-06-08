using System;
using Microsoft.AspNet.SignalR.Client.Hubs;
using NServiceBus;
using Shared.Events;
using Shared.OrderRepository;

namespace Sales.Handler.OrderProcessor
{
    public class ProcessOrderHandler : IHandleMessages<OrderSentToSalesEvent>
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

        public void Handle(OrderSentToSalesEvent message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine("SALES");
            Console.WriteLine("Order {0} in process...", message.OrderId);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;

            this.NotifyClientAboutOrder(message.OrderId);
        }

        #endregion

        #region Helpers

        private void NotifyClientAboutOrder(Guid orderId)
        {
            var connection = new HubConnection("http://localhost:1111/signalr");
            var hub = connection.CreateHubProxy("SalesHub");
            connection.Start().Wait();

            hub.Invoke("NewOrder", orderId).Wait();
        }

        #endregion
    }
}
