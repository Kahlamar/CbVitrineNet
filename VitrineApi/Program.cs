using VitrineApi.Services.Interfaces;
using VitrineApi.Services;
using StackExchange.Redis;
using VitrineApi.Services.CV;
using MongoDB.Driver;

namespace VitrineApi;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddScoped<IVitrineService, VitrineService>();
        builder.Services.AddScoped<ICvService, CvService>();
        builder.Services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect("redis:6379"));
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        builder.Services.AddSingleton<IMongoClient>(sp =>
        {
            var connectionString = builder.Configuration.GetValue<string>("mongodb://root:example@mongodb/")
            ?? "mongodb://root:example@mongodb/";
            return new MongoClient(connectionString);
        });
        //builder.Services.AddGraphQLServer();

        var app = builder.Build();
        app.MapControllers();
        app.MapGet("/", () => "Démarrage Microservice OK");
        app.Run();
    }
}
