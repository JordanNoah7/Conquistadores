using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
                    CateNombre = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CateDescripcion = table.Column<string>(type: "nvarchar(500)", nullable: false),
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
                    ClasNombre = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ClasDescripcion = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    ClasImagen = table.Column<string>(type: "nvarchar(50)", nullable: false),
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
                    ParaValor = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    TipoTabla = table.Column<string>(type: "nchar(3)", nullable: false),
                    TipoId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Tipos", x => new { x.TipoTabla, x.TipoId });
                });

            migrationBuilder.CreateTable(
                name: "Unidades",
                columns: table => new
                {
                    UnidId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnidNombre = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    UnidLema = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnidGritoGuerra = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnidDescripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnidImagen = table.Column<string>(type: "nvarchar(50)", nullable: false),
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
                    UsuaCambiarContrasenia = table.Column<bool>(type: "bit", nullable: true),
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
                    CateId = table.Column<int>(type: "int", nullable: false),
                    EspeId = table.Column<int>(type: "int", nullable: false),
                    EspeNombre = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    EspeDescripcion = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    EspeImagen = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    AudiUserCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiFechCrea = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    AudiHostCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiUserMod = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    AudiFechMod = table.Column<DateTime>(type: "datetime", nullable: true),
                    AudiHostMod = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidades", x => new { x.CateId, x.EspeId });
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
                    ClasId = table.Column<int>(type: "int", nullable: false),
                    ItcuId = table.Column<int>(type: "int", nullable: false),
                    ItcuDescripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AudiUserCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiFechCrea = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    AudiHostCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiUserMod = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    AudiFechMod = table.Column<DateTime>(type: "datetime", nullable: true),
                    AudiHostMod = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsCuadernillo", x => new { x.ClasId, x.ItcuId });
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
                    PersId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConqFechaInvestidura = table.Column<DateTime>(type: "datetime", nullable: true),
                    ConqEscuela = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    ConqCurso = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    ConqTurno = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    PersDni = table.Column<string>(type: "nchar(8)", nullable: false),
                    PersNombres = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    PersApellidoPaterno = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    PersApellidoMaterno = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    PersFechaNacimiento = table.Column<DateTime>(type: "datetime", nullable: false),
                    PersCorreoPersonal = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    PersCorreoCorporativo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    PersCelular = table.Column<string>(type: "nvarchar(18)", nullable: false),
                    PersTelefono = table.Column<string>(type: "nvarchar(18)", nullable: true),
                    PersSexo = table.Column<string>(type: "char(1)", nullable: false),
                    PersDireccionCasa = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    PersNacionalidad = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    PersRegion = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    PersCiudad = table.Column<string>(type: "nvarchar(250)", nullable: false),
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
                    table.PrimaryKey("PK_Conquistadores", x => x.PersId);
                    table.ForeignKey(
                        name: "FK_Conquistadores_Usuarios_UsuaId",
                        column: x => x.UsuaId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sesiones",
                columns: table => new
                {
                    UsuaId = table.Column<int>(type: "int", nullable: false),
                    SesiId = table.Column<int>(type: "int", nullable: false),
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
                name: "Tutores",
                columns: table => new
                {
                    PersId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TutoCentroTrabajo = table.Column<string>(type: "nvarchar(18)", nullable: false),
                    TutoDireccionTrabajo = table.Column<string>(type: "nvarchar(18)", nullable: false),
                    PersDni = table.Column<string>(type: "nchar(8)", nullable: false),
                    PersNombres = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    PersApellidoPaterno = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    PersApellidoMaterno = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    PersFechaNacimiento = table.Column<DateTime>(type: "datetime", nullable: false),
                    PersCorreoPersonal = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    PersCorreoCorporativo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    PersCelular = table.Column<string>(type: "nvarchar(18)", nullable: false),
                    PersTelefono = table.Column<string>(type: "nvarchar(18)", nullable: true),
                    PersSexo = table.Column<string>(type: "char(1)", nullable: false),
                    PersDireccionCasa = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    PersNacionalidad = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    PersRegion = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    PersCiudad = table.Column<string>(type: "nvarchar(250)", nullable: false),
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
                    table.PrimaryKey("PK_Tutores", x => x.PersId);
                    table.ForeignKey(
                        name: "FK_Tutores_Usuarios_UsuaId",
                        column: x => x.UsuaId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioRoles",
                columns: table => new
                {
                    UsuaId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    AudiUserCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiFechCrea = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    AudiHostCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiUserMod = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    AudiFechMod = table.Column<DateTime>(type: "datetime", nullable: true),
                    AudiHostMod = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioRoles", x => new { x.UsuaId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UsuarioRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioRoles_Usuarios_UsuaId",
                        column: x => x.UsuaId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cronogramas",
                columns: table => new
                {
                    ClasId = table.Column<int>(type: "int", nullable: false),
                    ItcuId = table.Column<int>(type: "int", nullable: false),
                    CronAno = table.Column<int>(type: "int", nullable: false),
                    CronEstaHecho = table.Column<bool>(type: "bit", nullable: false),
                    CronFechaInicio = table.Column<DateTime>(type: "datetime", nullable: false),
                    CronFechaFin = table.Column<DateTime>(type: "datetime", nullable: false),
                    AudiUserCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiFechCrea = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    AudiHostCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiUserMod = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    AudiFechMod = table.Column<DateTime>(type: "datetime", nullable: true),
                    AudiHostMod = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cronogramas", x => new { x.ClasId, x.ItcuId, x.CronAno });
                    table.ForeignKey(
                        name: "FK_Cronogramas_ItemsCuadernillo_ClasId_ItcuId",
                        columns: x => new { x.ClasId, x.ItcuId },
                        principalTable: "ItemsCuadernillo",
                        principalColumns: new[] { "ClasId", "ItcuId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActividadConquistadores",
                columns: table => new
                {
                    ActiId = table.Column<int>(type: "int", nullable: false),
                    ConqId = table.Column<int>(type: "int", nullable: false),
                    AccoTipoParticipacionTabla = table.Column<string>(type: "nchar(3)", nullable: false),
                    AccoTipoParticipacionId = table.Column<int>(type: "int", nullable: false),
                    AccoAutorizado = table.Column<bool>(type: "bit", nullable: false),
                    AccoSaludPerfecta = table.Column<bool>(type: "bit", nullable: false),
                    AccoDetalles = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccoFechaAutorizado = table.Column<DateTime>(type: "datetime", nullable: false),
                    AudiUserCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiFechCrea = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    AudiHostCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiUserMod = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    AudiFechMod = table.Column<DateTime>(type: "datetime", nullable: true),
                    AudiHostMod = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActividadConquistadores", x => new { x.ActiId, x.ConqId });
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
                        principalColumn: "PersId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActividadConquistadores_Tipos_AccoTipoParticipacionTabla_AccoTipoParticipacionId",
                        columns: x => new { x.AccoTipoParticipacionTabla, x.AccoTipoParticipacionId },
                        principalTable: "Tipos",
                        principalColumns: new[] { "TipoTabla", "TipoId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Asistencias",
                columns: table => new
                {
                    ConqId = table.Column<int>(type: "int", nullable: false),
                    AsisId = table.Column<int>(type: "int", nullable: false),
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
                        principalColumn: "PersId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClaseConquistadores",
                columns: table => new
                {
                    ClasId = table.Column<int>(type: "int", nullable: false),
                    ConqId = table.Column<int>(type: "int", nullable: false),
                    ClcoTipoCargoClaseTabla = table.Column<string>(type: "nchar(3)", nullable: false),
                    ClcoTipoCargoClaseId = table.Column<int>(type: "int", nullable: false),
                    ClcoAprobado = table.Column<bool>(type: "bit", nullable: true),
                    ClcoFechaAprobado = table.Column<DateTime>(type: "datetime", nullable: true),
                    AudiUserCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiFechCrea = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    AudiHostCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiUserMod = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    AudiFechMod = table.Column<DateTime>(type: "datetime", nullable: true),
                    AudiHostMod = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaseConquistadores", x => new { x.ConqId, x.ClasId });
                    table.ForeignKey(
                        name: "FK_ClaseConquistadores_Clases_ClasId",
                        column: x => x.ClasId,
                        principalTable: "Clases",
                        principalColumn: "ClasId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClaseConquistadores_Conquistadores_ConqId",
                        column: x => x.ConqId,
                        principalTable: "Conquistadores",
                        principalColumn: "PersId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConquistadorEspecialidades",
                columns: table => new
                {
                    ConqId = table.Column<int>(type: "int", nullable: false),
                    EspeId = table.Column<int>(type: "int", nullable: false),
                    CateId = table.Column<int>(type: "int", nullable: false),
                    CoesCompleto = table.Column<bool>(type: "bit", nullable: false),
                    CoesFechaCompleto = table.Column<DateTime>(type: "datetime", nullable: false),
                    CoesFirma = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    AudiUserCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiFechCrea = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    AudiHostCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiUserMod = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    AudiFechMod = table.Column<DateTime>(type: "datetime", nullable: true),
                    AudiHostMod = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConquistadorEspecialidades", x => new { x.ConqId, x.EspeId });
                    table.ForeignKey(
                        name: "FK_ConquistadorEspecialidades_Conquistadores_ConqId",
                        column: x => x.ConqId,
                        principalTable: "Conquistadores",
                        principalColumn: "PersId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConquistadorEspecialidades_Especialidades_CateId_EspeId",
                        columns: x => new { x.CateId, x.EspeId },
                        principalTable: "Especialidades",
                        principalColumns: new[] { "CateId", "EspeId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConquistadorItemsCuadernillo",
                columns: table => new
                {
                    ConqId = table.Column<int>(type: "int", nullable: false),
                    ClasId = table.Column<int>(type: "int", nullable: false),
                    ItcuId = table.Column<int>(type: "int", nullable: false),
                    CoicCompleto = table.Column<bool>(type: "bit", nullable: false),
                    CoicFechaCompleto = table.Column<DateTime>(type: "datetime", nullable: false),
                    CoicFirma = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    AudiUserCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiFechCrea = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    AudiHostCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiUserMod = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    AudiFechMod = table.Column<DateTime>(type: "datetime", nullable: true),
                    AudiHostMod = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConquistadorItemsCuadernillo", x => new { x.ConqId, x.ClasId, x.ItcuId });
                    table.ForeignKey(
                        name: "FK_ConquistadorItemsCuadernillo_Conquistadores_ConqId",
                        column: x => x.ConqId,
                        principalTable: "Conquistadores",
                        principalColumn: "PersId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConquistadorItemsCuadernillo_ItemsCuadernillo_ClasId_ItcuId",
                        columns: x => new { x.ClasId, x.ItcuId },
                        principalTable: "ItemsCuadernillo",
                        principalColumns: new[] { "ClasId", "ItcuId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CuentaCorriente",
                columns: table => new
                {
                    ConqId = table.Column<int>(type: "int", nullable: false),
                    CucoId = table.Column<int>(type: "int", nullable: false),
                    CucoFecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    CucoMontoDepositado = table.Column<decimal>(type: "decimal(9,3)", nullable: false),
                    CucoMontoRetirado = table.Column<decimal>(type: "decimal(9,3)", nullable: false),
                    AudiUserCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiFechCrea = table.Column<DateTime>(type: "datetime", nullable: false),
                    AudiHostCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiUserMod = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    AudiFechMod = table.Column<DateTime>(type: "datetime", nullable: true),
                    AudiHostMod = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuentaCorriente", x => new { x.ConqId, x.CucoId });
                    table.ForeignKey(
                        name: "FK_CuentaCorriente_Conquistadores_ConqId",
                        column: x => x.ConqId,
                        principalTable: "Conquistadores",
                        principalColumn: "PersId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FichasMedicas",
                columns: table => new
                {
                    ConqId = table.Column<int>(type: "int", nullable: false),
                    FimeId = table.Column<int>(type: "int", nullable: false),
                    FimeAnio = table.Column<int>(type: "int", nullable: false),
                    FimeSangreRH = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    FimeVacunas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FimeEnfermedades = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FimeAlergias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AudiUserCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiFechCrea = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    AudiHostCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiUserMod = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    AudiFechMod = table.Column<DateTime>(type: "datetime", nullable: true),
                    AudiHostMod = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FichasMedicas", x => new { x.ConqId, x.FimeId, x.FimeAnio });
                    table.ForeignKey(
                        name: "FK_FichasMedicas_Conquistadores_ConqId",
                        column: x => x.ConqId,
                        principalTable: "Conquistadores",
                        principalColumn: "PersId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inscripciones",
                columns: table => new
                {
                    ConqId = table.Column<int>(type: "int", nullable: false),
                    InscAnio = table.Column<int>(type: "int", nullable: false),
                    InscFecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    InscMonto = table.Column<decimal>(type: "decimal(9,3)", nullable: false),
                    InscCompleto = table.Column<bool>(type: "bit", nullable: false),
                    AudiUserCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiFechCrea = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    AudiHostCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiUserMod = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    AudiFechMod = table.Column<DateTime>(type: "datetime", nullable: true),
                    AudiHostMod = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscripciones", x => new { x.ConqId, x.InscAnio });
                    table.ForeignKey(
                        name: "FK_Inscripciones_Conquistadores_ConqId",
                        column: x => x.ConqId,
                        principalTable: "Conquistadores",
                        principalColumn: "PersId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UnidadConquistadores",
                columns: table => new
                {
                    UnidId = table.Column<int>(type: "int", nullable: false),
                    ConqId = table.Column<int>(type: "int", nullable: false),
                    UncoAno = table.Column<int>(type: "int", nullable: false),
                    UncoCargoTabla = table.Column<string>(type: "nchar(3)", nullable: false),
                    UncoCargoId = table.Column<int>(type: "int", nullable: false),
                    AudiUserCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiFechCrea = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    AudiHostCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiUserMod = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    AudiFechMod = table.Column<DateTime>(type: "datetime", nullable: true),
                    AudiHostMod = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadConquistadores", x => new { x.UnidId, x.ConqId, x.UncoAno });
                    table.ForeignKey(
                        name: "FK_UnidadConquistadores_Conquistadores_ConqId",
                        column: x => x.ConqId,
                        principalTable: "Conquistadores",
                        principalColumn: "PersId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnidadConquistadores_Unidades_UnidId",
                        column: x => x.UnidId,
                        principalTable: "Unidades",
                        principalColumn: "UnidId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TutorConquistadores",
                columns: table => new
                {
                    TutoId = table.Column<int>(type: "int", nullable: false),
                    ConqId = table.Column<int>(type: "int", nullable: false),
                    TucoTipoParentescoTabla = table.Column<string>(type: "nchar(3)", nullable: false),
                    TucoTipoParentescoId = table.Column<int>(type: "int", nullable: false),
                    AudiUserCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiFechCrea = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    AudiHostCrea = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AudiUserMod = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    AudiFechMod = table.Column<DateTime>(type: "datetime", nullable: true),
                    AudiHostMod = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TutorConquistadores", x => new { x.TutoId, x.ConqId });
                    table.ForeignKey(
                        name: "FK_TutorConquistadores_Conquistadores_ConqId",
                        column: x => x.ConqId,
                        principalTable: "Conquistadores",
                        principalColumn: "PersId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TutorConquistadores_Tipos_TucoTipoParentescoTabla_TucoTipoParentescoId",
                        columns: x => new { x.TucoTipoParentescoTabla, x.TucoTipoParentescoId },
                        principalTable: "Tipos",
                        principalColumns: new[] { "TipoTabla", "TipoId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TutorConquistadores_Tutores_TutoId",
                        column: x => x.TutoId,
                        principalTable: "Tutores",
                        principalColumn: "PersId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActividadConquistadores_AccoTipoParticipacionTabla_AccoTipoParticipacionId",
                table: "ActividadConquistadores",
                columns: new[] { "AccoTipoParticipacionTabla", "AccoTipoParticipacionId" });

            migrationBuilder.CreateIndex(
                name: "IX_ActividadConquistadores_ConqId",
                table: "ActividadConquistadores",
                column: "ConqId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaseConquistadores_ClasId",
                table: "ClaseConquistadores",
                column: "ClasId");

            migrationBuilder.CreateIndex(
                name: "IX_Conquistadores_UsuaId",
                table: "Conquistadores",
                column: "UsuaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConquistadorEspecialidades_CateId_EspeId",
                table: "ConquistadorEspecialidades",
                columns: new[] { "CateId", "EspeId" });

            migrationBuilder.CreateIndex(
                name: "IX_ConquistadorItemsCuadernillo_ClasId_ItcuId",
                table: "ConquistadorItemsCuadernillo",
                columns: new[] { "ClasId", "ItcuId" });

            migrationBuilder.CreateIndex(
                name: "IX_TutorConquistadores_ConqId",
                table: "TutorConquistadores",
                column: "ConqId");

            migrationBuilder.CreateIndex(
                name: "IX_TutorConquistadores_TucoTipoParentescoTabla_TucoTipoParentescoId",
                table: "TutorConquistadores",
                columns: new[] { "TucoTipoParentescoTabla", "TucoTipoParentescoId" });

            migrationBuilder.CreateIndex(
                name: "IX_Tutores_UsuaId",
                table: "Tutores",
                column: "UsuaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UnidadConquistadores_ConqId",
                table: "UnidadConquistadores",
                column: "ConqId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRoles_RoleId",
                table: "UsuarioRoles",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActividadConquistadores");

            migrationBuilder.DropTable(
                name: "Asistencias");

            migrationBuilder.DropTable(
                name: "ClaseConquistadores");

            migrationBuilder.DropTable(
                name: "ConquistadorEspecialidades");

            migrationBuilder.DropTable(
                name: "ConquistadorItemsCuadernillo");

            migrationBuilder.DropTable(
                name: "Cronogramas");

            migrationBuilder.DropTable(
                name: "CuentaCorriente");

            migrationBuilder.DropTable(
                name: "FichasMedicas");

            migrationBuilder.DropTable(
                name: "Inscripciones");

            migrationBuilder.DropTable(
                name: "Parametros");

            migrationBuilder.DropTable(
                name: "Sesiones");

            migrationBuilder.DropTable(
                name: "TutorConquistadores");

            migrationBuilder.DropTable(
                name: "UnidadConquistadores");

            migrationBuilder.DropTable(
                name: "UsuarioRoles");

            migrationBuilder.DropTable(
                name: "Actividades");

            migrationBuilder.DropTable(
                name: "Especialidades");

            migrationBuilder.DropTable(
                name: "ItemsCuadernillo");

            migrationBuilder.DropTable(
                name: "Tipos");

            migrationBuilder.DropTable(
                name: "Tutores");

            migrationBuilder.DropTable(
                name: "Conquistadores");

            migrationBuilder.DropTable(
                name: "Unidades");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Clases");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
