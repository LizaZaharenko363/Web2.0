using Microsoft.AspNetCore.Mvc;
using WebApplication9.Models;
using WebApplication9.Services.Customers;
using Microsoft.AspNetCore.Authorization;


namespace WebApplication9.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AuthController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IPasswordHashService _passwordHashService;

        public AuthController(ICustomerService customerService, IPasswordHashService passwordHashService)
        {
            _customerService = customerService;
            _passwordHashService = passwordHashService;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginRequestModel model)
        {
            var customer = await _customerService.GetCustomerByEmail(model.Email);
            if (customer == null)
            {
                return NotFound("User not found");
            }

            if (!_passwordHashService.VerifyPassword(customer.Password, model.Password))
            {
                return Unauthorized("Invalid password");
            }

            return Ok("Login successful");
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterRequestModel model)
        {
            var existingCustomer = await _customerService.GetCustomerByEmail(model.Email);
            if (existingCustomer != null)
            {
                return Conflict("Email is already registered");
            }

            string hashedPassword = _passwordHashService.HashPassword(model.Password);


            var newCustomer = new Customer
            {
                Email = model.Email,
                Password = hashedPassword,
                FirstName = model.FirstName,
                LastName = model.LastName
            };


            await _customerService.AddCustomer(newCustomer);

            return CreatedAtAction(nameof(Login), new { email = newCustomer.Email }, "User registered successfully");
        }
    }
}
