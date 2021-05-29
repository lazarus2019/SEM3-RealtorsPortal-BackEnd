using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NETAPI_SEM3.Models;
using NETAPI_SEM3.ViewModel;
using NETAPI_SEM3.Services;
using AutoMapper;
using DemoSession16.Helpers;
using Microsoft.Extensions.Configuration;
using System.Security.Authentication;
using MailKit.Net.Smtp;
using MailKit.Net.Pop3;
using MailKit.Security;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using NETAPI_SEM3.Security;

namespace NETAPI_SEM3.Controllers
{
    [Route("api/member")]
    [MyAuthorize(Roles = "1")]
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
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
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
