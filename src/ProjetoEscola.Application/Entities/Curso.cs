using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEscola.Domain.Entities
{
    public class Curso : EntityBase
	{
        public Guid CursoId { get; set; }
        public string Nome { get; set; }
        public int CargaHoraria { get; set; }
        public virtual Escola Escola { get; set; }
        public virtual Coordenador Coordenador { get; set; }

        public virtual ICollection<Aluno> Alunos { get; set; }
    }
}
