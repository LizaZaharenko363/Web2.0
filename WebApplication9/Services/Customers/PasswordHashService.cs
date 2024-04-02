using System;
using System.Security.Cryptography;
using System.Text;

namespace WebApplication9.Services.Customers
{
    public interface IPasswordHashService
    {
        string HashPassword(string password);
        bool VerifyPassword(string hashedPassword, string password);
    }

    public class PasswordHashService : IPasswordHashService
    {
        public string HashPassword(string password)
        {
            using (var algorithm = new SHA256Managed())
            {
                var hashBytes = algorithm.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashBytes);
            }
        }

        public bool VerifyPassword(string hashedPassword, string password)
        {
            return HashPassword(password) == hashedPassword;
        }
    }
}
