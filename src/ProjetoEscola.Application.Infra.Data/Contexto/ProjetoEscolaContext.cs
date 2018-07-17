using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ProjetoEscola.Application.Infra.Data.EntityConfig;
using ProjetoEscola.Domain.Entities;

namespace ProjetoEscola.Application.Infra.Data.Contexto
{
	public class ProjetoEscolaContext : DbContext
	{
		public ProjetoEscolaContext() : base("ProjetoEscolaContext")
		{

		}
		public DbSet<Aluno> Alunos { get; set; }
		public DbSet<Curso> Cursos { get; set; }
		public DbSet<Coordenador> Coordenadores { get; set; }
		public DbSet<Escola> Escolas { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
			modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
			modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

			modelBuilder.Properties()
				.Where(p => p.Name == p.ReflectedType.Name + "Id")
				.Configure(p => p.IsKey());

			modelBuilder.Properties<string>()
				.Configure(p => p.HasColumnType("varchar"));

			modelBuilder.Properties<string>()
				.Configure(p => p.HasMaxLength(100));

			modelBuilder.Configurations.Add(new AlunoConfiguration());
			modelBuilder.Configurations.Add(new CursoConfiguration());
			modelBuilder.Configurations.Add(new CoordenadorConfiguration());
			modelBuilder.Configurations.Add(new EscolaConfiguration());
		}
	}


}
