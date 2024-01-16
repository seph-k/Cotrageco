using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cotrageco.Migrations
{
    /// <inheritdoc />
    public partial class Project_Titles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Project_Title",
                table: "Projects");

            migrationBuilder.AddColumn<int>(
                name: "Project_TitleId",
                table: "Projects",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Project_Titles",
                columns: table => new
                {
                    Project_TitleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project_Titles", x => x.Project_TitleId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_Project_TitleId",
                table: "Projects",
                column: "Project_TitleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Project_Titles_Project_TitleId",
                table: "Projects",
                column: "Project_TitleId",
                principalTable: "Project_Titles",
                principalColumn: "Project_TitleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Project_Titles_Project_TitleId",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "Project_Titles");

            migrationBuilder.DropIndex(
                name: "IX_Projects_Project_TitleId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Project_TitleId",
                table: "Projects");

            migrationBuilder.AddColumn<string>(
                name: "Project_Title",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
