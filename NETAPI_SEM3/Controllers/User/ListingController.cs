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

        [Produces("application/json")]
        [HttpGet("getalllisting")]
        public IActionResult GetAllListing ()
        {
            try
            {
                var listings = listingService.getAll();
                return Ok(listings); 
            }
            catch 
            {
                return BadRequest(); 
            }
        }
    }
}
