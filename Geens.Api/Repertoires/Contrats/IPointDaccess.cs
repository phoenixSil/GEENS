namespace Geens.Api.Repertoires.Contrats
{
    public interface IPointDaccess : IDisposable
    {
        IRepertoireDadresse RepertoireDadresse { get; }
        IRepertoireDenseignant RepertoireDenseignant { get; }
        Task Enregistrer();
    }
}
