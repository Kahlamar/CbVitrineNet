﻿namespace VitrineApi.Classes.CV
{
    public class Formation
    {
        public int IdFormation { get; set; }
        public string DateDebut { get; set; }
        public string DateFin { get; set; }
        public string Titre { get; set; }
        public string Organisme { get; set; }
        public string Emplacement { get; set; }
        public string NiveauAtteint { get; set; }
        List<string> Cours { get; set; }

    }
}
