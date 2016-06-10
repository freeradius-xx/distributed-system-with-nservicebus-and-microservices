using System;
using System.Linq;
using Website.Entities;
using Website.SagaDb;

namespace Website.Sagas.Repository
{
    public class OrderSagaRepository : IDisposable
    {
        #region Fields

        private readonly SagaContext _ctx = new SagaContext();

        #endregion

        #region CRUD

        public PlaceOrderSagaData GetSagaState(Guid id)
        {
            return this._ctx.Orders.SingleOrDefault(o => o.OrderId == id);
        }

        public void SaveSagaState(PlaceOrderSagaData vm)
        {
            var data = this._ctx.Orders.SingleOrDefault(o => o.OrderId == vm.OrderId);
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
