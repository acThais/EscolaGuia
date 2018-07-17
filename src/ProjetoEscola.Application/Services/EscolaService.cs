using System.Collections.Generic;
using System.Linq;
using ProjetoEscola.Domain.Entities;
using ProjetoEscola.Domain.Interfaces.Repositories;
using ProjetoEscola.Domain.Interfaces.Services;
using ProjetoEscola.Domain.Interfaces.Services.Entities;

namespace ProjetoEscola.Domain.Services
{
    public class EscolaService: ServiceBase<Escola>, IEscolaService
    {
		public IEscolaRepositorioLeitura LeituraRepository { get { return _LeituraRepository as IEscolaRepositorioLeitura; } }
		public IEscolaRepositorioEscrita EscritaRepository { get { return _EscritaRepository as IEscolaRepositorioEscrita; } }


		public EscolaService(IEscolaRepositorioLeitura leituraRepository,
			IEscolaRepositorioEscrita escritaRepository
			) : base(leituraRepository, escritaRepository)
		{

		}
    }
}
