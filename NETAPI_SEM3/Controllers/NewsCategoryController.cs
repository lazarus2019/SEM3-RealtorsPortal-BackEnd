using Microsoft.AspNetCore.Mvc;
using NETAPI_SEM3.Models;
using NETAPI_SEM3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Controllers
{
	[Route("api/admin/newsCategory")]
	public class NewsCategoryController : Controller
	{
		private NewsCategoryService newsCategoryService;

		public NewsCategoryController(NewsCategoryService _newsCategoryService)
		{
			newsCategoryService = _newsCategoryService;
		}

		[Produces("application/json")]
		[HttpGet("getAllNewsCategory")]
		public IActionResult getAllNewsCategory()
		{
			try
			{
				return Ok(newsCategoryService.getAllNewsCategory());
			}
			catch
			{
				return StatusCode(500, "Can not get category");
			}
		}

		[Produces("application/json")]
		[HttpPost("createNewsCategory")]
		public IActionResult createNewsCategory([FromBody] NewsCategory newsCategory)
		{
			try
			{
				return Ok(newsCategoryService.createNewsCategory(newsCategory));
			}
			catch
			{
				return StatusCode(500, "Can not get category");
			}
		}

		[Produces("application/json")]
		[HttpGet("findNewsCategory/{newsId}")]
		public IActionResult findNewsCategory(int newsId)
		{

			try
			{
				return Ok(newsCategoryService.findNewsCategory(newsId));
			}
			catch
			{
				return StatusCode(500, "Can not get news");
			}
		}

		[HttpDelete("deleteNewsCategory/{newId}")]
		public IActionResult deleteNewsCategory(int newId)
		{
			try
			{
				if (newsCategoryService.deleteNewsCategory(newId))
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
		[HttpPut("updateNewsCategory")]
		[Consumes("application/json")]
		public IActionResult updateNewsCategory([FromBody] NewsCategory newsCategory)
		{
			try
			{
				if (newsCategoryService.updateNewsCategory(newsCategory))
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


	}
}
