using System.Data.Entity.ModelConfiguration;
using ProjetoEscola.Domain.Entities;

namespace ProjetoEscola.Application.Infra.Data.EntityConfig
{
	public class EscolaConfiguration : EntityTypeConfiguration<Escola>
    {

        public EscolaConfiguration()
        {

            HasKey(e => e.EscolaId);

            Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(150);
        }
    }
}
