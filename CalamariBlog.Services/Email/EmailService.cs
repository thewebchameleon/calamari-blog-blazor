using CalamariBlog.Services.Email.Contracts;
using CalamariBlog.Infrastructure.Configuration;
using CalamariBlog.Infrastructure.Repositories.SendGridRepo.Contracts;
using CalamariBlog.Models.ServiceModels;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace CalamariBlog.Services.Email
{
    public class EmailService : IEmailService
    {
        private readonly ISendGridRepo _sendGridRepo;
        private readonly EmailConfig _settings;

        public EmailService(ISendGridRepo sendGridRepo, IOptions<EmailConfig> settings)
        {
            _settings = settings.Value;
            _sendGridRepo = sendGridRepo;
        }

        public async Task<SendContactEmailResponse> SendContactEmail(SendContactEmailRequest request)
        {
            if (_settings.IsEnabled)
            {
                //todo: this is a terrible way, rather use an html template
                await _sendGridRepo.SendSystemEmail($"New Message from {request.Name}",
                    "<html><head></head><body>" +
                    $"<h2><b>From:</b> {request.Name}</h1>" +
                    $"<h4><b>Mobile:</b> {request.MobileNumber}</h1>" +
                    $"<p>{request.Message}</p>" +
                    "</body></html>");
            }
            return new SendContactEmailResponse();
        }
    }
}
