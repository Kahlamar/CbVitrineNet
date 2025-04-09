namespace VitrineApi.Classes.Dtos.CV;

/// <summary>
/// Expérience DTO
/// </summary>
public class ExperienceDto
{
    /// <summary>
    /// Date de début
    /// </summary>
    public string? DateDebut { get; set; }

    /// <summary>
    /// Date de fin
    /// </summary>
    public string? DateFin { get; set; }

    /// <summary>
    /// Poste Occupé
    /// </summary>
    public string? Poste { get; set; }

    /// <summary>
    /// Entreprise
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
