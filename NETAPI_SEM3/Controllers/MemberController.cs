using Microsoft.AspNetCore.Mvc;
using System;
using NETAPI_SEM3.Services;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using NETAPI_SEM3.Security;

namespace NETAPI_SEM3.Controllers
{
    [Route("api/member")]
    //[MyAuthorize(Roles = "SuperAdmin")]
    public class MemberController : Controller
    {
        private readonly MemberService _memberService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public MemberController(MemberService memberService, IMapper mapper, IConfiguration _configuration)
        {
            this._memberService = memberService;
            this._mapper = mapper;
            this._configuration = _configuration;
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

        [HttpGet("search/{fullName}/{roleId}/{status}")]
        public IActionResult SearchMember(string fullName, string roleId, string status)
        {
            try
            {
                return Ok(_memberService.SearchMember(fullName, roleId, status));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("search/{fullName}/{roleId}/{status}/{page}")]
        public IActionResult SearchMemberPage(string fullName, string roleId, string status, int page)
        {
            try
            {
                return Ok(_memberService.SearchMemberPage(fullName, roleId, status, page));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("updateStatus/{id:int}")]
        public IActionResult UpdateStatus(int id, [FromBody] bool status)
        {
            try
            {
                _memberService.UpdateStatus(id, status);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
