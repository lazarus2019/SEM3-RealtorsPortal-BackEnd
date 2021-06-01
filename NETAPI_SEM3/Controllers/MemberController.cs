using Microsoft.AspNetCore.Mvc;
using NETAPI_SEM3.Models;
using NETAPI_SEM3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Controllers
{
	[Route("api/admin/member")]
	public class MemberController : Controller
	{
		private MemberService memberService;

		public MemberController(MemberService _memberService)
		{
			memberService = _memberService;
		}

		[Produces("application/json")]
		[HttpPut("updateMember")]
		public IActionResult updateMember([FromBody] Member member)
		{
			try
			{
				if (memberService.updateMember(member))
				{
					return Ok();
				}
				return StatusCode(500, "Can not update member - Func");
			}
			catch
			{
				return StatusCode(500, "Can not update member");
			}
		}

		[Produces("application/json")]
		[HttpGet("findUser/{userId}")]
		public IActionResult findUser(string userId)
		{
			try
			{
				return Ok(memberService.findUser(userId));
			}
			catch
			{
				return StatusCode(500, "Can not update member");
			}
		}
	}
}
