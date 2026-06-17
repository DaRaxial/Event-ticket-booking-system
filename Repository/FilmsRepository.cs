using Dapper;
using EventSeatManager.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace EventSeatManager.Repository
{
    public class FilmsRepository
    {
        readonly private string _connString = ConfigurationManager.ConnectionStrings["postgresDbITOP"].ConnectionString;

        public async Task<List<Films>> GetAllFilms()
        {
            await using var conn = new NpgsqlConnection(_connString);
            await conn.OpenAsync();

            string getAllFilmsCmd = "SELECT * FROM Films ORDER BY id";
            var result = await conn.QueryAsync<Films>(getAllFilmsCmd);

            return result.ToList();
        }

        public async Task<List<Films>> GetDataFilmsForProfile()
        {
            await using var conn = new NpgsqlConnection(_connString);
            await conn.OpenAsync();

            string getAllFilmsCmd = "SELECT id FROM Films";
            var result = await conn.QueryAsync<Films>(getAllFilmsCmd);

            return result.ToList();
        }

        public async Task InsertBookedSeatsToFilm(List<int> seatPlace, int filmId)
        {
            try
            {
                await using var conn = new NpgsqlConnection(_connString);
                await conn.OpenAsync();

                string updateFilmTableCmd = """
                    UPDATE films
                    SET bookedseats = COALESCE(bookedseats, ARRAY[]::integer[]) || @bookedSeats
                    WHERE id = @id;
                """;

                var result = await conn.ExecuteAsync(updateFilmTableCmd,
                    new
                    {
                        bookedSeats = seatPlace,
                        id = filmId
                    });
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine($"Ошибка обновления записи в postgres: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Общая ошибка обновления записи: {ex.Message}");
            }
        }

        public async Task<List<int>> GetBookedSeatsForFilm(int filmId)
        {
            await using var conn = new NpgsqlConnection(_connString);
            await conn.OpenAsync();

            string getBookedSeatsCmd = "SELECT bookedseats FROM films WHERE id = @id";
            var result = await conn.QueryFirstOrDefaultAsync<int[]>(getBookedSeatsCmd, new { id = filmId });
            
            return result?.ToList() ?? new List<int>();
        }
    }
}
