using System;
using ePizzaHub.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ePizzaHub.Repositories.Implementations
{
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
	{
        protected readonly DbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        protected AppDbContext AppDbContext
        {
            get
            {
                return _dbContext as AppDbContext;
            }
        }

        public Repository(DbContext dbContext)
		{
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
		}

        public async Task Add(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
        }

        public async Task Delete(int id)
        {
            TEntity entity = await _dbContext.Set<TEntity>().FindAsync(id);
            if (entity != null)
            {
                _dbContext.Set<TEntity>().Remove(entity);
            }
        }

        public async Task<TEntity> Find(int id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
            await SaveChange();
        }

        public async Task<int> SaveChange()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public async Task Update(TEntity entity)
        {
            _dbSet.Update(entity);
            await SaveChange();
        }
    }
}

