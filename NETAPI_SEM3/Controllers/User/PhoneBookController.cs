using Microsoft.AspNetCore.Mvc;
using NETAPI_SEM3.Services.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Controllers.User
{
    [Route("api/user/")]
    public class PhoneBookController : Controller
    {

        private SellerService sellerService;

        public PhoneBookController(SellerService _sellerService)
        {
            sellerService = _sellerService;
        }

        [Produces("application/json")]
        [HttpGet("loadseller")]
        public IActionResult LoadSeller()
        {
            try
            {
                var seller = sellerService.LoadSeller();

                return Ok(seller);
            }
            catch
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("loadagent")]
        public IActionResult LoadAgent()
        {
            try
            {
                var agent = sellerService.LoadAgent();

                return Ok(agent);
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [HttpGet("sellerID/{sellerId}")]
        public IActionResult SellerDetails(int sellerId)
        {
            try
            {
                var detail = sellerService.SellerDetails(sellerId);
                return Ok(detail);
            }
            catch
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("propertyID/{propertyId}")]
        public IActionResult SellerPropertyId(int propertyId)
        {
            try
            {
                var propertyID = sellerService.LoadPropertyId(propertyId);
                return Ok(propertyID);
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}