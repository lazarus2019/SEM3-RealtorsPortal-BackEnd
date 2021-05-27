using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NETAPI_SEM3.Services.User;

namespace NETAPI_SEM3.Controllers.User
{
    [Route("api/user")]
    public class NewsController : Controller
    {
        private NewsBlogService newsBlogService;

        public NewsController(NewsBlogService _newsBlogService)
        {
            newsBlogService = _newsBlogService;
        }

        [Produces("application/json")]
        [HttpGet("loadnews")]
        public IActionResult LoadSeller()
        {
            try
            {
                var news = newsBlogService.loadnewCategory();

                return Ok(news);
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [HttpGet("newpropertyID/{propertyId}")]
        public IActionResult LoadPropertyId(int propertyId)
        {
            try
            {
                var detail = newsBlogService.loadnewCategoryId(propertyId);
                return Ok(detail);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}