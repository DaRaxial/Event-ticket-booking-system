namespace EventSeatManager.Core.Database.Models
{
    public class Halls
    {
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public bool Available { get; set; }
    }
}
