using IQOUTSOURCING.Domain.Interfaces.Repository;

namespace IQOUTSOURCING.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveAsync();
        IUsuarioRepository UsuarioRepository { get; }
        IRolRepository RolRepository { get; }
        IAuditoriaRepository AuditoriaRepository { get; }
    }
}
