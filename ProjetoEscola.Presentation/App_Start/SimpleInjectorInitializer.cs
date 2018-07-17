using ProjetoEscola.CrossCutting.IOC;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(ProjetoEscola.Presentation.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace ProjetoEscola.Presentation.App_Start
{
	public static class SimpleInjectorInitializer
	{
		/// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
		public static void Initialize()
		{
			var container = new Container();
			container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

			// Chamada dos módulos do Simple Injector
			InitializeContainer(container);

	
			container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

			container.Verify();

			DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
		}

		private static void InitializeContainer(Container container)
		{
			//Chamada da injeção de dependência na camada de cross cutting.
			//Aqui é onde a mágica acontece, as interfaces associadas as classes retornarão erro se não estiverem no cross cutting.
			//Porque esse cara aqui, sempre inicializa junto com o projeto verificando cada interface e classe.
			//Porem essa verificação só acontece caso as mesmas já estejam em uso nos controllers.
			BootStrapper.RegisterServices(container);
		}
	}
}