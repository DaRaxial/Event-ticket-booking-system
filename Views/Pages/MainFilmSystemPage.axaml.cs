using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.VisualTree;
using EventSeatManager.ViewModels;
using EventSeatManager.Views;

namespace EventSeatManager;

public partial class MainFilmSystemPage : UserControl
{
    public MainFilmSystemPage()
    {
        InitializeComponent();
        DataContext = new MainFilmSystemPageViewModel();
    }
}