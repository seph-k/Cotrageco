using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cotrageco.Migrations
{
    /// <inheritdoc />
    public partial class MyCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Realisation_Captions",
                table: "Our_Realisations");

            migrationBuilder.DropColumn(
                name: "Realisation_Description",
                table: "Our_Realisations");

            migrationBuilder.DropColumn(
                name: "Realisation_Title",
                table: "Our_Realisations");

            migrationBuilder.AddColumn<int>(
                name: "Realisation_Caption",
                table: "Our_Realisations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Realisation_CaptionsRealisation_CaptionId",
                table: "Our_Realisations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Realisation_Caption",
                columns: table => new
                {
                    Realisation_CaptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Caption = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Realisation_Caption", x => x.Realisation_CaptionId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Our_Realisations_Realisation_CaptionsRealisation_CaptionId",
                table: "Our_Realisations",
                column: "Realisation_CaptionsRealisation_CaptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Our_Realisations_Realisation_Caption_Realisation_CaptionsRealisation_CaptionId",
                table: "Our_Realisations",
                column: "Realisation_CaptionsRealisation_CaptionId",
                principalTable: "Realisation_Caption",
                principalColumn: "Realisation_CaptionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Our_Realisations_Realisation_Caption_Realisation_CaptionsRealisation_CaptionId",
                table: "Our_Realisations");

            migrationBuilder.DropTable(
                name: "Realisation_Caption");

            migrationBuilder.DropIndex(
                name: "IX_Our_Realisations_Realisation_CaptionsRealisation_CaptionId",
                table: "Our_Realisations");

            migrationBuilder.DropColumn(
                name: "Realisation_Caption",
                table: "Our_Realisations");

            migrationBuilder.DropColumn(
                name: "Realisation_CaptionsRealisation_CaptionId",
                table: "Our_Realisations");

            migrationBuilder.AddColumn<string>(
                name: "Realisation_Captions",
                table: "Our_Realisations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Realisation_Description",
                table: "Our_Realisations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Realisation_Title",
                table: "Our_Realisations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
