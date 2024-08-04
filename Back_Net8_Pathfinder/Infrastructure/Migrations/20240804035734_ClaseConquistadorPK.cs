using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ClaseConquistadorPK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ClaseConquistadores",
                table: "ClaseConquistadores");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClaseConquistadores",
                table: "ClaseConquistadores",
                columns: new[] { "ConqId", "ClasId", "ClcoAnio" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ClaseConquistadores",
                table: "ClaseConquistadores");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClaseConquistadores",
                table: "ClaseConquistadores",
                columns: new[] { "ConqId", "ClasId" });
        }
    }
}
