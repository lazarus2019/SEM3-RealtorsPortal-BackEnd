using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NETAPI_SEM3.Entities;
using NETAPI_SEM3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Controllers
{
    [Route("api/adspackage")]
    public class AdsPackageController : Controller
    {
        private readonly IMapper _mapper;
        private readonly AdsPackageService _adsPackageService;

        public AdsPackageController(AdsPackageService adsPackageService, IMapper mapper)
        {
            this._adsPackageService = adsPackageService;
            this._mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllAdsPackage()
        {
            try
            {
                return Ok(_adsPackageService.GetAllAdsPackage());
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
