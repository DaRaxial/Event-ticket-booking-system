using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EventSeatManager.Services;
using EventSeatManager.Views;
using FluentAvalonia.UI.Controls;

namespace EventSeatManager.ViewModels
{
    public partial class LoginPageViewModel : ObservableValidator
    {
        [ObservableProperty]
        private string _loginEmailInput = string.Empty;
        [ObservableProperty]
        private string _loginPasswordInput = string.Empty;

        [RelayCommand]
        private void LoginButton()
        {
            AppService.MainFrame.Navigate(typeof(MainFilmSystemPage));
        }

        [RelayCommand]
        private void InLoginRegistrButton() => AppService.MainFrame.Navigate(typeof(RegistationPage));
    }
}
