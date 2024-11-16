using Infra.UPX4.Domain.Entities;

namespace Infra.UPX4.Domain.Interfaces.Repositories
{
    public interface IPontoDeAcessibilidadeRepository : IRepository<PontoDeAcessibilidadeEntity>
    {
        Task<List<PontoDeAcessibilidadeEntity>> GetPontosDentroDosLimitesAsync(double north, double south, double east, double west);

    }
}