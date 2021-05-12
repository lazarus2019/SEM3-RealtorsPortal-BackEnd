using Microsoft.AspNetCore.Mvc;
using NETAPI_SEM3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Controllers
{
	[Route("api/admin")]
	public class DemoController : Controller
	{
		private DemoService demoService;

		public DemoController(DemoService _demoService)
		{
			demoService = _demoService;
		}

		[Produces("application/json")]
		[HttpGet("getAllNews")]
		public IActionResult getAllNews()
		{
			try
			{
				return Ok(demoService.getAllNews());
			}
			catch
			{
				return BadRequest();
			}
		}

	}
}
