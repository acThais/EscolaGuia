using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEscola.Domain.Entities
{
    public class Aluno : EntityBase
	{
        public Guid AlunoId { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Endereço { get; set; }
        public string Sexo { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataMatricula { get; set; }
        public DateTime DataNascimento { get; set; }

        public virtual ICollection<Curso> Cursos { get; set; }
    }
}
