using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiSSESI.Migrations
{
    public partial class Migracion_Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CentrosEducativos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    Direccion = table.Column<string>(maxLength: 100, nullable: false),
                    Barrio = table.Column<string>(maxLength: 50, nullable: false),
                    EstaBorrado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentrosEducativos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TelefonoCEducativo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Telefono = table.Column<string>(maxLength: 50, nullable: false),
                    CentroId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelefonoCEducativo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TelefonoCEducativo_CentrosEducativos_CentroId",
                        column: x => x.CentroId,
                        principalTable: "CentrosEducativos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TelefonoCEducativo_CentroId",
                table: "TelefonoCEducativo",
                column: "CentroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TelefonoCEducativo");

            migrationBuilder.DropTable(
                name: "CentrosEducativos");
        }
    }
}
