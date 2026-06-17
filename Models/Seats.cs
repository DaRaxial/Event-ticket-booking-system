using CommunityToolkit.Mvvm.ComponentModel;

namespace EventSeatManager.Models
{
    public partial class Seats : ObservableObject
    {
        public int Id { get; set; }
        public int Row { get; set; } = 1;
        public int FilmId { get; set; }
        public bool IsAvailable { get; set; } = true;
        public bool SelectedSeat { get; set;}
        public bool IsEnabled { get; set; } = true;
    }
}
