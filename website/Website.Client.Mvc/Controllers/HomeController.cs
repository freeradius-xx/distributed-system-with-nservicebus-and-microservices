using System;
using System.Linq;
using System.Web.Mvc;
using Shared.Commands;
using Shared.Infrastructure;
using Shared.ViewModels;
using Website.Client.ApplicationServices;

namespace Website.Client.Mvc.Controllers
{
    public class HomeController : Controller
    {
        #region Fields

        private readonly QueryProductsService _productService;
        private readonly QueryOrdersService _orderService;

        #endregion

        #region C-Tor

        public HomeController()
        {
            this._productService = new QueryProductsService();
            this._orderService = new QueryOrdersService();
        }

        #endregion

        #region Actions

        public ActionResult Index()
        {
            return View(new QueryProductsService().GetProducts().ToList());
        }

        public ActionResult Buy(int id)
        {
            var product = this._productService.GetProducts().SingleOrDefault(p => p.Id == id);
            if (product == null)
                return RedirectToAction("Index");

            // send message to:
            // Website.Handler.OrderProcessor.ProcessOrderHandler
            // because only microservices should publish events
            // and not the client (website, wpf,...)
            // the client should only send commands
            ServiceBus.Bus.Send(
                new ProcessOrderCommand
                {
                    OrderId = Guid.NewGuid(),
                    CustomerId = Guid.NewGuid(),
                    ProductId = product.Id,
                    ProductPrice = product.Price,
                    State = OrderState.OrderPlaced
                });

            return RedirectToAction("Index");
        }

        public ActionResult Orders()
        {
            return View(this._orderService.GetOrders().ToList());
        }

        #endregion
    }
}