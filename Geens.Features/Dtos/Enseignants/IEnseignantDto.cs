using Geens.Domain.Modeles;
using Geens.Domain.Modeles.Utils;

namespace Geens.Features.Dtos.Enseignants
{
    public interface IEnseignantDto
    {
        public DateTime DateDembauche { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
    }
}
