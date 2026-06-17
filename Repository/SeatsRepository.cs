using System.Configuration;

namespace EventSeatManager.Repository
{
    public class SeatsRepository
    {
        readonly private string _connString = ConfigurationManager.ConnectionStrings["postgresDbITOP"].ConnectionString;
    }
}
