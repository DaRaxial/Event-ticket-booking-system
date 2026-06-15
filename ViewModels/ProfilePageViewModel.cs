using CommunityToolkit.Mvvm.ComponentModel;
using EventSeatManager.Services;

namespace EventSeatManager.ViewModels
{
    public partial class ProfilePageViewModel : ObservableValidator
    {
        [ObservableProperty]
        private string _firstName;
        [ObservableProperty]
        private string _email;
        [ObservableProperty]
        private int _countOfTickets;

        public ProfilePageViewModel()
        {
            var user = UserSession.CurrentUser;

            FirstName = user!.FirstName;
            Email = user.Email;
            CountOfTickets = user.CountOfTickets;
        }

    }
}
