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
    public class TicketsRepository
    {
        readonly private string _connString = ConfigurationManager.ConnectionStrings["postgresDbITOP"].ConnectionString;

        // После оплаты создание билета (привязано к id пользователя)
        public async Task CreateNewTicket(int buyerId, string sessionDate, int specialId, List<int> seatPlace, List<int> rowPlace, int filmId)
        {
            try
            {
                await using var conn = new NpgsqlConnection(_connString);
                await conn.OpenAsync();

                string getUserByEmailCmd = """
                    INSERT INTO tickets (buyerid, sessiondate, specialid, seatplace, rowplace, filmid)
                    VALUES (@buyerId, @sessionDate, @specialId, @seatPlace, @rowPlace, @filmId)
                """;

                var result = await conn.ExecuteAsync(getUserByEmailCmd,
                    new
                    {
                        BuyerId = buyerId,
                        SessionDate = sessionDate,
                        SpecialId = specialId,
                        SeatPlace = seatPlace,
                        RowPlace = rowPlace,
                        FilmId = filmId
                    });
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine($"Ошибка создание билета в postgresDb: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Общая ошибка создания билета: {ex.Message}");
            }
        }

        public async Task<List<Tickets>> GetDataForProfile()
        {
            try
            {
                await using var conn = new NpgsqlConnection(_connString);
                await conn.OpenAsync();

                string getTicketsDataCmd = "SELECT * FROM tickets";

                var result = await conn.QueryAsync<Tickets>(getTicketsDataCmd);
                return result.ToList();
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine($"Ошибка загрузки билетов из postgresDb: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Общая ошибка: {ex.Message}");
                return null;
            }
        }
    }
}