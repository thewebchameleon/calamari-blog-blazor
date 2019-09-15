using System.Threading.Tasks;

namespace CalamariBlog.Infrastructure.Repositories.SendGridRepo.Contracts
{
    public interface ISendGridRepo
    {
        Task SendSystemEmail(string subject, string htmlContent);
    }
}
