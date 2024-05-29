using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ConqCelularCorreo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConqCelular",
                table: "Conquistadores",
                type: "nvarchar(18)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ConqCorreoCorporativo",
                table: "Conquistadores",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConqCorreoPersonal",
                table: "Conquistadores",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ConqTelefono",
                table: "Conquistadores",
                type: "nvarchar(18)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConqCelular",
                table: "Conquistadores");

            migrationBuilder.DropColumn(
                name: "ConqCorreoCorporativo",
                table: "Conquistadores");

            migrationBuilder.DropColumn(
                name: "ConqCorreoPersonal",
                table: "Conquistadores");

            migrationBuilder.DropColumn(
                name: "ConqTelefono",
                table: "Conquistadores");
        }
    }
}
