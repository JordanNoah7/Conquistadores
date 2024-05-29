using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class parametrosSesiones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parametros",
                columns: table => new
                {
                    ParaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParaNombre = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    ParaValor = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    AudiUserCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiFechCrea = table.Column<DateTime>(type: "datetime", nullable: false),
                    AudiHostCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiUserMod = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    AudiFechMod = table.Column<DateTime>(type: "datetime", nullable: true),
                    AudiHostMod = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parametros", x => x.ParaID);
                });

            migrationBuilder.CreateTable(
                name: "Sesiones",
                columns: table => new
                {
                    SesiID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SesiUsuarioUsuaID = table.Column<int>(type: "int", nullable: false),
                    SesiFecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    AudiUserCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiFechCrea = table.Column<DateTime>(type: "datetime", nullable: false),
                    AudiHostCrea = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sesiones", x => x.SesiID);
                    table.ForeignKey(
                        name: "FK_Sesiones_Usuarios_SesiUsuarioUsuaID",
                        column: x => x.SesiUsuarioUsuaID,
                        principalTable: "Usuarios",
                        principalColumn: "UsuaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sesiones_SesiUsuarioUsuaID",
                table: "Sesiones",
                column: "SesiUsuarioUsuaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parametros");

            migrationBuilder.DropTable(
                name: "Sesiones");
        }
    }
}
