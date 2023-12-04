using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly Store21Context _DbContext;

        public OrderRepository(Store21Context dbContext)
        {
            _DbContext = dbContext;
        }
        public async Task<Order> CreateNewOrder(Order order)
        {
            await _DbContext.Orders.AddAsync(order);
            await _DbContext.SaveChangesAsync();
            return order;

        }
    }
}
