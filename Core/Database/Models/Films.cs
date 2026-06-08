using Avalonia.Media.Imaging;

namespace EventSeatManager.Core.Database.Models
{
    public class Films
    {
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public int AgeRating { get; set; }
        public int Release { get; set; } // год выпуска
        public string PosterPath { get; set; } = string.Empty;
    } 
}
