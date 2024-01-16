using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cotrageco.Migrations
{
    /// <inheritdoc />
    public partial class OtherCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Our_Realisations_Realisation_Caption_Realisation_CaptionsRealisation_CaptionId",
                table: "Our_Realisations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Realisation_Caption",
                table: "Realisation_Caption");

            migrationBuilder.DropColumn(
                name: "Realisation_Caption",
                table: "Our_Realisations");

            migrationBuilder.RenameTable(
                name: "Realisation_Caption",
                newName: "Realisation_Captions");

            migrationBuilder.RenameColumn(
                name: "Realisation_CaptionsRealisation_CaptionId",
                table: "Our_Realisations",
                newName: "Realisation_CaptionId");

            migrationBuilder.RenameIndex(
                name: "IX_Our_Realisations_Realisation_CaptionsRealisation_CaptionId",
                table: "Our_Realisations",
                newName: "IX_Our_Realisations_Realisation_CaptionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Realisation_Captions",
                table: "Realisation_Captions",
                column: "Realisation_CaptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Our_Realisations_Realisation_Captions_Realisation_CaptionId",
                table: "Our_Realisations",
                column: "Realisation_CaptionId",
                principalTable: "Realisation_Captions",
                principalColumn: "Realisation_CaptionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Our_Realisations_Realisation_Captions_Realisation_CaptionId",
                table: "Our_Realisations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Realisation_Captions",
                table: "Realisation_Captions");

            migrationBuilder.RenameTable(
                name: "Realisation_Captions",
                newName: "Realisation_Caption");

            migrationBuilder.RenameColumn(
                name: "Realisation_CaptionId",
                table: "Our_Realisations",
                newName: "Realisation_CaptionsRealisation_CaptionId");

            migrationBuilder.RenameIndex(
                name: "IX_Our_Realisations_Realisation_CaptionId",
                table: "Our_Realisations",
                newName: "IX_Our_Realisations_Realisation_CaptionsRealisation_CaptionId");

            migrationBuilder.AddColumn<int>(
                name: "Realisation_Caption",
                table: "Our_Realisations",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Realisation_Caption",
                table: "Realisation_Caption",
                column: "Realisation_CaptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Our_Realisations_Realisation_Caption_Realisation_CaptionsRealisation_CaptionId",
                table: "Our_Realisations",
                column: "Realisation_CaptionsRealisation_CaptionId",
                principalTable: "Realisation_Caption",
                principalColumn: "Realisation_CaptionId");
        }
    }
}
