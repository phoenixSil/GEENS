using Geens.Api.Dtos.Adresses;
using System.ComponentModel.DataAnnotations;
using Geens.Api.Modeles.Utils;
using Geens.Api.Modeles;

namespace Geens.Api.Dtos.Enseignants
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
