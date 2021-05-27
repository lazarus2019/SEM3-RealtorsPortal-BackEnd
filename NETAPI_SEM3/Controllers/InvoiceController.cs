using AutoMapper;
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
    [Route("api/invoice")]
    public class InvoiceController : Controller
    {
        private readonly InvoiceService _invoiceService;
        private readonly IMapper _mapper;

        public InvoiceController(InvoiceService invoiceService, IMapper mapper)
        {
            this._invoiceService = invoiceService;
            this._mapper = mapper;
        }

        [HttpPost("create")]
        public IActionResult CreateInvoice([FromBody] InvoiceViewModel model)
        {
            try
            {
                Debug.WriteLine("packageId: " + model.PackageId);
                model.MemberId = 4;
                var invoice = _mapper.Map<Invoice>(model);
                return Ok(_invoiceService.CreateInvoice(invoice));
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
