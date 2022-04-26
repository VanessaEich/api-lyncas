using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiLyncas.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pessoa",
                columns: table => new
                {
                    IdPessoa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Sobrenome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pessoa", x => x.IdPessoa);
                });

            migrationBuilder.CreateTable(
                name: "autenticacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Senha = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    IdPessoa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_autenticacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_autenticacao_pessoa_IdPessoa",
                        column: x => x.IdPessoa,
                        principalTable: "pessoa",
                        principalColumn: "IdPessoa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "pessoa",
                columns: new[] { "IdPessoa", "DataNascimento", "Email", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 1, new DateTime(2022, 4, 11, 16, 5, 45, 562, DateTimeKind.Local).AddTicks(617), "administrador@lyncas.net", "Administrador", "Sistema", "4799999999" });

            migrationBuilder.InsertData(
                table: "autenticacao",
                columns: new[] { "Id", "IdPessoa", "Senha", "Status" },
                values: new object[] { 1, 1, "c8ba7d9e4d39b05a437483b9d847cf0cc8cbb53cf2583679c572f4efb79a2183", true });

            migrationBuilder.CreateIndex(
                name: "IX_autenticacao_IdPessoa",
                table: "autenticacao",
                column: "IdPessoa",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_pessoa_Email",
                table: "pessoa",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "autenticacao");

            migrationBuilder.DropTable(
                name: "pessoa");
        }
    }
}
