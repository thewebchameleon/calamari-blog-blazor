using System.Threading.Tasks;

namespace CB.Blazor.Infrastructure.Repositories.SendGridRepo.Contracts
{
    public interface ISendGridRepo
    {
        Task SendAdminEmail(string subject, string htmlContent);
    }
}
