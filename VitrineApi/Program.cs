using VitrineApi.Services.Interfaces;
using VitrineApi.Services;
using StackExchange.Redis;
using VitrineApi.Services.CV;
using MongoDB.Driver;

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
            builder.Services.AddScoped<ICvService, CvService>();
            //builder.Services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect("redis:6379"));
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddSingleton<IMongoClient>(sp =>
            {
                // Récupération de la chaîne de connexion depuis la configuration
                // Par défaut, on se connecte à mongodb://localhost:27017 si aucune configuration n'est définie
                var connectionString = builder.Configuration.GetValue<string>("mongodb://root:example@localhost/") ?? "mongodb://root:example@localhost/";
                return new MongoClient(connectionString);
            });

            var app = builder.Build();
            app.MapControllers();
            app.MapGet("/", () => "Démarrage Microservice OK");
            app.Run();
        }
    }
}
