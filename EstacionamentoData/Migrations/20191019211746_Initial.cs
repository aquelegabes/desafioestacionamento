using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EstacionamentoData.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Registros",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ativo = table.Column<bool>(nullable: false, defaultValue: true),
                    Placa = table.Column<string>(nullable: false),
                    Chegada = table.Column<DateTime>(nullable: false),
                    Saida = table.Column<DateTime>(nullable: true),
                    Duracao = table.Column<TimeSpan>(nullable: true),
                    TempoCobrado = table.Column<int>(nullable: true),
                    Preco = table.Column<decimal>(nullable: true),
                    ValorTotal = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vigencias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ativo = table.Column<bool>(nullable: false, defaultValue: true),
                    ValorHora = table.Column<decimal>(nullable: false),
                    HoraAdicional = table.Column<decimal>(nullable: false),
                    VigenciaInicio = table.Column<DateTime>(nullable: false),
                    VigenciaFim = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vigencias", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Registros_Id",
                table: "Registros",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vigencias_Id",
                table: "Vigencias",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registros");

            migrationBuilder.DropTable(
                name: "Vigencias");
        }
    }
}
