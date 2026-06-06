using EventSeatManager.Core.Database.Models;
using System.Threading.Tasks;

namespace EventSeatManager.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<Users> GetByEmail(string email);
    }
}
