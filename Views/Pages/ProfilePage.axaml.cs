using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.VisualTree;
using EventSeatManager.Views;

namespace EventSeatManager;

public partial class ProfilePage : UserControl
{
    public ProfilePage()
    {
        InitializeComponent();
    }

    private void GoToMainPageButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (this.FindAncestorOfType<MainWindow>() is MainWindow mainWindow)
        {
            mainWindow.MainFrame.Navigate(typeof(MainFilmSystemWindow));
        }
    }
}