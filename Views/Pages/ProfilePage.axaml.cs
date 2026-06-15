using Avalonia.Controls;
using Avalonia.VisualTree;
using EventSeatManager.ViewModels;
using EventSeatManager.Views;

namespace EventSeatManager;

public partial class ProfilePage : UserControl
{
    public ProfilePage()
    {
        InitializeComponent();
        DataContext = new ProfilePageViewModel();
    }

    private void GoToMainPageButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        MainWindow main = this.FindAncestorOfType<MainWindow>()!;
        main.MainFrame.Navigate(typeof(MainFilmSystemPage));
    }
}