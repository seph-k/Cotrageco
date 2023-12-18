using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cotrageco.Data.Migrations
{
    /// <inheritdoc />
    public partial class bannerHeaderTwo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cotrageco_bannerHeaderTwo",
                table: "Cotrageco_Contents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cotrageco_bannerHeaderTwo",
                table: "Cotrageco_Contents");
        }
    }
}
