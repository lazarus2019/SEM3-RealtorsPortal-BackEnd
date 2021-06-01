using Microsoft.AspNetCore.Mvc;
using System;
using NETAPI_SEM3.Services;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using NETAPI_SEM3.Security;
using Microsoft.AspNetCore.Identity;
using NETAPI_SEM3.ViewModel;
using NETAPI_SEM3.Models;

namespace NETAPI_SEM3.Controllers
{
    [Route("api/member")]
    //[MyAuthorize(Roles = "SuperAdmin")]
    public class MemberController : Controller
    {
        private readonly MemberService _memberService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly UserManager<IdentityUser> _userManager;

        public MemberController(MemberService memberService, IMapper mapper, IConfiguration _configuration, UserManager<IdentityUser> userManager)
        {
            this._memberService = memberService;
            this._mapper = mapper;
            this._configuration = _configuration;
            this._userManager = userManager;
        }

        [HttpGet]
        public IActionResult GetAllMember()
        {
            try
            {
                return Ok(_memberService.GetAllMember());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{page}")]
        public IActionResult GetAllMemberPage(int page)
        {
            try
            {
                return Ok(_memberService.GetAllMemberPage(page));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("search/{fullName}/{position}/{status}")]
        public IActionResult SearchMember(string fullName, string position, string status)
        {
            try
            {
                return Ok(_memberService.SearchMember(fullName, position, status));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("search/{fullName}/{position}/{status}/{page}")]
        public IActionResult SearchMemberPage(string fullName, string position, string status, int page)
        {
            try
            {
                return Ok(_memberService.SearchMemberPage(fullName, position, status, page));
            }
            catch
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPut("updateStatus/{memberId}/{userId}")]
        public IActionResult UpdateStatus(int memberId, string userId, [FromBody] bool status)
        {
            try
            {
                var userTask = _userManager.FindByIdAsync(userId);
                userTask.Wait();
                var user = userTask.Result;

                if (status == true)
                {
                    _userManager.SetLockoutEnabledAsync(user, false);
                }
                else
                {
                    _userManager.SetLockoutEnabledAsync(user, true);
                }
                _memberService.UpdateStatus(memberId, status);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

    }
}
