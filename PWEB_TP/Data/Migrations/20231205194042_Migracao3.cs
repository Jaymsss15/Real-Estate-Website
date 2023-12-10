using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PWEB_TP.Data.Migrations
{
    public partial class Migracao3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataFimContrato",
                table: "Habitacoes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataInicioContrato",
                table: "Habitacoes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataFimContrato",
                table: "Habitacoes");

            migrationBuilder.DropColumn(
                name: "DataInicioContrato",
                table: "Habitacoes");
        }
    }
}
