using Geens.Api.Modeles;
using Geens.Api.Modeles.Utils;

namespace Geens.Api.Dtos.Enseignants
{
    public class EnseignantDto : BaseDomainDto, IEnseignantDto
    {
        public DateTime DateDembauche { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
    }
}
