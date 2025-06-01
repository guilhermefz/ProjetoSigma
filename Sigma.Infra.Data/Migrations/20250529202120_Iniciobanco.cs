using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sigma.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Iniciobanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "classificacao",
                table: "projetos",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "classificacao",
                table: "projetos",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }
    }
}
