using ProjetoEscola.Domain.ValueObjects;
using System;

namespace ProjetoEscola.Domain.Entities
{
	public class EntityBase
	{
		public string RecCreatedBy { get; set; }

		public DateTime? RecCreatedOn { get; set; }

		public string RecModifiedBy { get; set; }

		public DateTime? RecModifiedOn { get; set; }

		public virtual ValidationResult ResultValidation { get; set; }

		public short? Ativo { get; set; }
	}
}
