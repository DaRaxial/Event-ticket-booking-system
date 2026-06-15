namespace EventSeatManager.Models
{
    public class Seats
    {
        public int Id { get; set; }
        public int Row { get; set; } = 1;
        public int FilmId { get; set; }
        public bool IsAvailable { get; set; } = true;
        public bool SelectedSeat { get; set;}
    }
}
