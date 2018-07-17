using ProjetoEscola.Domain.Validation;
using ProjetoEscola.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEscola.Application.AppService
{
	public class AppServiceBase<TViewModel, TGridViewModel>
			 where TViewModel : class
			 where TGridViewModel : class
	{
		protected ValidationAppResult DomainToApplicationResult(ValidationResult result)
		{
			var validationAppResult = new ValidationAppResult();

			foreach (var validationError in result.Erros)
			{
				validationAppResult.Erros.Add(new ValidationAppError(validationError.Message));
			}
			validationAppResult.IsValid = result.IsValid;
			validationAppResult.Mensagem = result.Mensagem;

			return validationAppResult;
		}

		public virtual TViewModel GetNewRegistre()
		{
			throw new NotImplementedException();
		}

		public virtual IEnumerable<TGridViewModel> GetAll()
		{
			throw new NotImplementedException();
		}

		public virtual IEnumerable<TGridViewModel> GetByCodColigada(short codColigada)
		{
			throw new NotImplementedException();
		}

		public virtual TViewModel GetByKey(object[] key)
		{
			throw new NotImplementedException();
		}

		public virtual ValidationAppResult Add(TViewModel viewModel)
		{
			throw new NotImplementedException();
		}

		public virtual ValidationAppResult Update(TViewModel viewModel)
		{
			throw new NotImplementedException();
		}

		public virtual ValidationAppResult Update(TViewModel viewModel, string codUsuarioLogado)
		{
			throw new NotImplementedException();
		}

		public virtual ValidationAppResult RemoveByKey(object[] key, string codUsuarioLogado)
		{
			throw new NotImplementedException();
		}

		public virtual IEnumerable<TGridViewModel> Find(TViewModel viewModel)
		{
			throw new NotImplementedException();
		}
	}
}
