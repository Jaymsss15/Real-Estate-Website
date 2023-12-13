using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PWEB_TP.Data.Migrations
{
    public partial class Locadores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocadoresIdLocadores",
                table: "Habitacoes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Locadores",
                columns: table => new
                {
                    IdLocadores = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeLocador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoSubscricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locadores", x => x.IdLocadores);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Habitacoes_LocadoresIdLocadores",
                table: "Habitacoes",
                column: "LocadoresIdLocadores");

            migrationBuilder.AddForeignKey(
                name: "FK_Habitacoes_Locadores_LocadoresIdLocadores",
                table: "Habitacoes",
                column: "LocadoresIdLocadores",
                principalTable: "Locadores",
                principalColumn: "IdLocadores");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habitacoes_Locadores_LocadoresIdLocadores",
                table: "Habitacoes");

            migrationBuilder.DropTable(
                name: "Locadores");

            migrationBuilder.DropIndex(
                name: "IX_Habitacoes_LocadoresIdLocadores",
                table: "Habitacoes");

            migrationBuilder.DropColumn(
                name: "LocadoresIdLocadores",
                table: "Habitacoes");
        }
    }
}
