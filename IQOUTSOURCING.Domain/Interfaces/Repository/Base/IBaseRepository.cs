using IQOUTSOURCING.Domain.Entities.Base;
using System.Linq.Expressions;

namespace IQOUTSOURCING.Domain.Interfaces.Repository.Base
{
    public interface IBaseRepository<T> where T : Entity
    {
        Task<ICollection<T?>> GetAll();
        Task<T?> GetById(Guid id);
        Task Add(T entity);
        Task AddRange(ICollection<T> entities);
        void Update(T entity);
        void Delete(T entity);
        Task<T?> Find(Expression<Func<T, bool>> predicate);
    }
}
