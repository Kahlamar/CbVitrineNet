namespace VitrineApi.Classes.Dtos.CV;

/// <summary>
/// Certification DTO
/// </summary>
public class CertificationDto
{
    /// <summary>
    /// Titre de la Certification
    /// </summary>
    public string? Titre { get; set; }

    /// <summary>
    /// Organisme Certifiant
    /// </summary>
    public string? OrganismeCertifiant { get; set; }

    /// <summary>
    /// Durée de validité en années
    /// </summary>
    public string? DureeValiditeAnnees { get; set; }
}
