using Flunt.Notifications;
using Infra.UPX4.Domain.Dto;



namespace Infra.UPX4.Domain.Interfaces.Services
{
    public interface IPontoDeAcessibilidadeService
    {
        Task<PontoDeAcessibilidadeDto> Selecionar(Guid id);

        Task<IEnumerable<PontoDeAcessibilidadeDto>> Listar();
        
        Task<PontoDeAcessibilidadeDto> Salvar(PontoDeAcessibilidadeDto user);
        
        Task<(bool, List<Notification>)> Excluir(Guid id);

    }
}