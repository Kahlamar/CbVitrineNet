namespace VitrineApi.Classes.Dtos.CV;

public class ExperienceDto
{
    public required DateTime DateDebut { get; set; }
    public required DateTime DateFin { get; set; }
    public required string Poste { get; set; }
    public required string Entreprise { get; set; }
    public required string Emplacement { get; set; }
    public required string Description { get; set; }
}
