namespace Geens.Api.Dtos.Adresses
{
    public class AdresseACreerDto : IAdresseDto
    {
        public int Telephone { get; set; }
        public string Pays { get; set; }
        public string Region { get; set; }
        public string Ville { get; set; }
        public string Email { get; set; }
        public Guid EnseignantId { get; set; }
    }
}
