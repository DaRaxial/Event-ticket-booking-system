using System.Threading.Tasks;

namespace EventSeatManager.Services.AuthorizationService
{
    public interface IAuthService
    {
        Task<bool> CheckDataUserInLogin(string email, string password);
    }
}
