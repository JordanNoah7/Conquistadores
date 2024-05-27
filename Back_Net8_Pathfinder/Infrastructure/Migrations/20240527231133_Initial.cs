using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actividades",
                columns: table => new
                {
                    ActiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActiNombre = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ActiLugar = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    ActiDescripcion = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    ActiRequisitos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActiCosto = table.Column<decimal>(type: "decimal(9,3)", nullable: false),
                    ActiFechaInicio = table.Column<DateTime>(type: "datetime", nullable: false),
                    ActiFechaFin = table.Column<DateTime>(type: "datetime", nullable: false),
                    AudiUserCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiFechCrea = table.Column<DateTime>(type: "datetime", nullable: false),
                    AudiHostCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiUserMod = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    AudiFechMod = table.Column<DateTime>(type: "datetime", nullable: true),
                    AudiHostMod = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actividades", x => x.ActiId);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    CateID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CateNombre = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    CateDescripcion = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    CateColor = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    AudiUserCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiFechCrea = table.Column<DateTime>(type: "datetime", nullable: false),
                    AudiHostCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiUserMod = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    AudiFechMod = table.Column<DateTime>(type: "datetime", nullable: true),
                    AudiHostMod = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.CateID);
                });

            migrationBuilder.CreateTable(
                name: "Clases",
                columns: table => new
                {
                    ClasID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClasNombre = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    ClasDescripcion = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    AudiUserCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiFechCrea = table.Column<DateTime>(type: "datetime", nullable: false),
                    AudiHostCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiUserMod = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    AudiFechMod = table.Column<DateTime>(type: "datetime", nullable: true),
                    AudiHostMod = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clases", x => x.ClasID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleNombre = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    RoleDescripcion = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    AudiUserCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiFechCrea = table.Column<DateTime>(type: "datetime", nullable: false),
                    AudiHostCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiUserMod = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    AudiFechMod = table.Column<DateTime>(type: "datetime", nullable: true),
                    AudiHostMod = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "Unidades",
                columns: table => new
                {
                    UnidID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnidNombre = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    UnidLema = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    UnidGritoGuerra = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    UnidDescripcion = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    AudiUserCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiFechCrea = table.Column<DateTime>(type: "datetime", nullable: false),
                    AudiHostCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiUserMod = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    AudiFechMod = table.Column<DateTime>(type: "datetime", nullable: true),
                    AudiHostMod = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unidades", x => x.UnidID);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuaUsuario = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    UsuaContrasenia = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    AudiUserCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiFechCrea = table.Column<DateTime>(type: "datetime", nullable: false),
                    AudiHostCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiUserMod = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    AudiFechMod = table.Column<DateTime>(type: "datetime", nullable: true),
                    AudiHostMod = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuaID);
                });

            migrationBuilder.CreateTable(
                name: "Especialidades",
                columns: table => new
                {
                    EspeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EspeNombre = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    EspeDescripcion = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    EspeCategoriaCateID = table.Column<int>(type: "int", nullable: false),
                    AudiUserCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiFechCrea = table.Column<DateTime>(type: "datetime", nullable: false),
                    AudiHostCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiUserMod = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    AudiFechMod = table.Column<DateTime>(type: "datetime", nullable: true),
                    AudiHostMod = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidades", x => x.EspeID);
                    table.ForeignKey(
                        name: "FK_Especialidades_Categorias_EspeCategoriaCateID",
                        column: x => x.EspeCategoriaCateID,
                        principalTable: "Categorias",
                        principalColumn: "CateID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemsCuadernillo",
                columns: table => new
                {
                    ItcuID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItcuDescripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItcuClaseClasID = table.Column<int>(type: "int", nullable: false),
                    AudiUserCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiFechCrea = table.Column<DateTime>(type: "datetime", nullable: false),
                    AudiHostCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiUserMod = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    AudiFechMod = table.Column<DateTime>(type: "datetime", nullable: true),
                    AudiHostMod = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsCuadernillo", x => x.ItcuID);
                    table.ForeignKey(
                        name: "FK_ItemsCuadernillo_Clases_ItcuClaseClasID",
                        column: x => x.ItcuClaseClasID,
                        principalTable: "Clases",
                        principalColumn: "ClasID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Conquistadores",
                columns: table => new
                {
                    ConqID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConqDni = table.Column<string>(type: "nchar(8)", nullable: false),
                    ConqNombres = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ConqApellidoPaterno = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    ConqApellidoMaterno = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    ConqFechaNacimiento = table.Column<DateTime>(type: "datetime", nullable: false),
                    ConqFechaInvestidura = table.Column<DateTime>(type: "datetime", nullable: true),
                    ConqUsuarioUsuaID = table.Column<int>(type: "int", nullable: false),
                    ConqUnidadUnidID = table.Column<int>(type: "int", nullable: false),
                    ConqClaseClasID = table.Column<int>(type: "int", nullable: false),
                    AudiUserCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiFechCrea = table.Column<DateTime>(type: "datetime", nullable: false),
                    AudiHostCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiUserMod = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    AudiFechMod = table.Column<DateTime>(type: "datetime", nullable: true),
                    AudiHostMod = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conquistadores", x => x.ConqID);
                    table.ForeignKey(
                        name: "FK_Conquistadores_Clases_ConqClaseClasID",
                        column: x => x.ConqClaseClasID,
                        principalTable: "Clases",
                        principalColumn: "ClasID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Conquistadores_Unidades_ConqUnidadUnidID",
                        column: x => x.ConqUnidadUnidID,
                        principalTable: "Unidades",
                        principalColumn: "UnidID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Conquistadores_Usuarios_ConqUsuarioUsuaID",
                        column: x => x.ConqUsuarioUsuaID,
                        principalTable: "Usuarios",
                        principalColumn: "UsuaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolUsuario",
                columns: table => new
                {
                    RoleUsuariosUsuaID = table.Column<int>(type: "int", nullable: false),
                    UsuaRolesRoleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolUsuario", x => new { x.RoleUsuariosUsuaID, x.UsuaRolesRoleID });
                    table.ForeignKey(
                        name: "FK_RolUsuario_Roles_UsuaRolesRoleID",
                        column: x => x.UsuaRolesRoleID,
                        principalTable: "Roles",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolUsuario_Usuarios_RoleUsuariosUsuaID",
                        column: x => x.RoleUsuariosUsuaID,
                        principalTable: "Usuarios",
                        principalColumn: "UsuaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cronogramas",
                columns: table => new
                {
                    CronID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CronEstaHecho = table.Column<bool>(type: "bit", nullable: false),
                    CronFechaInicio = table.Column<DateTime>(type: "datetime", nullable: false),
                    CronFechaFin = table.Column<DateTime>(type: "datetime", nullable: false),
                    CronItemItcuID = table.Column<int>(type: "int", nullable: false),
                    AudiUserCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiFechCrea = table.Column<DateTime>(type: "datetime", nullable: false),
                    AudiHostCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiUserMod = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    AudiFechMod = table.Column<DateTime>(type: "datetime", nullable: true),
                    AudiHostMod = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cronogramas", x => x.CronID);
                    table.ForeignKey(
                        name: "FK_Cronogramas_ItemsCuadernillo_CronItemItcuID",
                        column: x => x.CronItemItcuID,
                        principalTable: "ItemsCuadernillo",
                        principalColumn: "ItcuID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActividadConquistadores",
                columns: table => new
                {
                    AccoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccoActividadActiId = table.Column<int>(type: "int", nullable: false),
                    AccoConquistadorConqID = table.Column<int>(type: "int", nullable: false),
                    AccoTipo = table.Column<string>(type: "nchar(1)", nullable: false),
                    AudiUserCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiFechCrea = table.Column<DateTime>(type: "datetime", nullable: false),
                    AudiHostCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiUserMod = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    AudiFechMod = table.Column<DateTime>(type: "datetime", nullable: true),
                    AudiHostMod = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActividadConquistadores", x => x.AccoId);
                    table.ForeignKey(
                        name: "FK_ActividadConquistadores_Actividades_AccoActividadActiId",
                        column: x => x.AccoActividadActiId,
                        principalTable: "Actividades",
                        principalColumn: "ActiId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActividadConquistadores_Conquistadores_AccoConquistadorConqID",
                        column: x => x.AccoConquistadorConqID,
                        principalTable: "Conquistadores",
                        principalColumn: "ConqID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Asistencias",
                columns: table => new
                {
                    AsisID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AsisConquistadorConqID = table.Column<int>(type: "int", nullable: false),
                    AsisFecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    AsisFrecuencia = table.Column<byte>(type: "tinyint", nullable: false),
                    AsisDevocion = table.Column<byte>(type: "tinyint", nullable: false),
                    AsisCuota = table.Column<byte>(type: "tinyint", nullable: false),
                    AsisDisciplina = table.Column<byte>(type: "tinyint", nullable: false),
                    AsisAnioBiblico = table.Column<byte>(type: "tinyint", nullable: false),
                    AsisRequerimiento = table.Column<byte>(type: "tinyint", nullable: false),
                    AsisTotal = table.Column<byte>(type: "tinyint", nullable: false),
                    AsisMonto = table.Column<decimal>(type: "decimal(9,3)", nullable: false),
                    AudiUserCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiFechCrea = table.Column<DateTime>(type: "datetime", nullable: false),
                    AudiHostCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiUserMod = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    AudiFechMod = table.Column<DateTime>(type: "datetime", nullable: true),
                    AudiHostMod = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asistencias", x => x.AsisID);
                    table.ForeignKey(
                        name: "FK_Asistencias_Conquistadores_AsisConquistadorConqID",
                        column: x => x.AsisConquistadorConqID,
                        principalTable: "Conquistadores",
                        principalColumn: "ConqID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConquistadorEspecialidad",
                columns: table => new
                {
                    ConqEspecialidadesEspeID = table.Column<int>(type: "int", nullable: false),
                    EspeConquistadoresConqID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConquistadorEspecialidad", x => new { x.ConqEspecialidadesEspeID, x.EspeConquistadoresConqID });
                    table.ForeignKey(
                        name: "FK_ConquistadorEspecialidad_Conquistadores_EspeConquistadoresConqID",
                        column: x => x.EspeConquistadoresConqID,
                        principalTable: "Conquistadores",
                        principalColumn: "ConqID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConquistadorEspecialidad_Especialidades_ConqEspecialidadesEspeID",
                        column: x => x.ConqEspecialidadesEspeID,
                        principalTable: "Especialidades",
                        principalColumn: "EspeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConquistadorItemsCuadernillo",
                columns: table => new
                {
                    CoicId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConqID = table.Column<int>(type: "int", nullable: false),
                    ItcuID = table.Column<int>(type: "int", nullable: false),
                    CoicEstaCompleto = table.Column<bool>(type: "bit", nullable: false),
                    AudiUserCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiFechCrea = table.Column<DateTime>(type: "datetime", nullable: false),
                    AudiHostCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiUserMod = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    AudiFechMod = table.Column<DateTime>(type: "datetime", nullable: true),
                    AudiHostMod = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConquistadorItemsCuadernillo", x => x.CoicId);
                    table.ForeignKey(
                        name: "FK_ConquistadorItemsCuadernillo_Conquistadores_ConqID",
                        column: x => x.ConqID,
                        principalTable: "Conquistadores",
                        principalColumn: "ConqID");
                    table.ForeignKey(
                        name: "FK_ConquistadorItemsCuadernillo_ItemsCuadernillo_ItcuID",
                        column: x => x.ItcuID,
                        principalTable: "ItemsCuadernillo",
                        principalColumn: "ItcuID");
                });

            migrationBuilder.CreateTable(
                name: "Inscripciones",
                columns: table => new
                {
                    InscID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InscFecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    InscMonto = table.Column<decimal>(type: "decimal(9,3)", nullable: false),
                    InscConquistadorConqID = table.Column<int>(type: "int", nullable: false),
                    AudiUserCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiFechCrea = table.Column<DateTime>(type: "datetime", nullable: false),
                    AudiHostCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiUserMod = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    AudiFechMod = table.Column<DateTime>(type: "datetime", nullable: true),
                    AudiHostMod = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscripciones", x => x.InscID);
                    table.ForeignKey(
                        name: "FK_Inscripciones_Conquistadores_InscConquistadorConqID",
                        column: x => x.InscConquistadorConqID,
                        principalTable: "Conquistadores",
                        principalColumn: "ConqID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActividadConquistadores_AccoActividadActiId",
                table: "ActividadConquistadores",
                column: "AccoActividadActiId");

            migrationBuilder.CreateIndex(
                name: "IX_ActividadConquistadores_AccoConquistadorConqID",
                table: "ActividadConquistadores",
                column: "AccoConquistadorConqID");

            migrationBuilder.CreateIndex(
                name: "IX_Asistencias_AsisConquistadorConqID",
                table: "Asistencias",
                column: "AsisConquistadorConqID");

            migrationBuilder.CreateIndex(
                name: "IX_Conquistadores_ConqClaseClasID",
                table: "Conquistadores",
                column: "ConqClaseClasID");

            migrationBuilder.CreateIndex(
                name: "IX_Conquistadores_ConqUnidadUnidID",
                table: "Conquistadores",
                column: "ConqUnidadUnidID");

            migrationBuilder.CreateIndex(
                name: "IX_Conquistadores_ConqUsuarioUsuaID",
                table: "Conquistadores",
                column: "ConqUsuarioUsuaID");

            migrationBuilder.CreateIndex(
                name: "IX_ConquistadorEspecialidad_EspeConquistadoresConqID",
                table: "ConquistadorEspecialidad",
                column: "EspeConquistadoresConqID");

            migrationBuilder.CreateIndex(
                name: "IX_ConquistadorItemsCuadernillo_ConqID",
                table: "ConquistadorItemsCuadernillo",
                column: "ConqID");

            migrationBuilder.CreateIndex(
                name: "IX_ConquistadorItemsCuadernillo_ItcuID",
                table: "ConquistadorItemsCuadernillo",
                column: "ItcuID");

            migrationBuilder.CreateIndex(
                name: "IX_Cronogramas_CronItemItcuID",
                table: "Cronogramas",
                column: "CronItemItcuID");

            migrationBuilder.CreateIndex(
                name: "IX_Especialidades_EspeCategoriaCateID",
                table: "Especialidades",
                column: "EspeCategoriaCateID");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_InscConquistadorConqID",
                table: "Inscripciones",
                column: "InscConquistadorConqID");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsCuadernillo_ItcuClaseClasID",
                table: "ItemsCuadernillo",
                column: "ItcuClaseClasID");

            migrationBuilder.CreateIndex(
                name: "IX_RolUsuario_UsuaRolesRoleID",
                table: "RolUsuario",
                column: "UsuaRolesRoleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActividadConquistadores");

            migrationBuilder.DropTable(
                name: "Asistencias");

            migrationBuilder.DropTable(
                name: "ConquistadorEspecialidad");

            migrationBuilder.DropTable(
                name: "ConquistadorItemsCuadernillo");

            migrationBuilder.DropTable(
                name: "Cronogramas");

            migrationBuilder.DropTable(
                name: "Inscripciones");

            migrationBuilder.DropTable(
                name: "RolUsuario");

            migrationBuilder.DropTable(
                name: "Actividades");

            migrationBuilder.DropTable(
                name: "Especialidades");

            migrationBuilder.DropTable(
                name: "ItemsCuadernillo");

            migrationBuilder.DropTable(
                name: "Conquistadores");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Clases");

            migrationBuilder.DropTable(
                name: "Unidades");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
