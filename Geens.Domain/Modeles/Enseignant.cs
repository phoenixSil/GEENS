using Geens.Domain.Modeles.Utils;
using System.ComponentModel.DataAnnotations;

namespace Geens.Domain.Modeles
{
    public class Enseignant: BaseEntite
    {
        public SPECIALITE_ENSEIGNANT Specialite { get; set; }
        public NIVEAU_ETUDE Niveau { get; set; }
        public DateTime DateDembauche { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateDeNaissance { get; set; }
        public string CNI { get; set; }
        public virtual List<Adresse> Adresses { get; set; }
    }
}
