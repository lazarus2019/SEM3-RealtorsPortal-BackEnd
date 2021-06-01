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

        [Produces("application/json")] 
        [HttpGet("getallinvoice/{page}")]
        public IActionResult GetAllInvoice(int page)
        {
            try
            {
                var invoices = _invoiceService.getAllInvoice(page);
                return Ok(invoices);
            }
            catch ( Exception e2)
            {
                return BadRequest(e2.Message); 
            }
        } 
              [Produces("application/json")] 
        [HttpGet("getallinvoicecount")]
        public IActionResult GetAllInvoiceCount()
        {
            try
            {
                var invoices = _invoiceService.getAllInvoiceCount();
                return Ok(invoices);
            }
            catch ( Exception e2)
            {
                return BadRequest(e2.Message); 
            }
        } 
        
        [Produces("application/json")] 
        [HttpGet("searchinvoice/{keyword}/{page}")]
        public IActionResult SearchInvoice(string keyword, int page)
        {
            try
            {
                var invoices = _invoiceService.searchInvoice(keyword,page);
                return Ok(invoices);
            }
            catch ( Exception e2)
            {
                return BadRequest(e2.Message); 
            }
        }
        
        [Produces("application/json")] 
        [HttpGet("searchinvoicecount/{keyword}")]
        public IActionResult SearchInvoiceCount(string keyword)
        {
            try
            {
                var invoices = _invoiceService.searchInvoiceCount(keyword);
                return Ok(invoices);
            }
            catch ( Exception e2)
            {
                return BadRequest(e2.Message); 
            }
        }
   
    }
}
