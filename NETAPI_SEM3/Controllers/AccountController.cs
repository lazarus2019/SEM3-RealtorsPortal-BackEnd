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
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.AspNetCore.Http;
//using AspNetCore.MailKit.Core;
//using CompanyEmployees.JwtFeatures;

using System.Web;
using System.IO;
using System.Reflection;
using DemoSession16.Helpers;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using Microsoft.Extensions.Logging;
using System.Security.Policy;

namespace NETAPI_SEM3.Controllers
{
    [Route("api/account")]
    public class AccountController : Controller
    {
        private readonly AccountService _accountService;
        private readonly MemberService _memberService;
        private readonly IConfiguration _configuration;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(
            AccountService accountService,
            MemberService memberService,
            IConfiguration configuration,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager
            )
        {
            this._accountService = accountService;
            this._memberService = memberService;
            this._configuration = configuration;
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._roleManager = roleManager;
        }

        [HttpPost("sendEmail")]
        public IActionResult Send([FromBody] MailRequest mailRequest)
        {
            try
            {
                var mailHelper = new MailHelper(_configuration);
                mailHelper.Send(_configuration["Gmail:Username"], mailRequest.email, mailRequest.subject, mailRequest.content);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] AccountViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.FindByNameAsync(model.Username);

            if (user == null)
                return BadRequest("Username or password is incorrect.");


            //if (!await _userManager.IsEmailConfirmedAsync(user))
            //    return Unauthorized(new AuthResponseDto { ErrorMessage = "Email is not confirmed" });

            //check password
            if (!await _userManager.CheckPasswordAsync(user, model.Password))
            {
                return Unauthorized("Invalid Authentication");
            }

            var resultToken = await GenerateToken(model);
            var role = await _userManager.GetRolesAsync(user);

            // Return token to user
            return Ok(new
            {
                token = resultToken,
                username = user.UserName,
                userId = user.Id,
                role = role
            });
        }

        private async Task<string> GenerateToken(AccountViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Username);

            // danh sách role của thằng user
            //var roles = await _userManager.GetRolesAsync(user);
            //var role = await _userManager.GetRolesAsync(user);
            IdentityOptions _options = new IdentityOptions();

            var claims = new List<Claim>
            {
                new Claim("Username", model.Username),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            var token = new JwtSecurityToken(_configuration["Tokens:Issuer"],
                  _configuration["Tokens:Issuer"],
                  claims,
                  expires: DateTime.Now.AddDays(30),
                  signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] AccountViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var hasUser = await _userManager.FindByEmailAsync(model.Username);//check username exist

            if (hasUser != null)
                return BadRequest("email da ton tai");

            var user = new IdentityUser
            {
                UserName = model.Username,
                Email = model.Username,

            };

            // tạo account aspnetuser
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // set role
                await _userManager.AddToRoleAsync(user, model.Role);

                var member = new Member
                {
                    AccountId = user.Id,
                    Username = user.UserName,
                    FullName = model.FullName,
                    Status = true,
                    Email = user.Email,
                    RoleId = model.Role,
                    Phone = "avatar.png",
                    CreateDate = DateTime.Now
                };
                // TODO: 
                _memberService.CreateMember(member);
                //confirm email
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                var confirmLink = Url.Action("EmailConfirmation", "api/account", new { userId = user.Id, token = token }, Request.Scheme);

                //_logger.Log(LogLevel.Warning, confirmLink);


                var mailHelper = new MailHelper(_configuration);
                //var body = mailHelper.GetMailBody(model.Username);
                mailHelper.Send(_configuration["Gmail:Username"], model.Email, "Confirm Your Email", confirmLink);

                return Ok();
            }

            return BadRequest("Register is unsuccessful.");
        }


        [HttpGet("emailconfirmation")]
        public async Task<IActionResult> EmailConfirmation([FromQuery] string userId, [FromQuery] string token)
        {
            if(userId == null || token == null)
            {
                return BadRequest("UserId or token is invalid");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return BadRequest("Invalid Email Confirmation Request");

            var confirmResult = await _userManager.ConfirmEmailAsync(user, token);
            if (!confirmResult.Succeeded)
                return BadRequest("Invalid Email Confirmation Request");

            return Ok();
        }
    }
}
