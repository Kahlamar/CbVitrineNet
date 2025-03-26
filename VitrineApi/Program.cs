using VitrineApi.Services.Interfaces;
using VitrineApi.Services;
using StackExchange.Redis;

namespace VitrineApi
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddScoped<IVitrineService, VitrineService>();
            builder.Services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect("redis:6379"));
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            var app = builder.Build();
            app.MapControllers();
            app.MapGet("/", () => "Démarrage Microservice OK");
            app.Run();
        }
    }
}
