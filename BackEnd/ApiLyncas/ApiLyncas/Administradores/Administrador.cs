using ApiLyncas.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiLyncas.Administradores
{
    public class Administrador
    {
        private readonly ModelBuilder modelBuilder;

        public Administrador(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void PopulaDB()
        {
            modelBuilder.Entity<Pessoa>().HasData(
             new Pessoa()
             {
                 IdPessoa = 1,
                 Nome = "Administrador",
                 Sobrenome = "Sistema",
                 Email = "administrador@lyncas.net",
                 Telefone = "4799999999",
                 DataNascimento = DateTime.Now
             });
            modelBuilder.Entity<Autenticacao>().HasData(new Autenticacao()
            {
                IdPessoa = 1,
                Id = 1,
                Senha = "c8ba7d9e4d39b05a437483b9d847cf0cc8cbb53cf2583679c572f4efb79a2183",
                Status = true,
            });
        }
    }
}

