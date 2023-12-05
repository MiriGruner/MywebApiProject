using Entities;
using Microsoft.Extensions.Logging;
using repository;
using NLog.Web;

namespace servies
{
    public class OrderService : IOrderService
    {
       private readonly ILogger _logger;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductsRepository _productsRepository;
        public OrderService(IOrderRepository orderRepository, IProductsRepository productsRepository,ILogger<OrderService> logger)
        {
            _orderRepository = orderRepository;
            _productsRepository = productsRepository;
            _logger = logger;
        }
        public async Task<Order> CreateNewOrder(Order order)
        {
            order.OrderDate = DateTime.Now;
            int sum = 0;
            Product product;
            
            foreach(OrderItem o in order.OrderItems)
            {
                product = await _productsRepository.getProductById(o.ProductId);
                sum += product.Price;
            }
            if (sum != order.OrderSum)
            {
                _logger.LogError($"user {order.UserId}  tried perchasing with a difffrent price {order.OrderSum} instead of {sum}");
                _logger.LogInformation($"user {order.UserId}  tried perchasing with a difffrent price {order.OrderSum} instead of {sum}");
            }
            order.OrderSum = sum;
            return await _orderRepository.CreateNewOrder(order);
        }
    }
}

