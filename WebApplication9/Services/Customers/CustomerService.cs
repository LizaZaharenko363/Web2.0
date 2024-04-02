using WebApplication9.Models;

namespace WebApplication9.Services.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly List<Customer> _customers = new List<Customer>
        {
            new Customer { Id = 1, FirstName = "William", LastName = "Afton", Email = "WilliamAfton@gmail.com", Password = "qgstYt87X" },
            new Customer { Id = 2, FirstName = "Sarah", LastName = "Johnson", Email = "SarahJohnson@hotmail.com", Password = "r7Fthk21Z" },
            new Customer { Id = 3, FirstName = "Michael", LastName = "Doe", Email = "MichaelDoe@yahoo.com", Password = "p9Gnwq32Y" },
            new Customer { Id = 4, FirstName = "Emily", LastName = "Smith", Email = "EmilySmith@gmail.com", Password = "u8Vxfj75K" },
            new Customer { Id = 5, FirstName = "Jessica", LastName = "Brown", Email = "JessicaBrown@aol.com", Password = "w3Zdmv89L" },
            new Customer { Id = 6, FirstName = "David", LastName = "Jones", Email = "DavidJones@gmail.com", Password = "t4Cpql67R" },
            new Customer { Id = 7, FirstName = "Jennifer", LastName = "Miller", Email = "JenniferMiller@hotmail.com", Password = "s6Bhzx43M" },
            new Customer { Id = 8, FirstName = "Daniel", LastName = "Wilson", Email = "DanielWilson@yahoo.com", Password = "v2Skow56N" },
            new Customer { Id = 9, FirstName = "Emma", LastName = "Taylor", Email = "EmmaTaylor@aol.com", Password = "x5Vjyr34O" },
            new Customer { Id = 10, FirstName = "James", LastName = "Anderson", Email = "JamesAnderson@gmail.com", Password = "z1Lncp98P" }
        };

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await Task.FromResult(_customers);
        }
        public async Task<Customer> GetCustomerByEmail(string email)
        {
            return await Task.FromResult(_customers.FirstOrDefault(c => c.Email == email));
        }
        public async Task AddCustomer(Customer customer)
        {
            _customers.Add(customer);
            await Task.CompletedTask;
        }

        public async Task UpdateCustomer(Customer customer)
        {
            var existingCustomer = _customers.FirstOrDefault(c => c.Id == customer.Id);
            if (existingCustomer != null)
            {
                existingCustomer.FirstName = customer.FirstName;
                existingCustomer.LastName = customer.LastName;
                existingCustomer.Email = customer.Email;
                existingCustomer.Password = customer.Password;
            }
            await Task.CompletedTask;
        }

        public async Task DeleteCustomer(int id)
        {
            _customers.RemoveAll(c => c.Id == id);
            await Task.CompletedTask;
        }
    }
}
