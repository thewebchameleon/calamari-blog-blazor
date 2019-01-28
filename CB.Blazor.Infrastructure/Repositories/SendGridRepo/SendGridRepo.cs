using CB.Blazor.Infrastructure.Configuration;
using CB.Blazor.Infrastructure.Repositories.SendGridRepo.Contracts;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CB.Blazor.Infrastructure.Repositories.SendGridRepo
{
    public class SendGridRepo : ISendGridRepo
    {
        private readonly EmailConfig _settings;
        private readonly ISendGridClient _client;

        public SendGridRepo(IOptions<EmailConfig> settings)
        {
            _settings = settings.Value;
            _client = new SendGridClient(_settings.APIKey);
        }

        public async Task SendAdminEmail(string subject, string htmlContent)
        {
            var from = new EmailAddress(_settings.SystemEmailAddress, _settings.SystemEmailName);
            var to = new EmailAddress(_settings.AdminEmailAddress);
            var plainTextContent = Regex.Replace(htmlContent, "<[^>]*>", "");
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await _client.SendEmailAsync(msg);

            if (response.StatusCode != System.Net.HttpStatusCode.Accepted)
            {
                //todo: log this
            }
        }
    }
}
