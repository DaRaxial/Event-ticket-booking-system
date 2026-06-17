using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EventSeatManager.Models;
using EventSeatManager.Repository.YandexCloud;
using EventSeatManager.Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace EventSeatManager.ViewModels
{
    public partial class ProfilePageViewModel : ObservableValidator
    {
        private readonly YandexCloudStorageRepository _ycStorageRepo = new();
        private readonly UserProfileService _profileService = new();

        [ObservableProperty]
        private ObservableCollection<FilmsAndTickets>? _ticketData = new();


        [ObservableProperty]
        private string _firstName = string.Empty;
        [ObservableProperty]
        private string _email = string.Empty;
        [ObservableProperty]
        private int _countOfTickets;

        [ObservableProperty]
        private decimal _balance;

        public ProfilePageViewModel()
        {
            InitializeUserData();
            _ = LoadDataAsync();
        }

        [RelayCommand]
        private async void UpdateTicketList()
        {
            InitializeUserData();
            await LoadDataAsync();
            await LoadCurrentBalance();
        }

        [RelayCommand]
        private void AddToBalance()
        {
            Balance += 1000;
            _profileService.UpdateBalance(Balance);
        }
        private void InitializeUserData()
        {
            var user = UserSessionService.CurrentUser;
            
            FirstName = user?.FirstName ?? "Неизвестно";
            Email = user?.Email ?? "Неизвестно";
            CountOfTickets = user?.CountOfTickets ?? 0;
            Balance = (decimal)(user?.Balance);
        }

        private async Task LoadDataAsync()
        {
            try
            {
                await _profileService.GetAllDataToDisplay();
                if (_profileService.TicketDataService?.Any() == true)
                {
                    var reversedList = _profileService.TicketDataService.Reverse().ToList();
                    TicketData.Clear();
                    foreach (var item in reversedList)
                    {
                        TicketData.Add(item);
                    }
                    CountOfTickets = TicketData.Count();
                }
                else
                {
                    Console.WriteLine("Данные загружены, но коллекция пуста");
                }
                var currentBalance = await _profileService.GetNewBalance();
                Balance = currentBalance;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка загрузки данных в ViewModel: {ex.Message}");
            }
        }
        private async Task LoadCurrentBalance()
        {
            var balance = await _profileService.GetNewBalance();
        }
    }
}
