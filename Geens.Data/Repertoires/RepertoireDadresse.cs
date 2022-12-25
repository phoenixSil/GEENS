using Geens.Data;
using Geens.Data.Context;
using Geens.Domain.Modeles;
using Geens.Features.Contrats.Repertoires;
using Microsoft.EntityFrameworkCore;
using MsCommun.Repertoires;

namespace Geens.Data.Repertoires
{
    public class RepertoireDadresse : RepertoireGenerique<Adresse>, IRepertoireDadresse
    {
        private readonly EnseignantDbContext _context;
        public RepertoireDadresse(EnseignantDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Adresse>> LireToutesLesAdresseDunEnseignant(Guid enseignantId)
        {
            var listeAdresse = await _context.Adresses
                .Where(pers => pers.EnseignantId == enseignantId)
                .ToListAsync();

            return listeAdresse;
        }

    }
}
