using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zorgi.Data.Migrations
{
    /// <inheritdoc />
    public partial class AssistidoDocumento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Documento",
                table: "Cuidadores",
                type: "char(11)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Documento",
                table: "Assistidos",
                type: "char(11)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Documento",
                table: "Assistidos");

            migrationBuilder.AlterColumn<string>(
                name: "Documento",
                table: "Cuidadores",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(11)");
        }
    }
}
