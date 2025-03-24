using Microsoft.Data.SqlClient;
using VitrineApi.Services.Interfaces;

namespace VitrineApi.Services;

public class VitrineService : IVitrineService
{
    public async Task<List<string>> GetBouchonnageAsync()
    {
        string connectionString = "Server=sqlservervitrine,1433;Database=Vitrine;User Id=sa;Password=MotDePasse!;Encrypt=False;";
        var result = new List<string>();
        using (var connection = new SqlConnection(connectionString))
        {
            await connection.OpenAsync();
            var cmd = new SqlCommand("SELECT * FROM TestTable;", connection);
            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    result.Add(reader.GetString(0));
                }
            }
        }
        return result;
    }
}