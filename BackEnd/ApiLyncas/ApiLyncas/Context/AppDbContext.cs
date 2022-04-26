using ApiLyncas.Administradores;
using ApiLyncas.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiLyncas.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Pessoa>? Pessoa { get; set; }
        public DbSet<Autenticacao>? Autenticacao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autenticacao>()
                .HasOne(a => a.Pessoa)
                .WithOne(p => p.Autenticacao)
                .HasForeignKey<Autenticacao>(a => a.IdPessoa);

            modelBuilder.Entity<Pessoa>()
               .HasIndex(a => a.Email).IsUnique();

            new Administrador(modelBuilder).PopulaDB();
        }
    }
}
