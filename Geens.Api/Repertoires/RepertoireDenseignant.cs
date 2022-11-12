using Geens.Api.Datas;
using Geens.Api.Modeles;
using Geens.Api.Repertoires.Contrats;
using Microsoft.EntityFrameworkCore;
using MsCommun.Repertoires;

namespace Geens.Api.Repertoires
{
    public class RepertoireDenseignant : RepertoireGenerique<Enseignant>, IRepertoireDenseignant
    {
        private readonly EnseignantDbContext _context;
        public RepertoireDenseignant(EnseignantDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Enseignant> LireDetailDunEnseignant(Guid id)
        {
            var enseignant = await _context.Enseignants.Where(x => x.Id == id)
                .Include(etd => etd.Adresses).FirstOrDefaultAsync();

            return enseignant;
        }
    }
}
