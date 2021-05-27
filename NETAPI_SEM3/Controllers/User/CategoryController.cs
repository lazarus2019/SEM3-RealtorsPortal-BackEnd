using Microsoft.AspNetCore.Mvc;
using NETAPI_SEM3.Services;
using NETAPI_SEM3.Services.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Controllers.User
{
    [Route("api/user/")]
    public class CategoryController : Controller
    {
        private CategoryService categoryService;
        private UserService userService;
        public CategoryController(CategoryService _categoryService, UserService _userService)
        {
            categoryService = _categoryService;
            userService = _userService; 
        }

        [Produces("application/json")]
        [HttpGet("getallcategory")]
        public IActionResult getAllCategory()
        {
            try
            {
                var categories = categoryService.getAllCategory();
                return Ok(categories);
            }
            catch (Exception e2)
            {
                return BadRequest(e2.Message); 
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpGet("propertybycategory/{categoryId}")]
        public IActionResult PropertyByCategory(int categoryId)
        {
            try
            {
                var properties = categoryService.PropertyByCategory(categoryId);
                return Ok(properties);
            }
            catch (Exception e2)
            {
                return BadRequest(e2.Message);
            }
        }
    }
}
