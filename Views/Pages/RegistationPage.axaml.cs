using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.VisualTree;
using EventSeatManager.Views;

namespace EventSeatManager;

public partial class RegistationPage : UserControl
{
    public RegistationPage()
    {
        InitializeComponent();
    }

    private void BackToLoginPage_Click(object? sender, RoutedEventArgs e)
    {
        if (this.FindAncestorOfType<MainWindow>() is MainWindow mainWindow)
        {
            mainWindow.MainFrame.Navigate(typeof(LoginPage));
        }
    }

    private void RegistrationButton_Click(object? sender, RoutedEventArgs e)
    {
        if (this.FindAncestorOfType<MainWindow>() is MainWindow mainWindow)
        {
            mainWindow.MainFrame.Navigate(typeof(LoginPage));
        }
    }
}