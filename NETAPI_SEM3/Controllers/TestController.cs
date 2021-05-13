using Microsoft.AspNetCore.Mvc;
using NETAPI_SEM3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Controllers
{
	[Route("api/test")]
	public class TestController : Controller
	{
		private NewsService newsService;

		public TestController(NewsService _newsService)
		{
			newsService = _newsService;
		}
		[Produces("application/json")]
		[HttpGet("getAllNewsCategory")]
		public IActionResult getAllNewsCategory()
		{
			try
			{
				return Ok(newsService.getAllNewsCategory());
			}
			catch
			{
				return BadRequest();
			}
		}
	}
}
