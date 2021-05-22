using Microsoft.AspNetCore.Mvc;
using NETAPI_SEM3.Models;
using NETAPI_SEM3.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Controllers
{
	[Route("api/admin/faq")]
	public class FAQController : Controller
	{
		private FAQService faqService;

		public FAQController(FAQService _faqService)
		{
			faqService = _faqService;
		}

		[HttpGet("getAllFAQ")]
		public IActionResult getAllFAQ()
		{
			try
			{
				return Ok(faqService.getAllFAQ());
			}
			catch
			{
				return StatusCode(500, "Can not get all faq!");
			}
		}

		[HttpGet("findFAQ/{faqId}")]
		public IActionResult findFAQ(int faqId)
		{
			try
			{
				return Ok(faqService.findFAQ(faqId));
			}
			catch
			{
				return StatusCode(500, "Can not get faq!");
			}
		}

		[Produces("application/json")]
		[HttpPost("createFAQ")]
		public IActionResult createFAQ([FromBody]Faq faq)
		{
			try
			{
				var result = faqService.createFAQ(faq);
				if (result)
				{
				return Ok();
				}
				return StatusCode(500, "Can not add new faq - Func!");
			}
			catch
			{
				return StatusCode(500, "Can not add new faq!");
			}
		}
	
		[HttpDelete("deleteFAQ/{faqId}")]
		public IActionResult deleteFAQ(int faqId)
		{
			try
			{
				var result = faqService.deleteFAQ(faqId);
				if (result)
				{
					return Ok();
				}
				return StatusCode(500, "Can not delete FAQ! - Func");
			}
			catch
			{
				return StatusCode(500, "Can not delete FAQ!");
			}
		}

		[Produces("application/json")]
		[HttpPut("updateFAQ")]
		[Consumes("application/json")]
		public IActionResult updateFAQ([FromBody]Faq faq)
		{
			try
			{
				var result = faqService.updateFAQ(faq);
				if (result)
				{
					return Ok();
				}
				return StatusCode(500, "Can not update your FAQ! - Func");
			}
			catch
			{
				return StatusCode(500, "Can not update your FAQ!");
			}
		}
	}
}
