using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cotrageco.Migrations
{
    /// <inheritdoc />
    public partial class MarvelousCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AboutUs_Banner",
                table: "Cotrageco_Contents");

            migrationBuilder.DropColumn(
                name: "Contact_Banner",
                table: "Cotrageco_Contents");

            migrationBuilder.DropColumn(
                name: "OFS_Banner",
                table: "Cotrageco_Contents");

            migrationBuilder.DropColumn(
                name: "Services_Banner",
                table: "Cotrageco_Contents");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AboutUs_Banner",
                table: "Cotrageco_Contents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Contact_Banner",
                table: "Cotrageco_Contents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OFS_Banner",
                table: "Cotrageco_Contents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Services_Banner",
                table: "Cotrageco_Contents",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
