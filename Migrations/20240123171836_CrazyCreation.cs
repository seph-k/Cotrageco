using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cotrageco.Migrations
{
    /// <inheritdoc />
    public partial class CrazyCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Our_Resources");

            migrationBuilder.DropTable(
                name: "Representations");

            migrationBuilder.AddColumn<string>(
                name: "Representation_Description",
                table: "Cotrageco_Contents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Representation_Title",
                table: "Cotrageco_Contents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Resource_Description",
                table: "Cotrageco_Contents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Resource_Title",
                table: "Cotrageco_Contents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Representation_Description",
                table: "Cotrageco_Contents");

            migrationBuilder.DropColumn(
                name: "Representation_Title",
                table: "Cotrageco_Contents");

            migrationBuilder.DropColumn(
                name: "Resource_Description",
                table: "Cotrageco_Contents");

            migrationBuilder.DropColumn(
                name: "Resource_Title",
                table: "Cotrageco_Contents");

            migrationBuilder.CreateTable(
                name: "Our_Resources",
                columns: table => new
                {
                    Our_ResourceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Resource_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resource_Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Our_Resources", x => x.Our_ResourceId);
                });

            migrationBuilder.CreateTable(
                name: "Representations",
                columns: table => new
                {
                    RepresentationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Representation_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Representation_Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Representations", x => x.RepresentationId);
                });
        }
    }
}
