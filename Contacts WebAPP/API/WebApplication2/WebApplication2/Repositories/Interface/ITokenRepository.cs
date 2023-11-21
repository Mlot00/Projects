using Microsoft.AspNetCore.Identity;

namespace WebApplication2.Repositories.Interface
{
	public interface ITokenRepository
	{
		string CreateJwtToken(IdentityUser user, List<string> roles);
	}
}
