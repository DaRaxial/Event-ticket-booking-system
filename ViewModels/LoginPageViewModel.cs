using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EventSeatManager.Models;
using EventSeatManager.Services.AuthorizationService;
using EventSeatManager.Services.Navigation;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace EventSeatManager.ViewModels
{
    public partial class LoginPageViewModel : ObservableValidator
    {
        private readonly AuthService _loginService;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [EmailAddress(ErrorMessage = "Неверный email!")]
        private string _loginEmailInput = string.Empty;

        [ObservableProperty]
        private string _loginPasswordInput = string.Empty;

        [ObservableProperty]
        private string _errorMessage = string.Empty;

        public LoginPageViewModel()
        {
            _loginService = new AuthService();
        }

        [RelayCommand]
        private async Task LoginButton()
        {
            var result = await _loginService.CheckDataUserInLogin(LoginEmailInput, LoginPasswordInput);
            if (result == true)
            {
                AppNavigationService.MainFrame!.Navigate(typeof(MainFilmSystemPage));
                ErrorMessage = string.Empty;
            }
            else
                ErrorMessage = "Неверная почта или пароль! Повторите попытку!";
        }

        [RelayCommand]
        private void InLoginRegistrButton() => AppNavigationService.MainFrame!.Navigate(typeof(RegistationPage));
    }
}
