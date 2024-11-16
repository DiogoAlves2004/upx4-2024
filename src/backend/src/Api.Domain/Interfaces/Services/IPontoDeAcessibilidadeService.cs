using Flunt.Notifications;
using Infra.UPX4.Domain.Dto;
using Infra.UPX4.Domain.Entities;



namespace Infra.UPX4.Domain.Interfaces.Services
{
    public interface IPontoDeAcessibilidadeService
    {
        Task<PontoDeAcessibilidadeDto> Selecionar(Guid id);

        Task<IEnumerable<PontoDeAcessibilidadeDto>> Listar();

        Task<PontoDeAcessibilidadeDto> Salvar(PontoDeAcessibilidadeDto user);

        Task<(bool, List<Notification>)> Excluir(Guid id);

        Task<List<PontoDeAcessibilidadeEntity>> GetPontosDentroDosLimitesAsync(double north, double south, double east, double west);

    }
}