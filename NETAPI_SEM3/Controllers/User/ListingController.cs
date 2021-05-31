using Microsoft.AspNetCore.Mvc;
using NETAPI_SEM3.Services.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Controllers.User
{
    [Route("api/user/")]
    public class ListingController : Controller
    {
        private ListingService listingService;

        
        public ListingController(ListingService _listingService)
        {
            listingService = _listingService;
        }



        #region getAllListing
        [Produces("application/json")]
        [HttpGet("getalllisting/{page}")]
        public IActionResult GetAllListing(int page)
        {
            try
            {
                var listings = listingService.GetAllListing(page);
                return Ok(listings);
            }
            catch ( Exception e2)
            {
                return BadRequest(e2.Message);
            }
        }
        [Produces("application/json")]
        [HttpGet("getlistingcount")]
        public IActionResult GetListingCount()
        {
            try
            {
                var listingCount = listingService.GetListingCount();
                return Ok(listingCount);
            }
            catch ( Exception e2)
            {
                return BadRequest(e2.Message);
            }
        }

        #endregion

        #region search
        [Produces("application/json")]
        [HttpGet("searchproperty/{keyword}/{categoryId}/{countryId}/{page}")]
        public IActionResult SearchProperty(string keyword, int categoryId, int countryId, int page )
        {
            try
            {
                var listings = listingService.SearchProperty( keyword, categoryId, countryId , page);
                return Ok(listings);
            }
            catch (Exception e2)
            {
                return BadRequest(e2.Message);
            }
        }
        
        [Produces("application/json")]
        [HttpGet("searchpropertycount/{keyword}/{categoryId}/{countryId}")]
        public IActionResult SearchPropertyCount(string keyword, int categoryId, int countryId)
        {
            try
            {
                var listingCount = listingService.SearchPropertyCount(keyword, categoryId, countryId);
                return Ok(listingCount);
            }
            catch (Exception e2)
            {
                return BadRequest(e2.Message);
            }
        }
        

        [Produces("application/json")]
        [HttpGet("searchpropertylisting/{keyword}/{categoryId}/{countryId}/{city}/{type}/{area}/{bed}/{room}/{price}/{page}")]
        public IActionResult SearchPropertyListing(string keyword, int categoryId, int countryId, int city, string type, double area, int bed, int room, double price ,int page)
        {
            try
            {
                var listingCount = listingService.SearchPropertyListing(keyword, categoryId, countryId , city, type, area, bed, room, price, page );
                return Ok(listingCount);
            }
            catch (Exception e2)
            {
                return BadRequest(e2.Message);
            }
        }
        [Produces("application/json")]
        [HttpGet("searchpropertylistingcount/{keyword}/{categoryId}/{countryId}/{city}/{type}/{area}/{bed}/{room}/{price}")]
        public IActionResult SearchPropertyListingCount(string keyword, int categoryId, int countryId, int city, string type, double area, int bed, int room, double price)
        {
            try
            {
                var listingCount = listingService.SearchPropertyListingCount(keyword, categoryId, countryId , city, type, area, bed, room, price);
                return Ok(listingCount);
            }
            catch (Exception e2)
            {
                return BadRequest(e2.Message);
            }
        }

        #endregion

        #region single_property
        [Produces("application/json")]
        [HttpGet("propertydetail/{propertyId}")]
        public IActionResult PropertyDetail(int propertyId)
        {
            try
            {
                var detail = listingService.PropertyDetail(propertyId);
                return Ok(detail);
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [HttpGet("getpopularpost/{memberId}")]
        public IActionResult Popularpost(int memberId)
        {
            try
            {
                var listing = listingService.GetPopularPost(memberId);
                return Ok(listing); 
            }
            catch
            {
                return BadRequest();
            }
        }

        #endregion

        #region city region country
        [Produces("application/json")]
        [HttpGet("loadregion")]
        public IActionResult LoadRegion()
        {
            try
            {
                var regions = listingService.getRegion();
                return Ok(regions);
            }
            catch
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("loadcity/{countryId}")]
        public IActionResult LoadCity(int countryId)
        {
            try
            {
                var cities = listingService.getCity(countryId);
                return Ok(cities);
            }
            catch
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("loadallcity")]
        public IActionResult LoadAllCity()
        {
            try
            {
                var cities = listingService.getAllCity();
                return Ok(cities);
            }
            catch
            {
                return BadRequest();
            }
        }
        #endregion


        [Produces("application/json")]
        [HttpGet("getallrole")]
        public IActionResult GetAllRole()
        {
            try
            {
                var listings = listingService.GetAllRole(); // dc chua
                return Ok(listings);
            }
            catch (Exception e2)
            {
                return BadRequest(e2.Message);
            }
        } 




    }
}
