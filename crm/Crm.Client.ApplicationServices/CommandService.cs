using Shared.ProductRepository;
using Shared.ViewModels;

namespace Crm.Client.ApplicationServices
{
    public class CommandService
    {
        #region Fields

        private readonly ProductRepository _db;
        #endregion

        #region C-Tor

        public CommandService()
        {
            this._db = new ProductRepository();
        }

        #endregion

        #region CRUD

        public void CreateNewProduct(ProductViewModel vm)
        {
            this._db.AddProduct(vm);
        }

        #endregion
    }
}
