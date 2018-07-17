using ProjetoEscola.Application.Infra.Data.Contexto;
using ProjetoEscola.Application.Infra.Data.Interfaces;

namespace ProjetoEscola.Application.Infra.Data.UoW
{
	public class UnitOfWork : IUnitOfWork
	{
		private ProjetoEscolaContext _context;

		public UnitOfWork(ProjetoEscolaContext context)
		{
			_context = context;
		}

		public void Commit()
		{
			_context.SaveChanges();
		}

		public void Dispose()
		{
			Dispose(true);
		}

		private void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (_context != null)
				{
					_context.Dispose();
					_context = null;
				}
			}
		}
	}
}
