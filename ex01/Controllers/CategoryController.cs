using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using servies;
using System.Collections.Generic;
using System.Data.SqlTypes;

namespace project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoriesService _categoriesService;

        private readonly IMapper _mapper;

        public CategoryController(ICategoriesService categoriesService, IMapper mapper)
        {
            _categoriesService = categoriesService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            IEnumerable<Category> categories = await _categoriesService.getAllCategories();
            IEnumerable<CategoryDTO> categoryDTOs = _mapper.Map<IEnumerable<Category>,IEnumerable<CategoryDTO>>(categories);
            return Ok(categoryDTOs);
        }
  
        }
}

