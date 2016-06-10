using System;
using System.Linq;
using Shared.ProductDb;
using Shared.ViewModels;

namespace Shared.ProductRepository
{
    public class ProductRepository : IDisposable
    {
        #region Fields

        private readonly ProductContext _ctx = new ProductContext();

        #endregion

        #region CRUD

        public IQueryable<ProductViewModel> GetProducts()
        {
            var products = this._ctx.Products.ToList();
            var list = products.Select(p => new ProductViewModel
            {
                Name = p.Name,
                Price = p.Price,
                Id = p.ProductId
            }).ToList();
            return list.AsQueryable();
        }

        public void AddProduct(ProductViewModel vm)
        {
            this._ctx.Products.Add(
                    new Product
                    {
                        Price = vm.Price,
                        Name = vm.Name
                    });
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
