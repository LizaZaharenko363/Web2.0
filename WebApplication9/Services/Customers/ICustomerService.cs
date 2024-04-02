using WebApplication9.Models;

namespace WebApplication9.Services.Customers
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetCustomers();
        Task<Customer> GetCustomerByEmail(string email);
        Task AddCustomer(Customer customer);
        Task UpdateCustomer(Customer customer);
        Task DeleteCustomer(int id);
    }
}
