using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cotrageco.Migrations
{
    /// <inheritdoc />
    public partial class CrCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sector",
                table: "Sectors_Of_Interventions");

            migrationBuilder.DropColumn(
                name: "Company_Presentation",
                table: "Cotrageco_Contents");

            migrationBuilder.DropColumn(
                name: "Presentation_Title",
                table: "Cotrageco_Contents");

            migrationBuilder.DropColumn(
                name: "Registration_Description",
                table: "Cotrageco_Contents");

            migrationBuilder.CreateTable(
                name: "Banner",
                columns: table => new
                {
                    BannerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AboutUs_Banner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OFS_Banner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Services_Banner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact_Banner = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banner", x => x.BannerId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Banner");

            migrationBuilder.AddColumn<string>(
                name: "Sector",
                table: "Sectors_Of_Interventions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Company_Presentation",
                table: "Cotrageco_Contents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Presentation_Title",
                table: "Cotrageco_Contents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Registration_Description",
                table: "Cotrageco_Contents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
