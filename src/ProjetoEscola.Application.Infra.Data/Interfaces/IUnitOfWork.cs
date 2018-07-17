using System;

namespace ProjetoEscola.Application.Infra.Data.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{
		void Commit();
	}
}
