using Sense.Domain.DBEntities;
using Sense.Domain;
using Microsoft.EntityFrameworkCore;
using Sense.Application.RequestFeatures;

namespace Sense.Application.ProductRepositories
{
    public class ProductRepository : RepositoryBase<ProductTbl>, IProductRepository
    {
        public ProductRepository(SenseDbContext context) : base(context)
        {
        }

        public void CreateProduct(ProductTbl product)
            => Create(product);


        public void DeleteProduct(ProductTbl product)
            => Delete(product);

        public IQueryable<ProductTbl> GetAllProductsAsQuery()
            => FindByCondition(x => x.IsDeleted == false).AsNoTracking().Include(x => x.Category).Include(x => x.Brand).Include(x => x.Model).Include(x => x.Provider).ThenInclude(p => p.ApplicationUser).AsQueryable();

        public async Task<PagedList<ProductTbl>> GetAllProductsAsync(ProductParameters productParameters)
        {
            var query = FindAll().Include(x => x.Category).Include(x => x.Brand).Include(x => x.Model).Include(x => x.Provider).ThenInclude(p => p.ApplicationUser).AsQueryable();

            if (productParameters == null)
            {
                var itemsWithoutFilter = await query.Where(x => x.IsDeleted == false).ToListAsync();
                return PagedList<ProductTbl>.ToPagedList(itemsWithoutFilter, 1, itemsWithoutFilter.Count);
            }
            // Apply filters
            if (!string.IsNullOrEmpty(productParameters.ProductName))
            {
                query = query.Where(i => i.Name.Contains(productParameters.ProductName) || i.Category.Name.Contains(productParameters.ProductName) || i.Brand.Name.Contains(productParameters.ProductName));
            }
            if (productParameters.ProductCategoryId.HasValue)
            {
                query = query.Where(i => i.CategoryId == productParameters.ProductCategoryId);
            }
            if (productParameters.ProductBrandId.HasValue)
            {
                query = query.Where(i => i.BrandId == productParameters.ProductBrandId);
            }
            if (productParameters.ProductModelId.HasValue)
            {
                query = query.Where(i => i.ModelId == productParameters.ProductModelId);
            }

            if (productParameters.IsSparePart.HasValue)
            {
                query = query.Where(i => i.IsSparePart == productParameters.IsSparePart);
            }

            if (productParameters.Status.HasValue)
            {
                query = query.Where(i => i.Status == productParameters.Status);
            }

            if (productParameters.ProviderId.HasValue)
            {
                query = query.Where(i => i.ProviderId == productParameters.ProviderId);
            }


            // Fetch items with pagination
            var items = await query.Where(x => x.IsDeleted == false).ToListAsync();

            return PagedList<ProductTbl>.ToPagedList(items, productParameters.PageNumber, productParameters.PageSize);
        }

        public async Task<IEnumerable<ProductTbl>> GetOutOfStockProducts()
            => await FindByCondition(x => x.QuantityAvaliable == 0).Include(x => x.Category).Include(x => x.Brand).Include(x => x.Model).ToListAsync();

        public async Task<ProductTbl> GetProductByIdAsync(int id)
            => await FindByCondition(x => x.Id == id && x.IsDeleted == false).Include(x => x.Category).Include(x => x.Brand).Include(x => x.Model).Include(x => x.Provider).FirstOrDefaultAsync();


        public void UpdateProduct(ProductTbl product)
            => Update(product);

    }
}
