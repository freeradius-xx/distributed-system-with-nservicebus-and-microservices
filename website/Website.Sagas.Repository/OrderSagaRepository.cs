using System;
using System.Linq;
using Website.Entities;
using Website.SagaDb;

namespace Website.Sagas.Repository
{
    public class OrderSagaRepository
    {
        #region CRUD

        public PlaceOrderSagaData GetOrder(Guid id)
        {
            using (var ctx = new OrderSagarContext())
            {
                var data = ctx.Orders.SingleOrDefault(o => o.OrderId == id);
                return data;
            }
        }

        public void SaveOrder(PlaceOrderSagaData vm)
        {
            using (var ctx = new OrderSagarContext())
            {
                var data = ctx.Orders.SingleOrDefault(o => o.OrderId == vm.OrderId);
                if (data != null)
                {
                    data.OrderId = vm.OrderId;
                    data.Customerid = vm.Customerid;
                    data.Id = vm.Id;
                    data.OrderState = vm.OrderState;
                    data.OriginalMessageId = vm.OriginalMessageId;
                    data.Originator = vm.Originator;
                    data.ProductId = vm.ProductId;
                    data.ProductPrice = vm.ProductPrice;
                }
                else
                {
                    data = new PlaceOrderSagaData
                    {
                        OrderId = vm.OrderId,
                        Customerid = vm.Customerid,
                        Id = vm.Id,
                        OrderState = vm.OrderState,
                        OriginalMessageId = vm.OriginalMessageId,
                        Originator = vm.Originator,
                        ProductId = vm.ProductId,
                        ProductPrice = vm.ProductPrice
                    };
                    ctx.Orders.Add(data);
                }

                ctx.SaveChanges();
            }
        }

        #endregion
    }
}
