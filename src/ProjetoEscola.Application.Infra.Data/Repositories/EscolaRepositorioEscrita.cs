using ProjetoEscola.Application.Infra.Data.Contexto;
using ProjetoEscola.Domain.Entities;
using ProjetoEscola.Domain.Interfaces.Repositories;

namespace ProjetoEscola.Application.Infra.Data.Repositories
{
	public class EscolaRepositorioEscrita :  RepositorioEscritaBase<Escola>, IEscolaRepositorioEscrita
	{
		public EscolaRepositorioEscrita(ProjetoEscolaContext context) : base(context)
		{

		}
	}
}
