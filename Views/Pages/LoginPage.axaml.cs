using Avalonia.Controls;
using EventSeatManager.ViewModels;

namespace EventSeatManager;

public partial class LoginPage : UserControl
{
    public LoginPage()
    {
        InitializeComponent();
        DataContext = new LoginPageViewModel();
    }
}