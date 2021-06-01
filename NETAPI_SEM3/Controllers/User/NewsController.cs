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

        //Get News Start
        [Produces("application/json")]
        [HttpGet("getallnews/{page}/{numNewsPerPage}")]
        public IActionResult GetAllNews(int page, int numNewsPerPage)
        {
            try
            {
                var news = newsBlogService.getAllNews(page, numNewsPerPage);

                return Ok(news);
            }
            catch
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("getallnewscount")]
        public IActionResult getAllNewsCount()
        {
            try
            {
                var count = newsBlogService.getIdNews();
                return Ok(count);
            }
            catch
            {
                return BadRequest();
            }
        }

        // news property
        [Produces("application/json")]
        [HttpGet("getallnewsid/{newsid}")]
        public IActionResult LoadPropertyId(int newsid)
        {
            try
            {
                var detail = newsBlogService.getAllNewsId(newsid);
                return Ok(detail);
            }
            catch
            {
                return BadRequest();
            }
        }

        // top 3 news find id
        [Produces("application/json")]
        [HttpGet("getallpropertys/{propertyID}")]
        public IActionResult LoadAllProperty(int propertyID)
        {
            try
            {
                var results = newsBlogService.getAllProperty(propertyID);
                return Ok(results);
            }
            catch
            {
                return BadRequest();
            }
        }

        //Get News Search
        [Produces("application/json")]
        [HttpGet("searchnewsresult/{titles}/{categoryId}")]
        public IActionResult SearchPropertyListingCount(string titles, int categoryId)
        {
            try
            {
                var newsresult = newsBlogService.getReasultNewsSearch( titles, categoryId);
                return Ok(newsresult);
            }
            catch (Exception e2)
            {
                return BadRequest(e2.Message);
            }
        }

        [Produces("application/json")]
        [HttpGet("searchnews/{page}/{titles}/{categoryId}")]
        public IActionResult SearchPropertyListing(int page, string titles, int categoryId)
        {
            try
            {
                var news = newsBlogService.getAllNewsSearch(page, titles, categoryId);
                return Ok(news);
            }
            catch (Exception e2)
            {
                return BadRequest(e2.Message);
            }
        }

        //Get All newcategory
        [Produces("application/json")]
        [HttpGet("getallnewscategory")]
        public IActionResult LoadNewsCategory()
        {
            try
            {
                var newscategories = newsBlogService.getAllNewsCategory();
                return Ok(newscategories);
            }
            catch
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("getGallery/{newsId}")]
        public IActionResult getGallery(int newsId)
        {
            try
            {
                return Ok(newsBlogService.getGallery(newsId));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}