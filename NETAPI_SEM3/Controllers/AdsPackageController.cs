using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NETAPI_SEM3.Models;
using NETAPI_SEM3.Security;
using NETAPI_SEM3.Services;
using NETAPI_SEM3.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Controllers
{
    [Route("api/adspackage")]
    [MyAuthorize(Roles = "SuperAdmin,Admin")]
    public class AdsPackageController : Controller
    {
        private readonly IMapper _mapper;
        private readonly MemberService _memberService;
        private readonly AdsPackageService _adsPackageService;

        public AdsPackageController(AdsPackageService adsPackageService, IMapper mapper, MemberService memberService)
        {
            this._adsPackageService = adsPackageService;
            this._mapper = mapper;
            this._memberService = memberService;
        }

        [HttpGet("getall")]
        public IActionResult GetAllAdsPackage()
        {
            try
            {
                return Ok(_adsPackageService.GetAllAdsPackage());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }        
        
    
        
        [HttpGet("getall/{page}")]
        public IActionResult GetAllAdsPackagePage(int page)
        {
            try
            {
                return Ok(_adsPackageService.GetAllAdsPackagePage(page));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        [HttpGet("getallforsalepage")]
        public IActionResult GetAllAdsPackageForSalePage()
        {
            try
            {
                return Ok(_adsPackageService.GetAllAdsPackageForSalePage());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("getallforsalepage/{page}")]
        public IActionResult GetAllAdsPackageForSalePagePerPage(int page)
        {
            try
            {
                return Ok(_adsPackageService.GetAllAdsPackageForSalePagePerPage(page));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("getmaxprice")]
        public IActionResult GetMaxPrice()
        {
            try
            {
                var maxPrice = _adsPackageService.GetMaxPrice();
                var result = Math.Round(maxPrice / 100, 0) * 100;
                return Ok(result + 100);
            }
            catch
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("{id:int}")]
        public IActionResult GetAdPackageById(int id)
        {
            try
            {
                var adsPackage = _adsPackageService.GetAdPackageByid(id);
                return Ok(_mapper.Map<AdPackage, AdspackageViewModel>(adsPackage));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteAdsPackage(int id)
        {
            try
            {
                return Ok(_adsPackageService.DeleteAdsPackage(id));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("updateStatus/{id:int}")]
        public IActionResult UpdateStatus(int id, [FromBody] bool status)
        {
            try
            {
                var property = _adsPackageService.UpdateStatus(id, status);
                return Ok(property);

            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("update")]
        public IActionResult UpdateAdsPackage([FromBody] AdspackageViewModel model)
        {
            try
            {
                var Adspackage =  _adsPackageService.UpdateAdsPackage(_mapper.Map<AdPackage>(model));
                return Ok(Adspackage);

            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("create")]
        public IActionResult CreateAdsPackage([FromBody] AdspackageViewModel model)
        {
            try
            {
                model.StatusBuy = true;
                model.isDelete = false;
                var adPackage = _mapper.Map<AdPackage>(model);
                return Ok(_adsPackageService.CreateAdsPackage(adPackage));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("createadsdetail/{userId}")]
        public IActionResult CreateAdsPackageDetailViewModel([FromBody] AdsPackageDetailViewModel model, string userId)
        {
            try
            {
                var memberId = _memberService.GetMemberId(userId);
                _adsPackageService.DeletePackageDetail(memberId);
                model.MemberId = _memberService.GetMemberId(userId);
                var periodDay = _adsPackageService.GetPeriodDay(model.PackageId);
                model.ExpiryDate = DateTime.UtcNow.AddDays(periodDay);
                var adPackageDetail = _mapper.Map<MemberPackageDetail>(model);
                return Ok(_adsPackageService.CreateMemberPackageDetail(adPackageDetail));
            }
            catch
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("search/{name}/{status}/{price}")]
        public IActionResult SearchAdPackage(string name, string status, string price)
        {
            try
            {
                return Ok(_adsPackageService.SearchAdsPackage(status, name, price));
            }
            catch
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("search/{name}/{status}/{price}/{page}")]
        public IActionResult SearchAdPackagePage(string name, string status, string price, int page)
        {
            try
            {
                return Ok(_adsPackageService.SearchAdsPackagePage(status, name, price, page));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("checkexpiry/{userId}")]
        public IActionResult CheckExpiryDate(string userId)
        {
            try
            {
                var memberId = _memberService.GetMemberId(userId);
                var result = _adsPackageService.CheckExpiryDate(memberId);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
