using Microsoft.AspNetCore.Mvc;
using NETAPI_SEM3.Models;
using NETAPI_SEM3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Controllers
{
	[Route("api/admin/setting")]
	public class SettingController : Controller
	{
		#region Injection Services
		private SettingService settingService;

		public SettingController(SettingService _settingService)
		{
			settingService = _settingService;
		}

		#endregion

		[Produces("application/json")]
		[HttpGet("getSetting")]
		public IActionResult getSetting()
		{
			try
			{
				return Ok(settingService.getSetting());
			}
			catch
			{
				return StatusCode(500, "Can not get setting!");
			}
		}

		[Produces("application/json")]
		[HttpPut("updateWebsiteSetting")]
		public IActionResult updateWebsiteSetting([FromBody]Setting setting)
		{
			try
			{
				var result = settingService.updateWebsiteSetting(setting);
				if (result)
				{
					return Ok();
				}
				return StatusCode(500, "Can not update setting! - Func");
			}
			catch
			{
				return StatusCode(500, "Can not update setting!");
			}
		}
		
		[Produces("application/json")]
		[HttpPut("updateAdminSetting")]
		public IActionResult updateAdminSetting([FromBody]Setting setting)
		{
			try
			{
				var result = settingService.updateAdminSetting(setting);
				if (result)
				{
					return Ok();
				}
				return StatusCode(500, "Can not update setting! - Func");
			}
			catch
			{
				return StatusCode(500, "Can not update setting!");
			}
		}
		
		[Produces("application/json")]
		[HttpPut("updateUserSetting")]
		public IActionResult updateUserSetting([FromBody]Setting setting)
		{
			try
			{
				var result = settingService.updateUserSetting(setting);
				if (result)
				{
					return Ok();
				}
				return StatusCode(500, "Can not update setting! - Func");
			}
			catch
			{
				return StatusCode(500, "Can not update setting!");
			}
		}

		[Produces("application/json")]
		[HttpGet("getMaxNewsImage")]
		public IActionResult getMaxNewsImage()
		{
			try
			{
				return Ok(settingService.getMaxNewsImage());
			}
			catch
			{
				return StatusCode(500, "Can not get max news image!");
			}
		}

	}
}
