using System.Linq;
using Shared.OrderRepository;
using Shared.ViewModels;

namespace Shipping.Client.ApplicationServices
{
    public class QueryService
    {
        #region Fields

        private readonly OrderRepository _db;

        #endregion

        #region C-Tor

        public QueryService()
        {
            this._db = new OrderRepository();
        }

        #endregion

        #region CRUD

        public IQueryable<OrderViewModel> GetOrders()
        {
            return this._db.GetOrders().AsQueryable();
        }

        #endregion
    }
}
