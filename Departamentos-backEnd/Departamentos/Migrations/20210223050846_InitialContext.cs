using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Departamentos.Migrations
{
    public partial class InitialContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Asuntos",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true),
                    asunto = table.Column<string>(type: "text", nullable: true),
                    Descripcion = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asuntos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Catedras",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catedras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Docentes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Legajo = table.Column<long>(type: "bigint", nullable: false),
                    Nombre = table.Column<string>(type: "text", nullable: true),
                    Apellido = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Cuil = table.Column<string>(type: "text", nullable: true),
                    EsDirectivo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docentes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Entidades",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadoCargos",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoCargos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadoTramites",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoTramites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoCargos",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Tipo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCargos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoDocumentos",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Tipo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDocumentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoTramites",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Tipo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoTramites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Asignaturas",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true),
                    IdCatedra = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asignaturas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Asignaturas_Catedras_IdCatedra",
                        column: x => x.IdCatedra,
                        principalTable: "Catedras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EtapaTramites",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdAsunto = table.Column<short>(type: "smallint", nullable: false),
                    IdTipoTramite = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EtapaTramites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EtapaTramites_Asuntos_IdAsunto",
                        column: x => x.IdAsunto,
                        principalTable: "Asuntos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EtapaTramites_TipoTramites_IdTipoTramite",
                        column: x => x.IdTipoTramite,
                        principalTable: "TipoTramites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true),
                    IdAsignatura = table.Column<short>(type: "smallint", nullable: false),
                    IdTipoCargo = table.Column<short>(type: "smallint", nullable: false),
                    IdEstadoCargo = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cargos_Asignaturas_IdAsignatura",
                        column: x => x.IdAsignatura,
                        principalTable: "Asignaturas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cargos_EstadoCargos_IdEstadoCargo",
                        column: x => x.IdEstadoCargo,
                        principalTable: "EstadoCargos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cargos_TipoCargos_IdTipoCargo",
                        column: x => x.IdTipoCargo,
                        principalTable: "TipoCargos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocenteTomaCargos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ingreso = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Vencimiento = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IdCargo = table.Column<int>(type: "integer", nullable: false),
                    IdDocente = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocenteTomaCargos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocenteTomaCargos_Cargos_IdCargo",
                        column: x => x.IdCargo,
                        principalTable: "Cargos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocenteTomaCargos_Docentes_IdDocente",
                        column: x => x.IdDocente,
                        principalTable: "Docentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Numero = table.Column<long>(type: "bigint", nullable: false),
                    Año = table.Column<int>(type: "integer", nullable: false),
                    DocNumeroOriginal = table.Column<string>(type: "text", nullable: true),
                    FechaIngreso = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    FechaSalida = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IdTipoDocumento = table.Column<short>(type: "smallint", nullable: false),
                    IdEntidadOrigen = table.Column<short>(type: "smallint", nullable: false),
                    IdEntidadDestino = table.Column<short>(type: "smallint", nullable: false),
                    IdCargo = table.Column<int>(type: "integer", nullable: false),
                    IdEstadoTramite = table.Column<short>(type: "smallint", nullable: false),
                    IdEtapaTramite = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notas_Cargos_IdCargo",
                        column: x => x.IdCargo,
                        principalTable: "Cargos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notas_Entidades_IdEntidadDestino",
                        column: x => x.IdEntidadDestino,
                        principalTable: "Entidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notas_Entidades_IdEntidadOrigen",
                        column: x => x.IdEntidadOrigen,
                        principalTable: "Entidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notas_EstadoTramites_IdEstadoTramite",
                        column: x => x.IdEstadoTramite,
                        principalTable: "EstadoTramites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notas_EtapaTramites_IdEtapaTramite",
                        column: x => x.IdEtapaTramite,
                        principalTable: "EtapaTramites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notas_TipoDocumentos_IdTipoDocumento",
                        column: x => x.IdTipoDocumento,
                        principalTable: "TipoDocumentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pases",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Fecha = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Observaciones = table.Column<string>(type: "text", nullable: true),
                    IdDocumento = table.Column<long>(type: "bigint", nullable: false),
                    IdDocente = table.Column<int>(type: "integer", nullable: false),
                    IdEstadoTramite = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pases_Docentes_IdDocente",
                        column: x => x.IdDocente,
                        principalTable: "Docentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pases_EstadoTramites_IdEstadoTramite",
                        column: x => x.IdEstadoTramite,
                        principalTable: "EstadoTramites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pases_Notas_IdDocumento",
                        column: x => x.IdDocumento,
                        principalTable: "Notas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReferenciaDocentes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdDocumento = table.Column<long>(type: "bigint", nullable: false),
                    IdDocenteReferenciado = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferenciaDocentes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReferenciaDocentes_Docentes_IdDocenteReferenciado",
                        column: x => x.IdDocenteReferenciado,
                        principalTable: "Docentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReferenciaDocentes_Notas_IdDocumento",
                        column: x => x.IdDocumento,
                        principalTable: "Notas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReferenciaDocumentos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdDocumento = table.Column<long>(type: "bigint", nullable: false),
                    IdDocumentoReferenciado = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferenciaDocumentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReferenciaDocumentos_Notas_IdDocumento",
                        column: x => x.IdDocumento,
                        principalTable: "Notas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReferenciaDocumentos_Notas_IdDocumentoReferenciado",
                        column: x => x.IdDocumentoReferenciado,
                        principalTable: "Notas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReferenciaEntidades",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdDocumento = table.Column<long>(type: "bigint", nullable: false),
                    IdEntidadReferenciada = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferenciaEntidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReferenciaEntidades_Entidades_IdEntidadReferenciada",
                        column: x => x.IdEntidadReferenciada,
                        principalTable: "Entidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReferenciaEntidades_Notas_IdDocumento",
                        column: x => x.IdDocumento,
                        principalTable: "Notas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentoMovimientos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Fecha = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Observaciones = table.Column<string>(type: "text", nullable: true),
                    IdDocumento = table.Column<long>(type: "bigint", nullable: false),
                    IdEntidadOrigen = table.Column<short>(type: "smallint", nullable: false),
                    IdEntidadDestino = table.Column<short>(type: "smallint", nullable: false),
                    IdPase = table.Column<long>(type: "bigint", nullable: false),
                    IdDocente = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentoMovimientos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentoMovimientos_Docentes_IdDocente",
                        column: x => x.IdDocente,
                        principalTable: "Docentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentoMovimientos_Entidades_IdEntidadDestino",
                        column: x => x.IdEntidadDestino,
                        principalTable: "Entidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentoMovimientos_Entidades_IdEntidadOrigen",
                        column: x => x.IdEntidadOrigen,
                        principalTable: "Entidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentoMovimientos_Notas_IdDocumento",
                        column: x => x.IdDocumento,
                        principalTable: "Notas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentoMovimientos_Pases_IdPase",
                        column: x => x.IdPase,
                        principalTable: "Pases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asignaturas_IdCatedra",
                table: "Asignaturas",
                column: "IdCatedra");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cargos_IdAsignatura",
                table: "Cargos",
                column: "IdAsignatura");

            migrationBuilder.CreateIndex(
                name: "IX_Cargos_IdEstadoCargo",
                table: "Cargos",
                column: "IdEstadoCargo");

            migrationBuilder.CreateIndex(
                name: "IX_Cargos_IdTipoCargo",
                table: "Cargos",
                column: "IdTipoCargo");

            migrationBuilder.CreateIndex(
                name: "IX_DocenteTomaCargos_IdCargo",
                table: "DocenteTomaCargos",
                column: "IdCargo");

            migrationBuilder.CreateIndex(
                name: "IX_DocenteTomaCargos_IdDocente",
                table: "DocenteTomaCargos",
                column: "IdDocente");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentoMovimientos_IdDocente",
                table: "DocumentoMovimientos",
                column: "IdDocente");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentoMovimientos_IdDocumento",
                table: "DocumentoMovimientos",
                column: "IdDocumento");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentoMovimientos_IdEntidadDestino",
                table: "DocumentoMovimientos",
                column: "IdEntidadDestino");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentoMovimientos_IdEntidadOrigen",
                table: "DocumentoMovimientos",
                column: "IdEntidadOrigen");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentoMovimientos_IdPase",
                table: "DocumentoMovimientos",
                column: "IdPase");

            migrationBuilder.CreateIndex(
                name: "IX_EtapaTramites_IdAsunto",
                table: "EtapaTramites",
                column: "IdAsunto");

            migrationBuilder.CreateIndex(
                name: "IX_EtapaTramites_IdTipoTramite",
                table: "EtapaTramites",
                column: "IdTipoTramite");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_IdCargo",
                table: "Notas",
                column: "IdCargo");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_IdEntidadDestino",
                table: "Notas",
                column: "IdEntidadDestino");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_IdEntidadOrigen",
                table: "Notas",
                column: "IdEntidadOrigen");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_IdEstadoTramite",
                table: "Notas",
                column: "IdEstadoTramite");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_IdEtapaTramite",
                table: "Notas",
                column: "IdEtapaTramite");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_IdTipoDocumento",
                table: "Notas",
                column: "IdTipoDocumento");

            migrationBuilder.CreateIndex(
                name: "IX_Pases_IdDocente",
                table: "Pases",
                column: "IdDocente");

            migrationBuilder.CreateIndex(
                name: "IX_Pases_IdDocumento",
                table: "Pases",
                column: "IdDocumento");

            migrationBuilder.CreateIndex(
                name: "IX_Pases_IdEstadoTramite",
                table: "Pases",
                column: "IdEstadoTramite");

            migrationBuilder.CreateIndex(
                name: "IX_ReferenciaDocentes_IdDocenteReferenciado",
                table: "ReferenciaDocentes",
                column: "IdDocenteReferenciado");

            migrationBuilder.CreateIndex(
                name: "IX_ReferenciaDocentes_IdDocumento",
                table: "ReferenciaDocentes",
                column: "IdDocumento");

            migrationBuilder.CreateIndex(
                name: "IX_ReferenciaDocumentos_IdDocumento",
                table: "ReferenciaDocumentos",
                column: "IdDocumento");

            migrationBuilder.CreateIndex(
                name: "IX_ReferenciaDocumentos_IdDocumentoReferenciado",
                table: "ReferenciaDocumentos",
                column: "IdDocumentoReferenciado");

            migrationBuilder.CreateIndex(
                name: "IX_ReferenciaEntidades_IdDocumento",
                table: "ReferenciaEntidades",
                column: "IdDocumento");

            migrationBuilder.CreateIndex(
                name: "IX_ReferenciaEntidades_IdEntidadReferenciada",
                table: "ReferenciaEntidades",
                column: "IdEntidadReferenciada");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DocenteTomaCargos");

            migrationBuilder.DropTable(
                name: "DocumentoMovimientos");

            migrationBuilder.DropTable(
                name: "ReferenciaDocentes");

            migrationBuilder.DropTable(
                name: "ReferenciaDocumentos");

            migrationBuilder.DropTable(
                name: "ReferenciaEntidades");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Pases");

            migrationBuilder.DropTable(
                name: "Docentes");

            migrationBuilder.DropTable(
                name: "Notas");

            migrationBuilder.DropTable(
                name: "Cargos");

            migrationBuilder.DropTable(
                name: "Entidades");

            migrationBuilder.DropTable(
                name: "EstadoTramites");

            migrationBuilder.DropTable(
                name: "EtapaTramites");

            migrationBuilder.DropTable(
                name: "TipoDocumentos");

            migrationBuilder.DropTable(
                name: "Asignaturas");

            migrationBuilder.DropTable(
                name: "EstadoCargos");

            migrationBuilder.DropTable(
                name: "TipoCargos");

            migrationBuilder.DropTable(
                name: "Asuntos");

            migrationBuilder.DropTable(
                name: "TipoTramites");

            migrationBuilder.DropTable(
                name: "Catedras");
        }
    }
}
