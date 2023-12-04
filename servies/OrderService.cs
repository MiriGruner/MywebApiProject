using Entities;
using repository;

namespace servies
{
    public class OrderService : IOrderService
    {

        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<Order> CreateNewOrder(Order order)
        {
            order.OrderDate = DateTime.Now;


            return await _orderRepository.CreateNewOrder(order);
        }
    }
}

