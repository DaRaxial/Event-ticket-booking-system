using Amazon.S3.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EventSeatManager.Models;
using EventSeatManager.Services;
using EventSeatManager.Services.Navigation;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace EventSeatManager.ViewModels
{
    public partial class MainFilmSystemPageViewModel : ObservableValidator
    {
        [ObservableProperty]
        private ObservableCollection<Films>? _films;
        private readonly FilmsService _filmsService = new();

        [ObservableProperty]
        private Films? _selectedFilm;

        public MainFilmSystemPageViewModel()
        {
            LoadFilms();
        }

        [RelayCommand]
        private void GoToProfilePage() => AppNavigationService.MainFrame!.Navigate(typeof(ProfilePage));

        [RelayCommand]
        private void GoToBookingPage(Films? film)
        {
            if (film == null) return;
            SelectedFilm = film;
            NavigationData.CurrentFilm = film;
            AppNavigationService.MainFrame!.Navigate(typeof(BookingPage), film);
        }

        private async Task LoadFilms()
        {
            var result = await _filmsService.ProcessFilmsToDisplay();
            Films = result;
        }
    }
}
