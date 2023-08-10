using Microsoft.Extensions.Configuration;
using OnlineStore.Services.Data._0_Interfaces.MailInterfaces;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Services.Data.MailServices
{
    
    public class MailService : IMailService
    {
        private IConfiguration config;
        public MailService(IConfiguration config)
        {
                this.config = config;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string content)
        {
            var apiKey = config["SendGridApiKey"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(config["SendGridEmailSender"], config["SendGridNameSender"]);
            var subjectx = subject;
            var to = new EmailAddress(toEmail);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, content, content);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
