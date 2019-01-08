using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiSSESI.Migrations
{
    public partial class Padres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alumno_Clases_ClaseId",
                table: "Alumno");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Alumno",
                table: "Alumno");

            migrationBuilder.RenameTable(
                name: "Alumno",
                newName: "Alumnos");

            migrationBuilder.RenameIndex(
                name: "IX_Alumno_ClaseId",
                table: "Alumnos",
                newName: "IX_Alumnos_ClaseId");

            migrationBuilder.AlterColumn<string>(
                name: "Telefono",
                table: "Alumnos",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<long>(
                name: "Cedula",
                table: "Alumnos",
                maxLength: 9,
                nullable: false,
                oldClrType: typeof(long),
                oldMaxLength: 9);

            migrationBuilder.AddColumn<bool>(
                name: "EstaBorrado",
                table: "Alumnos",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Alumnos",
                table: "Alumnos",
                column: "Cedula");

            migrationBuilder.CreateTable(
                name: "Padres",
                columns: table => new
                {
                    Cedula = table.Column<long>(maxLength: 9, nullable: false),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    Apellido = table.Column<string>(maxLength: 100, nullable: false),
                    Username = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 100, nullable: false),
                    Edad = table.Column<int>(nullable: false),
                    Direccion = table.Column<string>(maxLength: 100, nullable: false),
                    Telefono = table.Column<string>(maxLength: 20, nullable: true),
                    Trabajo = table.Column<string>(maxLength: 100, nullable: true),
                    Monitoreo = table.Column<bool>(nullable: false),
                    EstaBorrado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Padres", x => x.Cedula);
                });

            migrationBuilder.CreateTable(
                name: "PadreTieneHijos",
                columns: table => new
                {
                    PadreCedula = table.Column<long>(nullable: false),
                    AlumnoCedula = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PadreTieneHijos", x => new { x.AlumnoCedula, x.PadreCedula });
                    table.ForeignKey(
                        name: "FK_PadreTieneHijos_Alumnos_AlumnoCedula",
                        column: x => x.AlumnoCedula,
                        principalTable: "Alumnos",
                        principalColumn: "Cedula");
                    table.ForeignKey(
                        name: "FK_PadreTieneHijos_Padres_PadreCedula",
                        column: x => x.PadreCedula,
                        principalTable: "Padres",
                        principalColumn: "Cedula");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Padres_Username",
                table: "Padres",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PadreTieneHijos_PadreCedula",
                table: "PadreTieneHijos",
                column: "PadreCedula");

            migrationBuilder.AddForeignKey(
                name: "FK_Alumnos_Clases_ClaseId",
                table: "Alumnos",
                column: "ClaseId",
                principalTable: "Clases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alumnos_Clases_ClaseId",
                table: "Alumnos");

            migrationBuilder.DropTable(
                name: "PadreTieneHijos");

            migrationBuilder.DropTable(
                name: "Padres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Alumnos",
                table: "Alumnos");

            migrationBuilder.DropColumn(
                name: "EstaBorrado",
                table: "Alumnos");

            migrationBuilder.RenameTable(
                name: "Alumnos",
                newName: "Alumno");

            migrationBuilder.RenameIndex(
                name: "IX_Alumnos_ClaseId",
                table: "Alumno",
                newName: "IX_Alumno_ClaseId");

            migrationBuilder.AlterColumn<string>(
                name: "Telefono",
                table: "Alumno",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Cedula",
                table: "Alumno",
                maxLength: 9,
                nullable: false,
                oldClrType: typeof(long),
                oldMaxLength: 9)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Alumno",
                table: "Alumno",
                column: "Cedula");

            migrationBuilder.AddForeignKey(
                name: "FK_Alumno_Clases_ClaseId",
                table: "Alumno",
                column: "ClaseId",
                principalTable: "Clases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
