using System;
namespace ePizzaHub.Repositories.Interfaces
{
	public interface IRepository<TEntity> where TEntity : class
	{
		Task<IEnumerable<TEntity>> GetAll();

		Task<TEntity> Find(int id);

		Task Add(TEntity entity);

		Task Update(TEntity entity);

		Task Remove(TEntity entity);

		Task Delete(int id);

		Task<int> SaveChange();

	}
}
