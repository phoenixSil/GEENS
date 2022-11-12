using Geens.Api.Modeles;
using Geens.Api.Modeles.Utils;

namespace Geens.Api.Dtos.Enseignants
{
    public interface IEnseignantDto
    {
        public DateTime DateDembauche { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
    }
}
