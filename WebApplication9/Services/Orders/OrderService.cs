using WebApplication9.Models;

namespace WebApplication9.Services.Orders
{
    public class OrderService : IOrderService
    {
        private readonly List<Order> _orders = new List<Order>
        {
            new Order { Id = 1, OrderNumber = "ORD123456", OrderDate = new DateTime(2024, 3, 19), TotalAmount = 105.99m },
            new Order { Id = 2, OrderNumber = "ORD789012", OrderDate = new DateTime(2024, 3, 18), TotalAmount = 87.49m },
            new Order { Id = 3, OrderNumber = "ORD345678", OrderDate = new DateTime(2024, 3, 17), TotalAmount = 204.99m },
            new Order { Id = 4, OrderNumber = "ORD901234", OrderDate = new DateTime(2024, 3, 16), TotalAmount = 68.99m },
            new Order { Id = 5, OrderNumber = "ORD567890", OrderDate = new DateTime(2024, 3, 15), TotalAmount = 152.59m },
            new Order { Id = 6, OrderNumber = "ORD234567", OrderDate = new DateTime(2024, 3, 14), TotalAmount = 118.79m },
            new Order { Id = 7, OrderNumber = "ORD890123", OrderDate = new DateTime(2024, 3, 13), TotalAmount = 77.99m },
            new Order { Id = 8, OrderNumber = "ORD456789", OrderDate = new DateTime(2024, 3, 12), TotalAmount = 36.89m },
            new Order { Id = 9, OrderNumber = "ORD012345", OrderDate = new DateTime(2024, 3, 11), TotalAmount = 95.99m },
            new Order { Id = 10, OrderNumber = "ORD678901", OrderDate = new DateTime(2024, 3, 10), TotalAmount = 62.29m }
        };

        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await Task.FromResult(_orders);
        }

        public async Task AddOrder(Order order)
        {
            _orders.Add(order);
            await Task.CompletedTask;
        }

        public async Task UpdateOrder(Order order)
        {
            var existingOrder = _orders.Find(o => o.Id == order.Id);
            if (existingOrder != null)
            {
                existingOrder.OrderNumber = order.OrderNumber;
                existingOrder.OrderDate = order.OrderDate;
                existingOrder.TotalAmount = order.TotalAmount;
            }
            await Task.CompletedTask;
        }

        public async Task DeleteOrder(int id)
        {
            _orders.RemoveAll(o => o.Id == id);
            await Task.CompletedTask;
        }
    }
}
