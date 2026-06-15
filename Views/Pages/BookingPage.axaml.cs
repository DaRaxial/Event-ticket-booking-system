using Avalonia;
using Avalonia.Controls;
using EventSeatManager.Services.Navigation;
using EventSeatManager.ViewModels;

namespace EventSeatManager;

public partial class BookingPage : UserControl
{
    public BookingPage()
    {
        InitializeComponent();
        UpdateDataContext();
    }
    protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
    {
        base.OnAttachedToVisualTree(e);
        UpdateDataContext();
    }

    private void UpdateDataContext()
    {
        var film = NavigationData.CurrentFilm;
        if (film != null)
        {
            if (DataContext is BookingPageViewModel existingViewModel)
            {
                existingViewModel.UpdateWithFilm(film);
            }
            else
            {
                DataContext = new BookingPageViewModel(film);
            }
            NavigationData.CurrentFilm = null;
        }
        else if (DataContext == null)
        {
            DataContext = new BookingPageViewModel();
        }
    }

}
