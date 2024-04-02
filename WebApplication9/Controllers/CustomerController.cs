using Microsoft.AspNetCore.Mvc;
using WebApplication9.Models;
using Microsoft.AspNetCore.Authorization;
using WebApplication9.Services.Customers;

namespace WebAplication7.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IPasswordHashService _passwordHashService;

        public CustomerController(ICustomerService customerService, IPasswordHashService passwordHashService)
        {
            _customerService = customerService;
            _passwordHashService = passwordHashService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> Get()
        {
            var customers = await _customerService.GetCustomers();
            return Ok(customers);
        }


        [HttpPost]
        public async Task<ActionResult<Customer>> Post(Customer customer)
        {
            customer.Password = _passwordHashService.HashPassword(customer.Password);

            await _customerService.AddCustomer(customer);
            return CreatedAtAction(nameof(Get), new { id = customer.Id }, customer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            if (!string.IsNullOrEmpty(customer.Password))
            {
                customer.Password = _passwordHashService.HashPassword(customer.Password);
            }

            await _customerService.UpdateCustomer(customer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _customerService.DeleteCustomer(id);
            return NoContent();
        }
    }
}
