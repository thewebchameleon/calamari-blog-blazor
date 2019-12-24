using CalamariBlog.Infrastructure.Configuration;
using CalamariBlog.Infrastructure.Repositories.SendGridRepo.Contracts;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CalamariBlog.Infrastructure.Repositories.SendGridRepo
{
    public class SendGridRepo : ISendGridRepo
    {
        private readonly EmailSettings _settings;
        private readonly ISendGridClient _client;

        public SendGridRepo(IOptions<EmailSettings> settings)
        {
            _settings = settings.Value;
            _client = new SendGridClient(_settings.SendGrid.APIKey);
        }

        public async Task SendSystemEmail(string subject, string htmlContent)
        {
            var from = new EmailAddress(_settings.SystemEmailAddress, _settings.SystemEmailName);
            var to = new EmailAddress(_settings.RecipientEmailAddress);
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
