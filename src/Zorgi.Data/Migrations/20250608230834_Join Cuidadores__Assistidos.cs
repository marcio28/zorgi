using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zorgi.Data.Migrations
{
    /// <inheritdoc />
    public partial class JoinCuidadores__Assistidos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assistidos_Cuidadores_CuidadorId",
                table: "Assistidos");

            migrationBuilder.DropIndex(
                name: "IX_Assistidos_CuidadorId",
                table: "Assistidos");

            migrationBuilder.DropColumn(
                name: "CuidadorId",
                table: "Assistidos");

            migrationBuilder.CreateTable(
                name: "Cuidadores__Assistidos",
                columns: table => new
                {
                    CuidadorId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AssistidoId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuidadores__Assistidos", x => new { x.CuidadorId, x.AssistidoId });
                    table.ForeignKey(
                        name: "FK_Cuidadores__Assistidos_Assistidos_AssistidoId",
                        column: x => x.AssistidoId,
                        principalTable: "Assistidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cuidadores__Assistidos_Cuidadores_CuidadorId",
                        column: x => x.CuidadorId,
                        principalTable: "Cuidadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cuidadores__Assistidos_AssistidoId",
                table: "Cuidadores__Assistidos",
                column: "AssistidoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cuidadores__Assistidos");

            migrationBuilder.AddColumn<Guid>(
                name: "CuidadorId",
                table: "Assistidos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assistidos_CuidadorId",
                table: "Assistidos",
                column: "CuidadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assistidos_Cuidadores_CuidadorId",
                table: "Assistidos",
                column: "CuidadorId",
                principalTable: "Cuidadores",
                principalColumn: "Id");
        }
    }
}
