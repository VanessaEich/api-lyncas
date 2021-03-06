// <auto-generated />
using System;
using ApiLyncas.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiLyncas.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220411190545_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ApiLyncas.Models.Autenticacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdPessoa")
                        .HasColumnType("int");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("IdPessoa")
                        .IsUnique();

                    b.ToTable("autenticacao");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IdPessoa = 1,
                            Senha = "c8ba7d9e4d39b05a437483b9d847cf0cc8cbb53cf2583679c572f4efb79a2183",
                            Status = true
                        });
                });

            modelBuilder.Entity("ApiLyncas.Models.Pessoa", b =>
                {
                    b.Property<int>("IdPessoa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPessoa"), 1L, 1);

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("Date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.HasKey("IdPessoa");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("pessoa");

                    b.HasData(
                        new
                        {
                            IdPessoa = 1,
                            DataNascimento = new DateTime(2022, 4, 11, 16, 5, 45, 562, DateTimeKind.Local).AddTicks(617),
                            Email = "administrador@lyncas.net",
                            Nome = "Administrador",
                            Sobrenome = "Sistema",
                            Telefone = "4799999999"
                        });
                });

            modelBuilder.Entity("ApiLyncas.Models.Autenticacao", b =>
                {
                    b.HasOne("ApiLyncas.Models.Pessoa", "Pessoa")
                        .WithOne("Autenticacao")
                        .HasForeignKey("ApiLyncas.Models.Autenticacao", "IdPessoa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("ApiLyncas.Models.Pessoa", b =>
                {
                    b.Navigation("Autenticacao")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
