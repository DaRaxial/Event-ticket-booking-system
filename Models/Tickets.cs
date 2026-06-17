using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventSeatManager.Models
{
    public class Tickets
    {
        public int Id { get; set; }
        public int BuyerId { get; set; }
        public string SessionDate { get; set; } = string.Empty;
        public int SpecialId { get; set; }
        public int[] SeatPlace { get; set; } = Array.Empty<int>();
        public int[] RowPlace { get; set; } = Array.Empty<int>();
        public int FilmId { get; set; }
    }
}
