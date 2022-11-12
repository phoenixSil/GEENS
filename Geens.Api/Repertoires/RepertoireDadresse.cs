using Geens.Api.Datas;
using Geens.Api.Modeles;
using Geens.Api.Repertoires.Contrats;
using Microsoft.EntityFrameworkCore;
using MsCommun.Repertoires;

namespace Geens.Api.Repertoires
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
