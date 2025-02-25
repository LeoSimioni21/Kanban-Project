using Microsoft.EntityFrameworkCore;
using Projeto_kanban.Models;

namespace Projeto_kanban.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<AtividadeModel> Atividades { get; set; }
        public DbSet<StatusModel> Status { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<StatusModel>().HasData(
                    new StatusModel { Id = 1, Nome = "Pendente"},
                    new StatusModel { Id = 2, Nome = "Em andamento" },
                    new StatusModel { Id = 3, Nome = "Concluído" }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
