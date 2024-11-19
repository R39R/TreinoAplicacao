using Treino_aplicacao_web.Models.Empresa;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Treino_aplicacao_web.Database
{
    public class EmpresaDbContext : DbContext
    {
        public EmpresaDbContext() : base("DbConnection")
        {
        }

        public DbSet<Empresa> Empresa { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}