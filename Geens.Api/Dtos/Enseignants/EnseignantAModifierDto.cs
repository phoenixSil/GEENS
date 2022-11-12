using Geens.Api.Modeles;
using Geens.Api.Modeles.Utils;
using System.ComponentModel.DataAnnotations;

namespace Geens.Api.Dtos.Enseignants
{
    public class EnseignantAModifierDto : BaseDomainDto, IEnseignantDto
    {
        [Required]
        public SPECIALITE_ENSEIGNANT Specialite { get; set; }

        [Required]
        public NIVEAU_ETUDE Niveau { get; set; }
        public DateTime DateDembauche { get; set; }

        [Required]
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateDeNaissance { get; set; }

        [Required]
        public string CNI { get; set; }
    }
}
