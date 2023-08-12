using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using User.Management.API.Models;
using User.Management.API.Models.Authentication.Login;
using User.Management.API.Models.Authentication.SignUp;

namespace User.Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _configuaration;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthenticationController(IConfiguration configuaration,
                                        UserManager<IdentityUser> userManager,
                                        RoleManager<IdentityRole> roleManager)
        {
            this._configuaration = configuaration;
            this._userManager = userManager;
            this._roleManager = roleManager;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUser request)
        {
            var userExist = await _userManager.FindByEmailAsync(request.Email);
            if(userExist != null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new Response
                {
                    Status = "Error",
                    Message = "User already exists!"
                });
            }
            //add a user in the database
            IdentityUser user = new IdentityUser() { 
            Email=request.Email,
            SecurityStamp=Guid.NewGuid().ToString(),
            UserName=request.Username
            };
            //{ Failed: PasswordRequiresNonAlphanumeric,PasswordRequiresDigit,PasswordRequiresUpper}
            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
                return StatusCode(StatusCodes.Status201Created, new Response
                {
                    Status = "Error",
                    Message = "User created successfully!"
                });
            }
            else
            {
                var errors = result.Errors.Select(e => e.Description).ToList();
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                {
                    Status = "Error",
                    Message = "User failed to create!",
                    Errors = errors
                });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel request)
        {

        }
    }
}
