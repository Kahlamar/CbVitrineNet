namespace VitrineApi.Classes.CV;

/// <summary>
/// Classe Experience (SQL Server)
/// </summary>
public class Experience
{
    /// <summary>
    /// Id de l'expérience
    /// </summary>
    public int IdExperience { get; set; }

    /// <summary>
    /// Date de début
    /// </summary>
    public string? DateDebut { get; set; }

    /// <summary>
    /// Date de fin
    /// </summary>
    public string? DateFin { get; set; }

    /// <summary>
    /// Poste occupév
    /// </summary>
    public string? Poste { get; set; }

    /// <summary>
    /// Entreprise d'accueil
    /// </summary>
    public string? Entreprise { get; set; }

    /// <summary>
    /// Emplacement
    /// </summary>
    public string? Emplacement { get; set; }

    /// <summary>
    /// Liste des tâches effectuées
    /// </summary>
    public List<string>? TachesEffectuees { get; set; }
}
