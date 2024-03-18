using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace clinic.Migrations
{
    /// <inheritdoc />
    public partial class AtualizacaoModelo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PacienteID",
                table: "Pacientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "fk_PacienteID",
                table: "Consultas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_fk_PacienteID",
                table: "Consultas",
                column: "fk_PacienteID");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Pacientes_fk_PacienteID",
                table: "Consultas",
                column: "fk_PacienteID",
                principalTable: "Pacientes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Pacientes_fk_PacienteID",
                table: "Consultas");

            migrationBuilder.DropIndex(
                name: "IX_Consultas_fk_PacienteID",
                table: "Consultas");

            migrationBuilder.DropColumn(
                name: "PacienteID",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "fk_PacienteID",
                table: "Consultas");
        }
    }
}
