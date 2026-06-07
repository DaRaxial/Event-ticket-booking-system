using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EventSeatManager.Core.Database.Models
{
    public class Tickets
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string BuyerName { get; set; } = string.Empty;
        public required Date BoughtDate { get; set; }
        public required Date SessionDate { get; set; }
        public int SpecialId { get; set; }
        public int SeatPlace { get; set; }
        public int RowPlace { get; set; }
    }
}
