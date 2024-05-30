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
                    AudiFechCrea = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
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
                    CateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CateNombre = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    CateDescripcion = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    CateColor = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    AudiUserCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiFechCrea = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    AudiHostCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiUserMod = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    AudiFechMod = table.Column<DateTime>(type: "datetime", nullable: true),
                    AudiHostMod = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.CateId);
                });

            migrationBuilder.CreateTable(
                name: "Clases",
                columns: table => new
                {
                    ClasId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClasNombre = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    ClasDescripcion = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    AudiUserCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiFechCrea = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    AudiHostCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiUserMod = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    AudiFechMod = table.Column<DateTime>(type: "datetime", nullable: true),
                    AudiHostMod = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clases", x => x.ClasId);
                });

            migrationBuilder.CreateTable(
                name: "Parametros",
                columns: table => new
                {
                    ParaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParaNombre = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    ParaValor = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    AudiUserCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiFechCrea = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    AudiHostCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiUserMod = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    AudiFechMod = table.Column<DateTime>(type: "datetime", nullable: true),
                    AudiHostMod = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parametros", x => x.ParaId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleNombre = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    RoleDescripcion = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    AudiUserCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiFechCrea = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    AudiHostCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiUserMod = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    AudiFechMod = table.Column<DateTime>(type: "datetime", nullable: true),
                    AudiHostMod = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Tipos",
                columns: table => new
                {
                    TipoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoTabla = table.Column<string>(type: "char(3)", nullable: false),
                    TipoDescripcion = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    TipoEstaActivo = table.Column<bool>(type: "bit", nullable: false),
                    AudiUserCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiFechCrea = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    AudiHostCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiUserMod = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    AudiFechMod = table.Column<DateTime>(type: "datetime", nullable: true),
                    AudiHostMod = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipos", x => x.TipoId);
                });

            migrationBuilder.CreateTable(
                name: "Tutores",
                columns: table => new
                {
                    TutoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TutoDni = table.Column<string>(type: "nchar(8)", nullable: false),
                    TutoNombres = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    TutoApellidoPaterno = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    TutoApellidoMaterno = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    TutoFechaNacimiento = table.Column<DateTime>(type: "datetime", nullable: false),
                    TutoCorreoPersonal = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    TutoCorreoCorporativo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    TutoCelular = table.Column<string>(type: "nvarchar(18)", nullable: false),
                    TutoTelefono = table.Column<string>(type: "nvarchar(18)", nullable: true),
                    AudiUserCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiFechCrea = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    AudiHostCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiUserMod = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    AudiFechMod = table.Column<DateTime>(type: "datetime", nullable: true),
                    AudiHostMod = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tutores", x => x.TutoId);
                });

            migrationBuilder.CreateTable(
                name: "Unidades",
                columns: table => new
                {
                    UnidId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnidNombre = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    UnidLema = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    UnidGritoGuerra = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    UnidDescripcion = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    AudiUserCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiFechCrea = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    AudiHostCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiUserMod = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    AudiFechMod = table.Column<DateTime>(type: "datetime", nullable: true),
                    AudiHostMod = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unidades", x => x.UnidId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuaUsuario = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    UsuaContrasenia = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    AudiUserCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiFechCrea = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    AudiHostCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiUserMod = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    AudiFechMod = table.Column<DateTime>(type: "datetime", nullable: true),
                    AudiHostMod = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuaId);
                });

            migrationBuilder.CreateTable(
                name: "Especialidades",
                columns: table => new
                {
                    EspeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EspeNombre = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    EspeDescripcion = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    CateId = table.Column<int>(type: "int", nullable: false),
                    AudiUserCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiFechCrea = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    AudiHostCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiUserMod = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    AudiFechMod = table.Column<DateTime>(type: "datetime", nullable: true),
                    AudiHostMod = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidades", x => x.EspeId);
                    table.ForeignKey(
                        name: "FK_Especialidades_Categorias_CateId",
                        column: x => x.CateId,
                        principalTable: "Categorias",
                        principalColumn: "CateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemsCuadernillo",
                columns: table => new
                {
                    ItcuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItcuDescripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClasId = table.Column<int>(type: "int", nullable: false),
                    AudiUserCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiFechCrea = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    AudiHostCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiUserMod = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    AudiFechMod = table.Column<DateTime>(type: "datetime", nullable: true),
                    AudiHostMod = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsCuadernillo", x => x.ItcuId);
                    table.ForeignKey(
                        name: "FK_ItemsCuadernillo_Clases_ClasId",
                        column: x => x.ClasId,
                        principalTable: "Clases",
                        principalColumn: "ClasId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Conquistadores",
                columns: table => new
                {
                    ConqId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConqDni = table.Column<string>(type: "nchar(8)", nullable: false),
                    ConqNombres = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ConqApellidoPaterno = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    ConqApellidoMaterno = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    ConqFechaNacimiento = table.Column<DateTime>(type: "datetime", nullable: false),
                    ConqFechaInvestidura = table.Column<DateTime>(type: "datetime", nullable: true),
                    ConqCorreoPersonal = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ConqCorreoCorporativo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ConqCelular = table.Column<string>(type: "nvarchar(18)", nullable: false),
                    ConqTelefono = table.Column<string>(type: "nvarchar(18)", nullable: true),
                    UsuaId = table.Column<int>(type: "int", nullable: false),
                    UnidId = table.Column<int>(type: "int", nullable: true),
                    ClasId = table.Column<int>(type: "int", nullable: true),
                    AudiUserCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiFechCrea = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    AudiHostCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiUserMod = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    AudiFechMod = table.Column<DateTime>(type: "datetime", nullable: true),
                    AudiHostMod = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conquistadores", x => x.ConqId);
                    table.ForeignKey(
                        name: "FK_Conquistadores_Clases_ClasId",
                        column: x => x.ClasId,
                        principalTable: "Clases",
                        principalColumn: "ClasId");
                    table.ForeignKey(
                        name: "FK_Conquistadores_Unidades_UnidId",
                        column: x => x.UnidId,
                        principalTable: "Unidades",
                        principalColumn: "UnidId");
                    table.ForeignKey(
                        name: "FK_Conquistadores_Usuarios_UsuaId",
                        column: x => x.UsuaId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolesUsuario",
                columns: table => new
                {
                    RousId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    UsuaId = table.Column<int>(type: "int", nullable: false),
                    AudiUserCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiFechCrea = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    AudiHostCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiUserMod = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    AudiFechMod = table.Column<DateTime>(type: "datetime", nullable: true),
                    AudiHostMod = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesUsuario", x => new { x.RousId, x.UsuaId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_RolesUsuario_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolesUsuario_Usuarios_UsuaId",
                        column: x => x.UsuaId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sesiones",
                columns: table => new
                {
                    SesiId = table.Column<int>(type: "int", nullable: false),
                    UsuaId = table.Column<int>(type: "int", nullable: false),
                    SesiFecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    AudiUserCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiFechCrea = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    AudiHostCrea = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sesiones", x => new { x.UsuaId, x.SesiId });
                    table.ForeignKey(
                        name: "FK_Sesiones_Usuarios_UsuaId",
                        column: x => x.UsuaId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cronogramas",
                columns: table => new
                {
                    CronId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CronEstaHecho = table.Column<bool>(type: "bit", nullable: false),
                    CronFechaInicio = table.Column<DateTime>(type: "datetime", nullable: false),
                    CronFechaFin = table.Column<DateTime>(type: "datetime", nullable: false),
                    ItcuId = table.Column<int>(type: "int", nullable: false),
                    AudiUserCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiFechCrea = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    AudiHostCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiUserMod = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    AudiFechMod = table.Column<DateTime>(type: "datetime", nullable: true),
                    AudiHostMod = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cronogramas", x => x.CronId);
                    table.ForeignKey(
                        name: "FK_Cronogramas_ItemsCuadernillo_ItcuId",
                        column: x => x.ItcuId,
                        principalTable: "ItemsCuadernillo",
                        principalColumn: "ItcuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActividadConquistadores",
                columns: table => new
                {
                    AccoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActiId = table.Column<int>(type: "int", nullable: false),
                    ConqId = table.Column<int>(type: "int", nullable: false),
                    AccoTipoParticipacionId = table.Column<int>(type: "int", nullable: false),
                    AudiUserCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiFechCrea = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    AudiHostCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiUserMod = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    AudiFechMod = table.Column<DateTime>(type: "datetime", nullable: true),
                    AudiHostMod = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActividadConquistadores", x => new { x.AccoId, x.ActiId, x.ConqId });
                    table.ForeignKey(
                        name: "FK_ActividadConquistadores_Actividades_ActiId",
                        column: x => x.ActiId,
                        principalTable: "Actividades",
                        principalColumn: "ActiId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActividadConquistadores_Conquistadores_ConqId",
                        column: x => x.ConqId,
                        principalTable: "Conquistadores",
                        principalColumn: "ConqId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActividadConquistadores_Tipos_AccoTipoParticipacionId",
                        column: x => x.AccoTipoParticipacionId,
                        principalTable: "Tipos",
                        principalColumn: "TipoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Asistencias",
                columns: table => new
                {
                    AsisId = table.Column<int>(type: "int", nullable: false),
                    ConqId = table.Column<int>(type: "int", nullable: false),
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
                    AudiFechCrea = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    AudiHostCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiUserMod = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    AudiFechMod = table.Column<DateTime>(type: "datetime", nullable: true),
                    AudiHostMod = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asistencias", x => new { x.ConqId, x.AsisId });
                    table.ForeignKey(
                        name: "FK_Asistencias_Conquistadores_ConqId",
                        column: x => x.ConqId,
                        principalTable: "Conquistadores",
                        principalColumn: "ConqId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConquistadorEspecialidades",
                columns: table => new
                {
                    CoesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConqId = table.Column<int>(type: "int", nullable: false),
                    EspeId = table.Column<int>(type: "int", nullable: false),
                    AudiUserCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiFechCrea = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    AudiHostCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiUserMod = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    AudiFechMod = table.Column<DateTime>(type: "datetime", nullable: true),
                    AudiHostMod = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConquistadorEspecialidades", x => new { x.CoesId, x.ConqId, x.EspeId });
                    table.ForeignKey(
                        name: "FK_ConquistadorEspecialidades_Conquistadores_ConqId",
                        column: x => x.ConqId,
                        principalTable: "Conquistadores",
                        principalColumn: "ConqId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConquistadorEspecialidades_Especialidades_EspeId",
                        column: x => x.EspeId,
                        principalTable: "Especialidades",
                        principalColumn: "EspeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConquistadorItemsCuadernillo",
                columns: table => new
                {
                    CoicId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoicEstaCompleto = table.Column<bool>(type: "bit", nullable: false),
                    ConqId = table.Column<int>(type: "int", nullable: true),
                    ItcuId = table.Column<int>(type: "int", nullable: true),
                    AudiUserCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiFechCrea = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    AudiHostCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiUserMod = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    AudiFechMod = table.Column<DateTime>(type: "datetime", nullable: true),
                    AudiHostMod = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConquistadorItemsCuadernillo", x => x.CoicId);
                    table.ForeignKey(
                        name: "FK_ConquistadorItemsCuadernillo_Conquistadores_ConqId",
                        column: x => x.ConqId,
                        principalTable: "Conquistadores",
                        principalColumn: "ConqId");
                    table.ForeignKey(
                        name: "FK_ConquistadorItemsCuadernillo_ItemsCuadernillo_ItcuId",
                        column: x => x.ItcuId,
                        principalTable: "ItemsCuadernillo",
                        principalColumn: "ItcuId");
                });

            migrationBuilder.CreateTable(
                name: "Inscripciones",
                columns: table => new
                {
                    InscId = table.Column<int>(type: "int", nullable: false),
                    ConqId = table.Column<int>(type: "int", nullable: false),
                    InscFecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    InscMonto = table.Column<decimal>(type: "decimal(9,3)", nullable: false),
                    AudiUserCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiFechCrea = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    AudiHostCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiUserMod = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    AudiFechMod = table.Column<DateTime>(type: "datetime", nullable: true),
                    AudiHostMod = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscripciones", x => new { x.ConqId, x.InscId });
                    table.ForeignKey(
                        name: "FK_Inscripciones_Conquistadores_ConqId",
                        column: x => x.ConqId,
                        principalTable: "Conquistadores",
                        principalColumn: "ConqId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TutorConquistadores",
                columns: table => new
                {
                    TucoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TutoId = table.Column<int>(type: "int", nullable: false),
                    ConqId = table.Column<int>(type: "int", nullable: false),
                    TucoParentescoId = table.Column<int>(type: "int", nullable: false),
                    AudiUserCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiFechCrea = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    AudiHostCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiUserMod = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    AudiFechMod = table.Column<DateTime>(type: "datetime", nullable: true),
                    AudiHostMod = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TutorConquistadores", x => new { x.TucoId, x.TutoId, x.ConqId });
                    table.ForeignKey(
                        name: "FK_TutorConquistadores_Conquistadores_ConqId",
                        column: x => x.ConqId,
                        principalTable: "Conquistadores",
                        principalColumn: "ConqId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TutorConquistadores_Tipos_TucoParentescoId",
                        column: x => x.TucoParentescoId,
                        principalTable: "Tipos",
                        principalColumn: "TipoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TutorConquistadores_Tutores_TutoId",
                        column: x => x.TutoId,
                        principalTable: "Tutores",
                        principalColumn: "TutoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActividadConquistadores_AccoTipoParticipacionId",
                table: "ActividadConquistadores",
                column: "AccoTipoParticipacionId");

            migrationBuilder.CreateIndex(
                name: "IX_ActividadConquistadores_ActiId",
                table: "ActividadConquistadores",
                column: "ActiId");

            migrationBuilder.CreateIndex(
                name: "IX_ActividadConquistadores_ConqId",
                table: "ActividadConquistadores",
                column: "ConqId");

            migrationBuilder.CreateIndex(
                name: "IX_Conquistadores_ClasId",
                table: "Conquistadores",
                column: "ClasId");

            migrationBuilder.CreateIndex(
                name: "IX_Conquistadores_UnidId",
                table: "Conquistadores",
                column: "UnidId");

            migrationBuilder.CreateIndex(
                name: "IX_Conquistadores_UsuaId",
                table: "Conquistadores",
                column: "UsuaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConquistadorEspecialidades_ConqId",
                table: "ConquistadorEspecialidades",
                column: "ConqId");

            migrationBuilder.CreateIndex(
                name: "IX_ConquistadorEspecialidades_EspeId",
                table: "ConquistadorEspecialidades",
                column: "EspeId");

            migrationBuilder.CreateIndex(
                name: "IX_ConquistadorItemsCuadernillo_ConqId",
                table: "ConquistadorItemsCuadernillo",
                column: "ConqId");

            migrationBuilder.CreateIndex(
                name: "IX_ConquistadorItemsCuadernillo_ItcuId",
                table: "ConquistadorItemsCuadernillo",
                column: "ItcuId");

            migrationBuilder.CreateIndex(
                name: "IX_Cronogramas_ItcuId",
                table: "Cronogramas",
                column: "ItcuId");

            migrationBuilder.CreateIndex(
                name: "IX_Especialidades_CateId",
                table: "Especialidades",
                column: "CateId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsCuadernillo_ClasId",
                table: "ItemsCuadernillo",
                column: "ClasId");

            migrationBuilder.CreateIndex(
                name: "IX_RolesUsuario_RoleId",
                table: "RolesUsuario",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RolesUsuario_UsuaId",
                table: "RolesUsuario",
                column: "UsuaId");

            migrationBuilder.CreateIndex(
                name: "IX_Sesiones_UsuaId",
                table: "Sesiones",
                column: "UsuaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TutorConquistadores_ConqId",
                table: "TutorConquistadores",
                column: "ConqId");

            migrationBuilder.CreateIndex(
                name: "IX_TutorConquistadores_TucoParentescoId",
                table: "TutorConquistadores",
                column: "TucoParentescoId");

            migrationBuilder.CreateIndex(
                name: "IX_TutorConquistadores_TutoId",
                table: "TutorConquistadores",
                column: "TutoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActividadConquistadores");

            migrationBuilder.DropTable(
                name: "Asistencias");

            migrationBuilder.DropTable(
                name: "ConquistadorEspecialidades");

            migrationBuilder.DropTable(
                name: "ConquistadorItemsCuadernillo");

            migrationBuilder.DropTable(
                name: "Cronogramas");

            migrationBuilder.DropTable(
                name: "Inscripciones");

            migrationBuilder.DropTable(
                name: "Parametros");

            migrationBuilder.DropTable(
                name: "RolesUsuario");

            migrationBuilder.DropTable(
                name: "Sesiones");

            migrationBuilder.DropTable(
                name: "TutorConquistadores");

            migrationBuilder.DropTable(
                name: "Actividades");

            migrationBuilder.DropTable(
                name: "Especialidades");

            migrationBuilder.DropTable(
                name: "ItemsCuadernillo");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Conquistadores");

            migrationBuilder.DropTable(
                name: "Tipos");

            migrationBuilder.DropTable(
                name: "Tutores");

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
