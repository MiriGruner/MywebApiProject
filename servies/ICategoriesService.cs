using Entities;

namespace servies
{
    public interface ICategoriesService
    {
        Task<IEnumerable<Category>> getAllCategories();

        Task<Category> getCategoryById(int id);


    }
}