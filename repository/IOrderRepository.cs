using Entities;

namespace repository
{
    public interface IOrderRepository
    {
        Task<Order> CreateNewOrder(Order order);
    }
}