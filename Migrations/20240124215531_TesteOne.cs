using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agendamento.Migrations
{
    /// <inheritdoc />
    public partial class TesteOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Roles",
                table: "UserDb",
                newName: "Role");

            migrationBuilder.AddColumn<int>(
                name: "MedicoId",
                table: "ConsultasDb",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PacienteId",
                table: "ConsultasDb",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MedicoDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Especialidade = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicoDb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicoDb_UserDb_UserId",
                        column: x => x.UserId,
                        principalTable: "UserDb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PacienteDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacienteDb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PacienteDb_UserDb_UserId",
                        column: x => x.UserId,
                        principalTable: "UserDb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsultasDb_MedicoId",
                table: "ConsultasDb",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultasDb_PacienteId",
                table: "ConsultasDb",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicoDb_UserId",
                table: "MedicoDb",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PacienteDb_UserId",
                table: "PacienteDb",
                column: "UserId",
                unique: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsultasDb_MedicoDb_MedicoId",
                table: "ConsultasDb");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsultasDb_PacienteDb_PacienteId",
                table: "ConsultasDb");

            migrationBuilder.DropTable(
                name: "MedicoDb");

            migrationBuilder.DropTable(
                name: "PacienteDb");

            migrationBuilder.DropIndex(
                name: "IX_ConsultasDb_MedicoId",
                table: "ConsultasDb");

            migrationBuilder.DropIndex(
                name: "IX_ConsultasDb_PacienteId",
                table: "ConsultasDb");

            migrationBuilder.DropColumn(
                name: "MedicoId",
                table: "ConsultasDb");

            migrationBuilder.DropColumn(
                name: "PacienteId",
                table: "ConsultasDb");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "UserDb",
                newName: "Roles");
        }
    }
}
