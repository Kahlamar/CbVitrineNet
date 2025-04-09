namespace VitrineApi.Classes.CV;

/// <summary>
/// Classe Certification (SQL Server)
/// </summary>
public class Certification
{
    /// <summary>
    /// Id de la Certification
    /// </summary>
    public int IdCertification { get; set; }

    /// <summary>
    /// Titre de la certification
    /// </summary>
    public string? Titre { get; set; }

    /// <summary>
    /// Organisme certifiant
    /// </summary>
    public string? OrganismeCertifiant { get; set; }

    /// <summary>
    /// Durée de validité en années
    /// </summary>
    public string? DureeValiditeAnnees { get; set; }
}
