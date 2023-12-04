using Entities;

namespace repository
{
    public interface ICategoriesRepository
    {
        Task<IEnumerable<Category>> getAllCategories();
        Task<Category> getCategoryById(int id);
    }
}