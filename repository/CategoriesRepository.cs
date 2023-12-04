using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository
{
    public class CategoriesRepository : ICategoriesRepository
    {

        private readonly Store21Context _DbContext;

        public CategoriesRepository(Store21Context dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task<IEnumerable<Category>> getAllCategories()
        {
            return await _DbContext.Categories.ToListAsync();
        }
        public async Task<Category> getCategoryById(int id)
        {
            return await _DbContext.Categories.Where(i => i.CategoryId == id).FirstOrDefaultAsync();
        }
    }
}
