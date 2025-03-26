using Microsoft.Data.SqlClient;
using VitrineApi.Classes.CV;
using VitrineApi.Services.Interfaces;

namespace VitrineApi.Services.CV;

public class CvService : ICvService
{
    public async Task<List<Experience>> GetExperiencesAsync()
    {
        string connectionString = "Server=sqlservervitrine,1433;Database=Vitrine;User Id=sa;Password=MotDePasse!;Encrypt=False;";
        List<Experience> experiences = [];
        using (var connection = new SqlConnection(connectionString))
        {
            await connection.OpenAsync();
            var cmd = new SqlCommand("SELECT * FROM Experiences;", connection);
            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    experiences.Add(new Experience
                    {
                        IdExperience = reader.GetInt32(0),
                        DateDebut = reader.GetDateTime(1),
                        DateFin = reader.GetDateTime(2),
                        Poste = reader.GetString(3),
                        Entreprise = reader.GetString(4),
                        Emplacement = reader.GetString(5),
                        Description = reader.GetString(6),
                    });
                }
            }
        }
        return experiences;
    }
}
