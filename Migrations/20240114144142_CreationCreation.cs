using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cotrageco.Migrations
{
    /// <inheritdoc />
    public partial class CreationCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OFS_Banner",
                table: "Cotrageco_Contents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Company_Presentation",
                table: "Cotrageco_Contents");

            migrationBuilder.DropColumn(
                name: "Presentation_Title",
                table: "Cotrageco_Contents");

            migrationBuilder.DropColumn(
                name: "Registration_Description",
                table: "Cotrageco_Contents");

            migrationBuilder.AlterColumn<string>(
                name: "OFS_Banner",
                table: "Cotrageco_Contents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
