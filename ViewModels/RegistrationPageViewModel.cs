using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EventSeatManager.Services;
using EventSeatManager.Services.AuthorizationService;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace EventSeatManager.ViewModels
{
    public partial class RegistrationPageViewModel : ObservableValidator
    {
        private readonly AuthService _loginService;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Поле обязательно к заполнению!")]
        private string _registrNameInput = string.Empty;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Поле обязательно к заполнению!")]
        [EmailAddress(ErrorMessage = "Неверный email!")]
        private string _registrEmailInput = string.Empty;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Поле обязательно к заполнению!")]
        private string _registrPasswordInput = string.Empty;

        [ObservableProperty]
        private string _errorMessage = string.Empty;

        public RegistrationPageViewModel()
        {
            _loginService = new AuthService();
        }

        [RelayCommand]
        private async Task RegistrationButton()
        {
            var result = await _loginService.CheckDataToCreateNewUser(RegistrNameInput, RegistrEmailInput, RegistrPasswordInput);
            if (result == true)
            {
                AppNavigationService.MainFrame!.Navigate(typeof(LoginPage));
                ErrorMessage = string.Empty;
            }
            else
                ErrorMessage = "Неверная почта или пароль! Повторите попытку!";
        }

        [RelayCommand]
        private void BackToLoginPageButton() => AppNavigationService.MainFrame!.Navigate(typeof(LoginPage));
    }
}
