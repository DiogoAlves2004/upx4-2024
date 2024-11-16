using Microsoft.EntityFrameworkCore;
using Infra.UPX4.Data.Context;
using Infra.UPX4.Domain.Interfaces.Repositories;
using Infra.UPX4.Domain.Entities;
namespace Infra.UPX4.Data.Repository

{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        //variables with myContext interface 
        protected readonly MyContext _context;

        private DbSet<T> _dataset;

        //waiting a context to deal
        public BaseRepository(MyContext context)
        {
            _context = context;
            _dataset = context.Set<T>();
        }
        public async Task<T> InsertAsync(T item)
        {
            try
            {
                if (item.Id == Guid.Empty)
                {
                    item.Id = Guid.NewGuid();
                }


                _dataset.Add(item);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));

                if (result == null)
                    return false;

                _dataset.Remove(result);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<T> UpdateAsync(T item)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(item.Id));

                if (result == null)
                {
                    return null;
                }



                _context.Entry(result).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();

                return item;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> ExistAsync(Guid id)
        {
            return await _dataset.AnyAsync(p => p.Id == id)
;
        }
        public async Task<T> SelectAsync(Guid id)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));

                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IEnumerable<T>> SelectAsync()
        {
            try
            {

                var result = await _dataset.ToListAsync();

                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}