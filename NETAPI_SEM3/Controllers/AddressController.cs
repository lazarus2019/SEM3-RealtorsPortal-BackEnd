using Microsoft.AspNetCore.Mvc;
using NETAPI_SEM3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Controllers
{
    [Route("api/address")]
    public class AddressController : ControllerBase
    {
        private readonly AddressService _addressService;

        public AddressController(AddressService addressService)
        {
            this._addressService = addressService;
        }

        [HttpGet("getregion")]
        public IActionResult GetRegion()
        {
            try
            {
                return Ok(_addressService.GetAllRegion());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("getcountry/{regionId}")]
        public IActionResult GetCountry(int regionId)
        {
            try
            {
                return Ok(_addressService.GetAllCountry(regionId));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("getcity/{countryId}")]
        public IActionResult GetCity(int countryId)
        {
            try
            {
                return Ok(_addressService.GetAllCity(countryId));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
