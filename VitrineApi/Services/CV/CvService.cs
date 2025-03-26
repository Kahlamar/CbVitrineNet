using Microsoft.Data.SqlClient;
using VitrineApi.Classes.CV;
using VitrineApi.Services.Interfaces;

namespace VitrineApi.Services.CV;

public class CvService : ICvService
{
    public async Task<IAsyncEnumerable<Experience>> GetExperiencesAsync()
    {
        string connectionString = "Server=sqlservervitrine,1433;Database=Vitrine;User Id=sa;Password=MotDePasse!;Encrypt=False;";
        IAsyncEnumerable<Experience> experiences;
        using (var connection = new SqlConnection(connectionString))
        {
            await connection.OpenAsync();
            var cmd = new SqlCommand("SELECT * FROM TestTable;", connection);
            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    //experiences.Add(reader.GetString(0));
                }
            }
        }
        return experiences;
    }
}
