using Infra.UPX4.Data.Context;
using Infra.UPX4.Domain.Entities;
using Infra.UPX4.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;


namespace Infra.UPX4.Data.Repository
{
    public class PontoDeAcessibilidadeRepository : BaseRepository<PontoDeAcessibilidadeEntity>, IPontoDeAcessibilidadeRepository
    {
        private DbSet<PontoDeAcessibilidadeEntity> _dataset;

        public PontoDeAcessibilidadeRepository(MyContext context) : base(context)
        {
            _dataset = _context.Set<PontoDeAcessibilidadeEntity>();
        }

        public async Task<List<PontoDeAcessibilidadeEntity>> GetPontosDentroDosLimitesAsync(double north, double south, double east, double west)
        {
            return await _dataset
                .Where(p => p.cordy >= south &&
                            p.cordy <= north &&
                            p.cordx >= west &&
                            p.cordx <= east)
                .ToListAsync();
        }

    }
}