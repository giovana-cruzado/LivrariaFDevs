using Microsoft.EntityFrameworkCore;
using LivrariaFDevs.Models;

namespace LivrariaFDevs.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts)
            : base(opts) { }

        public DbSet<Categoria> Categorias => Set<Categoria>();
        public DbSet<Livro> Livros => Set<Livro>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Categoria>()
                .Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(120);

            modelBuilder.Entity<Livro>()
                .Property(l => l.Titulo)
                .IsRequired()
                .HasMaxLength(250);
        }
    }
}
