using System;
using System.Linq;
using Shipping.Db;
using Shipping.Entities;

namespace Shipping.Repository
{
    public class ShippingOrderRepository
    {
        #region CRUD

        public ShippingOrderData GetState(Guid id)
        {
            using (var ctx = new ShippingContext())
            {
                return ctx.Orders.SingleOrDefault(o => o.OrderId == id);
            }
        }

        public void SaveState(ShippingOrderData vm)
        {
            using (var ctx = new ShippingContext())
            {
                var data = ctx.Orders.SingleOrDefault(o => o.OrderId == vm.OrderId);
                if (data != null)
                {
                    data.OrderId = vm.OrderId;
                    data.OrderState = vm.OrderState;
                    data.EditedAt = DateTime.Now;
                    data.EditedBy = "";
                    data.ResponsiblePerson = "";
                }
                else
                {
                    data = new ShippingOrderData
                    {
                        OrderId = vm.OrderId,
                        OrderState = vm.OrderState,
                        EditedAt = DateTime.Now,
                        EditedBy = "",
                        ResponsiblePerson = ""
                };
                    ctx.Orders.Add(data);
                }

                ctx.SaveChanges();
            }
        }

        #endregion
    }
}
