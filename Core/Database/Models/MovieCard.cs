namespace EventSeatManager.Core.Database.Models
{
    public class MovieCard
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Poster { get; set; }
        public string Genre { get; set;  }
        public int Release { get; set; } // год выпуска
        public int Age_rating { get; set; }
    }
}
