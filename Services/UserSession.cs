using EventSeatManager.Models;

namespace EventSeatManager.Services
{
    public class UserSession
    {
        public static Users? CurrentUser { get; private set; }

        public static void SetCurrentUser(Users user) => CurrentUser = user;
    }
}
