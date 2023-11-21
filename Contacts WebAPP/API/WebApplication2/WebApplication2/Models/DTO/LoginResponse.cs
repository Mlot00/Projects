using System.Reflection.Metadata.Ecma335;

namespace WebApplication2.Models.DTO
{
	public class LoginResponse
	{
        public string Email { get; set; }
        public string Token { get; set; }
        public List<string> Roles { get; set; }
    }
}
