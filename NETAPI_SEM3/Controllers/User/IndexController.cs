using Microsoft.AspNetCore.Mvc;
using NETAPI_SEM3.Models;
using NETAPI_SEM3.Services.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Controllers.User
{
    [Route("api/user/")]
    public class IndexController : Controller
    {

        private IndexService indexService;
        public IndexController(IndexService _indexService)
        {
            indexService = _indexService;
        }

        [Produces("application/json")]
        [HttpGet("loadtopproperty")]
        public IActionResult LoadTopProperty()
        {
            try
            {
                var properties = indexService.LoadTopProperty();                 
                return Ok(properties);
            }
            catch( Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Produces("application/json")]
        [HttpGet("loadpopularlocation")]
        public IActionResult LoadCategoriesNumber()
        {
            try
            {
                var categories = indexService.LoadPopularLocations(); 
                
                return Ok(categories);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("loadcountries")]
        public IActionResult LoadCountries()
        {
            try
            {
                var countries = indexService.LoadCountries();
                return Ok(countries); 
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("loadcategories")]
        public IActionResult LoadCategories()
        {
            try
            {
                var countries = indexService.LoadCategories();
                return Ok(countries); 
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
