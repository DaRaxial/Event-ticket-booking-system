using Dapper;
using EventSeatManager.Core.Database.Models;
using Npgsql;
using System;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace EventSeatManager.Repository
{
    public class UserRepository
    {
        readonly private string _connString = ConfigurationManager.ConnectionStrings["postgresDb"].ConnectionString;
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
            catch(NpgsqlException ex)
            {
                Console.WriteLine($"Проблема с созданием таблицы Users: {ex.Message}");
                return false;
            }
        }
        async public Task GetUserData()
        {
            Users userGetData = new Users();
        }
    }
}
