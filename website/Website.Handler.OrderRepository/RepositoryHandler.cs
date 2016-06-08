using NServiceBus;
using Shared.Messages;
using Shared.ViewModels;

namespace Website.Handler.OrderRepository
{
    public class RepositoryHandler : IHandleMessages<AddNewOrderMessage>
    {
        #region Fields

        private readonly Shared.OrderRepository.OrderRepository _orderRepository;

        #endregion

        #region C-Tor

        public RepositoryHandler()
        {
            this._orderRepository = new Shared.OrderRepository.OrderRepository();
        }

        #endregion

        #region Handlers

        public void Handle(AddNewOrderMessage message)
        {
            this._orderRepository.AddOrder(
                new OrderViewModel
                {
                    CustomerId = message.CustomerId,
                    OrderId = message.OrderId,
                    OrderState = OrderState.OrderPlaced,
                    ProductId = message.ProductId
                });
        }

        #endregion
    }
}
