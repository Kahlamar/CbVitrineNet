namespace VitrineApi.Classes.Dtos.CV
{
    public class FormationDto
    {
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public string Titre { get; set; }
        public string Organisme { get; set; }
        public string Emplacement { get; set; }
        public string NiveauAtteint { get; set; }
        List<string> Cours { get; set; }
    }
}
