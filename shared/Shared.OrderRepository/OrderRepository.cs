using System.Collections.Generic;
using System.Linq;
using Shared.OrderDb;
using Shared.ViewModels;

namespace Shared.OrderRepository
{
    public class OrderRepository
    {
        #region CRUD

        public IQueryable<OrderViewModel> GetOrders()
        {
            using (var ctx = new OrderContext())
            {
                var orders = ctx.Orders.ToList();
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
        }

        public void AddOrder(OrderViewModel vm)
        {
            using (var ctx = new OrderContext())
            {
                if (ctx.Orders.SingleOrDefault(o => o.OrderId == vm.OrderId) != null)
                    return;

                ctx.Orders.Add(
                    new Order
                    {
                        OrderId = vm.OrderId,
                        CustomerId = vm.CustomerId,
                        ProductId = vm.ProductId,
                        OrderState = vm.OrderState
                    });
                ctx.SaveChanges();
            }
        }

        public void Update(OrderViewModel vm)
        {
            using (var ctx = new OrderContext())
            {
                var order = ctx.Orders.SingleOrDefault(o => o.OrderId == vm.OrderId);
                if (order != null)
                {
                    order.OrderState = vm.OrderState;
                }
                ctx.SaveChanges();
            }
        }

        #endregion
    }
}
