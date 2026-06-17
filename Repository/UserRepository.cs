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
        readonly private string _connString = ConfigurationManager.ConnectionStrings["postgresDbITOP"].ConnectionString;

        public async Task<Users> GetByEmail(string email)
        {
            await using var conn = new NpgsqlConnection(_connString);
            await conn.OpenAsync();

            string getUserByEmailCmd = "SELECT * FROM Users WHERE Email = @email";
            var result = await conn.QueryFirstOrDefaultAsync<Users>(getUserByEmailCmd, new { Email = email });

            if (result != null)
                UserSessionService.SetCurrentUser(result);
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

        public async Task<Users> GetAllUserDataById(int id)
        {
            await using var conn = new NpgsqlConnection(_connString);
            await conn.OpenAsync();

            string getUserByEmailCmd = "SELECT * FROM Users WHERE id = @id";
            return await conn.QueryFirstOrDefaultAsync<Users>(getUserByEmailCmd, new {id = id});
            
        }
        public async Task UpdateUserBalance(int id, decimal balance)
        {
            await using var conn = new NpgsqlConnection(_connString);
            await conn.OpenAsync();

            string createNewUserCmd = """
                    UPDATE Users
                    SET balance = @balance
                    WHERE id = @id
                """;
            var result = await conn.ExecuteAsync(createNewUserCmd, new { balance = balance, id = id });
        }
    }
}
