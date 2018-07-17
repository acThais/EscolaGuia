using ProjetoEscola.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEscola.Application.ViewModel
{
	public class BaseViewModel
	{
		public ValidationAppResult ResultValidation { get; set; }

		public short? Ativo { get; set; }
	}
}
