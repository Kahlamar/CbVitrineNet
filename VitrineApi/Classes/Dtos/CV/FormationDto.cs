namespace VitrineApi.Classes.Dtos.CV;

/// <summary>
/// Formation DTO
/// </summary>
public class FormationDto
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
    /// Titre de la formation
    /// </summary>
    public string? Titre { get; set; }

    /// <summary>
    /// Organisme
    /// </summary>
    public string? Organisme { get; set; }

    /// <summary>
    /// Emplacement
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
