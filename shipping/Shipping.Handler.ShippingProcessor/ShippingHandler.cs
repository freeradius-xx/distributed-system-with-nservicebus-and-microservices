using System;
using System.Linq;
using NServiceBus;
using Shared.Commands;
using Shared.Events;
using Shared.OrderRepository;
using Shared.ViewModels;

namespace Shipping.Handler.ShippingProcessor
{
    public class ShippingHandler : IHandleMessages<ShippOrderCommand>
    {
        #region Fields

        private readonly IBus _bus;
        private readonly OrderRepository _repository;

        #endregion

        #region C-Tor

        public ShippingHandler(IBus bus)
        {
            this._bus = bus;
            this._repository = new OrderRepository();
        }

        #endregion

        #region IHandleMessage implementation

        public void Handle(ShippOrderCommand message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine("SHIPPING");
            Console.WriteLine("Order {0} shipped!", message.OrderId);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;

            this.UpdateOrderState(message.OrderId);

            this._bus.Publish<OrderShippedEvent>(
                e =>
                {
                    e.OrderId = message.OrderId;
                    e.State = OrderState.Shipped;
                });
        }

        #endregion

        #region Helpers

        private void UpdateOrderState(Guid orderId)
        {
            var order = this._repository.GetOrders().ToList().SingleOrDefault(o => o.OrderId == orderId);
            if (order == null) return;
            order.OrderState = OrderState.Shipped;
            this._repository.Update(order);
        }

        #endregion
    }
}
