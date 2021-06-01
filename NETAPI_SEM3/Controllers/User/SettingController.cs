using Microsoft.AspNetCore.Mvc;
using NETAPI_SEM3.Services.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Controllers.User
{
    [Route("api/user/")]
    public class SettingController : Controller
    {
        private SettingService settingService;

        public SettingController(SettingService _settingService)
        {
            settingService = _settingService;
        }
        [Produces("application/json")]
        [HttpGet("getallsetting")]
        public IActionResult LoadSetting()
        {
            try
            {
                var settings = settingService.getAllSetting();
                return Ok(settings);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
