using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agendamento.Migrations
{
    /// <inheritdoc />
    public partial class CreatePacienteCPFinConsulta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "PacienteDB");

            migrationBuilder.AddColumn<int>(
                name: "EmailId",
                table: "PacienteDB",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CPF1",
                table: "ConsultaDB",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Roles = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PacienteDB_EmailId",
                table: "PacienteDB",
                column: "EmailId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultaDB_CPF1",
                table: "ConsultaDB",
                column: "CPF1");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultaDB_PacienteDB_CPF1",
                table: "ConsultaDB",
                column: "CPF1",
                principalTable: "PacienteDB",
                principalColumn: "CPF");

            migrationBuilder.AddForeignKey(
                name: "FK_PacienteDB_User_EmailId",
                table: "PacienteDB",
                column: "EmailId",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsultaDB_PacienteDB_CPF1",
                table: "ConsultaDB");

            migrationBuilder.DropForeignKey(
                name: "FK_PacienteDB_User_EmailId",
                table: "PacienteDB");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_PacienteDB_EmailId",
                table: "PacienteDB");

            migrationBuilder.DropIndex(
                name: "IX_ConsultaDB_CPF1",
                table: "ConsultaDB");

            migrationBuilder.DropColumn(
                name: "EmailId",
                table: "PacienteDB");

            migrationBuilder.DropColumn(
                name: "CPF1",
                table: "ConsultaDB");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "PacienteDB",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
