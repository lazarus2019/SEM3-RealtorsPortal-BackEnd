using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NETAPI_SEM3.Entities;
using NETAPI_SEM3.Services;
using NETAPI_SEM3.ViewModel;
using System;
using System.Collections.Generic;
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
                return Ok(_propertyService.GetPropertyByid(id));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult UpdateStatus(int id, [FromBody] PropertyViewModel model)
        {
            try
            {
                var newProperty = _mapper.Map<PropertyViewModel, Property>(model);
                var result = _propertyService.GetPropertyByid(id);

                return Ok(_mapper.Map<Property, PropertyViewModel>(newProperty));

            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
