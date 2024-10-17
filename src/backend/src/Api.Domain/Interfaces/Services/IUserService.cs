using Infra.UPX4.Domain.Dto;



namespace Infra.UPX4.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserDto> GetOneById(Guid id);
        Task<IEnumerable<UserDto>> GetAll();
        Task<UserDto> Update(UserDto user);
        Task<UserDto> Create(UserDto user);
        Task<bool> Delete(Guid id);

    }
}