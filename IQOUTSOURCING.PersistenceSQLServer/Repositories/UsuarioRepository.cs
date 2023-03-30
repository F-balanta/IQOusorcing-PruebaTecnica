using IQOUTSOURCING.Domain.Entities;
using IQOUTSOURCING.Domain.Interfaces.Repository;
using IQOUTSOURCING.PersistenceSQLServer.DataContext;
using IQOUTSOURCING.PersistenceSQLServer.Repositories.Base;

namespace IQOUTSOURCING.PersistenceSQLServer.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(Context context) : base(context)
        {
        }
    }
}
