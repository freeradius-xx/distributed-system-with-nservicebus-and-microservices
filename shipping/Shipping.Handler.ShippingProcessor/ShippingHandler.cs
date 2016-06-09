using System;
using NServiceBus;
using Shared.Commands;
using Shared.Events;
using Shared.ViewModels;
using Shipping.Entities;
using Shipping.Repository;

namespace Shipping.Handler.ShippingProcessor
{
    public class ShippingHandler : IHandleMessages<ShippOrderCommand>
    {
        #region Fields

        private readonly IBus _bus;
        private readonly ShippingOrderRepository _repository;

        #endregion

        #region C-Tor

        public ShippingHandler(IBus bus)
        {
            this._bus = bus;
            this._repository = new ShippingOrderRepository();
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

            this._repository.SaveState(
                new ShippingOrderData
                {
                    OrderState = message.State,
                    OrderId = message.OrderId
                });

            this._bus.Publish<OrderShippedEvent>(
                e =>
                {
                    e.OrderId = message.OrderId;
                    e.State = OrderState.Shipped;
                });
        }

        #endregion
    }
}
