using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace EventSeatManager.Models
{
    public partial class FilmsAndTickets : ObservableObject
    {
        public int FilmId { get; set; }
        public string FilmTitle { get; set; } = string.Empty;
        public string FilmGenre { get; set; } = string.Empty;
        public int FilmAgeRating { get; set; }
        public Task<Bitmap?>? FilmPosterImageToView { get; set; }

        public string TicketSessionDate { get; set; } = string.Empty;
        public int TicketSpecialId { get; set; }

        [ObservableProperty]
        private ObservableCollection<int> _ticketSeatPlace = new();

        [ObservableProperty]
        private ObservableCollection<int> _ticketRowPlace = new();

        [ObservableProperty]
        private string _seatPlacesDisplay = string.Empty;

        [ObservableProperty]
        private string _rowPlacesDisplay = string.Empty;

        public void UpdateDisplayStrings()
        {
            SeatPlacesDisplay = string.Join(", ", TicketSeatPlace);
            RowPlacesDisplay = string.Join(", ", TicketRowPlace);
        }
    }
}
