namespace EventSeatManager.Core.Database.Models
{
    public class MovieCard
    {
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Poster { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public int Release { get; set; } // год выпуска
        public int AgeRating { get; set; }
    }
}
