using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EventSeatManager.Services;
using EventSeatManager.Services.AuthorizationService;
using EventSeatManager.Views;
using FluentAvalonia.UI.Controls;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace EventSeatManager.ViewModels
{
    public partial class LoginPageViewModel : ObservableValidator
    {
        private readonly IAuthService _loginService;

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
                AppNavigationService.MainFrame!.Navigate(typeof(MainFilmSystemPage));
            else
                ErrorMessage = "Ошибка входа! Повторите попытку!";
        }

        [RelayCommand]
        private void InLoginRegistrButton() => AppNavigationService.MainFrame!.Navigate(typeof(RegistationPage));
    }
}
