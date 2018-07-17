using ProjetoEscola.Application.Infra.Data.Contexto;
using ProjetoEscola.Domain.Entities;
using ProjetoEscola.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEscola.Application.Infra.Data.Repositories
{
	public class RepositorioEscritaBase<TEntity> : IRepositorioEscritaBase<TEntity>
	   where TEntity : EntityBase
	{
		protected readonly ProjetoEscolaContext dbContext;

		protected readonly DbSet<TEntity> dbSet;


		public RepositorioEscritaBase(ProjetoEscolaContext context)
		{
			dbContext = context;
			dbSet = context.Set<TEntity>();
		}

		public virtual void Update(TEntity entity)
		{
			var entry = dbContext.Entry(entity);
			dbSet.Attach(entity);
			entry.State = EntityState.Modified;
		}

		public virtual void Remove(TEntity entity)
		{
			var entry = dbContext.Entry(entity);
			dbSet.Remove(entity);
			entry.State = EntityState.Deleted;
		}

		public virtual TEntity Add(TEntity entity)
		{
			entity.Ativo = 1;
			var entityReturn = dbSet.Add(entity);
			return entityReturn;
		}

		public void Dispose()
		{
			dbContext.Dispose();
			GC.SuppressFinalize(this);
		}
	}
}
