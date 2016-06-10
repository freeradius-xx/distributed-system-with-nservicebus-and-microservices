using System;
using System.Collections.Generic;
using System.Linq;
using Sales.Db;
using Sales.Entities;
using Shared.ViewModels;

namespace Sales.Repository
{
    public class OrderSalesRepository : IDisposable
    {
        #region Fields

        private readonly SalesContext _ctx = new SalesContext();

        #endregion

        #region CRUD

        public SalesOrderData GetState(Guid id)
        {
            return this._ctx.Orders.SingleOrDefault(o => o.OrderId == id);
        }

        public IEnumerable<SalesOrderData> GetState(OrderState state)
        {
            return this._ctx.Orders.Where(o => o.OrderState == state);
        }

        public void SaveState(SalesOrderData vm)
        {
            var data = this._ctx.Orders.SingleOrDefault(o => o.OrderId == vm.OrderId);
            if (data != null)
            {
                data.OrderId = vm.OrderId;
                data.OrderState = vm.OrderState;
                data.CustomerId = vm.CustomerId;
                data.ProductId = vm.ProductId;
                data.EditedAt = DateTime.Now;
                data.EditedBy = "";
                data.ResponsiblePerson = "";
            }
            else
            {
                data = new SalesOrderData
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
