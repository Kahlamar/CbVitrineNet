using VitrineApi.Services.Interfaces;

namespace VitrineApi.Services;

public class VitrineService : IVitrineService
{
    public async Task<List<string>> GetBouchonnageAsync()
    {
        return new List<string>() { "Bou", "Chonnage" };
    }
}
