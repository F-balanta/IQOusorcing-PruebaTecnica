using IQOUTSOURCING.Domain.Entities;
using IQOUTSOURCING.Domain.Interfaces.Repository;
using IQOUTSOURCING.PersistenceSQLServer.DataContext;
using IQOUTSOURCING.PersistenceSQLServer.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace IQOUTSOURCING.PersistenceSQLServer.Repositories
{
    public class AuditoriaRepository : BaseRepository<Auditoria>, IAuditoriaRepository
    {
        Context context;
        public AuditoriaRepository(Context context) : base(context)
        {
            this.context = context;
        }

        public async override Task<ICollection<Auditoria?>> GetAll()
        {
            return await context.Auditoria.Include(x => x.Usuario).ToListAsync()!;
        }
    }
}
