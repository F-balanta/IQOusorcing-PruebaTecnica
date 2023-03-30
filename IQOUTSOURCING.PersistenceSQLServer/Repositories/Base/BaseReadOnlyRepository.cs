using IQOUTSOURCING.Domain.Entities.Base;
using IQOUTSOURCING.Domain.Interfaces.Repository.Base;
using IQOUTSOURCING.PersistenceSQLServer.DataContext;
using Microsoft.EntityFrameworkCore;

namespace IQOUTSOURCING.PersistenceSQLServer.Repositories.Base
{
    public class BaseReadOnlyRepository<T> : IBaseReadOnlyRepository<T> where T : Entity
    {
        private readonly Context context;

        public BaseReadOnlyRepository(Context context)
        {
            this.context = context;
        }

        public virtual async Task<ICollection<T?>> GetAll()
        {
            return await context!.Set<T>().ToListAsync()!;
        }
    }
}
