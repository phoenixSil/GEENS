using Geens.Api.Modeles.Utils;

namespace Geens.Api.Dtos.Enseignants
{
    public class EnseignantGdcACreerDto
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public Guid NumeroExterne { get; set; }
		public SPECIALITE_ENSEIGNANT Specialite { get; set; }
		public NIVEAU_ETUDE Niveau { get; set; }
    }
}
