using EventSeatManager.Models;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace EventSeatManager.Services
{
    public static class UserSessionService
    {
        public static Users? CurrentUser { get; private set; }

        public static void SetCurrentUser(Users user) => CurrentUser = user;
        public static Users? GetCurrentUser()
        {
            return CurrentUser;
        }

    }
}
