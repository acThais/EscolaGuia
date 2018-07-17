using ProjetoEscola.Application.Infra.Data.Contexto;
using ProjetoEscola.Domain.Entities;
using ProjetoEscola.Domain.Interfaces.Repositories;

namespace ProjetoEscola.Application.Infra.Data.Repositories
{
	public class EscolaRepositorioLeitura : RepositorioLeituraBase<Escola>, IEscolaRepositorioLeitura
	{
		public EscolaRepositorioLeitura(ProjetoEscolaContext context) : base(context)
		{

		}
	}
}
