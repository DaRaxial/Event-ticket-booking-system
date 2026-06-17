using CommunityToolkit.Mvvm.ComponentModel;
using System.Drawing;

namespace EventSeatManager.Models
{
    public partial class Seats : ObservableObject
    {
        public int Id { get; set; }
        public int Row { get; set; } = 1;
        public int FilmId { get; set; }
        public bool IsEnabled { get; set; } = true;
    }
}
