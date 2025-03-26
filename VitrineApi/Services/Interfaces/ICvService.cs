using VitrineApi.Classes.CV;

namespace VitrineApi.Services.Interfaces;

public interface ICvService
{
    Task<IAsyncEnumerable<Experience>> GetExperiencesAsync();
}
