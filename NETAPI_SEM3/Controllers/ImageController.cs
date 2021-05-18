using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NETAPI_SEM3.Models;
using NETAPI_SEM3.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Controllers
{

	[Route("api/upload")]
	[ApiController]
	public class ImageController : ControllerBase
	{
		private NewsImageService newsImageService;
		private IWebHostEnvironment iwebHostEnvironment;

		public ImageController(IWebHostEnvironment _iwebHostEnvironment, NewsImageService _newsImageService)
		{
			iwebHostEnvironment = _iwebHostEnvironment;
			newsImageService = _newsImageService;
		}

		[DisableRequestSizeLimit]
		[HttpPost("news/{newsId}")]
		public IActionResult UploadNews(int newsId, IFormFile file)
		{
			try
			{
				Debug.WriteLine(newsId);
				Debug.WriteLine(file.FileName);
				var folderName = Path.Combine("images", "news");
				var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

				if (file.Length > 0)
				{
					var dateTime = DateTime.Now.ToString("ddMMyyyyHHmmss");
					var fileName = dateTime + ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
					var fullPath = Path.Combine(iwebHostEnvironment.WebRootPath, "images/news", fileName);
					var dbPath = Path.Combine(folderName, fileName);

					using (var stream = new FileStream(fullPath, FileMode.Create))
					{
						file.CopyTo(stream);
					}
					if (newsId != 0)
					{
						var image = new NewsImage
						{
							NewsId = newsId,
							Name = fileName
						};
						var result = newsImageService.createNewsImage(image);
						if (!result)
						{
							return StatusCode(500, "Lỗi k tạo được newsImage");
						}
					}
					else
					{
						return StatusCode(500, "Lỗi k nhận được id");
					}
					return Ok();

			}
				else
			{
				return StatusCode(500, "Lỗi truyền file");
			}

		}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex}");
			}
		}
	}
}
