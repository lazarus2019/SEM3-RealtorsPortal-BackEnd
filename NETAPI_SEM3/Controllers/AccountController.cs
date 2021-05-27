using Microsoft.AspNetCore.Mvc;
using NETAPI_SEM3.Services;
using NETAPI_SEM3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NETAPI_SEM3.ViewModel;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace NETAPI_SEM3.Controllers
{
    [Route("api/account")]
    public class AccountController : Controller
    {
        private readonly AccountService _accountService;
        private readonly IConfiguration _configuration;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(
            AccountService accountService,
            IConfiguration configuration,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager
            )
        {
            this._accountService = accountService;
            this._configuration = configuration;
            this._userManager = userManager;
            this._signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody]AccountViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.FindByNameAsync(model.Username);

            if (user == null)
                return BadRequest("Username or password is incorrect.");

            var isValidPassword = await _userManager.CheckPasswordAsync(user, model.Password);

            if (!isValidPassword)
                return BadRequest("Password is incorrect.");

            var resultToken = await GenerateToken(model);


            // Return token to user
            return Ok(new { resultToken });
        }

        private async Task<string> GenerateToken(AccountViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Username);

            // danh sách role của thằng user
            var roles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Role, string.Join(";",roles)),
                new Claim(ClaimTypes.Name, model.Username)            
            };



            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            var token = new JwtSecurityToken(_configuration["Tokens:Issuer"],
                  _configuration["Tokens:Issuer"],
                  claims,
                  expires: DateTime.Now.AddHours(3),
                  signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] AccountViewModel request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var hasUser = await _userManager.FindByEmailAsync(request.Username);//check username exist

            if (hasUser != null)
                return BadRequest("email da ton tai");

            var user = new IdentityUser
            {
                UserName = request.Username,
                PhoneNumber = "12345678",
                Email = request.Username,
                
            };
            
           

            // tạo account aspnetuser
            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                // set role
                await _userManager.AddToRoleAsync(user, request.Role);
                
                var member = new Member
                {
                    AccountId = user.Id,
                    Username = user.UserName,
                    Phone = user.PhoneNumber,
                    Status = true

                };
                // TODO: 
                //tao service add member
                return Ok();
            }

            return BadRequest("Register is unsuccessful.");


        }
    }
}
