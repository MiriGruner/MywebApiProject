using AutoMapper;
using DTO;
using Entities;

namespace project
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<User, UserDTO>().ReverseMap();

            CreateMap<Category,CategoryDTO>();

            CreateMap<OrderDTO, Order>().ReverseMap();

            CreateMap<OrderItemDTO, OrderItem>().ReverseMap();

            CreateMap<Product, ProductDTO>().ForMember(dest => dest.CategoryName,
                opts => opts.MapFrom(src => src.Category.Name));
        }
    }
}
