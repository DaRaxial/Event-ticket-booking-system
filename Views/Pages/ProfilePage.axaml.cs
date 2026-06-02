using Avalonia.Controls;
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
        var main = this.FindAncestorOfType<MainWindow>();
        main.MainFrame.Navigate(typeof(MainFilmSystemWindow));
    }
}