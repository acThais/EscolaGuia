using FastMapper;
using ProjetoEscola.Application.ViewModel;
using ProjetoEscola.Domain.Entities;
using System.Collections.Generic;

namespace ProjetoEscola.Application.Mapper
{
	public class EscolaMapper
	{
		public static Escola ToDomain(EscolaViewModel viewModel)
		{
			return TypeAdapter.Adapt<EscolaViewModel, Escola>(viewModel);
		}

		public static EscolaViewModel ToViewModel(Escola model)
		{
			return TypeAdapter.Adapt<Escola, EscolaViewModel>(model);
		}

		public static IEnumerable<EscolaViewModel> ToListViewModel(IEnumerable<Escola> list)
		{
			return TypeAdapter.Adapt<IEnumerable<Escola>, IEnumerable<EscolaViewModel>>(list);
		}

		public static IEnumerable<EscolaViewModel> ToFilterListViewModel(IEnumerable<Escola> list)
		{
			return TypeAdapter.Adapt<IEnumerable<Escola>, IEnumerable<EscolaViewModel>>(list);
		}

		public static Escola FilterToDomain(EscolaViewModel viewModel)
		{
			return TypeAdapter.Adapt<EscolaViewModel, Escola>(viewModel);
		}
	}
}
