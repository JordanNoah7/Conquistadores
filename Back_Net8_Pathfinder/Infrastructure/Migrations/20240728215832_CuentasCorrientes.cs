using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CuentasCorrientes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CuentaCorriente_Conquistadores_ConqId",
                table: "CuentaCorriente");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CuentaCorriente",
                table: "CuentaCorriente");

            migrationBuilder.RenameTable(
                name: "CuentaCorriente",
                newName: "CuentasCorrientes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CuentasCorrientes",
                table: "CuentasCorrientes",
                columns: new[] { "ConqId", "CucoId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CuentasCorrientes_Conquistadores_ConqId",
                table: "CuentasCorrientes",
                column: "ConqId",
                principalTable: "Conquistadores",
                principalColumn: "PersId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CuentasCorrientes_Conquistadores_ConqId",
                table: "CuentasCorrientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CuentasCorrientes",
                table: "CuentasCorrientes");

            migrationBuilder.RenameTable(
                name: "CuentasCorrientes",
                newName: "CuentaCorriente");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CuentaCorriente",
                table: "CuentaCorriente",
                columns: new[] { "ConqId", "CucoId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CuentaCorriente_Conquistadores_ConqId",
                table: "CuentaCorriente",
                column: "ConqId",
                principalTable: "Conquistadores",
                principalColumn: "PersId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
