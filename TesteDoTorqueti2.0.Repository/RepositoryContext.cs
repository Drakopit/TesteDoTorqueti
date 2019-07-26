using System.Data.Entity;
using TesteDoTorqueti2._0.Domain.Models;

namespace TesteDoTorqueti2._0.Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext() : base("name=Contexto") { }

        DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
