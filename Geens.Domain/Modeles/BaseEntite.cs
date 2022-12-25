namespace Geens.Domain.Modeles
{
    public class BaseEntite
    {
        public Guid Id { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateDerniereModification { get; set; }
    }
}
