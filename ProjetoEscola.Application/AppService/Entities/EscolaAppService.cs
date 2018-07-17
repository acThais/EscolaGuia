using ProjetoEscola.Application.IAppService.Entities;
using ProjetoEscola.Application.Infra.Data.Interfaces;
using ProjetoEscola.Application.Mapper;
using ProjetoEscola.Application.ViewModel;
using ProjetoEscola.Domain.Interfaces.Repositories;
using ProjetoEscola.Domain.Interfaces.Services.Entities;
using ProjetoEscola.Domain.ValueObjects;
using System.Collections.Generic;

namespace ProjetoEscola.Application.AppService.Entities
{
	public class EscolaAppService : ApplicationService, IEscolaAppService
	{
		private readonly IEscolaService _service;
		private readonly IEscolaRepositorioLeitura _repositoryLeitura;
		private readonly IEscolaRepositorioEscrita _repositoryEscrita;


		public EscolaAppService(IUnitOfWork unitOfWork,
			IEscolaService service,
			IEscolaRepositorioLeitura repositoryLeitura,
			IEscolaRepositorioEscrita repositoryEscrita
			) : base(unitOfWork)
		{
			_service = service;
			_repositoryLeitura = repositoryLeitura;
			_repositoryEscrita = repositoryEscrita;
		}

		public IEnumerable<EscolaViewModel> BuscarTodasEscolas()
		{
			//Usa a interface de leitura base implementada e busca todos com o método genérico também implementado.
			//Informar que utiliza a entidade ESCOLA para a consulta, fica a critério da inejeção do simple injector
			var buscaTodasAsEscolas = _repositoryLeitura.FindReadOnly(e => e.EscolaId > 0); //Busque todas onde o Id é maior que 0.
			//Aqui ele recebe a lista das escolas encontradas e converte para uma lista de EscolaViewModel
			var converteParaListaDeViewModel = EscolaMapper.ToListViewModel(buscaTodasAsEscolas);
			//retorna essa lista para controller
			return converteParaListaDeViewModel;

			//Também pode ser feito direto
			//return EscolaMapper.ToListViewModel(_repositoryLeitura.FindReadOnly(e => e.EscolaId > 0));
		}

		public EscolaViewModel Salvar(EscolaViewModel model)
		{
			//Converte para entidade, que é necessária para salvar
			var entity = EscolaMapper.ToDomain(model);

			//Verifica se o validation é null, ele é necessário para fazer um tratamento de erro mais elaborado e para auditoria
			if (entity.ResultValidation == null)
				entity.ResultValidation = new ValidationResult();

			//Salva a entidade no banco utilizando o escrita base
			_repositoryEscrita.Add(entity);

			//Efetua o commit, converte a entidade salva em viewmodel e retorna a mesma para a view.
			Commit();
			var viewModel = EscolaMapper.ToViewModel(entity);
			return viewModel;
		}
	}
}
