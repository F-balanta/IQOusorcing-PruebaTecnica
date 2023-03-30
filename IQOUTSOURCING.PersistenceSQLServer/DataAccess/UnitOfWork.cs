using IQOUTSOURCING.Domain.Interfaces;
using IQOUTSOURCING.Domain.Interfaces.Repository;
using IQOUTSOURCING.PersistenceSQLServer.DataContext;
using IQOUTSOURCING.PersistenceSQLServer.Repositories;

namespace IQOUTSOURCING.PersistenceSQLServer.DataAccess
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public UnitOfWork(Context context)
        {
            this.context = context;
        }
        private readonly Context context;

        private UsuarioRepository? _usuarioRepository;
        public IUsuarioRepository UsuarioRepository
        {
            get
            {
                if (_usuarioRepository == null)
                    _usuarioRepository = new UsuarioRepository(context);
                return _usuarioRepository;
            }
        }

        private RolRepository? _rolRepository;
        public IRolRepository RolRepository
        {
            get
            {
                if (_rolRepository == null)
                    _rolRepository = new RolRepository(context);
                return _rolRepository;
            }
        }

        private AuditoriaRepository? _auditoriaRepository;
        public IAuditoriaRepository AuditoriaRepository
        {
            get
            {
                if (_auditoriaRepository == null)
                    _auditoriaRepository = new AuditoriaRepository(context);
                return _auditoriaRepository;
            }
        }


        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
