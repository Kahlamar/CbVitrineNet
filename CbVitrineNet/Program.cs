using CbVitrineNet.Components;
using Radzen;


namespace CbVitrineNet;

/// <summary>
/// Classe Program destiné au lancement de l'application Blazor
/// </summary>
public class Program
{
    /// <summary>
    /// Méthode principale pour la configuration et le lancement.
    /// 
    /// Les services configurés sont les services nécessaires au bon fonctionnement de la librairie Radzen.
    /// Le service HttpClient pour les requêtes est aussi déclaré ici.
    /// 
    /// </summary>
    /// <param name="args">Liste des arguments en cas de lancerment console</param>
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddRazorComponents().AddInteractiveServerComponents();
        builder.Services.AddRadzenComponents();
        builder.Services.AddScoped<ContextMenuService>();
        builder.Services.AddScoped<TooltipService>();
        builder.Services.AddScoped<NotificationService>();
        builder.Services.AddScoped<DialogService>();
        builder.Services.AddScoped<HttpClient>();

        var app = builder.Build();
        app.UseStaticFiles();
        app.UseAntiforgery();
        app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
        app.Run();
    }
}
