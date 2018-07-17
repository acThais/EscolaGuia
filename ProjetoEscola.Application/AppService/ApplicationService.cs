using ProjetoEscola.Application.Infra.Data.Interfaces;
using ProjetoEscola.Domain.Validation;
using ProjetoEscola.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEscola.Application.AppService
{
	public class ApplicationService
	{
		private readonly IUnitOfWork _unitOfWork;

		public ApplicationService(IUnitOfWork unitOfWork)
		{
			this._unitOfWork = unitOfWork;
		}

		protected void Commit()
		{
			_unitOfWork.Commit();
		}

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
	}
}
