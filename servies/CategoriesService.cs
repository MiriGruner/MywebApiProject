using Entities;
using Microsoft.EntityFrameworkCore;
using repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace servies
{
    public class CategoriesService : ICategoriesService
    {

        private readonly ICategoriesRepository _categoriesRepository;
        public CategoriesService(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }
        public async Task<IEnumerable<Category>> getAllCategories()
        {
            return await _categoriesRepository.getAllCategories();
        }

        public async Task<Category> getCategoryById(int id)
        {
            return await _categoriesRepository.getCategoryById(id);
        }
    }
}
