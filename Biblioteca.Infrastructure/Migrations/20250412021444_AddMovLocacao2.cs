using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMovLocacao2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovLocacao_Livros_LivroId",
                table: "MovLocacao");

            migrationBuilder.DropForeignKey(
                name: "FK_MovLocacao_Usuarios_UsuarioId",
                table: "MovLocacao");

            migrationBuilder.DropIndex(
                name: "IX_MovLocacao_LivroId",
                table: "MovLocacao");

            migrationBuilder.DropIndex(
                name: "IX_MovLocacao_UsuarioId",
                table: "MovLocacao");

            migrationBuilder.DropColumn(
                name: "DescricaoStatus",
                table: "MovLocacao");

            migrationBuilder.RenameColumn(
                name: "MovStatus",
                table: "MovLocacao",
                newName: "Status");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "MovLocacao",
                newName: "MovStatus");

            migrationBuilder.AddColumn<string>(
                name: "DescricaoStatus",
                table: "MovLocacao",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_MovLocacao_LivroId",
                table: "MovLocacao",
                column: "LivroId");

            migrationBuilder.CreateIndex(
                name: "IX_MovLocacao_UsuarioId",
                table: "MovLocacao",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovLocacao_Livros_LivroId",
                table: "MovLocacao",
                column: "LivroId",
                principalTable: "Livros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovLocacao_Usuarios_UsuarioId",
                table: "MovLocacao",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
