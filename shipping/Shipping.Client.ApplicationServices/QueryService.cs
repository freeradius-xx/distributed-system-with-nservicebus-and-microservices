using System.Collections.Generic;
using System.Linq;
using Shared.ViewModels;
using Shipping.Entities;
using Shipping.Repository;

namespace Shipping.Client.ApplicationServices
{
    public class QueryService
    {
        #region Fields

        private readonly ShippingOrderRepository _repository;

        #endregion

        #region C-Tor

        public QueryService()
        {
            this._repository = new ShippingOrderRepository();
        }

        #endregion

        #region CRUD

        public List<ShippingOrderData> GetOrders()
        {
            return this._repository.GetOrders(OrderState.AcceptedBySales).ToList();
        }

        #endregion
    }
}
