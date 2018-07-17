using System.Collections.Generic;

namespace ProjetoEscola.Application.ViewModel
{
	public class EscolaViewModel : BaseViewModel
	{
		public int EscolaId { get; set; }

		public string Nome { get; set; }

		public List<EscolaViewModel> ListaDeEscolas { get; set; }
	}
}
