using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cotrageco.Migrations
{
    /// <inheritdoc />
    public partial class TheCreationsCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Website_Logo",
                table: "Banner",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Website_Logo",
                table: "Banner");
        }
    }
}
