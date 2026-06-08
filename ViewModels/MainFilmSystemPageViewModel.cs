using CommunityToolkit.Mvvm.ComponentModel;
using EventSeatManager.Core.Database.Models;
using System.Collections.ObjectModel;

namespace EventSeatManager.ViewModels
{
    public partial class MainFilmSystemPageViewModel : ObservableValidator
    {
        [ObservableProperty]
        private ObservableCollection<Films> _films;

        public MainFilmSystemPageViewModel()
        {
            Films = new ObservableCollection<Films>
            {
                new Films
                {
                    Title = "1+1",
                    PosterPath = "/Assets/Shrek.jpg",
                    Author = "Оливье Накаш",
                    AgeRating = 16,
                    Description = "Пострадав в результате несчастного случая..."
                }
            };
        }
    }
}
