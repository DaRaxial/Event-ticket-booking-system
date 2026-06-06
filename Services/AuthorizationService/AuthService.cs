using Avalonia.Controls;
using EventSeatManager.Repository.Classes;
using EventSeatManager.Repository.Interfaces;
using System;
using System.Threading.Tasks;

namespace EventSeatManager.Services.AuthorizationService
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        public AuthService()
        {
            _userRepository = new UserRepository();
        }

        // Проверка данных для страницы 'LoginPage'
        async public Task<bool> CheckDataUserInLogin(string email, string password)
        {
            try
            {
                var user = await _userRepository.GetByEmail(email);

                if (user.Password == password)
                    return true;
                else
                    return false;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Ошибка проверки пользователя на входе: {ex.Message}");
                return false;
            }
        }
    }
}
