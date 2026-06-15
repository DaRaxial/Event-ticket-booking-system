using Avalonia.Data;

namespace EventSeatManager.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int CountOfTickets { get; set; }
        public decimal Balance { get; set; }
    }
}
