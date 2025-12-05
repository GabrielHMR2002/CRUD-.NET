using Microsoft.EntityFrameworkCore;
using WebApp.WebApp.Domain.Entities;

namespace WebApp.WebApp.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Products");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nome).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Descricao).HasMaxLength(500);
                entity.Property(e => e.Preco).HasColumnType("decimal(18,2)");
                entity.Property(e => e.DataCriacao).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            // Seed data
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Nome = "Notebook Dell",
                    Descricao = "Notebook Dell Inspiron 15, 16GB RAM, 512GB SSD",
                    Preco = 3500.00M,
                    QuantidadeEstoque = 10,
                    DataCriacao = DateTime.UtcNow,
                    Ativo = true
                },
                new Product
                {
                    Id = 2,
                    Nome = "Mouse Logitech",
                    Descricao = "Mouse sem fio Logitech MX Master 3",
                    Preco = 350.00M,
                    QuantidadeEstoque = 25,
                    DataCriacao = DateTime.UtcNow,
                    Ativo = true
                }
            );
        }
    }
}
