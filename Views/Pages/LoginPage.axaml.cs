using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.VisualTree;
using EventSeatManager.ViewModels;
using EventSeatManager.Views;
using FluentAvalonia.UI.Controls;

namespace EventSeatManager;

public partial class LoginPage : UserControl
{
    public LoginPage()
    {
        InitializeComponent();
        DataContext = new LoginPageViewModel();
    }
}