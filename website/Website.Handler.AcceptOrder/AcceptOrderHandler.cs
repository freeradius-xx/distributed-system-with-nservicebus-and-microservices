using System;
using System.Linq;
using Microsoft.AspNet.SignalR.Client.Hubs;
using NServiceBus;
using Shared.Messages;
using Shared.OrderRepository;
using Shared.ViewModels;

namespace Website.Handler.AcceptOrder
{
    public class AcceptOrderHandler : IHandleMessages<OrderAcceptedMessage>
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

        public void Handle(OrderAcceptedMessage message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine("WEBSITE");
            Console.WriteLine("Order {0} accepted and forwarded for shipping...", message.OrderId);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;

            this.UpdateOrder(message);

            this.NotifyClientAboutOrder(message.OrderId);
        }

        #endregion

        #region Helpers

        private void UpdateOrder(OrderAcceptedMessage message)
        {
            var order = this._repository.GetOrders().ToList().SingleOrDefault(o => o.OrderId == message.OrderId);
            if (order == null) return;
            order.OrderState = OrderState.AcceptedBySales;
            this._repository.Update(order);
        }

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