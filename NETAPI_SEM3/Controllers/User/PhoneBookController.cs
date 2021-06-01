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
        [HttpGet("getsellerId")]
        public IActionResult LoadSellerId()
        {
            try
            {
                var sellers = sellerService.getIdSeller();

                return Ok(sellers);
            }
            catch
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("getallseller/{page}")]
        public IActionResult GetAllSeller(int page)
        {
            try
            {
                var sellers = sellerService.getAllSeller(page);

                return Ok(sellers);
            }
            catch
            {
                return BadRequest();
            }
        }

        // 

        [Produces("application/json")]
        [HttpGet("getagentId")]
        public IActionResult LoadAgentId()
        {
            try
            {
                var agent = sellerService.getIdAgent();

                return Ok(agent);
            }
            catch
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("getallagent/{page}")]
        public IActionResult GetAllAgent(int page)
        {
            try
            {
                var agent = sellerService.getAllAgent(page);

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