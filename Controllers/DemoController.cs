using ASP_APIServer1.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_APIServer1.Controllers
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
