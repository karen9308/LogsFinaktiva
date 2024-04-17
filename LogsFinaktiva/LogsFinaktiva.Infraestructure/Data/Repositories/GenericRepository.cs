using LogsFinaktiva.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace LogsFinaktiva.Infraestructure.Data.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext _appDbContext;
        public GenericRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        #region Métodos Sincrónicos

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _appDbContext.Set<TEntity>().Where(predicate);
        }

        public void Create(TEntity entity)
        {
            _appDbContext.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {
            _appDbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            _appDbContext.Set<TEntity>().Remove(entity);
        }

        #endregion

        #region Métodos Asincrónicos
        public ValueTask<TEntity> GetByIdAsync(Guid id)
        {
            return _appDbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _appDbContext.Set<TEntity>().AddAsync(entity);
        }
        public Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return _appDbContext.Set<TEntity>().SingleOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _appDbContext.Set<TEntity>().ToListAsync();
        }
        #endregion

    }
}
