using AutoMapper;
using Infra.UPX4.Domain.Dto;
using Infra.UPX4.Domain.Entities;
using Infra.UPX4.Domain.Interfaces.Repositories;
using Infra.UPX4.Domain.Interfaces.Services;
using Infra.UPX4.Domain.Models;

using Flunt.Notifications;

namespace Infra.UPX4.Service.Services
{
    public class PontoDeAcessibilidadeService : IPontoDeAcessibilidadeService
    {
        private IRepository<PontoDeAcessibilidadeEntity> _pontoDeAcessibilidadeRepository;
        private readonly IMapper _mapper;


        public PontoDeAcessibilidadeService(IRepository<PontoDeAcessibilidadeEntity> pontoRepository, IMapper mapper)
        {
            _pontoDeAcessibilidadeRepository = pontoRepository;
            _mapper = mapper;
        }

        public Task<PontoDeAcessibilidadeDto> Selecionar(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PontoDeAcessibilidadeDto>> Listar()
        {
            throw new NotImplementedException();
        }

        public async Task<PontoDeAcessibilidadeDto> Salvar(PontoDeAcessibilidadeDto ponto)
        {
            var pontoModel = _mapper.Map<PontoDeAcessibilidadeModel>(ponto);
            var pontoEntity = _mapper.Map<PontoDeAcessibilidadeEntity>(pontoModel);
            var result = await _pontoDeAcessibilidadeRepository.InsertAsync(pontoEntity);

            return _mapper.Map<PontoDeAcessibilidadeDto>(result);

        }

        public Task<(bool, List<Notification>)> Excluir(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}