using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cotrageco.Migrations
{
    /// <inheritdoc />
    public partial class AnotherCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Contact_Address",
                table: "Cotrageco_Contents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Contact_Email",
                table: "Cotrageco_Contents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Contact_Phone",
                table: "Cotrageco_Contents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OFS_Banner",
                table: "Cotrageco_Contents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contact_Address",
                table: "Cotrageco_Contents");

            migrationBuilder.DropColumn(
                name: "Contact_Email",
                table: "Cotrageco_Contents");

            migrationBuilder.DropColumn(
                name: "Contact_Phone",
                table: "Cotrageco_Contents");

            migrationBuilder.DropColumn(
                name: "OFS_Banner",
                table: "Cotrageco_Contents");
        }
    }
}
