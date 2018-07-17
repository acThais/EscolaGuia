using ProjetoEscola.Domain.Entities;
using ProjetoEscola.Domain.ValueObjects;

namespace ProjetoEscola.Domain.Interfaces.Services
{
	public interface IServiceBase<TEntity> where TEntity : EntityBase
	{
		TEntity Add(TEntity obj);
		TEntity Update(TEntity obj);
		ValidationResult Remove(TEntity obj);
		void Dispose();
	}
}
