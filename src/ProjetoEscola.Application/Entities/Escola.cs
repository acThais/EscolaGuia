using System;
using System.Collections.Generic;

namespace ProjetoEscola.Domain.Entities
{
	public class Escola : EntityBase
	{
		//Usa int que é mais fácil
        public int EscolaId { get; set; }
        public string Nome { get; set; }
        public virtual IEnumerable<Curso> Cursos { get; set; }
    }
}
