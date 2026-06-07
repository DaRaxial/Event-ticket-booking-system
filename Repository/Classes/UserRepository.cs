using Dapper;
using EventSeatManager.Core.Database.Models;
using Npgsql;
using System.Configuration;
using System.Threading.Tasks;

namespace EventSeatManager.Repository.Classes
{
    public class UserRepository
    {
        readonly private string _connString = ConfigurationManager.ConnectionStrings["postgresDb"].ConnectionString;

        /*// Создание таблицы в случае отсутсвия
        async public Task<bool> CreateTableUsers()
        {
            try
            {
                await using var conn = new NpgsqlConnection(_connString);
                await conn.OpenAsync();
                string sql = File.ReadAllText("/SqlRequests/CreateTableUsers.sql");

                await conn.ExecuteAsync(sql);
                return true;
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine($"Проблема с созданием таблицы Users: {ex.Message}");
                return false;
            }
        }*/

        public async Task<Users> GetByEmail(string email)
        {
            await using var conn = new NpgsqlConnection(_connString);
            await conn.OpenAsync();

            string getUserByEmailCmd = "SELECT * FROM Users WHERE Email = @email";
            var result = await conn.QueryFirstOrDefaultAsync<Users>(getUserByEmailCmd, new { Email = email });
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
