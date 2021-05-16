using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NETAPI_SEM3.Entities;
using NETAPI_SEM3.Services;
using NETAPI_SEM3.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Controllers
{
    [Route("api/property/")]
    public class PropertyController : Controller
    {
        private readonly PropertyService _propertyService;
        private readonly IMapper _mapper;

        public PropertyController(PropertyService propertyService, IMapper mapper)
        {
            this._propertyService = propertyService;
            this._mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllProperty()
        {
            try
            {
                return Ok(_propertyService.GetAllProperty());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetPropertyById(int id)
        {
            try
            {
                var property = _propertyService.GetPropertyByid(id);
                Debug.WriteLine("member: " + property.Member.FullName);
                return Ok(_mapper.Map<Property, PropertyViewModel>(property));
                //return Ok(_propertyService.GetPropertyByid(id));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("updateStatus")]
        public IActionResult UpdateStatus([FromBody] PropertyViewModel model)
        {
            try
            {
                var property =  _propertyService.UpdateProperty(_mapper.Map<PropertyViewModel, Property>(model));
                return Ok(null);

            }
            catch
            {
                return BadRequest();
            }
        }
        
        [HttpPut("update")]
        public IActionResult UpdateProperty([FromBody] PropertyViewModel model)
        {
            try
            {
                var property =  _propertyService.UpdateProperty(_mapper.Map<PropertyViewModel, Property>(model));
                return Ok(property);

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
                Debug.WriteLine("id: " + id);
                return Ok(_propertyService.DeleteProperty(id));

            }
            catch
            {
                return BadRequest();
            }
        }
        
        [HttpPost()]
        public IActionResult AddNewProperty([FromBody] PropertyViewModel model)
        {
            try
            {
                foreach(var image in model.PropertyImagePath)
                {
                    Debug.WriteLine("image: " + image);
                }
                return Ok(_mapper.Map<PropertyViewModel, Property>(model));

            }
            catch
            {
                return BadRequest();
            }
        }


    }
}
