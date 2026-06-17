using CommunityToolkit.Mvvm.ComponentModel;
using EventSeatManager.Models;
using EventSeatManager.Repository;
using EventSeatManager.Repository.YandexCloud;
using EventSeatManager.Utils;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace EventSeatManager.Services
{
    public partial class UserProfileService : ObservableObject
    {
        private readonly TicketsRepository _ticketRepository = new();
        private readonly FilmsRepository _filmsRepository = new();
        private readonly UserRepository _userRepository = new();
        private readonly YandexCloudStorageRepository _ycStorageRepo = new();


        [ObservableProperty]
        private ObservableCollection<FilmsAndTickets>? _ticketDataService = new();

        public async Task GetAllDataToDisplay()
        {
            TicketDataService?.Clear();

            {
                var films = await _filmsRepository.GetAllFilms();
                var tickets = await _ticketRepository.GetDataForProfile();

                var userTickets = tickets.Where(t => t.BuyerId == UserSessionService.CurrentUser!.Id).ToList();

                foreach (var ticket in userTickets)
                {
                    var film = films.FirstOrDefault(f => f.Id == ticket.FilmId);
                    if (film == null) continue;

                    try
                    {
                        var combinedData = new FilmsAndTickets
                        {
                            FilmId = film.Id,
                            FilmTitle = film.Title,
                            FilmGenre = film.Genre,
                            FilmAgeRating = film.AgeRating,
                            FilmPosterImageToView = ImageHelper.LoadFromWeb(new Uri(_ycStorageRepo.GetObjectUrl(film.PosterPath))),
                            TicketSessionDate = ticket.SessionDate,
                            TicketSpecialId = ticket.SpecialId,
                            TicketSeatPlace = new ObservableCollection<int>(ticket.SeatPlace),
                            TicketRowPlace = new ObservableCollection<int>(ticket.RowPlace)
                        };
                        combinedData.UpdateDisplayStrings();
                        TicketDataService?.Add(combinedData);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка создания списка билетов: {ex.Message}");
                    }
                }
            }
        }

        public async Task UpdateBalance(decimal balance)
            => await _userRepository.UpdateUserBalance(UserSessionService.CurrentUser!.Id, balance);

        public async Task<decimal> GetNewBalance()
        {
            var user = await _userRepository.GetAllUserDataById(UserSessionService.CurrentUser!.Id);
            if (user != null)
            {
                UserSessionService.SetCurrentUser(user);
                return user.Balance;
            }
            return 0m;
        }

        public async Task<bool> BalanceDecreaseFromBooking(decimal amount)
        {
            var currentUser = UserSessionService.CurrentUser;
            if (currentUser == null)
                return false;

            if (currentUser.Balance < amount)
                return false;

            await _userRepository.UpdateUserBalance(currentUser.Id, currentUser.Balance - amount);

            var updatedUser = await _userRepository.GetAllUserDataById(currentUser.Id);
            if (updatedUser != null)
            {
                UserSessionService.SetCurrentUser(updatedUser);
                return true;
            }
            return false;
        }

    }
}
