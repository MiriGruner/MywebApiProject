using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using servies;
using System.Collections.Generic;

namespace project.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get([FromQuery] string? desc, [FromQuery] int? minPrice, [FromQuery] int? maxPrice,[FromQuery] int?[] categoryIds)
        {
           IEnumerable <Product> products =  await _productService.getAllProducts(desc, minPrice, maxPrice,
            categoryIds);
            IEnumerable<ProductDTO> productsdto = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products);
            return  Ok(productsdto);
        }

        }
}
