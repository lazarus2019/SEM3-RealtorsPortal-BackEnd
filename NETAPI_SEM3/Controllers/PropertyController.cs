using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NETAPI_SEM3.Models;
using NETAPI_SEM3.Services;
using NETAPI_SEM3.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Controllers
{
    [Route("api/property")]
    public class PropertyController : Controller
    {
        private readonly PropertyService _propertyService;
        private readonly AdsPackageService _adsPackageService;
        private readonly MemberService _memberService;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;

        public PropertyController(
            PropertyService propertyService, 
            AdsPackageService adsPackageService,
            MemberService memberService,
            IMapper mapper, 
            UserManager<IdentityUser> userManager)
        {
            this._propertyService = propertyService;
            this._adsPackageService = adsPackageService;
            this._memberService = memberService;
            this._mapper = mapper;
            this._userManager = userManager;
        }

        [Produces("application/json")]
        [HttpGet]
       // [Authorize(Roles = "Admin")]

        public IActionResult GetAllProperty(int page)
        {
            try
            {
                return Ok(_propertyService.GetAllProperty(page));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("{id:int}")]
        public IActionResult GetPropertyById(int id)
        {
            try
            {
                var property = _propertyService.GetPropertyByid(id);
                return Ok(_mapper.Map<Property, PropertyViewModel>(property));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("updateStatus/{id:int}")]
        public IActionResult UpdateStatus(int id, [FromBody] int statusId)
        {
            try
            {
                var property = _propertyService.UpdateStatus(id, statusId);
                return Ok(property);

            }
            catch
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPut("update")]
        public IActionResult UpdateProperty([FromBody] PropertyViewModel model)
        {
            try
            {
                _propertyService.UpdateProperty(_mapper.Map<Property>(model));
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteProperty(int id)
        {
            try
            {
                if (id > 0)
                {
                    _propertyService.DeleteProperty(id);
                }
                return Ok();

            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("create")]
        public IActionResult CreateProperty([FromBody] PropertyViewModel model)
        {
            try
            {
                model.UploadDate = DateTime.Now;
                model.StatusId = 4;
                model.MemberId = 3;
                var property = _mapper.Map<Property>(model);

                return Ok(_propertyService.CreateProperty(property));
            }
            catch
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("search/{page}/{title}/{partners}/{categoryId}/{statusId}")]
        public IActionResult SearchProperty(int page ,string title, string partners, string categoryId, string statusId)
        {
            try
            {
                var claimIdentity = User.Identity as IdentityUser;
                if (partners.Equals(partners))
                {
                    partners = "agent";
                }
                return Ok(_propertyService.SearchProperty(page ,  title, partners, categoryId, statusId));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("getGallery/{propertyId}")]
        public IActionResult GetGallery(int propertyId)
        {
            try
            {
                return Ok(_propertyService.GetGallery(propertyId));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("checktoaddnew/{userId}")]
        public IActionResult CheckToAddNew(string userId)
        {
            try
            {
                var memberId = _memberService.GetMemberId(userId);
                var packageId = _adsPackageService.GetPackageIdByMemberId(memberId);
                var postLimit =  _adsPackageService.GetAdPackageByid(packageId).PostNumber;
                var countProperty = _propertyService.CountProperty(memberId);

                var result = true;
                if(countProperty < postLimit)
                {
                    result = true;
                } else
                {
                    result = false;
                }
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
