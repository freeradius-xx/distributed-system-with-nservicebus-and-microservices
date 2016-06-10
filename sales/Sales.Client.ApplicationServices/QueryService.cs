using System.Collections.Generic;
using System.Linq;
using Sales.Repository;
using Shared.ViewModels;

namespace Sales.Client.ApplicationServices
{
    public class QueryService
    {
        #region Fields

        private readonly OrderSalesRepository _repository;

        #endregion

        #region C-Tor

        public QueryService()
        {
            this._repository = new OrderSalesRepository();
        }

        #endregion

        #region CRUD

        public IQueryable<OrderViewModel> GetOrders()
        {
            var model =  this._repository.GetState(OrderState.OrderPlaced);
            var vm = new List<OrderViewModel>();
            foreach (var o in model)
            {
                vm.Add(
                    new OrderViewModel
                    {
                        OrderId = o.OrderId,
                        OrderState = o.OrderState,
                        CustomerId = o.CustomerId,
                        ProductId = o.ProductId
                    });
            }
            return vm.ToList().AsQueryable();
        }

        #endregion
    }
}
