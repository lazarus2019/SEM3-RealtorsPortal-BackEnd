using Microsoft.AspNetCore.Mvc;
using NETAPI_SEM3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Controllers
{
	[Route("api/user")]
	public class UserController : Controller
	{
		private UserService userService;

		public UserController(UserService _userService)
		{
			userService = _userService;
		}

		[Produces("application/json")]
		[HttpGet("getsetting")]
		public IActionResult GetSetting()
		{
			try
			{
				var setting = userService.GetSetting();
				return Ok(setting);
			}
			catch
			{
				return BadRequest();
			}
		}

	}
}
