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
        private readonly MemberService _memberService;
        private readonly IMapper _mapper;

        public InvoiceController(InvoiceService invoiceService, MemberService memberService, IMapper mapper)
        {
            this._invoiceService = invoiceService;
            this._memberService = memberService;
            this._mapper = mapper;
        }

        [HttpPost("create/{userId}")]
        public IActionResult CreateInvoice(string userId, [FromBody] InvoiceViewModel model)
        {
            try
            {
                var memberId = _memberService.GetMemberId(userId);

                _invoiceService.CheckPackage(memberId);

                model.MemberId = memberId;
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
