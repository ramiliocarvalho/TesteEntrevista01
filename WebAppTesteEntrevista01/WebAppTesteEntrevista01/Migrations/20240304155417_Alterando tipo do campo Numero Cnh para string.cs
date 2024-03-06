using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppTesteEntrevista01.Migrations
{
    /// <inheritdoc />
    public partial class AlterandotipodocampoNumeroCnhparastring : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Entregadores_UsuarioId",
                table: "Entregadores");

            migrationBuilder.AlterColumn<string>(
                name: "NumeroCnh",
                table: "Entregadores",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_Entregadores_UsuarioId",
                table: "Entregadores",
                column: "UsuarioId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Entregadores_UsuarioId",
                table: "Entregadores");

            migrationBuilder.AlterColumn<int>(
                name: "NumeroCnh",
                table: "Entregadores",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateIndex(
                name: "IX_Entregadores_UsuarioId",
                table: "Entregadores",
                column: "UsuarioId");
        }
    }
}
