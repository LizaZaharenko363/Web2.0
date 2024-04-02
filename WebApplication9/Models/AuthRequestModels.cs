namespace WebApplication9.Models
{
    public class LoginRequestModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class RegisterRequestModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
