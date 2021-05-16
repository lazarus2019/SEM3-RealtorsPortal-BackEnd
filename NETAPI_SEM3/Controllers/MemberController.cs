using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NETAPI_SEM3.Entities;
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

namespace NETAPI_SEM3.Controllers
{
    [Route("api/member/")]
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

        [HttpPost("sendEmail")]
        public IActionResult Send([FromBody] MailRequest mailRequest)
        {
            try
            {
                Debug.WriteLine("subject: " + mailRequest.subject);
                Debug.WriteLine("subject: " + mailRequest.email);
                var mailHelper = new MailHelper(_configuration);
                mailHelper.Send(mailRequest.email, _configuration["Gmail:Username"], mailRequest.subject, mailRequest.content);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }


    }
}
