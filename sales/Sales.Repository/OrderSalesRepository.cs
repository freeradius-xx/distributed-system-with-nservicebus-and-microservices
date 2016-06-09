using System;
using System.Linq;
using System.Net.Http;
using Sales.Db;
using Sales.Entities;

namespace Sales.Repository
{
    public class OrderSalesRepository
    {
        #region CRUD

        public SalesOrderData GetState(Guid id)
        {
            using (var ctx = new SalesContext())
            {
                return ctx.Orders.SingleOrDefault(o => o.OrderId == id);
            }
        }

        public void SaveState(SalesOrderData vm)
        {
            using (var ctx = new SalesContext())
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
                    data = new SalesOrderData
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
