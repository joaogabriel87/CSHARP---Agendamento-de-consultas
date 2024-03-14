using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agendamento.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicoDB",
                columns: table => new
                {
                    CRM = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCompleto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Especialidade = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicoDB", x => x.CRM);
                });

            migrationBuilder.CreateTable(
                name: "PacienteDB",
                columns: table => new
                {
                    CPF = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NomeCompleto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacienteDB", x => x.CPF);
                });

            migrationBuilder.CreateTable(
                name: "ConsultaDB",
                columns: table => new
                {
                    Protocolo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataConsulta = table.Column<DateTime>(type: "datetime", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    PacienteCPF = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MedicoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultaDB", x => x.Protocolo);
                    table.ForeignKey(
                        name: "FK_ConsultaDB_MedicoDB_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "MedicoDB",
                        principalColumn: "CRM",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsultaDB_PacienteDB_PacienteCPF",
                        column: x => x.PacienteCPF,
                        principalTable: "PacienteDB",
                        principalColumn: "CPF",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsultaDB_MedicoId",
                table: "ConsultaDB",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultaDB_PacienteCPF",
                table: "ConsultaDB",
                column: "PacienteCPF");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsultaDB");

            migrationBuilder.DropTable(
                name: "MedicoDB");

            migrationBuilder.DropTable(
                name: "PacienteDB");
        }
    }
}
