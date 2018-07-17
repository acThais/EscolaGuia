using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEscola.Domain.Entities
{
    public class Coordenador : EntityBase
	{
        public Guid CoordenadorId { get; set; }
        public string Nome { get; set; }
        public virtual IEnumerable<Curso> Cursos { get; set; }
    }
}
