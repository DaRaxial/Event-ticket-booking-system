using EventSeatManager.Repository;

namespace EventSeatManager.Services
{
    public class SeatsService
    {
        private readonly SeatsRepository _seatsRepository;

        public SeatsService()
        {
            _seatsRepository = new SeatsRepository();
        }


    }
}
