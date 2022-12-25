using Geens.Domain.Modeles.Utils;
using Geens.Features.Dtos.Adresses;
using System.ComponentModel.DataAnnotations.Schema;
using Geens.Domain.Modeles;

namespace Geens.Features.Dtos.Enseignants
{
    public class EnseignantDetailDto : BaseDomainDto, IEnseignantDto
    {
        public SPECIALITE_ENSEIGNANT Specialite { get; set; }
        public NIVEAU_ETUDE Niveau { get; set; }
        public DateTime DateDembauche { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateDeNaissance { get; set; }
        public string CNI { get; set; }
        public virtual List<AdresseDto> Adresses { get; set; }
    }
}
