using CB.Blazor.Interface.ServiceModels;
using System.Threading.Tasks;

namespace CB.Blazor.Email.Contracts
{
    public interface IEmailService
    {
        Task<SendContactEmailResponse> SendContactEmail(SendContactEmailRequest request);
    }
}
