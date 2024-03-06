using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppTesteEntrevista01.Migrations
{
    /// <inheritdoc />
    public partial class CriandoasPKsdaslocações : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ValorDia",
                table: "Planos",
                newName: "ValorDiaria");

            migrationBuilder.RenameColumn(
                name: "NumeroDias",
                table: "Planos",
                newName: "NumeroDiaria");

            migrationBuilder.RenameColumn(
                name: "EntregadorId",
                table: "Locacoes",
                newName: "UsuarioEntregadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Locacoes_MotoId",
                table: "Locacoes",
                column: "MotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Locacoes_PlanoId",
                table: "Locacoes",
                column: "PlanoId");

            migrationBuilder.CreateIndex(
                name: "IX_Locacoes_UsuarioEntregadorId",
                table: "Locacoes",
                column: "UsuarioEntregadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locacoes_Motos_MotoId",
                table: "Locacoes",
                column: "MotoId",
                principalTable: "Motos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locacoes_Planos_PlanoId",
                table: "Locacoes",
                column: "PlanoId",
                principalTable: "Planos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locacoes_Usuarios_UsuarioEntregadorId",
                table: "Locacoes",
                column: "UsuarioEntregadorId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locacoes_Motos_MotoId",
                table: "Locacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Locacoes_Planos_PlanoId",
                table: "Locacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Locacoes_Usuarios_UsuarioEntregadorId",
                table: "Locacoes");

            migrationBuilder.DropIndex(
                name: "IX_Locacoes_MotoId",
                table: "Locacoes");

            migrationBuilder.DropIndex(
                name: "IX_Locacoes_PlanoId",
                table: "Locacoes");

            migrationBuilder.DropIndex(
                name: "IX_Locacoes_UsuarioEntregadorId",
                table: "Locacoes");

            migrationBuilder.RenameColumn(
                name: "ValorDiaria",
                table: "Planos",
                newName: "ValorDia");

            migrationBuilder.RenameColumn(
                name: "NumeroDiaria",
                table: "Planos",
                newName: "NumeroDias");

            migrationBuilder.RenameColumn(
                name: "UsuarioEntregadorId",
                table: "Locacoes",
                newName: "EntregadorId");
        }
    }
}
