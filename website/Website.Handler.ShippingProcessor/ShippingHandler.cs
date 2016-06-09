using System;
using System.Linq;
using Microsoft.AspNet.SignalR.Client.Hubs;
using NServiceBus;
using Shared.Messages;
using Shared.OrderRepository;
using Shared.ViewModels;

namespace Website.Handler.ShippingProcessor
{
    public class ShippingHandler : IHandleMessages<OrderShippedMessage>
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

        public void Handle(OrderShippedMessage message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine("WEBSITE");
            Console.WriteLine("Order {0} shipped...", message.OrderId);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;

            this.UpdateOrder(message);

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

        private void UpdateOrder(OrderShippedMessage message)
        {
            var order = this._repository.GetOrders().ToList().SingleOrDefault(o => o.OrderId == message.OrderId);
            if (order == null) return;
            order.OrderState = OrderState.Shipped;
            this._repository.Update(order);
        }

        #endregion
    }
}
