using System;
using System.Linq;
using NServiceBus;
using Shared.Commands;
using Shared.Events;
using Shared.OrderRepository;
using Shared.ViewModels;

namespace Sales.Handler.OrderForwarder
{
    public class ForwardOrderForShippingHandler : IHandleMessages<ForwardOrderForShippingCommand>
    {
        #region Fields

        private readonly IBus _bus;
        private readonly OrderRepository _repository;

        #endregion

        #region C-Tor

        public ForwardOrderForShippingHandler(IBus bus)
        {
            this._bus = bus;
            this._repository = new OrderRepository();
        }

        #endregion

        #region IHandleMessage implementation

        public void Handle(ForwardOrderForShippingCommand message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine("SALES");
            Console.WriteLine("Order {0} forwarded for shipping...", message.OrderId);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;

            this.UpdateOrderState(message.OrderId);

            this._bus.Publish<OrderAcceptedEvent>(
                e =>
                {
                    e.OrderId = message.OrderId;
                    e.State = OrderState.AcceptedBySales;
                });
        }

        #endregion

        #region Helpers

        private void UpdateOrderState(Guid orderId)
        {
            var order = this._repository.GetOrders().ToList().SingleOrDefault(o => o.OrderId == orderId);
            if (order == null) return;
            order.OrderState = OrderState.AcceptedBySales;
            this._repository.Update(order);
        }

        #endregion
    }
}
