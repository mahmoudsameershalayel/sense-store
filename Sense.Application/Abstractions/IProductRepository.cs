using Sense.Application.RequestFeatures;
using Sense.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.Abstractions
{
    public interface IProductRepository
    {
        IQueryable<ProductTbl> GetAllProductsAsQuery();
        Task<PagedList<ProductTbl>> GetAllProductsAsync(ProductParameters productParameters);
        Task<IEnumerable<ProductTbl>> GetOutOfStockProducts();
        void CreateProduct(ProductTbl product);
        void UpdateProduct(ProductTbl product);
        void DeleteProduct(ProductTbl product);
        Task<ProductTbl> GetProductByIdAsync(int id);
    }
}
