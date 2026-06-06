namespace EventSeatManager.Core.Database.Models
{
    public class Seats
    {
        public int Id { get; set; }
        public int Row { get; set; }
        public string TypeOfHall { get; set; } = string.Empty;
    }
}
