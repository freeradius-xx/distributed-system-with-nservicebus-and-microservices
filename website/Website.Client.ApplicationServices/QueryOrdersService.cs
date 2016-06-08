using System.Linq;
using Shared.OrderRepository;
using Shared.ViewModels;

namespace Website.Client.ApplicationServices
{
    public class QueryOrdersService
    {
        #region Fields

        private readonly OrderRepository _db;

        #endregion

        #region C-Tor

        public QueryOrdersService()
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
