using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cotrageco.Migrations
{
    /// <inheritdoc />
    public partial class OneMoreCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Purpose_Description",
                table: "Cotrageco_Contents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Purpose_Title",
                table: "Cotrageco_Contents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Purpose_Description",
                table: "Cotrageco_Contents");

            migrationBuilder.DropColumn(
                name: "Purpose_Title",
                table: "Cotrageco_Contents");
        }
    }
}
