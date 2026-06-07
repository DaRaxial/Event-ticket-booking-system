using Dapper;
using Npgsql;
using System;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace EventSeatManager.Repository
{
    public static class CreateTablesRepository
    {
        readonly private static string _connString = ConfigurationManager.ConnectionStrings["postgresDb"].ConnectionString;

        async public static Task CreateAllTables()
        {
            await CreateTableUsers();
            await CreateTableHalls();
            await CreateTableFilms();
            await CreateTableSeats();
            await CreateTableTickets();
        }

        async public static Task<bool> CreateTableUsers()
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
        }
        async public static Task<bool> CreateTableHalls()
        {
            try
            {
                await using var conn = new NpgsqlConnection(_connString);
                await conn.OpenAsync();
                string sql = File.ReadAllText("/SqlRequests/CreateTableHalls.sql");

                await conn.ExecuteAsync(sql);
                return true;
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine($"Проблема с созданием таблицы Halls: {ex.Message}");
                return false;
            }
        }
        async public static Task<bool> CreateTableFilms()
        {
            try
            {
                await using var conn = new NpgsqlConnection(_connString);
                await conn.OpenAsync();
                string sql = File.ReadAllText("/SqlRequests/CreateTableFilms.sql");

                await conn.ExecuteAsync(sql);
                return true;
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine($"Проблема с созданием таблицы Films: {ex.Message}");
                return false;
            }
        }
        async public static Task<bool> CreateTableSeats()
        {
            try
            {
                await using var conn = new NpgsqlConnection(_connString);
                await conn.OpenAsync();
                string sql = File.ReadAllText("/SqlRequests/CreateTableSeats.sql");

                await conn.ExecuteAsync(sql);
                return true;
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine($"Проблема с созданием таблицы Seats: {ex.Message}");
                return false;
            }
        }
        async public static Task<bool> CreateTableTickets()
        {
            try
            {
                await using var conn = new NpgsqlConnection(_connString);
                await conn.OpenAsync();
                string sql = File.ReadAllText("/SqlRequests/CreateTableTickets.sql");

                await conn.ExecuteAsync(sql);
                return true;
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine($"Проблема с созданием таблицы Tickets: {ex.Message}");
                return false;
            }
        }
    }
}
