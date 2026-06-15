using EventSeatManager.Repository;
using System;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace EventSeatManager.Services.AuthorizationService
{
    public class AuthService
    {
        private readonly UserRepository _userRepository;
        public AuthService()
        {
            _userRepository = new UserRepository();
        }

        // Проверка данных для страницы 'LoginPage'
        async public Task<bool> CheckDataUserInLogin(string email, string password)
        {
            try
            {
                var user = await _userRepository.GetByEmail(email.ToLower());

                if (user != null && BC.Verify(password, user.Password))
                {
                    UserSession.SetCurrentUser(user);
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка проверки пользователя на входе: {ex.Message}");
                return false;
            }
        }

        // Проверка данных на странице 'RegistrationPage'. В случае успеха, отправление данных в БД
        async public Task<bool> CheckDataToCreateNewUser(string firstName, string email, string password)
        {
            try
            {
                if (firstName != string.Empty && email != string.Empty && password != string.Empty)
                {
                    string hashedPassword = BC.HashPassword(password);
                    await _userRepository.CreateNewUser(firstName.ToLower(), email.ToLower(), hashedPassword);
                }
                else
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка регистрации нового пользователя: {ex.Message}");
                return false;
            }
        }
    }
}
