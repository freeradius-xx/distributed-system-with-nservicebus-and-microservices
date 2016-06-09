using System.Linq;
using NServiceBus;
using Shared.Messages;
using Shared.ViewModels;

namespace Website.Handler.OrderRepository
{
    /// <summary>
    /// here we should consider using an event store
    /// </summary>
    public class RepositoryHandler : 
        IHandleMessages<AddNewOrderMessage>,
        IHandleMessages<OrderAcceptedMessage>,
        IHandleMessages<OrderShippedMessage>
    {
        #region Fields

        private readonly Shared.OrderRepository.OrderRepository _repository;

        #endregion

        #region C-Tor

        public RepositoryHandler()
        {
            this._repository = new Shared.OrderRepository.OrderRepository();
        }

        #endregion

        #region Handlers

        public void Handle(AddNewOrderMessage message)
        {
            this._repository.AddOrder(
                new OrderViewModel
                {
                    CustomerId = message.CustomerId,
                    OrderId = message.OrderId,
                    OrderState = OrderState.OrderPlaced,
                    ProductId = message.ProductId
                });
        }

        public void Handle(OrderAcceptedMessage message)
        {
            this._repository.Update(
                new OrderViewModel
                {
                    OrderState = message.OrderState
                });
        }

        #endregion

        public void Handle(OrderShippedMessage message)
        {
            this._repository.Update(
                new OrderViewModel
                {
                    OrderState = message.OrderState
                });
        }
    }
}
