using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NETAPI_SEM3.Models;
using NETAPI_SEM3.Services;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http.Headers;

namespace NETAPI_SEM3.Controllers
{

	[Route("api/image")]
	[ApiController]
	public class ImageController : ControllerBase
	{
		#region Injection
		private NewsImageService newsImageService;
		private MemberService memberService;
		private SettingService settingService;
		private IWebHostEnvironment iwebHostEnvironment;

		public ImageController(IWebHostEnvironment _iwebHostEnvironment, NewsImageService _newsImageService, MemberService _memberService, SettingService _settingService)
		{
			iwebHostEnvironment = _iwebHostEnvironment;
			newsImageService = _newsImageService;
			memberService = _memberService;
			settingService = _settingService;
		}

		#endregion

		#region Property, News, Member
		[DisableRequestSizeLimit]
		[HttpPost("upload/{id}/{directName}")]
		public IActionResult UploadImage(int id, string directName, IFormFile file)
		{
			try
			{
				var folderName = Path.Combine("images", directName);
				var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

				if (file.Length > 0)
				{
					var dateTime = DateTime.Now.ToString("ddMMyyyyHHmmss");
					var fileName = dateTime + ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
					var fullPath = Path.Combine(iwebHostEnvironment.WebRootPath, "images/" + directName, fileName);
					var dbPath = Path.Combine(folderName, fileName);

					using (var stream = new FileStream(fullPath, FileMode.Create))
					{
						file.CopyTo(stream);
					}
					if (id != 0)
					{
						if (directName.ToLower().Equals("news"))
						{
							var result = createNewsImage(id, fileName);
							if (!result)
							{
								return StatusCode(500, "Lỗi k tạo được newsImage");
							}
						}
						if (directName.ToLower().Equals("property"))
						{

						}
						if (directName.ToLower().Equals("member"))
						{
							var result = changeMemberImage(id, fileName);
							if (!result)
							{
								return StatusCode(500, "Lỗi k doi được member Image");
							}
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

		[HttpDelete("delete/{id}/{name}/{directName}")]
		public IActionResult DeleteImage(int id, string name, string directName)
		{
			var result = false;
			if (directName.ToLower().Equals("news"))
			{
				result = deleteNewsImage(id);
				if (!result)
				{
					return StatusCode(500, "Can not delete file in database");
				}
			}
			if (directName.ToLower().Equals("property"))
			{

			}
			if (directName.ToLower().Equals("member"))
			{
				result = true;
			}

			string fullPath = Path.Combine(iwebHostEnvironment.WebRootPath, "images/" + directName, name);

			if (result)
			{
				if (System.IO.File.Exists(fullPath))
				{
					try
					{
						if (!name.Equals("avatar.png"))
						{
							System.IO.File.Delete(fullPath);
							return Ok();
						}
						return Ok();
					}
					catch
					{
						return StatusCode(500, "Can not delete file folder wwwroot");
					}
				}
			}
			else
			{
				return StatusCode(500, "Can not delete file in database");
			}

			return StatusCode(500, "Can not perform delete image in database & folder!");
		}

		#endregion

		#region Template User
		[HttpPost("uploadSingle/{column}/{directName}")]
		public IActionResult UploadSingleImage(string column, string directName, IFormFile file)
		{
			try
			{
				var folderName = Path.Combine("images", directName);
				var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

				if (file.Length > 0)
				{
					var dateTime = DateTime.Now.ToString("ddMMyyyyHHmmss");
					var fileName = dateTime + ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
					var fullPath = Path.Combine(iwebHostEnvironment.WebRootPath, "images/" + directName, fileName);
					var dbPath = Path.Combine(folderName, fileName);

					using (var stream = new FileStream(fullPath, FileMode.Create))
					{
						file.CopyTo(stream);
					}
					if (column != "")
					{
						if (column.ToLower().Equals("thumbnailaboutus"))
						{
							var result1 = settingService.updateThumbnailAboutUs(fileName);
							if (!result1)
							{
								return StatusCode(500, "Lỗi doi duoc ten trong database");
							}
						}
						if (column.ToLower().Equals("thumbnailhome"))
						{
							var result1 = settingService.updateThumbnailHome(fileName);
							if (!result1)
							{
								return StatusCode(500, "Lỗi doi duoc ten trong database");
							}
						}
						if (column.ToLower().Equals("thumbnailwebsite"))
						{
							var result1 = settingService.updateThumbnailWebsite(fileName);
							if (!result1)
							{
								return StatusCode(500, "Lỗi doi duoc ten trong database");
							}
						}
					}
					else
					{
						return StatusCode(500, "Lỗi k nhận được ten column");
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

		[HttpDelete("deleteSingle/{name}/{directName}")]
		public IActionResult DeleteSingleImage(string name, string directName)
		{
			string fullPath = Path.Combine(iwebHostEnvironment.WebRootPath, "images/" + directName, name);

			if (System.IO.File.Exists(fullPath))
			{
				try
				{
					System.IO.File.Delete(fullPath);
					return Ok();
				}
				catch
				{
					return StatusCode(500, "Can not delete file folder wwwroot");
				}
			}
			else
			{
				return StatusCode(500, "Can not delete image cause it doesn't exist!");
			}
		}


		#endregion

		#region Image News
		public bool createNewsImage(int newsId, string fileName)
		{
			try
			{
				var image = new Image
				{
					NewsId = newsId,
					Name = fileName
				};
				var result = newsImageService.createNewsImage(image);
				if (!result)
				{
					return false;
				}
				return true;
			}
			catch
			{
				return false;
			}

		}

		public bool deleteNewsImage(int newsImageId)
		{
			if (newsImageService.deleteNewsImage(newsImageId))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		#endregion

		#region Image Member

		public bool changeMemberImage(int memberId, string fileName)
		{
			try
			{
				var result = memberService.changeMemberImage(memberId, fileName);
				if (result)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			catch
			{
				return false;
			}

		}
		#endregion
	}
}
