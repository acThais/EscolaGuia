using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoEscola.Domain.Entities;

namespace ProjetoEscola.Application.Infra.Data.EntityConfig
{
    public class CoordenadorConfiguration : EntityTypeConfiguration<Coordenador>
    {
        public CoordenadorConfiguration()
        {
            HasKey(c => c.CoordenadorId);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);
        }
    }
}
