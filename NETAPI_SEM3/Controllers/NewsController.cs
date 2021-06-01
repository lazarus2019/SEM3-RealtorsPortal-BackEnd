using Microsoft.AspNetCore.Mvc;
using NETAPI_SEM3.Entities;
using NETAPI_SEM3.Models;
using NETAPI_SEM3.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Controllers
{
	[Route("api/admin/news")]
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
				return StatusCode(500, "Can not get amount news");
			}
		}
		
		[Produces("application/json")]
		[HttpGet("getNewsPerPage/{page}")]
		public IActionResult getNewsPerPage(int page)
		{
			try
			{
				return Ok(newsService.getNewsPerPage(page));
			}
			catch
			{
				return StatusCode(500, "Can not get news per page");
			}
		}

		[Produces("application/json")]
		[HttpGet("findNews/{newsId}")]
		public IActionResult findNews(int newsId)
		{
			
			try
			{
				return Ok(newsService.findNews(newsId));
			}
			catch
			{
				return StatusCode(500, "Can not get news");
			}
		}

		[HttpDelete("deleteNews/{newId}")]
		public IActionResult deleteNews(int newId)
		{
			try
			{
				if (newsService.deleteNew(newId))
				{
					return Ok();
				}
				return StatusCode(500, "Can not delete news - Func");
			}
			catch
			{
				return StatusCode(500, "Can not delete news");
			}
		}

		[Produces("application/json")]
		[HttpPost("createNews")]
		[Consumes("application/json")]
		public IActionResult createNews([FromBody] News news)
		{
			try
			{
				var returnId = newsService.createNews(news);
				if (returnId != 0)
				{
					return Ok(returnId);
				}
				return StatusCode(500, "Can not update create news - Func");
			}
			catch
			{
				return StatusCode(500, "Can not update create news");
			}
		}

		[Produces("application/json")]
		[HttpPut("updateNews")]
		[Consumes("application/json")]
		public IActionResult updateNews([FromBody] News news)
		{
			try
			{
				if (newsService.updateNews(news))
				{
					return Ok();
				}
				return StatusCode(500, "Can not update news - Func");
			}
			catch
			{
				return StatusCode(500, "Can not update news");
			}
		}

		[Produces("application/json")]
		[HttpPut("updateStatus")]
		[Consumes("application/json")]
		public IActionResult updateStatus([FromBody] News news)
		{
			try
			{
				if (newsService.updateStatus(news))
				{
					return Ok();
				}
				return StatusCode(500, "Can not update status - Func");
			}
			catch
			{
				return StatusCode(500, "Can not update status");
			}
		}

		[Produces("application/json")]
		[HttpGet("filterNewsPerPage/{page}/{title}/{category}/{status}/{sortDate}")]
		public IActionResult filterNewsPerPage(int page, string title, string category, string status, string sortDate)
		{
			try
			{
				return Ok(newsService.filterNewsPerPage(page, title, category, status, sortDate));
			}
			catch
			{
				return StatusCode(500, "Can not get any data");
			}
		}

		[Produces("application/json")]
		[HttpGet("getAllFilterNews/{title}/{category}/{status}/{sortDate}")]
		public IActionResult getAllFilterNews(string title, string category, string status, string sortDate)
		{
			try
			{
				return Ok(newsService.getAllFilterNews(title, category, status, sortDate));
			}
			catch
			{
				return StatusCode(500, "Can not get amount news");
			}
		}

		[Produces("application/json")]
		[HttpGet("getGallery/{newsId}")]
		public IActionResult getGallery(int newsId)
		{
			try
			{
				return Ok(newsService.getGallery(newsId));
			}
			catch
			{
				return StatusCode(500, "Can not get gallery");
			}
		}

	}
}
