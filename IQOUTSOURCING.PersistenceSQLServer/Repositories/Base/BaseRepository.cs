using IQOUTSOURCING.Domain.Entities.Base;
using IQOUTSOURCING.Domain.Interfaces.Repository.Base;
using IQOUTSOURCING.PersistenceSQLServer.DataContext;
using Microsoft.EntityFrameworkCore;

namespace IQOUTSOURCING.PersistenceSQLServer.Repositories.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Entity
    {
        private readonly Context context;

        public BaseRepository(Context context)
        {
            this.context = context;
        }

        public virtual async Task Add(T entity)
        {
            await context!.Set<T>().AddAsync(entity);
        }

        public virtual async Task AddRange(ICollection<T> entities)
        {
            await context!.Set<T>().AddRangeAsync(entities);
        }

        public virtual void Delete(T entity)
        {
            context!.Set<T>().Remove(entity);
        }

        public virtual async Task<T?> Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return await context!.Set<T>().FirstOrDefaultAsync(predicate)!;
        }

        public virtual async Task<ICollection<T?>> GetAll()
        {
            return await context!.Set<T>().ToListAsync()!;
        }

        public virtual async Task<T?> GetById(Guid id)
        {
            return await context!.Set<T>().FindAsync(id)!;
        }

        public virtual void Update(T entity)
        {
            context!.Set<T>().Update(entity);
        }
    }
}
