using Geens.Domain.Modeles;
using Geens.Domain.Modeles.Utils;

namespace Geens.Features.Dtos.Enseignants
{
    public class EnseignantDto : BaseDomainDto, IEnseignantDto
    {
        public DateTime DateDembauche { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
    }
}
