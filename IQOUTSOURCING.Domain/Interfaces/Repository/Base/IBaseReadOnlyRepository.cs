using IQOUTSOURCING.Domain.Entities.Base;

namespace IQOUTSOURCING.Domain.Interfaces.Repository.Base
{
    public interface IBaseReadOnlyRepository<T> where T : Entity
    {
        Task<ICollection<T?>> GetAll();
    }
}
