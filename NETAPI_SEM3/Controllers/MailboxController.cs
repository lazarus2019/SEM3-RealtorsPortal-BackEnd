using Microsoft.AspNetCore.Mvc;
using NETAPI_SEM3.Models;
using NETAPI_SEM3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Controllers
{
	[Route("api/admin/mailbox")]
	public class MailboxController : Controller
	{
		#region Injection Services
		private MailboxService mailboxService;

		public MailboxController(MailboxService _mailboxService)
		{
			mailboxService = _mailboxService;
		}
		#endregion

		[Produces("application/json")]
		[HttpGet("getMailboxByMemberId/{memberId}")]
		public IActionResult getMailboxByMemberId(int memberId)
		{
			try
			{
				return Ok(mailboxService.getMailboxByMemberId(memberId));
			}
			catch
			{
				return StatusCode(500, "Can not get mailbox of member!");
			}
		}

		[Produces("application/json")]
		[HttpGet("findMailbox/{mailboxId}")]
		public IActionResult findMailbox(int mailboxId)
		{
			try
			{
				return Ok(mailboxService.findMailbox(mailboxId));
			}
			catch
			{
				return StatusCode(500, "Can not get mailbox by Id!");
			}
		}

		[Produces("application/json")]
		[HttpPost("createMailbox")]
		public IActionResult createMailbox([FromBody]Mailbox mailbox)
		{
			try
			{
				var result = mailboxService.createMailbox(mailbox);
				if (result)
				{
					return Ok();
				}
				return StatusCode(500, "Can not create new mailbox! - Func");
			}
			catch
			{
				return StatusCode(500, "Can not create new mailbox!");
			}
		}

		[Produces("application/json")]
		[HttpDelete("deleteMailbox/{mailboxId}")]
		public IActionResult deleteMailbox(int mailboxId)
		{
			try
			{
				var result = mailboxService.deleteMailbox(mailboxId);
				if (result)
				{
					return Ok();
				}
				return StatusCode(500, "Can not delete mailbox! - Func");
			}
			catch
			{
				return StatusCode(500, "Can not delete mailbox!");
			}
		}
	
		[Produces("application/json")]
		[HttpPut("readMailbox")]
		public IActionResult readMailbox([FromBody]int mailboxId)
		{
			try
			{
				var result = mailboxService.readMailbox(mailboxId);
				if (result)
				{
					return Ok();
				}
				return StatusCode(500, "Can not change status read mailbox! - Func");
			}
			catch
			{
				return StatusCode(500, "Can not change status read mailbox!");
			}
		}

		[Produces("application/json")]
		[HttpGet("getAmountMailboxUnread/{memberId}")]
		public IActionResult getAmountMailboxUnread(int memberId)
		{
			try
			{
				return Ok(mailboxService.getAmountMailboxUnread(memberId));
			}
			catch
			{
				return StatusCode(500, "Can not get amount of mailbox!");
			}
		}

		[Produces("application/json")]
		[HttpGet("filterMail/{memberId}/{sortDate}/{status}")]
		public IActionResult filterMail(int memberId, string sortDate, string status)
		{
			try
			{
				return Ok(mailboxService.filterMail(memberId, sortDate, status));
			}
			catch
			{
				return StatusCode(500, "Can not get mailbox of member!");
			}
		}

	}
}
