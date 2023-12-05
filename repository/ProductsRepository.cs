using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly Store21Context _DbContext;

        public ProductsRepository(Store21Context dbContext)
        {
            _DbContext = dbContext;
        }
        
        public async Task<IEnumerable<Product>> getAllProducts(string? desc,int? minPrice, int? maxPrice,
            int?[] categoryIds)
        {
            var quary = _DbContext.Products.Where(product =>
            (desc == null ? (true) : (product.Description.Contains(desc)))
            && ((minPrice == null) ? (true) : (product.Price >= minPrice))
            && ((maxPrice == null) ? (true) : (product.Price <= maxPrice))
            && ((categoryIds.Length == 0) ? (true) : (categoryIds.Contains(product.CategoryId))))
                .OrderBy(product => product.Price).Include(i=>i.Category);
            List<Product> products = await quary.ToListAsync();
            return products;
        }
        public async Task<Product> getProductById(int id)
        {
            return await _DbContext.Products.Where(p=>p.ProductId==id).FirstOrDefaultAsync();
        }

    }
}
