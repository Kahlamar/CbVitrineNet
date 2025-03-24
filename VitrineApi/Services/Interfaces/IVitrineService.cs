
namespace VitrineApi.Services.Interfaces;

public interface IVitrineService
{
    Task<List<string>> GetBouchonnageAsync();
}
