using System.Data.Entity.ModelConfiguration;
using ProjetoEscola.Domain.Entities;

namespace ProjetoEscola.Application.Infra.Data.EntityConfig
{
	public class AlunoConfiguration : EntityTypeConfiguration<Aluno>
    {
        public AlunoConfiguration()
        {
            HasKey(a => a.AlunoId);

            Property(a => a.Nome)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.CPF)
                .HasMaxLength(11);

            Property(a => a.Nome)
                .IsRequired()
                .HasMaxLength(150);

             Property(a => a.Endereço)
                .IsRequired()
                .HasMaxLength(250);

             Property(a => a.Sexo)
                .IsRequired();

             Property(a => a.Ativo)
                .IsRequired();

            
             Property(a => a.DataMatricula)
                .IsRequired();
            
             Property(a => a.DataNascimento)
                .IsRequired();
        }
    }
}
