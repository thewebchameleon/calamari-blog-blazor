using CalamariBlog.Models.ServiceModels;
using System.Threading.Tasks;

namespace CalamariBlog.Services.Email.Contracts
{
    public interface IEmailService
    {
        Task<SendContactEmailResponse> SendContactEmail(SendContactEmailRequest request);
    }
}
