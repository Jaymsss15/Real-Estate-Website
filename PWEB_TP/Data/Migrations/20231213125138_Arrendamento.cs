using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PWEB_TP.Data.Migrations
{
    public partial class Arrendamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "Arrendamento",
                columns: table => new
                {
                    IdArrendamentos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    HabitacaoIdHabitacoes = table.Column<int>(type: "int", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PeridoMinimoArrendamento = table.Column<int>(type: "int", nullable: false),
                    ValorArrendamento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arrendamento", x => x.IdArrendamentos);
                    table.ForeignKey(
                        name: "FK_Arrendamento_AspNetUsers_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Arrendamento_Habitacoes_HabitacaoIdHabitacoes",
                        column: x => x.HabitacaoIdHabitacoes,
                        principalTable: "Habitacoes",
                        principalColumn: "IdHabitacoes",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Arrendamento_ClienteId",
                table: "Arrendamento",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Arrendamento_HabitacaoIdHabitacoes",
                table: "Arrendamento",
                column: "HabitacaoIdHabitacoes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Arrendamento");

            migrationBuilder.CreateTable(
                name: "Arrendamentos",
                columns: table => new
                {
                    IdArrendamentos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    HabitacaoIdHabitacoes = table.Column<int>(type: "int", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PeridoMinimoArrendamento = table.Column<int>(type: "int", nullable: false),
                    ValorArrendamento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arrendamentos", x => x.IdArrendamentos);
                    table.ForeignKey(
                        name: "FK_Arrendamentos_AspNetUsers_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Arrendamentos_Habitacoes_HabitacaoIdHabitacoes",
                        column: x => x.HabitacaoIdHabitacoes,
                        principalTable: "Habitacoes",
                        principalColumn: "IdHabitacoes",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Arrendamentos_ClienteId",
                table: "Arrendamentos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Arrendamentos_HabitacaoIdHabitacoes",
                table: "Arrendamentos",
                column: "HabitacaoIdHabitacoes");
        }
    }
}
