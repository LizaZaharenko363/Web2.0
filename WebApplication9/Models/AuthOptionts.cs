using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebApplication9.Models
{
    public class AuthOptions
    {
        public const string ISSUER = "MakeUpStore"; 
        public const string AUDIENCE = "MakeUpStore"; 
        const string KEY = "UzJcqI6H1NVReIKV2JP7s0RN0yEVYMl4NElzog";
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}
