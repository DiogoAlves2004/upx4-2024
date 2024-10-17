using Infra.UPX4.Domain.Dto;



namespace Infra.UPX4.Domain.Interfaces.Services
{
    public interface IAuthorizationService
    {
        Task<object> Login(LoginDto loginDto);


    }
}