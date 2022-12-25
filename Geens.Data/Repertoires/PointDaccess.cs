using Geens.Data;
using Geens.Data.Context;
using Geens.Features.Contrats.Repertoires;

namespace Geens.Data.Repertoires
{
    public class PointDaccess : IPointDaccess
    {
        private readonly EnseignantDbContext _context;
        private IRepertoireDenseignant _repertoireDenseignant;
        private IRepertoireDadresse _repertoireDadresse;

        public PointDaccess(EnseignantDbContext context)
        {
            _context = context;
        }

        public async Task Enregistrer()
        {
            await _context.SaveChangesAsync();
        }

        public IRepertoireDadresse RepertoireDadresse => _repertoireDadresse ??= new RepertoireDadresse(_context);
        public IRepertoireDenseignant RepertoireDenseignant => _repertoireDenseignant ??= new RepertoireDenseignant(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
