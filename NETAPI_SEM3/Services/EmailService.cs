using NETAPI_SEM3.Mails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Services
{
    public interface EmailService
    {
        void SendEmail(SendMailMessage message);
        Task SendEmailAsync(SendMailMessage message);
    }
}
