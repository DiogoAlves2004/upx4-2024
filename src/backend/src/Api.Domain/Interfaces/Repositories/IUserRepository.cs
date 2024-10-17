using Infra.UPX4.Domain.Entities;

namespace Infra.UPX4.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task<UserEntity> GetByEmail(string email);
    }
}