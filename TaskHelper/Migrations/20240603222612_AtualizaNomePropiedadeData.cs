using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskHelper.Migrations
{
    /// <inheritdoc />
    public partial class AtualizaNomePropiedadeData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "data",
                table: "Tarefas",
                newName: "Data");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Tarefas",
                newName: "data");
        }
    }
}
