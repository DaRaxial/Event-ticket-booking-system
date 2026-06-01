using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.VisualTree;
using EventSeatManager.Views;

namespace EventSeatManager;

public partial class MainFilmSystemWindow : UserControl
{
    public MainFilmSystemWindow()
    {
        InitializeComponent();
    }

    private void GoToProfileButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (this.FindAncestorOfType<MainWindow>() is MainWindow mainWindow)
        {
            mainWindow.MainFrame.Navigate(typeof(ProfilePage));
        }
    }
}