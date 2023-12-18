using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cotrageco.Data.Migrations
{
    /// <inheritdoc />
    public partial class SecondGenesis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AboutUs",
                table: "Cotrageco_Contents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "About_Banner",
                table: "Cotrageco_Contents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Contact_Banner",
                table: "Cotrageco_Contents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cotrageco_bannerHeaderThree",
                table: "Cotrageco_Contents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cotrageco_bannerHeaderfour",
                table: "Cotrageco_Contents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Objectives",
                table: "Cotrageco_Contents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Partners",
                table: "Cotrageco_Contents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Projects",
                table: "Cotrageco_Contents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Resources",
                table: "Cotrageco_Contents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Sectors",
                table: "Cotrageco_Contents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Services_Banner",
                table: "Cotrageco_Contents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Social_Objectives",
                table: "Cotrageco_Contents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Statistics",
                table: "Cotrageco_Contents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Corperate_Infos",
                columns: table => new
                {
                    Corperate_InfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Corperate_Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Corperate_Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Corperate_Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corperate_Infos", x => x.Corperate_InfoId);
                });

            migrationBuilder.CreateTable(
                name: "Home_Banners",
                columns: table => new
                {
                    Home_BannerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Home_Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Home_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Home_Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Home_Banners", x => x.Home_BannerId);
                });

            migrationBuilder.CreateTable(
                name: "Objectives",
                columns: table => new
                {
                    ObjectiveId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objectives", x => x.ObjectiveId);
                });

            migrationBuilder.CreateTable(
                name: "OFSs",
                columns: table => new
                {
                    OFSId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OFSs", x => x.OFSId);
                });

            migrationBuilder.CreateTable(
                name: "Partners",
                columns: table => new
                {
                    PartnerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partners", x => x.PartnerId);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Corperate_Infos");

            migrationBuilder.DropTable(
                name: "Home_Banners");

            migrationBuilder.DropTable(
                name: "Objectives");

            migrationBuilder.DropTable(
                name: "OFSs");

            migrationBuilder.DropTable(
                name: "Partners");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropColumn(
                name: "AboutUs",
                table: "Cotrageco_Contents");

            migrationBuilder.DropColumn(
                name: "About_Banner",
                table: "Cotrageco_Contents");

            migrationBuilder.DropColumn(
                name: "Contact_Banner",
                table: "Cotrageco_Contents");

            migrationBuilder.DropColumn(
                name: "Cotrageco_bannerHeaderThree",
                table: "Cotrageco_Contents");

            migrationBuilder.DropColumn(
                name: "Cotrageco_bannerHeaderfour",
                table: "Cotrageco_Contents");

            migrationBuilder.DropColumn(
                name: "Objectives",
                table: "Cotrageco_Contents");

            migrationBuilder.DropColumn(
                name: "Partners",
                table: "Cotrageco_Contents");

            migrationBuilder.DropColumn(
                name: "Projects",
                table: "Cotrageco_Contents");

            migrationBuilder.DropColumn(
                name: "Resources",
                table: "Cotrageco_Contents");

            migrationBuilder.DropColumn(
                name: "Sectors",
                table: "Cotrageco_Contents");

            migrationBuilder.DropColumn(
                name: "Services_Banner",
                table: "Cotrageco_Contents");

            migrationBuilder.DropColumn(
                name: "Social_Objectives",
                table: "Cotrageco_Contents");

            migrationBuilder.DropColumn(
                name: "Statistics",
                table: "Cotrageco_Contents");
        }
    }
}
