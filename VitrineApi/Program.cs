using CbVitrineNetClasses.CV;
using CbVitrineNetClasses.Testing;
using MongoDB.Driver;
using VitrineApi.Services.CV;
using VitrineApi.Services.Interfaces;
using VitrineApi.Services.Testing;

namespace VitrineApi;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddScoped<ICvService, CvService>();
        builder.Services.AddScoped<ITestingService, TestingService>();
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

    public static void SeedMongoDb()
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

            List<Experience> experiences = [
                new("exp-1", "2022-10-01", "2024-10-01", "Développeur Informatique", "Infotel Conseil", "Aix-En-Provence", [ new("1"), new("2")]),
                new("exp-2", "2020-10-01", "2022-10-01", "Développeur Informatique", "BPCE-IT", "Aix-En-Provence", [ new("1"), new("2")]),
                new("exp-3", "2020-10-01", "2022-10-01", "Fondateur", "SAS Dealz", "Martigues", [ new("1"), new("2")])
                ];
            IMongoCollection<Experience> experiencesCollection = vitrineNetBdd.GetCollection<Experience>("Experiences");
            experiencesCollection.InsertMany(experiences);

            List<Formation> formations = [
                new("for-1", "2022-10-01", "2024-10-01", "Manager en architecture et applications logicielles des systèmes d'information", "CESI", "Aix-En-Provence","Bac +5", [ new("1"), new("2")]),
                new("for-2", "2020-10-01", "2022-10-01", "Développeur Informatique", "CESI", "Aix-En-Provence","Bac +2", [ new("1"), new("2")]),
                new("for-3", "2013-09-01", "2016-07-01", "Bachelor In Business Administration spé Banque/Finance", "Kedge Business School", "Marseille","Bac +3", [ new("1"), new("2")])
                ];
            IMongoCollection<Formation> formationsCollection = vitrineNetBdd.GetCollection<Formation>("Formations");
            formationsCollection.InsertMany(formations);

            List<Certification> certifications = [
                new("cert-ctfl-istqb", "Certified Tester Foundation Level", "ISTQB", 100),
                new("cert-pcap-pi", "Python Certitified Associate Programmer", "Python Institute", 3),
                new("cert-cap-ci", "C++ Certitified Associate Programmer", "C++ Institute", 3)];
            IMongoCollection<Certification> certificationsCollection = vitrineNetBdd.GetCollection<Certification>("Certifications");
            certificationsCollection.InsertMany(certifications);
        }
        else
        {
            return;
        }
    }
}
