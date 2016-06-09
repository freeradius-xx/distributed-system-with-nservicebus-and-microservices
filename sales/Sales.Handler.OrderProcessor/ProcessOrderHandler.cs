using System;
using Microsoft.AspNet.SignalR.Client.Hubs;
using NServiceBus;
using Sales.Entities;
using Sales.Repository;
using Shared.Events;

namespace Sales.Handler.OrderProcessor
{
    public class ProcessOrderHandler : IHandleMessages<OrderSentToSalesEvent>
    {
        #region Fields

        private readonly OrderSalesRepository _repository;

        #endregion

        #region C-Tor

        public ProcessOrderHandler()
        {
            this._repository = new OrderSalesRepository();
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

            // save the current state
            this._repository.SaveState(
                new SalesOrderData
                {
                    OrderState = message.State,
                    OrderId = message.OrderId
                });

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
