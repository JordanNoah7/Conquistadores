using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TestError : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AudiFechCrea",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "AudiFechMod",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "AudiHostCrea",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "AudiHostMod",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "AudiUserCrea",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "AudiUserMod",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "AudiFechCrea",
                table: "Unidades");

            migrationBuilder.DropColumn(
                name: "AudiFechMod",
                table: "Unidades");

            migrationBuilder.DropColumn(
                name: "AudiHostCrea",
                table: "Unidades");

            migrationBuilder.DropColumn(
                name: "AudiHostMod",
                table: "Unidades");

            migrationBuilder.DropColumn(
                name: "AudiUserCrea",
                table: "Unidades");

            migrationBuilder.DropColumn(
                name: "AudiUserMod",
                table: "Unidades");

            migrationBuilder.DropColumn(
                name: "AudiFechCrea",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "AudiFechMod",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "AudiHostCrea",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "AudiHostMod",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "AudiUserCrea",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "AudiUserMod",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "AudiFechCrea",
                table: "ItemsCuadernillo");

            migrationBuilder.DropColumn(
                name: "AudiFechMod",
                table: "ItemsCuadernillo");

            migrationBuilder.DropColumn(
                name: "AudiHostCrea",
                table: "ItemsCuadernillo");

            migrationBuilder.DropColumn(
                name: "AudiHostMod",
                table: "ItemsCuadernillo");

            migrationBuilder.DropColumn(
                name: "AudiUserCrea",
                table: "ItemsCuadernillo");

            migrationBuilder.DropColumn(
                name: "AudiUserMod",
                table: "ItemsCuadernillo");

            migrationBuilder.DropColumn(
                name: "AudiFechCrea",
                table: "Inscripciones");

            migrationBuilder.DropColumn(
                name: "AudiFechMod",
                table: "Inscripciones");

            migrationBuilder.DropColumn(
                name: "AudiHostCrea",
                table: "Inscripciones");

            migrationBuilder.DropColumn(
                name: "AudiHostMod",
                table: "Inscripciones");

            migrationBuilder.DropColumn(
                name: "AudiUserCrea",
                table: "Inscripciones");

            migrationBuilder.DropColumn(
                name: "AudiUserMod",
                table: "Inscripciones");

            migrationBuilder.DropColumn(
                name: "AudiFechCrea",
                table: "Especialidades");

            migrationBuilder.DropColumn(
                name: "AudiFechMod",
                table: "Especialidades");

            migrationBuilder.DropColumn(
                name: "AudiHostCrea",
                table: "Especialidades");

            migrationBuilder.DropColumn(
                name: "AudiHostMod",
                table: "Especialidades");

            migrationBuilder.DropColumn(
                name: "AudiUserCrea",
                table: "Especialidades");

            migrationBuilder.DropColumn(
                name: "AudiUserMod",
                table: "Especialidades");

            migrationBuilder.DropColumn(
                name: "AudiFechCrea",
                table: "Cronogramas");

            migrationBuilder.DropColumn(
                name: "AudiFechMod",
                table: "Cronogramas");

            migrationBuilder.DropColumn(
                name: "AudiHostCrea",
                table: "Cronogramas");

            migrationBuilder.DropColumn(
                name: "AudiHostMod",
                table: "Cronogramas");

            migrationBuilder.DropColumn(
                name: "AudiUserCrea",
                table: "Cronogramas");

            migrationBuilder.DropColumn(
                name: "AudiUserMod",
                table: "Cronogramas");

            migrationBuilder.DropColumn(
                name: "AudiFechCrea",
                table: "ConquistadorItemsCuadernillo");

            migrationBuilder.DropColumn(
                name: "AudiFechMod",
                table: "ConquistadorItemsCuadernillo");

            migrationBuilder.DropColumn(
                name: "AudiHostCrea",
                table: "ConquistadorItemsCuadernillo");

            migrationBuilder.DropColumn(
                name: "AudiHostMod",
                table: "ConquistadorItemsCuadernillo");

            migrationBuilder.DropColumn(
                name: "AudiUserCrea",
                table: "ConquistadorItemsCuadernillo");

            migrationBuilder.DropColumn(
                name: "AudiUserMod",
                table: "ConquistadorItemsCuadernillo");

            migrationBuilder.DropColumn(
                name: "AudiFechCrea",
                table: "Conquistadores");

            migrationBuilder.DropColumn(
                name: "AudiFechMod",
                table: "Conquistadores");

            migrationBuilder.DropColumn(
                name: "AudiHostCrea",
                table: "Conquistadores");

            migrationBuilder.DropColumn(
                name: "AudiHostMod",
                table: "Conquistadores");

            migrationBuilder.DropColumn(
                name: "AudiUserCrea",
                table: "Conquistadores");

            migrationBuilder.DropColumn(
                name: "AudiUserMod",
                table: "Conquistadores");

            migrationBuilder.DropColumn(
                name: "AudiFechCrea",
                table: "Clases");

            migrationBuilder.DropColumn(
                name: "AudiFechMod",
                table: "Clases");

            migrationBuilder.DropColumn(
                name: "AudiHostCrea",
                table: "Clases");

            migrationBuilder.DropColumn(
                name: "AudiHostMod",
                table: "Clases");

            migrationBuilder.DropColumn(
                name: "AudiUserCrea",
                table: "Clases");

            migrationBuilder.DropColumn(
                name: "AudiUserMod",
                table: "Clases");

            migrationBuilder.DropColumn(
                name: "AudiFechCrea",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "AudiFechMod",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "AudiHostCrea",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "AudiHostMod",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "AudiUserCrea",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "AudiUserMod",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "AudiFechCrea",
                table: "Asistencias");

            migrationBuilder.DropColumn(
                name: "AudiFechMod",
                table: "Asistencias");

            migrationBuilder.DropColumn(
                name: "AudiHostCrea",
                table: "Asistencias");

            migrationBuilder.DropColumn(
                name: "AudiHostMod",
                table: "Asistencias");

            migrationBuilder.DropColumn(
                name: "AudiUserCrea",
                table: "Asistencias");

            migrationBuilder.DropColumn(
                name: "AudiUserMod",
                table: "Asistencias");

            migrationBuilder.DropColumn(
                name: "AudiFechCrea",
                table: "Actividades");

            migrationBuilder.DropColumn(
                name: "AudiFechMod",
                table: "Actividades");

            migrationBuilder.DropColumn(
                name: "AudiHostCrea",
                table: "Actividades");

            migrationBuilder.DropColumn(
                name: "AudiHostMod",
                table: "Actividades");

            migrationBuilder.DropColumn(
                name: "AudiUserCrea",
                table: "Actividades");

            migrationBuilder.DropColumn(
                name: "AudiUserMod",
                table: "Actividades");

            migrationBuilder.DropColumn(
                name: "AudiFechCrea",
                table: "ActividadConquistadores");

            migrationBuilder.DropColumn(
                name: "AudiFechMod",
                table: "ActividadConquistadores");

            migrationBuilder.DropColumn(
                name: "AudiHostCrea",
                table: "ActividadConquistadores");

            migrationBuilder.DropColumn(
                name: "AudiHostMod",
                table: "ActividadConquistadores");

            migrationBuilder.DropColumn(
                name: "AudiUserCrea",
                table: "ActividadConquistadores");

            migrationBuilder.DropColumn(
                name: "AudiUserMod",
                table: "ActividadConquistadores");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ConqFechaInvestidura",
                table: "Conquistadores",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "ClasID",
                table: "Clases",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AudiFechCrea",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiFechMod",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AudiHostCrea",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiHostMod",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AudiUserCrea",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiUserMod",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AudiFechCrea",
                table: "Unidades",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiFechMod",
                table: "Unidades",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiHostCrea",
                table: "Unidades",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiHostMod",
                table: "Unidades",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiUserCrea",
                table: "Unidades",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiUserMod",
                table: "Unidades",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiFechCrea",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiFechMod",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiHostCrea",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiHostMod",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiUserCrea",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiUserMod",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiFechCrea",
                table: "ItemsCuadernillo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiFechMod",
                table: "ItemsCuadernillo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiHostCrea",
                table: "ItemsCuadernillo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiHostMod",
                table: "ItemsCuadernillo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiUserCrea",
                table: "ItemsCuadernillo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiUserMod",
                table: "ItemsCuadernillo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiFechCrea",
                table: "Inscripciones",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiFechMod",
                table: "Inscripciones",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiHostCrea",
                table: "Inscripciones",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiHostMod",
                table: "Inscripciones",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiUserCrea",
                table: "Inscripciones",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiUserMod",
                table: "Inscripciones",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiFechCrea",
                table: "Especialidades",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiFechMod",
                table: "Especialidades",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiHostCrea",
                table: "Especialidades",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiHostMod",
                table: "Especialidades",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiUserCrea",
                table: "Especialidades",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiUserMod",
                table: "Especialidades",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiFechCrea",
                table: "Cronogramas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiFechMod",
                table: "Cronogramas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiHostCrea",
                table: "Cronogramas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiHostMod",
                table: "Cronogramas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiUserCrea",
                table: "Cronogramas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiUserMod",
                table: "Cronogramas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiFechCrea",
                table: "ConquistadorItemsCuadernillo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiFechMod",
                table: "ConquistadorItemsCuadernillo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiHostCrea",
                table: "ConquistadorItemsCuadernillo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiHostMod",
                table: "ConquistadorItemsCuadernillo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiUserCrea",
                table: "ConquistadorItemsCuadernillo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiUserMod",
                table: "ConquistadorItemsCuadernillo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ConqFechaInvestidura",
                table: "Conquistadores",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AudiFechCrea",
                table: "Conquistadores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiFechMod",
                table: "Conquistadores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiHostCrea",
                table: "Conquistadores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiHostMod",
                table: "Conquistadores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiUserCrea",
                table: "Conquistadores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiUserMod",
                table: "Conquistadores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "ClasID",
                table: "Clases",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "AudiFechCrea",
                table: "Clases",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiFechMod",
                table: "Clases",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiHostCrea",
                table: "Clases",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiHostMod",
                table: "Clases",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiUserCrea",
                table: "Clases",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiUserMod",
                table: "Clases",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiFechCrea",
                table: "Categorias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiFechMod",
                table: "Categorias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiHostCrea",
                table: "Categorias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiHostMod",
                table: "Categorias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiUserCrea",
                table: "Categorias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiUserMod",
                table: "Categorias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiFechCrea",
                table: "Asistencias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiFechMod",
                table: "Asistencias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiHostCrea",
                table: "Asistencias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiHostMod",
                table: "Asistencias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiUserCrea",
                table: "Asistencias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiUserMod",
                table: "Asistencias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiFechCrea",
                table: "Actividades",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiFechMod",
                table: "Actividades",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiHostCrea",
                table: "Actividades",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiHostMod",
                table: "Actividades",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiUserCrea",
                table: "Actividades",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiUserMod",
                table: "Actividades",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiFechCrea",
                table: "ActividadConquistadores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiFechMod",
                table: "ActividadConquistadores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiHostCrea",
                table: "ActividadConquistadores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiHostMod",
                table: "ActividadConquistadores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiUserCrea",
                table: "ActividadConquistadores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudiUserMod",
                table: "ActividadConquistadores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
