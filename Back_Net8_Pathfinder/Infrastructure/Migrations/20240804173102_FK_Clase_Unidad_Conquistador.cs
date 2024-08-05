using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FK_Clase_Unidad_Conquistador : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UnidadConquistadores_UncoCargoTabla_UncoCargoId",
                table: "UnidadConquistadores",
                columns: new[] { "UncoCargoTabla", "UncoCargoId" });

            migrationBuilder.CreateIndex(
                name: "IX_ClaseConquistadores_ClcoTipoCargoClaseTabla_ClcoTipoCargoClaseId",
                table: "ClaseConquistadores",
                columns: new[] { "ClcoTipoCargoClaseTabla", "ClcoTipoCargoClaseId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ClaseConquistadores_Tipos_ClcoTipoCargoClaseTabla_ClcoTipoCargoClaseId",
                table: "ClaseConquistadores",
                columns: new[] { "ClcoTipoCargoClaseTabla", "ClcoTipoCargoClaseId" },
                principalTable: "Tipos",
                principalColumns: new[] { "TipoTabla", "TipoId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UnidadConquistadores_Tipos_UncoCargoTabla_UncoCargoId",
                table: "UnidadConquistadores",
                columns: new[] { "UncoCargoTabla", "UncoCargoId" },
                principalTable: "Tipos",
                principalColumns: new[] { "TipoTabla", "TipoId" },
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClaseConquistadores_Tipos_ClcoTipoCargoClaseTabla_ClcoTipoCargoClaseId",
                table: "ClaseConquistadores");

            migrationBuilder.DropForeignKey(
                name: "FK_UnidadConquistadores_Tipos_UncoCargoTabla_UncoCargoId",
                table: "UnidadConquistadores");

            migrationBuilder.DropIndex(
                name: "IX_UnidadConquistadores_UncoCargoTabla_UncoCargoId",
                table: "UnidadConquistadores");

            migrationBuilder.DropIndex(
                name: "IX_ClaseConquistadores_ClcoTipoCargoClaseTabla_ClcoTipoCargoClaseId",
                table: "ClaseConquistadores");
        }
    }
}
