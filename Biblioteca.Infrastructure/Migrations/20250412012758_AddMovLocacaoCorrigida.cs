using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMovLocacaoCorrigida : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovLocacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LivroId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    DataRetirada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataDevolucaoPrevista = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataDevolucaoReal = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValorLocacao = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Multa = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    ValorRecebido = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    MovStatus = table.Column<int>(type: "int", nullable: false),
                    DescricaoStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovLocacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovLocacao_Livros_LivroId",
                        column: x => x.LivroId,
                        principalTable: "Livros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovLocacao_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovLocacao_LivroId",
                table: "MovLocacao",
                column: "LivroId");

            migrationBuilder.CreateIndex(
                name: "IX_MovLocacao_UsuarioId",
                table: "MovLocacao",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovLocacao");
        }
    }
}
