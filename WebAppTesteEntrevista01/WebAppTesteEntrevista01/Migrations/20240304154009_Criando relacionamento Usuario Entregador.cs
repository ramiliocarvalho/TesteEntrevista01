using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppTesteEntrevista01.Migrations
{
    /// <inheritdoc />
    public partial class CriandorelacionamentoUsuarioEntregador : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Entregadores");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Entregadores",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Entregadores_UsuarioId",
                table: "Entregadores",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entregadores_Usuarios_UsuarioId",
                table: "Entregadores",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entregadores_Usuarios_UsuarioId",
                table: "Entregadores");

            migrationBuilder.DropIndex(
                name: "IX_Entregadores_UsuarioId",
                table: "Entregadores");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Entregadores");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Entregadores",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
