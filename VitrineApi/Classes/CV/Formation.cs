namespace VitrineApi.Classes.CV;

/// <summary>
/// Classe Formation (SQL Server)
/// </summary>
public class Formation
{
    /// <summary>
    /// Id de la Formation
    /// </summary>
    public int IdFormation { get; set; }

    /// <summary>
    /// Date de début de la formation
    /// </summary>
    public string? DateDebut { get; set; }

    /// <summary>
    /// Date de fin de la formation
    /// </summary>
    public string? DateFin { get; set; }

    /// <summary>
    /// Titre de la formation
    /// </summary>
    public string? Titre { get; set; }

    /// <summary>
    /// Organisme de formation
    /// </summary>
    public string? Organisme { get; set; }

    /// <summary>
    /// Emplacement de la formation
    /// </summary>
    public string? Emplacement { get; set; }

    /// <summary>
    /// Niveau atteint
    /// </summary>
    public string? NiveauAtteint { get; set; }

    /// <summary>
    /// Liste des cours enseignés
    /// </summary>
    public List<string>? Cours { get; set; }
}
