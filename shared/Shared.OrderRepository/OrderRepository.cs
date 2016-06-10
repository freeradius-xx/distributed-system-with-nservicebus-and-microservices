using System;
using System.Collections.Generic;
using System.Linq;
using Shared.OrderDb;
using Shared.ViewModels;

namespace Shared.OrderRepository
{
    public class OrderRepository : IDisposable
    {
        #region Fields

        private readonly OrderContext _ctx = new OrderContext();

        #endregion

        #region CRUD

        public IQueryable<OrderViewModel> GetOrders()
        {
            var orders = this._ctx.Orders.ToList();
            var list = new List<OrderViewModel>();
            foreach (var o in orders)
            {
                list.Add(
                    new OrderViewModel
                    {
                        OrderId = o.OrderId,
                        CustomerId = o.CustomerId,
                        ProductId = o.ProductId,
                        OrderState = o.OrderState
                    });
            }
            return list.AsQueryable();
        }

        public void AddOrder(OrderViewModel vm)
        {
            if (this._ctx.Orders.SingleOrDefault(o => o.OrderId == vm.OrderId) != null)
                return;

            this._ctx.Orders.Add(
                new Order
                {
                    OrderId = vm.OrderId,
                    CustomerId = vm.CustomerId,
                    ProductId = vm.ProductId,
                    OrderState = vm.OrderState
                });
            this._ctx.SaveChanges();
        }

        public void Update(OrderViewModel vm)
        {
            var order = this._ctx.Orders.SingleOrDefault(o => o.OrderId == vm.OrderId);
            if (order != null)
            {
                order.OrderState = vm.OrderState;
            }
            this._ctx.SaveChanges();
        }

        #endregion

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
        }

        #endregion
    }
}
