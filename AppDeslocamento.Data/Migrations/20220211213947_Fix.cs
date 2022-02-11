using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppDeslocamento.Data.Migrations
{
    public partial class Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cpf = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "condutores",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_condutores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "veiculos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    placa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_veiculos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "deslocamentos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clienteId = table.Column<long>(type: "bigint", nullable: false),
                    condutorId = table.Column<long>(type: "bigint", nullable: false),
                    veiculoId = table.Column<long>(type: "bigint", nullable: false),
                    dataHoraInicio = table.Column<DateTime>(type: "datetime", nullable: false),
                    dataHoraFim = table.Column<DateTime>(type: "datetime", nullable: true),
                    kmInicio = table.Column<long>(type: "bigint", nullable: false),
                    kmFim = table.Column<long>(type: "bigint", nullable: false, defaultValue: 0L),
                    observacao = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_deslocamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cliente_Deslocamentos_clienteId",
                        column: x => x.clienteId,
                        principalTable: "clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Condutor_Deslocamentos_condutorId",
                        column: x => x.condutorId,
                        principalTable: "condutores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Veiculo_Deslocamentos_veiculoId",
                        column: x => x.veiculoId,
                        principalTable: "veiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_deslocamentos_clienteId",
                table: "deslocamentos",
                column: "clienteId");

            migrationBuilder.CreateIndex(
                name: "IX_deslocamentos_condutorId",
                table: "deslocamentos",
                column: "condutorId");

            migrationBuilder.CreateIndex(
                name: "IX_deslocamentos_veiculoId",
                table: "deslocamentos",
                column: "veiculoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "deslocamentos");

            migrationBuilder.DropTable(
                name: "clientes");

            migrationBuilder.DropTable(
                name: "condutores");

            migrationBuilder.DropTable(
                name: "veiculos");
        }
    }
}
