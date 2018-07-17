
using ProjetoEscola.Application.Infra.Data.Contexto;
using ProjetoEscola.Domain.Entities;
using ProjetoEscola.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Transactions;

namespace ProjetoEscola.Application.Infra.Data.Repositories
{
	public class RepositorioLeituraBase<TEntity> : IRepositorioLeituraBase<TEntity>
	  where TEntity : EntityBase
	{
		public System.Data.IDbConnection Connection
		{
			get
			{
				return new SqlConnection(ConfigurationManager.ConnectionStrings["EnvioDeCargasDbContext"].ConnectionString);
			}
		}

		protected readonly ProjetoEscolaContext dbContext;

		protected readonly DbSet<TEntity> dbSet;

		public RepositorioLeituraBase(ProjetoEscolaContext context)
		{
			dbContext = context;
			dbSet = context.Set<TEntity>();
		}

		public virtual TEntity GetByKey(int Id)
		{

			using (var transactionScope = new TransactionScope(TransactionScopeOption.Required,
													new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
			{
				return dbSet.Find(Id);
			}
		}

		public virtual TEntity GetByKeyReadOnly(object[] key)
		{
			throw new NotImplementedException();
		}

		public virtual IEnumerable<TEntity> GetAll()
		{
			using (var transactionScope = new TransactionScope(TransactionScopeOption.Required,
													new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
			{
				return dbSet.AsNoTracking().Take(1000);
			}
		}

		public virtual IEnumerable<TEntity> GetAllReadOnly()
		{
			using (var transactionScope = new TransactionScope(TransactionScopeOption.Required,
													new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
			{
				return dbSet.AsNoTracking().Take(1000);
			}
		}

		public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, int take = -1)
		{
			using (var transactionScope = new TransactionScope(TransactionScopeOption.Required,
													new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
			{
				take = take == -1 ? int.MaxValue : take;
				return dbSet.AsNoTracking().Where(predicate).Take(take);
			}
		}

		public virtual IEnumerable<TEntity> FindReadOnly(Expression<Func<TEntity, bool>> predicate, int take = -1)
		{
			using (var transactionScope = new TransactionScope(TransactionScopeOption.Required,
													new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
			{
				take = take == -1 ? int.MaxValue : take;
				return dbSet.AsNoTracking().Where(predicate).Take(take);
			}
		}

		public virtual IEnumerable<TEntity> FindReadOnlyLazyLoading(Expression<Func<TEntity, bool>> predicate, int take = -1)
		{
			using (var transactionScope = new TransactionScope(TransactionScopeOption.Required,
													new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
			{
				take = take == -1 ? int.MaxValue : take;
				return dbSet.AsNoTracking().Where(predicate).Take(take);
			}
		}

		public void Dispose()
		{
			dbContext.Dispose();
			GC.SuppressFinalize(this);
		}
	}
}
