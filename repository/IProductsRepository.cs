using Entities;

namespace repository
{
    public interface IProductsRepository
    {
        Task<IEnumerable<Product>> getAllProducts(string? desc, int? minPrice, int? maxPrice,
            int?[] categoryIds);
    }
}