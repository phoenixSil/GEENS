using Geens.Data;
using Geens.Data.Context;
using Geens.Domain.Modeles;
using Geens.Features.Contrats.Repertoires;
using Microsoft.EntityFrameworkCore;
using MsCommun.Repertoires;

namespace Geens.Data.Repertoires
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
