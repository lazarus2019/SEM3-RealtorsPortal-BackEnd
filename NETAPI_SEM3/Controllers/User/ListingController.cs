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

        #region getAllListing
        public ListingController(ListingService _listingService)
        {
            listingService = _listingService;
        }

        [Produces("application/json")]
        [HttpGet("getalllisting")]
        public IActionResult GetAllListing()
        {
            try
            {
                var listings = listingService.GetAllListing();
                return Ok(listings);
            }
            catch
            {
                return BadRequest();
            }
        }

        #endregion

        #region search
        [Produces("application/json")]
        [HttpGet("searchproperty/{keyword}/{categoryId}/{country}")]
        public IActionResult SearchProperty(string keyword, int categoryId, string country)
        {
            try
            {
                var listings = listingService.SearchProperty(keyword, categoryId, country);
                return Ok(listings);
            }
            catch (Exception e2)
            {
                return BadRequest(e2.Message);
            }
        }
        

        [Produces("application/json")]
        [HttpGet("searchpropertylisting/{keyword}/{categoryId}/{countryId}/{city}/{type}/{area}/{bed}/{room}/{price}")]
        public IActionResult SearchPropertyListing(string keyword, int categoryId, string countryId, string city, string type, double area, int bed, int room, double price)
        {
            try
            {
                var listings = listingService.SearchPropertyListing(keyword, categoryId, countryId , city, type, area, bed, room, price);
                return Ok(listings);
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
        public IActionResult LoadCity(string countryId)
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



    }
}
