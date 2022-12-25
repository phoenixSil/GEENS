using Geens.Features.Dtos.Adresses;
using System.ComponentModel.DataAnnotations;
using Geens.Domain.Modeles.Utils;
using Geens.Domain.Modeles;

namespace Geens.Features.Dtos.Enseignants
{
    public class EnseignantACreerDto: IEnseignantDto
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
