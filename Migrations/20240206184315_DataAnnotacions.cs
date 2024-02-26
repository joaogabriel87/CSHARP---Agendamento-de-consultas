using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agendamento.Migrations
{
    /// <inheritdoc />
    public partial class DataAnnotacions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Especialidades",
                table: "ConsultasDb");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "ConsultasDb");

            migrationBuilder.AddColumn<int>(
                name: "especialidade",
                table: "ConsultasDb",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "especialidade",
                table: "ConsultasDb");

            migrationBuilder.AddColumn<string>(
                name: "Especialidades",
                table: "ConsultasDb",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "ConsultasDb",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
