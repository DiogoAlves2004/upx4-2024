using Infra.UPX4.Data.Context;
using Infra.UPX4.Domain.Entities;
using Infra.UPX4.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;


namespace Infra.UPX4.Data.Repository
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        private DbSet<UserEntity> _dataset;

        public UserRepository(MyContext context) : base(context)
        {
            _dataset = _context.Set<UserEntity>();
        }

        public async Task<UserEntity> GetByEmail(string email)
        {
            var result = await _dataset.FirstOrDefaultAsync(u => u.Email.Equals(email));

            return result;
        }
    }
}