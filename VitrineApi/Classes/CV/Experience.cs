namespace VitrineApi.Classes.CV;

public class Experience
{
    public int IdExperience { get; set; }
    public string DateDebut { get; set; }
    public string DateFin { get; set; }
    public string Poste { get; set; }
    public string Entreprise { get; set; }
    public string Emplacement { get; set; }
    public List<string> TachesEffectuees { get; set; }
}
