using Microsoft.EntityFrameworkCore;

namespace BWay.Repository.Models
{
    public class ApiContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "AuthorDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlantaoModel>()
                .HasKey(k => new { k.Id });

            modelBuilder.Entity<ProjetoModel>()
                .HasKey(k => new { k.Id });
        }

        public DbSet<PlantaoModel> Plantoes { get; set; }
        public DbSet<ProjetoModel> Projetos { get; set; }

    }
}
