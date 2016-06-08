using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Website.Sagas.Repository
{
    class OrderSagaRepository
    {
        #region CRUD

        //public IQueryable<ProductViewModel> GetProducts()
        //{
        //    using (var ctx = new ProductContext())
        //    {
        //        var products = ctx.Products.ToList();
        //        var list = products.Select(p => new ProductViewModel
        //        {
        //            Name = p.Name,
        //            Price = p.Price,
        //            Id = p.ProductId
        //        }).ToList();
        //        return list.AsQueryable();
        //    }
        //}

        //public void AddProduct(ProductViewModel vm)
        //{
        //    using (var ctx = new ProductContext())
        //    {
        //        ctx.Products.Add(
        //            new Product
        //            {
        //                Price = vm.Price,
        //                Name = vm.Name
        //            });
        //        ctx.SaveChanges();
        //    }
        //}

        #endregion
    }
}
