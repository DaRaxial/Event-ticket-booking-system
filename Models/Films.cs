using Avalonia.Media.Imaging;
using EventSeatManager.Utils;
using FluentAvalonia.UI.Controls.Primitives;
using System;
using System.Threading.Tasks;

namespace EventSeatManager.Models
{
    public class Films
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public int AgeRating { get; set; }
        public int Duration { get; set; }
        public string PosterPath { get; set; } = string.Empty;
        public Task<Bitmap?>? PosterImageToView { get; set; }
        public string SessionDate { get; set; } = string.Empty;
    }
}
