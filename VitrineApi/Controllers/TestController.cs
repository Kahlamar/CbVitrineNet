using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace VitrineApi.Controllers;

[Route("api")]
[ApiController]
public class TestController : ControllerBase
{
    [HttpGet("test")]
    public async Task<IActionResult> TestAsync()
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
        return Ok(result);
    }
}


