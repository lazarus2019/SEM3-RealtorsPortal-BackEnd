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
using System.Diagnostics;

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
            //  return BadRequest("Your email was not confirmed.");


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
                Email = model.Email,

            };

            // create account aspnetuser
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // set role
                await _userManager.AddToRoleAsync(user, model.Role);

                // create Member
                var member = new Member
                {
                    AccountId = user.Id,
                    Username = user.UserName,
                    FullName = model.FullName,
                    Status = true,
                    Email = user.Email,
                    RoleId = model.Role,
                    Photo = "avatar.png",
                    CreateDate = DateTime.Now
                };
                _memberService.CreateMember(member);

                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                var encodedEmailToken = Encoding.UTF8.GetBytes(token);
                var validEmailToken = WebEncoders.Base64UrlEncode(encodedEmailToken);

                var mailHelper = new MailHelper(_configuration);
                var body = mailHelper.GetMailBody(user.Id, validEmailToken);
                mailHelper.Send(_configuration["Gmail:Username"], model.Email, "Confirm Your Email", body);

                return Ok();
            }

            return BadRequest("Register is unsuccessful.");
        }


        [HttpGet("emailconfirmation")]
        public async Task<IActionResult> EmailConfirmation([FromQuery] string userId, [FromQuery] string token)
        {
            //var contentError = new ContentResult
            //{
            //    ContentType = "text/html",
            //    Content = "<div>Loi hihi</div>"
            //};

            var contentError = BadRequest();

            if (userId == null || token == null)
            {
                return contentError;
            }

            var decodedToken = WebEncoders.Base64UrlDecode(token);
            string normalToken = Encoding.UTF8.GetString(decodedToken);

            //var callback = QueryHelpers.AddQueryString(userForRegistration.ClientURI, param);


            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return contentError;

            var confirmResult = await _userManager.ConfirmEmailAsync(user, normalToken);

            if (!confirmResult.Succeeded)
                return contentError;

            //return new ContentResult
            //{
            //    ContentType = "text/html",
            //    Content = "<div>Hello World</div>"
            //};

            return Redirect("https://google.com");
        }
    }
}
