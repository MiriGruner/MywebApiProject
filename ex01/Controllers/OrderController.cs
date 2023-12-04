using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using servies;

namespace project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _mapper = mapper;
            _orderService = orderService;

        }
        [HttpPost]
        public async Task<ActionResult<OrderDTO>> Post([FromBody] OrderDTO orderdto)
        {
            Order order1 = _mapper.Map<OrderDTO, Order>(orderdto);

            Order order= await _orderService.CreateNewOrder(order1);

            OrderDTO orderDTO = _mapper.Map<Order, OrderDTO>(order);

            return orderDTO;
        }
        }
}
