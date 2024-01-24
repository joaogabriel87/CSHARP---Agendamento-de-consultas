using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agendamento.Migrations
{
    /// <inheritdoc />
    public partial class TesteTwo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsultasDb_MedicoDb_MedicoId",
                table: "ConsultasDb");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsultasDb_PacienteDb_PacienteId",
                table: "ConsultasDb");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultasDb_MedicoDb_MedicoId",
                table: "ConsultasDb",
                column: "MedicoId",
                principalTable: "MedicoDb",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultasDb_PacienteDb_PacienteId",
                table: "ConsultasDb",
                column: "PacienteId",
                principalTable: "PacienteDb",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsultasDb_MedicoDb_MedicoId",
                table: "ConsultasDb");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsultasDb_PacienteDb_PacienteId",
                table: "ConsultasDb");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultasDb_MedicoDb_MedicoId",
                table: "ConsultasDb",
                column: "MedicoId",
                principalTable: "MedicoDb",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultasDb_PacienteDb_PacienteId",
                table: "ConsultasDb",
                column: "PacienteId",
                principalTable: "PacienteDb",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
