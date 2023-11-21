using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models.DTO;
using WebApplication2.Repositories.Interface;

namespace WebApplication2.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly UserManager<IdentityUser> _userManager;
		private readonly ITokenRepository _tokenRepository;

		public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
			_userManager = userManager;
			_tokenRepository = tokenRepository;
		}



		//POST: {apibaseurl}/api/auth/loginn
		[HttpPost]
		[Route("login")]
		public async Task<IActionResult> Login([FromBody] LoginRequest request)
		{
			//check email
			var identityUser = await _userManager.FindByEmailAsync(request.Email);

			if (identityUser != null)
			{
				//check password
				var checkPasswordResult = await _userManager.CheckPasswordAsync(identityUser, request.Password);
                if (checkPasswordResult)
                {
					var roles = await _userManager.GetRolesAsync(identityUser);


					//Create token and resposne 
					var jwtToken= _tokenRepository.CreateJwtToken(identityUser, roles.ToList());

					var resposne = new LoginResponse()
					{
						Email = request.Email,
						Roles = roles.ToList(),
						Token = jwtToken
					};

					return Ok(resposne);
                }
            }
			ModelState.AddModelError("", "Email or Password Incorrect");

			return ValidationProblem(ModelState);
		}


        //POST: {apibaseurl}/api/auth/register
        [HttpPost]
		public async Task<IActionResult> Register([FromBody] RegisterRequest request)
		{
			//Create IdentityUser object
			var user = new IdentityUser
			{
				UserName = request.Email?.Trim(),
				Email = request.Email?.Trim(),
			};

			//create user
			var identityResult = await _userManager.CreateAsync(user, request.Password);

			if(identityResult.Succeeded)
			{
				//add role to user
				identityResult = await _userManager.AddToRoleAsync(user, "Reader");
				if(identityResult.Succeeded)
				{
					return Ok();
				}
				else
				{
					if (identityResult.Errors.Any())
					{
						foreach (var error in identityResult.Errors)
						{
							ModelState.AddModelError("", error.Description);
						}
					}
				}
			}
			else
			{
				if(identityResult.Errors.Any())
				{
					foreach(var error in identityResult.Errors)
					{
						ModelState.AddModelError("", error.Description);
					}
				}
			}

			return ValidationProblem(ModelState);

		}
	}
}
