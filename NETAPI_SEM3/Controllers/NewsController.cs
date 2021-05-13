using Microsoft.AspNetCore.Mvc;
using NETAPI_SEM3.Entities;
using NETAPI_SEM3.Models;
using NETAPI_SEM3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Controllers
{
	[Route("api/admin")]
	public class NewsController : Controller
	{
		private NewsService newsService;

		public NewsController(NewsService _newsService)
		{
			newsService = _newsService;
		}

		[Produces("application/json")]
		[HttpGet("getAllNews")]
		public IActionResult getAllNews()
		{
			try
			{
				return Ok(newsService.getAllNews());
			}
			catch
			{
				return BadRequest();
			}
		}

		[Produces("text/plain")]
		[HttpDelete("delete/{newId}")]
		public IActionResult deleteNews(int newId)
		{
			try
			{
				if (newsService.deleteNew(newId))
				{
					return Ok();
				}
				return BadRequest();
			}
			catch
			{
				return BadRequest();
			}
		}

		[Produces("application/json")]
		[HttpPost("createNews")]
		[Consumes("application/json")]
		public IActionResult createNews([FromBody] News news)
		{
			try
			{
				if (newsService.createNews(news))
				{
					return Ok();
				}
				return BadRequest();
			}
			catch
			{
				return BadRequest();
			}
		}

		[Produces("application/json")]
		[HttpGet("sortFilterNews/{title}/{category}/status")]
		public IActionResult sortFilterNews(string title, string category, bool status)
		{
			try
			{
				return Ok(newsService.getAllNews());
			}
			catch
			{
				return BadRequest();
			}
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
