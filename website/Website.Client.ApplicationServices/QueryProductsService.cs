using System.Linq;
using Shared.ProductRepository;
using Shared.ViewModels;

namespace Website.Client.ApplicationServices
{
    public class QueryProductsService
    {
        #region Fields

        private readonly ProductRepository _db;

        #endregion

        #region C-Tor

        public QueryProductsService()
        {
            this._db = new ProductRepository();
        }

        #endregion

        #region CRUD

        public IQueryable<ProductViewModel> GetProducts()
        {
            return this._db.GetProducts().AsQueryable();
        }

        #endregion
    }
}
