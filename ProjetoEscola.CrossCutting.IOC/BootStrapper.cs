using ProjetoEscola.Application.AppService.Entities;
using ProjetoEscola.Application.IAppService.Entities;
using ProjetoEscola.Application.Infra.Data.Contexto;
using ProjetoEscola.Application.Infra.Data.Interfaces;
using ProjetoEscola.Application.Infra.Data.Repositories;
using ProjetoEscola.Application.Infra.Data.UoW;
using ProjetoEscola.Domain.Interfaces.Repositories;
using ProjetoEscola.Domain.Interfaces.Services.Entities;
using ProjetoEscola.Domain.Services;
using SimpleInjector;


namespace ProjetoEscola.CrossCutting.IOC
{
	public class BootStrapper
	{
		//Essa classe faz o registro das injeções do projeto. 
		//Associa as interfaces as respetivas classes que as usam. 
		//É necessário para fazer que funcione entre as camadas, ele subistitui o ninject do Eduardo Pires.
		public static void RegisterServices(Container container)
		{
			// Infra Dados
			container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
			container.Register<ProjetoEscolaContext>(Lifestyle.Scoped);

			//Entidades

			container.Register<IEscolaRepositorioLeitura, EscolaRepositorioLeitura>(Lifestyle.Scoped);
			container.Register<IEscolaRepositorioEscrita, EscolaRepositorioEscrita>(Lifestyle.Scoped);
			container.Register<IEscolaService, EscolaService>(Lifestyle.Scoped);
			container.Register<IEscolaAppService, EscolaAppService>(Lifestyle.Scoped);


		}

		public static void RegisterServicesStatic(Container container)
		{
			// Infra Dados
			container.Register<IUnitOfWork, UnitOfWork>();
			container.Register<ProjetoEscolaContext>();

			container.Register<IEscolaRepositorioLeitura, EscolaRepositorioLeitura>();
			container.Register<IEscolaRepositorioEscrita, EscolaRepositorioEscrita>();
			container.Register<IEscolaService, EscolaService>();
			container.Register<IEscolaAppService, EscolaAppService>();
		}

	}
}
