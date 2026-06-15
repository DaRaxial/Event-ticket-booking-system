using Dapper;
using EventSeatManager.Models;
using EventSeatManager.Services;
using Npgsql;
using System.Configuration;
using System.Threading.Tasks;

namespace EventSeatManager.Repository
{
    public class UserRepository
    {
        readonly private string _connString = ConfigurationManager.ConnectionStrings["postgresDb"].ConnectionString;

        public async Task<Users> GetByEmail(string email)
        {
            await using var conn = new NpgsqlConnection(_connString);
            await conn.OpenAsync();

            string getUserByEmailCmd = "SELECT * FROM Users WHERE Email = @email";
            var result = await conn.QueryFirstOrDefaultAsync<Users>(getUserByEmailCmd, new { Email = email });

            if (result != null)
                UserSession.SetCurrentUser(result);
            else
                return null;

            return result;
        }

        public async Task CreateNewUser(string firstName, string email, string password)
        {
            await using var conn = new NpgsqlConnection(_connString);
            await conn.OpenAsync();

            string createNewUserCmd = """
                    INSERT INTO Users (FirstName, Email, Password)
                    VALUES (@firstName, @email, @password)
                """;

            var result = await conn.QueryAsync<Users>(createNewUserCmd, new { FirstName = firstName, Email = email, Password = password });
        }
    }
}
