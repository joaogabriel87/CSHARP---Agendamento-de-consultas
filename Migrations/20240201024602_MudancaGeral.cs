using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agendamento.Migrations
{
    /// <inheritdoc />
    public partial class MudancaGeral : Migration
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

            migrationBuilder.DropTable(
                name: "EspecialidadeDb");

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
                name: "EspecialidadeId",
                table: "ConsultasDb");

            migrationBuilder.DropColumn(
                name: "MedicoId",
                table: "ConsultasDb");

            migrationBuilder.DropColumn(
                name: "PacienteId",
                table: "ConsultasDb");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "UserDb",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "UserDb",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "UserDb",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Especialidades",
                table: "ConsultasDb",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_UserDb_Email",
                table: "UserDb",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserDb_Email",
                table: "UserDb");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "UserDb");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "UserDb");

            migrationBuilder.DropColumn(
                name: "Especialidades",
                table: "ConsultasDb");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "UserDb",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "EspecialidadeId",
                table: "ConsultasDb",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                name: "EspecialidadeDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Especialidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EspecialidadeDb", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicoDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Especialidade = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultasDb_PacienteDb_PacienteId",
                table: "ConsultasDb",
                column: "PacienteId",
                principalTable: "PacienteDb",
                principalColumn: "Id");
        }
    }
}
