using System;
using System.Collections.Generic;
using System.Linq;
using Shared.ViewModels;
using Shipping.Db;
using Shipping.Entities;

namespace Shipping.Repository
{
    public class ShippingOrderRepository : IDisposable
    {
        #region Fields

        private readonly ShippingContext _ctx = new ShippingContext();

        #endregion

        #region CRUD

        public ShippingOrderData GetState(Guid id)
        {
            return this._ctx.Orders.SingleOrDefault(o => o.OrderId == id);
        }

        public IEnumerable<ShippingOrderData> GetOrders(OrderState orderState)
        {
            return this._ctx.Orders.Where(o => o.OrderState == orderState);
        }

        public void SaveState(ShippingOrderData vm)
        {
            var data = this._ctx.Orders.SingleOrDefault(o => o.OrderId == vm.OrderId);
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
                this._ctx.Orders.Add(data);
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
