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
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        builder.Services.AddSingleton<IMongoClient>(sp =>
        {
            return new MongoClient("mongodb://root:example@mongodb/");
        });

        SeedMongoDb();

        var app = builder.Build();
        app.MapControllers();
        app.MapGet("/", () => "Démarrage API OK");
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
                     "Insérer le nom valide dans la textbox Nom",
                     "Le curseur est affiché dans la textbox et cette dernière est remplie avec le nom valide",
                     "La textbox est bien remplie avec le nom",
                     "Pass",
                     "1.1.2"),
                new ("1.3",
                     "Insérer le prénom valide dans la textbox Prénom",
                     "Le curseur est affiché dans la textbox et cette dernière est remplie avec le prénom valide",
                     "La textbox est bien remplie avec le prénom",
                     "Pass",
                     "1.1.3"),
                new ("1.4",
                     "Insérer le mail valide dans la textbox Mail",
                     "Le curseur est affiché dans la textbox et cette dernière est remplie avec le mail valide",
                     "La textbox est bien remplie avec le Mail",
                     "Pass",
                     "1.1.4"),
                new ("1.5",
                     "Insérer le mot de passe valide dans la textbox Mot de Passe",
                     "Le curseur est affiché dans la textbox et cette dernière est remplie avec le mot de passe valide",
                     "La textbox est bien remplie avec le mot de passe valide (volontairement visible)",
                     "Pass",
                     "1.1.5"),
                new ("1.6",
                     "Insérer le mot de passe valide de confirmation dans la textbox Mot de Passe",
                     "Le curseur est affiché dans la textbox et cette dernière est remplie avec le mot de passe valide",
                     "La textbox est bien remplie avec le mot de passe valide de confirmation (volontairement visible)",
                     "Pass",
                     "1.1.6"),
                new ("1.7",
                     "Cliquer sur le bouton submit",
                     "La procédure de création d'utilisateur commence et nous sommes renvoyés sur notre compte.",
                     "La procédure de création d'utilisateur a bien commencé et nous sommes renvoyés sur notre compte.",
                     "Pass",
                     "1.1.7")
            ];

            TestCase testCaseValide = new($"L'utilisateur souhaitant s'authentifier doit avoir une adresse mail ainsi qu'un état civil.",
                                          etapesTestCaseValides);

            UserStory usToInsert = new("Sign In Utilisateur",
                                       "Faible",
                                       "Haute",
                                       "Chrome, Edge, Safari",
                                       "form-signin",
                                       "En tant que nouvel utilisateur, je souhaite créer un compte utilisateur afin de pouvoir accéder à toutes les fonctionnalités réservées aux membres inscrits." +
                                       "\r\n\r\nCritères d'acceptation :" +
                                       "\r\n- L'utilisateur peut saisir une adresse email valide et un mot de passe." +
                                       "\r\n- Un contrôle est effectué pour vérifier que l'adresse email n'est pas déjà utilisée." +
                                       "\r\n- Le mot de passe doit respecter les critères de sécurité minimaux (longueur minimum, présence d'un caractère spécial, etc.)." +
                                       "\r\n- Une fois confirmé, le compte utilisateur est activé automatiquement, et l'utilisateur est redirigé vers la page d'accueil connecté.",
                                       testCaseValide);

            userStoriesCollection.InsertOne(usToInsert);

            List<Experience> experiences = [
                new("exp-1", "2022-10-01", "2024-10-01", "Développeur Informatique", "Infotel Conseil", "Aix-En-Provence",
                [
                    new("Développement solution .Net (Blazor/ASP/Entity Framework/SQL Server)"),
                    new("Modélisations Schémas BDD SQL Server et architecture logicielle"),
                    new("Conceptions et exécutions des tests unitaires avec MSTest"),
                    new("Analyse du code et optimisation avec SonarQube"),
                    new("Travail d'équipe, meetings agile et rédactions documentations")
                ]),
                new("exp-2", "2020-10-01", "2022-10-01", "Développeur Informatique", "BPCE-IT", "Aix-En-Provence",
                [
                    new("Développement de solutions web destinées aux postes de travail BPCE-IT"),
                    new("Réalisation application complète .Net (Blazor/ASP/SQL Server)"),
                    new("Assistance pour un outil interne avec WPF"),
                    new("Conceptions et exécutions de tests unitaires avec MSTest"),
                    new("Travail d'équipe, meetings agile et rédactions documentations")
                ]),
                new("exp-3", "2020-10-01", "2022-10-01", "Fondateur", "SAS Dealz", "Martigues",
                [
                    new("Rédaction Business Plan, cahier des charges et specs techniques"),
                    new("Recherche partenaires financiers et informatiques"),
                    new("Prototypage Application Mobile et apprentissage programmation"),
                    new("Gestion de la vie de l'entreprise")
                ])
                ];
            IMongoCollection<Experience> experiencesCollection = vitrineNetBdd.GetCollection<Experience>("Experiences");
            experiencesCollection.InsertMany(experiences);

            List<Formation> formations = [
                new("for-1", "2022-10-01", "2024-10-01", "Manager en architecture et applications logicielles des systèmes d'information", "CESI", "Aix-En-Provence","Bac +5",
                [
                    new("Architecture Logicielle"),
                    new("Gestion de projet"),
                    new("Gestion des tests"),
                    new("Management"),
                    new("Référentiels SI")
                ]),
                new("for-2", "2020-10-01", "2022-10-01", "Développeur Informatique", "CESI", "Aix-En-Provence","Bac +2",
                [
                    new("C#/Java/Python"),
                    new("SQL/NoSQL"),
                    new("Méthodes Agiles"),
                    new("Docker"),
                    new("Git")
                ]),
                new("for-3", "2013-09-01", "2016-07-01", "Bachelor In Business Administration spé Banque/Finance", "Kedge Business School", "Marseille","Bac +3",
                [
                    new("Banque/Finance"),
                    new("Anglais"),
                    new("Management financier"),
                    new("Négociation/Vente"),
                    new("Marketing")
                ])
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

// TODO: Faire le README.md
// TODO: Faire les Tests Unitaires, BDD & Fonctionnels
