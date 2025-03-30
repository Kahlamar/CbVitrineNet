namespace VitrineApi.Classes.Dtos.CV
{
    public class FormationDto
    {
        public string? DateDebut { get; set; }
        public string? DateFin { get; set; }
        public string? Titre { get; set; }
        public string? Organisme { get; set; }
        public string? Emplacement { get; set; }
        public string? NiveauAtteint { get; set; }
        public List<string>? Cours { get; set; }
    }
}
