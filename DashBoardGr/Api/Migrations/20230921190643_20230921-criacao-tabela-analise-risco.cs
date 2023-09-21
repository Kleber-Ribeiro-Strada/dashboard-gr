using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class _20230921criacaotabelaanaliserisco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnaliseRisco",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataSolicitacaoAnalise = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAvaliacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Observacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotoristaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CnhId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnaliseRisco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnaliseRisco_Cnh_CnhId",
                        column: x => x.CnhId,
                        principalTable: "Cnh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnaliseRisco_Motorista_MotoristaId",
                        column: x => x.MotoristaId,
                        principalTable: "Motorista",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnaliseRiscoVeiculo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnaliseRiscoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VeiculoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnaliseRiscoVeiculo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnaliseRiscoVeiculo_AnaliseRisco_AnaliseRiscoId",
                        column: x => x.AnaliseRiscoId,
                        principalTable: "AnaliseRisco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnaliseRiscoVeiculo_Veiculo_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnaliseRisco_CnhId",
                table: "AnaliseRisco",
                column: "CnhId");

            migrationBuilder.CreateIndex(
                name: "IX_AnaliseRisco_MotoristaId",
                table: "AnaliseRisco",
                column: "MotoristaId");

            migrationBuilder.CreateIndex(
                name: "IX_AnaliseRiscoVeiculo_AnaliseRiscoId",
                table: "AnaliseRiscoVeiculo",
                column: "AnaliseRiscoId");

            migrationBuilder.CreateIndex(
                name: "IX_AnaliseRiscoVeiculo_VeiculoId",
                table: "AnaliseRiscoVeiculo",
                column: "VeiculoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnaliseRiscoVeiculo");

            migrationBuilder.DropTable(
                name: "AnaliseRisco");
        }
    }
}
