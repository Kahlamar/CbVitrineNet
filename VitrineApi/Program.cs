using VitrineApi.Services.Interfaces;
using VitrineApi.Services;
using StackExchange.Redis;

namespace VitrineApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddScoped<IVitrineService, VitrineService>();
            builder.Services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect("redis:6379"));

            var app = builder.Build();
            app.MapControllers();
            app.MapGet("/", () => "Démarrage Microservice OK");
            app.Run();
        }
    }
}
