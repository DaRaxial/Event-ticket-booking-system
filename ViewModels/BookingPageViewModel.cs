using Avalonia.Controls;
using Avalonia.VisualTree;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dapper;
using EventSeatManager.Models;
using EventSeatManager.Services;
using EventSeatManager.Services.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace EventSeatManager.ViewModels
{
    public partial class BookingPageViewModel : ObservableObject
    {
        // Поля и свойства
        private readonly TicketsService _ticketsService = new();
        private readonly FilmsService _filmsService = new();
        private readonly UserProfileService _userService = new();

        [ObservableProperty]
        private ObservableCollection<Seats>? _seats = new();
        [ObservableProperty]
        private ObservableCollection<Seats>? _bookedSeats = new() { };

        private const decimal _ticketPrice = 500;

        [ObservableProperty]
        private string _title = string.Empty;

        [ObservableProperty]
        private string _sessionDate = string.Empty;

        [ObservableProperty]
        private int _selectedSeatsCount;

        [ObservableProperty]
        private decimal _totalPrice;

        [ObservableProperty]
        private string _errorMessage = string.Empty;

        private int _filmId;

        // Конструкторы
        public BookingPageViewModel(Films film)
        {
            LoadSeats();
            UpdateWithFilm(film);
        }
        public BookingPageViewModel()
        {
            LoadSeats();
        }

        // Методы
        private void LoadSeats()
        {
            for (int i = 1; i <= 36; i++)
            {
                Seats?.Add(new Seats
                {
                    Id = i,
                    Row = (i - 1) / 6 + 1
                });
            }
            BookedSeats?.Clear();
        }

        [RelayCommand]
        private void AddSeatPlace(Seats seat)
        {
            if (seat == null) return;

            if (!BookedSeats!.Contains(seat))
            {
                BookedSeats.Add(seat);
                SelectedSeatsCount++;
                TotalPrice += _ticketPrice;
            }
        }

        [RelayCommand]
        private void ClearTickets()
        {
            BookedSeats?.Clear();
            TotalPrice = 0;
        }

        [RelayCommand]
        private async void ConfirmPayment()
        {
            if (BookedSeats != null)
            {
                if (BookedSeats == null || !BookedSeats.Any())
                    return;

                var seatPlaces = BookedSeats?.Select(s => s.Id).ToList();
                var rowPlaces = BookedSeats?.Select(r => r.Row).ToList();

                try
                {
                    bool balanceDeducted = await _userService.BalanceDecreaseFromBooking(TotalPrice);

                    if (!balanceDeducted)
                    {
                        ErrorMessage = "Недостаточно\n      средств";
                        return;
                    }
                    ErrorMessage = string.Empty;

                    await _ticketsService?.GetDataAndMakeTicketRequest(SessionDate, seatPlaces, rowPlaces, _filmId);
                    await _filmsService?.GetDataAndUpdateFilmTable(seatPlaces, _filmId);


                    ClearTickets();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при оплате: {ex.Message}");
                }
            }
        }


        public void UpdateWithFilm(Films film)
        {
            Title = film.Title;
            SessionDate = film.SessionDate;
            _filmId = film.Id;
            TotalPrice = 0;
            BookedSeats?.Clear();
        }

        // Верхняя панель (навигация)
        [RelayCommand]
        private void GoToProfilePage() => AppNavigationService.MainFrame!.Navigate(typeof(ProfilePage));

        [RelayCommand]
        private void GoToMainPage() => AppNavigationService.MainFrame!.Navigate(typeof(MainFilmSystemPage));
    }
}