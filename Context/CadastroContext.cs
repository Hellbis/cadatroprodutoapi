using CadastroProdutos.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroProdutos.Context
{
    public class CadastroContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("User ID=***;Password=***;Host=localhost;Port=5432;Database=CadastroProdutos;Pooling=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>()
                .HasOne<Fornecedor>()
                .WithMany()
                .HasForeignKey(p => p.CodigoFornecedor);

            modelBuilder.Entity<Produto>()
                .HasOne<Categoria>()
                .WithMany()
                .HasForeignKey(p => p.CodigoCategoria);
        }
    }
}
