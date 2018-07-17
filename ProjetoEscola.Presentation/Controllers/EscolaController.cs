using ProjetoEscola.Application.IAppService.Entities;
using ProjetoEscola.Application.ViewModel;
using System.Linq;
using System.Web.Mvc;

namespace ProjetoEscola.Presentation.Controllers
{
	public class EscolaController : Controller
    {
		private readonly IEscolaAppService _service;

		public EscolaController(IEscolaAppService service)
		{
			_service = service;
		}
        
        public ActionResult Index()
        {
			var escolasCadastradas = _service.BuscarTodasEscolas();
			var Model = new EscolaViewModel();
			if (escolasCadastradas.Count() > 0) {
				Model.ListaDeEscolas = escolasCadastradas.ToList();
			}
			return View(Model);
        }

		public ActionResult Create()
		{
			var Model = new EscolaViewModel();
			return View(Model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult CadastrarEscola(EscolaViewModel model)
		{
			if (ModelState.IsValid)
			{
				var result = _service.Salvar(model);
				return View("Create", result);
			}
			else
			{
				return RedirectToAction("Index");
			}

		}

	}
}