using System;

namespace ProjetoEscola.Domain.Interfaces.Repositories
{
	public interface IRepositorioEscritaBase<TEntity> : IDisposable where TEntity : class
	{
		TEntity Add(TEntity entity);
		void Update(TEntity entity);
		void Remove(TEntity entity);
	}
}
