using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PWEB_TP.Data.Migrations
{
    public partial class Migracao6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropForeignKey(
                name: "FK_Arrendamento_Habitacoes_HabitacaoIdHabitacoes",
                table: "Arrendamento");

            migrationBuilder.DropIndex(
                name: "IX_Arrendamento_ClienteId",
                table: "Arrendamento");

            migrationBuilder.DropIndex(
                name: "IX_Arrendamento_HabitacaoIdHabitacoes",
                table: "Arrendamento");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Arrendamento");

            migrationBuilder.DropColumn(
                name: "HabitacaoIdHabitacoes",
                table: "Arrendamento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropIndex(
                name: "IX_Arrendamento_ClienteId",
                table: "Arrendamento");

            migrationBuilder.DropIndex(
                name: "IX_Arrendamento_HabitacaoIdHabitacoes",
                table: "Arrendamento");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Arrendamento");

            migrationBuilder.DropColumn(
                name: "HabitacaoIdHabitacoes",
                table: "Arrendamento");
        }
    }
}