using WebApplication9.Models;

namespace WebApplication9.Services.Orders
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetOrders();
        Task AddOrder(Order order);
        Task UpdateOrder(Order order);
        Task DeleteOrder(int id);
    }
}
