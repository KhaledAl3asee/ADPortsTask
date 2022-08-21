using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ADPortsTask.Services.Interfaces
{
    public interface ISmtpService
    {
        string Address { get; }
        Task SendMailAsync(MailMessage message);
    }
}
