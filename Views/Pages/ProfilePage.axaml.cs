using Avalonia.Controls;
using Avalonia.VisualTree;
using EventSeatManager.Views;
using FluentAvalonia.UI.Controls;

namespace EventSeatManager;

public partial class ProfilePage : UserControl
{
    public ProfilePage()
    {
        InitializeComponent();
    }

    private void GoToMainPageButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        MainWindow main = this.FindAncestorOfType<MainWindow>()!;
        main.MainFrame.Navigate(typeof(MainFilmSystemPage));
    }
}