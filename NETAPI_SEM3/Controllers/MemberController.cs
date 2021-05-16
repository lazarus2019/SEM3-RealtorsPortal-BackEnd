﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NETAPI_SEM3.Entities;
using NETAPI_SEM3.ViewModel;
using NETAPI_SEM3.Services;
using AutoMapper;

namespace NETAPI_SEM3.Controllers
{
    [Route("api/member/")]
    public class MemberController : Controller
    {
        private readonly MemberService _memberService;
        private readonly IMapper _mapper;

        public MemberController(MemberService memberService, IMapper mapper)
        {
            this._memberService = memberService;
            this._mapper = mapper;
        }

        [Route("getallmember")]
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
    }
}
