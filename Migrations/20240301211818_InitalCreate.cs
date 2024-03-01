using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agendamento.Migrations
{
    /// <inheritdoc />
    public partial class InitalCreate : Migration
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
                    CPF = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    DataConsulta = table.Column<string>(type: "nvarchar(48)", nullable: false),
                    PacienteCPF = table.Column<int>(type: "int", nullable: true),
                    MedicoCRM = table.Column<int>(type: "int", nullable: true),
                    EspecialidadeCRM = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultaDB", x => x.Protocolo);
                    table.ForeignKey(
                        name: "FK_ConsultaDB_MedicoDB_EspecialidadeCRM",
                        column: x => x.EspecialidadeCRM,
                        principalTable: "MedicoDB",
                        principalColumn: "CRM");
                    table.ForeignKey(
                        name: "FK_ConsultaDB_MedicoDB_MedicoCRM",
                        column: x => x.MedicoCRM,
                        principalTable: "MedicoDB",
                        principalColumn: "CRM");
                    table.ForeignKey(
                        name: "FK_ConsultaDB_PacienteDB_PacienteCPF",
                        column: x => x.PacienteCPF,
                        principalTable: "PacienteDB",
                        principalColumn: "CPF");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsultaDB_EspecialidadeCRM",
                table: "ConsultaDB",
                column: "EspecialidadeCRM");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultaDB_MedicoCRM",
                table: "ConsultaDB",
                column: "MedicoCRM");

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
