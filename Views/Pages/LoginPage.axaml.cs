using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.VisualTree;
using EventSeatManager.ViewModels;
using EventSeatManager.Views;

namespace EventSeatManager;

public partial class LoginPage : UserControl
{
    public LoginPage()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }

    private void InLoginRegistrButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (this.FindAncestorOfType<MainWindow>() is MainWindow mainWindow)
        {
            mainWindow.MainFrame.Navigate(typeof(RegistationPage));
        }
    }

    private void LoginButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (this.FindAncestorOfType<MainWindow>() is MainWindow mainWindow)
        {
            mainWindow.MainFrame.Navigate(typeof(MainFilmSystemWindow));
        }
    }
}