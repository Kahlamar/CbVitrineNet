namespace VitrineApi.Classes.CV;

public class Experience
{
    public int IdExperience { get; set; }
    public required DateOnly DateDebut { get; set; }
    public required DateOnly DateFin { get; set; }
    public required string Poste { get; set; }
    public required string Entreprise { get; set; }
    public required string Emplacement { get; set; }
    public required string Description { get; set; }
}
