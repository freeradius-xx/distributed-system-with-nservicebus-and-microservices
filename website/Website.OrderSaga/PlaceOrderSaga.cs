using System;
using NServiceBus;
using NServiceBus.Saga;
using Shared.Commands;
using Shared.Events;
using Shared.Messages;
using Shared.ViewModels;

namespace Website.OrderSaga
{
    public class PlaceOrderSaga : Saga<PlaceOrderSagaData>,
        IAmStartedByMessages<ProcessOrderCommand>,
        IHandleMessages<OrderAcceptedEvent>,
        IHandleMessages<OrderShippedEvent>
    {
        #region Configure Saga

        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<PlaceOrderSagaData> mapper)
        {
            mapper.ConfigureMapping<ProcessOrderCommand>(o => o.OrderId).ToSaga(s => s.OrderId);
            mapper.ConfigureMapping<OrderAcceptedEvent>(o => o.OrderId).ToSaga(s => s.OrderId);
            mapper.ConfigureMapping<OrderShippedEvent>(o => o.OrderId).ToSaga(s => s.OrderId);
        }

        #endregion

        #region Hndler

        public void Handle(ProcessOrderCommand message)
        {
            Console.WriteLine();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine(DateTime.Now);
            Console.WriteLine("Processing order '{0}' to AcceptOrderHandler of the website...", message.OrderId);

            this.Data.OrderId = message.OrderId;
            this.Data.Customerid = message.CustomerId;
            this.Data.OrderState = message.State;
            this.Data.ProductId = message.ProductId;
            this.Data.ProductPrice = message.ProductPrice;

            Console.WriteLine();
            Console.WriteLine(DateTime.Now);
            Console.WriteLine("Adding new order '{0}' to the db...", message.OrderId);

            // save the order into the db
            this.Bus.Send(
                new AddNewOrderMessage
                {
                    OrderId = message.OrderId,
                    CustomerId = message.CustomerId,
                    ProductId = message.ProductId,
                    OrderState = message.State
                });

            Console.WriteLine();
            Console.WriteLine(DateTime.Now);
            Console.WriteLine("Processing order '{0}' to the SALES...", message.OrderId);

            // remote message to sales dept.
            this.Bus.Publish<OrderSentToSalesEvent>(
                e =>
                {
                    e.OrderId = message.OrderId;
                    e.ProductId = message.ProductId;
                    e.CustomerId = message.CustomerId;
                    e.State = OrderState.OrderPlaced;
                });

            Console.WriteLine("-----------------------------------");
            Console.WriteLine();
        }

        public void Handle(OrderAcceptedEvent message)
        {
            Console.WriteLine();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine(DateTime.Now);
            Console.WriteLine("Handling OrderAcceptedEvent '{0}'...", message.OrderId);
            Console.WriteLine("-----------------------------------");
            Console.WriteLine();

            this.Bus.Send(
                new OrderAcceptedMessage
                {
                    OrderId = message.OrderId,
                    OrderState = message.State
                });
        }

        public void Handle(OrderShippedEvent message)
        {
            Console.WriteLine();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine(DateTime.Now);
            Console.WriteLine("Handling OrderShippedEvent '{0}'...", message.OrderId);
            Console.WriteLine("-----------------------------------");
            Console.WriteLine();

            this.Bus.Send(
                new OrderShippedMessage
                {
                    OrderId = message.OrderId,
                    OrderState = message.State
                });

            MarkAsComplete();
        }

        #endregion
    }
}
