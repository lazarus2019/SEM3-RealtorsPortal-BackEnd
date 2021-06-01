using Microsoft.AspNetCore.Mvc;
using NETAPI_SEM3.Models;
using NETAPI_SEM3.Services.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Controllers.User
{
    [Route("api/user/")]
    public class MailController : Controller
    {
        private MailboxService mailboxService;
        public MailController(MailboxService _mailboxService)
        {
            mailboxService = _mailboxService;
        }

        [Consumes("application/json")]
        [HttpPost("addmailbox")]
        public IActionResult AddMailbox([FromBody] Mailbox mailbox)
        {
            try
            {
                var result = mailboxService.AddMailbox(mailbox);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
