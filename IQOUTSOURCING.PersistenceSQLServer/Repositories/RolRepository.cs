using IQOUTSOURCING.Domain.Entities;
using IQOUTSOURCING.Domain.Interfaces.Repository;
using IQOUTSOURCING.PersistenceSQLServer.DataContext;
using IQOUTSOURCING.PersistenceSQLServer.Repositories.Base;

namespace IQOUTSOURCING.PersistenceSQLServer.Repositories
{
    public class RolRepository : BaseRepository<Rol>, IRolRepository
    {
        public RolRepository(Context context) : base(context)
        {
        }
    }
}
