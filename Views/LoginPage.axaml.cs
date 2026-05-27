using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using EventSeatManager.ViewModels;

namespace EventSeatManager;

public partial class LoginPage : UserControl
{
    public LoginPage()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }
}