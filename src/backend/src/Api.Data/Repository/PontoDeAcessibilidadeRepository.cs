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

    }
}