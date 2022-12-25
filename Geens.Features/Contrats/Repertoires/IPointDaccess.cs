namespace Geens.Features.Contrats.Repertoires
{
    public interface IPointDaccess : IDisposable
    {
        IRepertoireDadresse RepertoireDadresse { get; }
        IRepertoireDenseignant RepertoireDenseignant { get; }
        Task Enregistrer();
    }
}
