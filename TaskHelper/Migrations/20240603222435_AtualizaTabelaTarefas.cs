using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskHelper.Migrations
{
    /// <inheritdoc />
    public partial class AtualizaTabelaTarefas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Tarefas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "Tarefas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
