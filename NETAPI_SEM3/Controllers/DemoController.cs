using Microsoft.AspNetCore.Mvc;
using NETAPI_SEM3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Controllers
{
	[Route("api/demo")]
	public class DemoController : Controller
	{
		private DemoService demoService;

		public DemoController(DemoService _demoService)
		{
			demoService = _demoService;
		}

		[Produces("application/json")]
		[HttpGet("demo1")]
		public IActionResult Demo1()
		{
			try
			{
				return Ok();
			}
			catch
			{
				return BadRequest();
			}
		}

	}
}
