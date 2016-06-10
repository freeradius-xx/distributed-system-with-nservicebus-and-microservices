using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Sales.Client.ApplicationServices;
using Shared.Commands;
using Shared.Infrastructure;
using Shared.ViewModels;

namespace Sales.Client.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Orders(Guid? id = null)
        {
            var model = new QueryService().GetOrders().ToList();

            if (!id.HasValue || !model.Any()) return View(model);

            var exist = model.FirstOrDefault(m => m.OrderId == id);
            if (exist != null)
            {
                model.Remove(exist);
            }

            return View(model);
        }

        public ActionResult RelayOrderForShipping(Guid orderId)
        {
            var order = new QueryService().GetOrders().SingleOrDefault(o => o.OrderId == orderId);
            if (order == null) throw new FileNotFoundException("Order not found");

            ServiceBus.Bus.Send(
                new ForwardOrderForShippingCommand
                {
                    OrderId = order.OrderId,
                    CustomerId = order.CustomerId,
                    ProductId = order.ProductId,
                    State = OrderState.OrderPlaced
                });

            return RedirectToAction("Orders", "Home", new { id = orderId });
        }
    }
}