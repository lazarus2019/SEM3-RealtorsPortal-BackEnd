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
        public IActionResult GetAllProperty()
        {
            try
            {
                return Ok(_propertyService.GetAllProperty());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("getallpage/{page}")]
        public IActionResult GetAllPropertyPage(int page)
        {
            try
            {
                return Ok(_propertyService.GetAllPropertyPage(page));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("getallbymember/{userId}")]
        public IActionResult GetAllPropertyByMember(string userId)
        {
            try
            {
                var memberId = _memberService.GetMemberId(userId);
                return Ok(_propertyService.GetAllPropertyByMember(memberId));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("getallpagebymember/{userId}/{page}")]
        public IActionResult GetAllPropertyPageByMember(string userId, int page)
        {
            try
            {
                var memberId = _memberService.GetMemberId(userId);
                return Ok(_propertyService.GetAllPropertyPageByMember(memberId, page));
            }
            catch (Exception ex)
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
                return Ok(property);
                //return Ok(_mapper.Map<Property, PropertyViewModel>(property));
            }
            catch( Exception e2)
            {

                return BadRequest(e2.Message);
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

        [HttpPost("create/{userId}")]
        public IActionResult CreateProperty([FromBody] PropertyViewModel model, string userId)
        {
            try
            {
                model.UploadDate = DateTime.Now;
                model.StatusId = 4;
                model.MemberId = _memberService.GetMemberId(userId);
                //model.CityId = 1;
                var property = _mapper.Map<Property>(model);

                return Ok(_propertyService.CreateProperty(property));
            }
            catch
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("search/{title}/{partners}/{categoryId}/{statusId}")]
        public IActionResult SearchProperty(string title, string partners, string categoryId, string statusId)
        {
            try
            {
                return Ok(_propertyService.SearchProperty(title, partners, categoryId, statusId));
            }
            catch
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("search/{title}/{partners}/{categoryId}/{statusId}/{page}")]
        public IActionResult SearchPropertyPage(string title, string partners, string categoryId, string statusId, int page)
        {
            try
            {
                return Ok(_propertyService.SearchPropertyPage(title, partners, categoryId, statusId, page));
            }
            catch
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("search/{userId}/{title}/{partners}/{categoryId}/{statusId}")]
        public IActionResult SearchPropertyByMember(string userId, string title, string partners, string categoryId, string statusId)
        {
            try
            {
                var memberId = _memberService.GetMemberId(userId);
                return Ok(_propertyService.SearchPropertyByMember(memberId, title, partners, categoryId, statusId));
            }
            catch
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("search/{userId}/{title}/{partners}/{categoryId}/{statusId}/{page}")]
        public IActionResult SearchPropertyPageByMember(string userId, string title, string partners, string categoryId, string statusId, int page)
        {
            try
            {
                var memberId = _memberService.GetMemberId(userId);
                return Ok(_propertyService.SearchPropertyPageByMember(memberId, title, partners, categoryId, statusId, page));
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
                var result = true;
                var memberId = _memberService.GetMemberId(userId);
                var packageId = _adsPackageService.GetPackageIdByMemberId(memberId);
                var postLimit = _adsPackageService.GetPostLimit(packageId);
                var countProperty = _propertyService.CountProperty(memberId);

                if (countProperty < postLimit)
                {
                    result = true;
                }
                else
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

        [HttpGet("checkbuypackage/{userId}")]
        public IActionResult CheckBuyPackage(string userId)
        {
            try
            {
                var result = true;
                var memberId = _memberService.GetMemberId(userId);
                var checkPackage = _adsPackageService.CheckPackage(memberId);
                if (checkPackage > 0)
                {
                    result = true;
                } else
                {
                    result = false;
                }
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("countpropertypending")]
        public IActionResult CountPropertyPending()
        {
            try
            {
                return Ok(_propertyService.CountPropertyPending());
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
