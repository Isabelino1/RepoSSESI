using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiSSESI.Migrations
{
    public partial class Monitoreo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EstaBorrado",
                table: "Materias",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EstaBorrado",
                table: "Clases",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "ClaseDelAlumno",
                columns: table => new
                {
                    ClaseId = table.Column<int>(nullable: false),
                    AlumnoCedula = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaseDelAlumno", x => new { x.ClaseId, x.AlumnoCedula });
                    table.UniqueConstraint("AK_ClaseDelAlumno_AlumnoCedula_ClaseId", x => new { x.AlumnoCedula, x.ClaseId });
                    table.ForeignKey(
                        name: "FK_ClaseDelAlumno_Alumnos_AlumnoCedula",
                        column: x => x.AlumnoCedula,
                        principalTable: "Alumnos",
                        principalColumn: "Cedula");
                    table.ForeignKey(
                        name: "FK_ClaseDelAlumno_Clases_ClaseId",
                        column: x => x.ClaseId,
                        principalTable: "Clases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Monitoreos",
                columns: table => new
                {
                    NumeroContrato = table.Column<string>(nullable: false),
                    FechaInicio = table.Column<DateTime>(nullable: false),
                    FechaFin = table.Column<DateTime>(nullable: false),
                    Longitud = table.Column<double>(nullable: false),
                    Latitud = table.Column<double>(nullable: false),
                    FechaHoraUbicacion = table.Column<DateTime>(nullable: false),
                    AlumnoCedula = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monitoreos", x => x.NumeroContrato);
                    table.ForeignKey(
                        name: "FK_Monitoreos_Alumnos_AlumnoCedula",
                        column: x => x.AlumnoCedula,
                        principalTable: "Alumnos",
                        principalColumn: "Cedula",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PadreObservaMonitoreos",
                columns: table => new
                {
                    PadreCedula = table.Column<long>(nullable: false),
                    MonitoreoNumeroContrato = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PadreObservaMonitoreos", x => new { x.PadreCedula, x.MonitoreoNumeroContrato });
                    table.ForeignKey(
                        name: "FK_PadreObservaMonitoreos_Monitoreos_MonitoreoNumeroContrato",
                        column: x => x.MonitoreoNumeroContrato,
                        principalTable: "Monitoreos",
                        principalColumn: "NumeroContrato",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PadreObservaMonitoreos_Padres_PadreCedula",
                        column: x => x.PadreCedula,
                        principalTable: "Padres",
                        principalColumn: "Cedula",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Monitoreos_AlumnoCedula",
                table: "Monitoreos",
                column: "AlumnoCedula");

            migrationBuilder.CreateIndex(
                name: "IX_PadreObservaMonitoreos_MonitoreoNumeroContrato",
                table: "PadreObservaMonitoreos",
                column: "MonitoreoNumeroContrato");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClaseDelAlumno");

            migrationBuilder.DropTable(
                name: "PadreObservaMonitoreos");

            migrationBuilder.DropTable(
                name: "Monitoreos");

            migrationBuilder.DropColumn(
                name: "EstaBorrado",
                table: "Materias");

            migrationBuilder.DropColumn(
                name: "EstaBorrado",
                table: "Clases");
        }
    }
}
