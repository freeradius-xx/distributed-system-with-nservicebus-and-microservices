using System;
using Microsoft.AspNet.SignalR.Client.Hubs;
using NServiceBus;
using Shared.Events;
using Shipping.Entities;
using Shipping.Repository;

namespace Shipping.Handler.OrderProcessor
{
    public class ProcessOrderHandler : IHandleMessages<OrderAcceptedEvent>
    {
        #region Fields

        private readonly ShippingOrderRepository _repository;

        #endregion

        #region C-Tor

        public ProcessOrderHandler()
        {
            this._repository = new ShippingOrderRepository();
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

            this._repository.SaveState(
                new ShippingOrderData
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
            var connection = new HubConnection("http://localhost:2222/signalr");
            var hub = connection.CreateHubProxy("ShippingHub");
            connection.Start().Wait();

            hub.Invoke("NewOrder", orderId).Wait();
        }

        #endregion
    }
}
