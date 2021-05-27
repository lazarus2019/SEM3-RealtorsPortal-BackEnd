using Microsoft.AspNetCore.Mvc;
using NETAPI_SEM3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Controllers
{
    [Route("api/status")]
    public class StatusController : Controller
    {
        private readonly StatusService statusService;

        public StatusController(StatusService statusService)
        {
            this.statusService = statusService;
        }

        [HttpGet]
        public IActionResult GetAllCategory()
        {
            try
            {
                return Ok(statusService.GetAllStatus());
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
