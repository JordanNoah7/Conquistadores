using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Alter_FichaMedica : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FichasMedicas",
                table: "FichasMedicas");

            migrationBuilder.DropColumn(
                name: "FimeId",
                table: "FichasMedicas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FichasMedicas",
                table: "FichasMedicas",
                columns: new[] { "ConqId", "FimeAnio" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FichasMedicas",
                table: "FichasMedicas");

            migrationBuilder.AddColumn<int>(
                name: "FimeId",
                table: "FichasMedicas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FichasMedicas",
                table: "FichasMedicas",
                columns: new[] { "ConqId", "FimeId", "FimeAnio" });
        }
    }
}
