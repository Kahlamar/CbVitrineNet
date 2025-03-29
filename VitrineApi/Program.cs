using VitrineApi.Services.Interfaces;
using VitrineApi.Services;
using VitrineApi.Services.CV;
using MongoDB.Driver;
using CbVitrineNetClasses.Testing;
using Microsoft.Data.SqlClient;
using SharpCompress.Common;
using System.Text.RegularExpressions;
using MongoDB.Driver.Core.Configuration;
using System.Data;

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
        //builder.Services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect("redis:6379"));
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        builder.Services.AddSingleton<IMongoClient>(sp =>
        {
            return new MongoClient("mongodb://root:example@mongodb/");
        });

        SeedMongoDb();

        var app = builder.Build();
        app.MapControllers();
        app.MapGet("/", () => "Démarrage Microservice OK");
        app.Run();
    }

    private static void SeedMongoDb()
    {
        MongoClient mongoClient = new("mongodb://root:example@mongodb/");

        IAsyncCursor<string> cursorBdds = mongoClient.ListDatabaseNames();
        List<string> listeBdds = cursorBdds.ToList();

        if (!listeBdds.Contains("VitrineNet"))
        {
            IMongoDatabase vitrineNetBdd = mongoClient.GetDatabase("VitrineNet");
            IMongoCollection<UserStory> userStoriesCollection = vitrineNetBdd.GetCollection<UserStory>("UserStories");

            List<EtapeTestCase> etapesTestCaseValides =
            [
                new("1.1",
                    "Aller sur la page d'inscription",
                    "La page d'inscription s'affiche et le formulaire est remplissable",
                    "La page d'inscription est bien affichée et le formulaire est bien remplissable",
                    "Pass",
                    "1.1.1"),
                new ("1.2",
                     "Insérer le prénom valide dans le textbox Prénom",
                     "Le curseur est affiché dans le textbox et ce dernier est rempli avec le prénom valide",
                     "Le textbox est bien rempli avec le prénom",
                     "Pass",
                     "1.1.2")
            ];

            TestCase testCaseValide = new($"L'utilisateur souhaitant s'authentifier doit avoir une adresse mail ainsi qu'un état civil.",
                                          etapesTestCaseValides);

            UserStory usToInsert = new("Sign In Utilisateur",
                                       "Faible",
                                       "Haute",
                                       "Chrome, Edge, Safari",
                                       "form-signin",
                                       "description détaillée",
                                       testCaseValide);

            userStoriesCollection.InsertOne(usToInsert);
        }
        else
        {
            return;
        }
    }

}


// TODO: Écrire TDD dans l'onglet Testeur
// TODO: Faire un middleware d'Expo



