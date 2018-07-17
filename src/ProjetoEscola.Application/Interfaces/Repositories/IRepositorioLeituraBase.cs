using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ProjetoEscola.Domain.Interfaces.Repositories
{
	public interface IRepositorioLeituraBase<TEntity> : IDisposable where TEntity : class
	{
		TEntity GetByKey(int Id);
		TEntity GetByKeyReadOnly(object[] key);
		IEnumerable<TEntity> GetAll();
		IEnumerable<TEntity> GetAllReadOnly();
		IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, int take = -1);
		IEnumerable<TEntity> FindReadOnly(Expression<Func<TEntity, bool>> predicate, int take = -1);
	}
}
