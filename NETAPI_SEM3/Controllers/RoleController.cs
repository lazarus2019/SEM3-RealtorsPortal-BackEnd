using Microsoft.AspNetCore.Mvc;
using NETAPI_SEM3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Controllers
{
    [Route("api/role")]
    public class RoleController : Controller
    {
        private readonly RoleService _roleService;

        public RoleController(RoleService roleService)
        {
            this._roleService = roleService;
        }

        [HttpGet]
        public IActionResult GetAllRole()
        {
            try
            {
                return Ok(_roleService.GetAllRoll());
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
