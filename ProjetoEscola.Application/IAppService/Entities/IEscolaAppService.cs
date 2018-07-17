using ProjetoEscola.Application.ViewModel;
using System.Collections.Generic;

namespace ProjetoEscola.Application.IAppService.Entities
{
	public interface IEscolaAppService
	{
		IEnumerable<EscolaViewModel> BuscarTodasEscolas();
		EscolaViewModel Salvar(EscolaViewModel model);
	}
}
