using Avalonia.Collections;
using EventSeatManager.Models;
using EventSeatManager.Repository;
using EventSeatManager.Repository.YandexCloud;
using EventSeatManager.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace EventSeatManager.Services
{
    public class FilmsService
    {
        private readonly FilmsRepository _filmsRepository;
        private readonly YandexCloudStorageRepository _ycStorageRepo = new();
        public Films? SelectedFilm { get; set; }

        public FilmsService()
        {
            _filmsRepository = new FilmsRepository();
        }

        public async Task<ObservableCollection<Films>> ProcessFilmsToDisplay()
        {
            try
            {
                var filmsFromDb = await _filmsRepository.GetAllFilms();

                var filmsViewModel = new ObservableCollection<Films>(
                    filmsFromDb.Select(film => new Films
                    {
                        Id = film.Id,
                        Title = film.Title,
                        Author = film.Author,
                        Genre = film.Genre,
                        Description = film.Description,
                        AgeRating = film.AgeRating,
                        Duration = film.Duration,
                        PosterImageToView = ImageHelper.LoadFromWeb(new Uri(_ycStorageRepo.GetObjectUrl(film.PosterPath))),
                        SessionDate = film.SessionDate,
                    }));

                return filmsViewModel;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка загрузки фильмов: {ex.Message}");
                return new ObservableCollection<Films>(); // пустой список фильмов
            }
        }

        public async Task GetDataAndUpdateFilmTable(List<int> seatPlace, int filmId)
            => await _filmsRepository.InsertBookedSeatsToFilm(seatPlace, filmId);

        public void GetFilmData(Films film)
        {
            SelectedFilm = film;
        }

        public async Task<List<int>> CheckSeatsStatus(int filmId)
        {
            var films = await _filmsRepository.GetBookedSeatsForFilm(filmId);
            return films;
        }
    }
}
