using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Khudmadad_Backend.Migrations
{
    public partial class OfferModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "Offers",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "Offers");
        }
    }
}
