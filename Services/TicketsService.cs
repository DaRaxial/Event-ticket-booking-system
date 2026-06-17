using Amazon.Runtime.Internal.Auth;
using EventSeatManager.Models;
using EventSeatManager.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventSeatManager.Services
{
    public class TicketsService
    {
        private readonly TicketsRepository _ticketsRepository = new();
        private readonly UserRepository _usersRepository = new();

        public async Task GetDataAndMakeTicketRequest(string sessionDate, List<int> bookedSeatPlaces, List<int> bookedRowPlaces, int filmId)
        {
            Users? currentUser = UserSessionService.CurrentUser;
            int userId = currentUser.Id;
            int newCount = UserSessionService.CurrentUser.CountOfTickets + 1;

            var rand = new Random();
            int specialId = rand.Next(1, 100000);
            await _ticketsRepository.CreateNewTicket(userId, sessionDate, specialId, bookedSeatPlaces, bookedRowPlaces, filmId);
        }

    }
}
