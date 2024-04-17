using System.Linq.Expressions;

namespace LogsFinaktiva.Domain.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        ValueTask<TEntity> GetByIdAsync(Guid id);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task CreateAsync(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}
