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
                // R�cup�ration de la cha�ne de connexion depuis la configuration
                // Par d�faut, on se connecte � mongodb://localhost:27017 si aucune configuration n'est d�finie
                var connectionString = builder.Configuration.GetValue<string>("mongodb://root:example@mongodb/") ?? "mongodb://root:example@mongodb/";
                return new MongoClient(connectionString);
            });

            var app = builder.Build();
            app.MapControllers();
            app.MapGet("/", () => "D�marrage Microservice OK");
            app.Run();
        }
    }
}

// TODO: Corriger la connectionString ligne 24 de program.cs de l'api
// TODO: �crire TDD dans l'onglet Testeur
// TODO: Faire un middleware d'Expo
// TODO: Remplkacer les h1 des onglets par du texte grossi



