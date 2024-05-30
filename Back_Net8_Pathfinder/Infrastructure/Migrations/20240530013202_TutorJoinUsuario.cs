using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TutorJoinUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuaId",
                table: "Tutores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tutores_UsuaId",
                table: "Tutores",
                column: "UsuaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tutores_Usuarios_UsuaId",
                table: "Tutores",
                column: "UsuaId",
                principalTable: "Usuarios",
                principalColumn: "UsuaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tutores_Usuarios_UsuaId",
                table: "Tutores");

            migrationBuilder.DropIndex(
                name: "IX_Tutores_UsuaId",
                table: "Tutores");

            migrationBuilder.DropColumn(
                name: "UsuaId",
                table: "Tutores");
        }
    }
}
