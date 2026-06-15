using Dapper;
using EventSeatManager.Models;
using EventSeatManager.Services;
using Npgsql;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace EventSeatManager.Repository
{
    public class FilmsRepository
    {
        readonly private string _connString = ConfigurationManager.ConnectionStrings["postgresDb"].ConnectionString;

        public async Task<List<Films>> GetAllFilms()
        {
            await using var conn = new NpgsqlConnection(_connString);
            await conn.OpenAsync();

            string getAllFilmsCmd = "SELECT * FROM Films ORDER BY id";
            var result = await conn.QueryAsync<Films>(getAllFilmsCmd);

            return result.ToList();
        }
    }
}
