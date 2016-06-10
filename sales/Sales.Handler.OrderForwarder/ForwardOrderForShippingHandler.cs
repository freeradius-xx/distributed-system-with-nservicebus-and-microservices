using System;
using NServiceBus;
using Sales.Entities;
using Sales.Repository;
using Shared.Commands;
using Shared.Events;
using Shared.ViewModels;

namespace Sales.Handler.OrderForwarder
{
    public class ForwardOrderForShippingHandler : IHandleMessages<ForwardOrderForShippingCommand>
    {
        #region Fields

        private readonly IBus _bus;
        private readonly OrderSalesRepository _repository;

        #endregion

        #region C-Tor

        public ForwardOrderForShippingHandler(IBus bus)
        {
            this._bus = bus;
            this._repository = new OrderSalesRepository();
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

            // save the current state
            this._repository.SaveState(
                new SalesOrderData
                {
                    OrderState = OrderState.AcceptedBySales,
                    OrderId = message.OrderId
                });

            this._bus.Publish<OrderAcceptedEvent>(
                e =>
                {
                    e.OrderId = message.OrderId;
                    e.State = OrderState.AcceptedBySales;
                });
        }

        #endregion
    }
}
